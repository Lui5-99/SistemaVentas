using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmCompras : Form
    {
        private Usuario _Usuario;
        public frmCompras(Usuario oUsuario = null)
        {
            _Usuario = oUsuario;
            InitializeComponent();
        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            cbDocumento.Items.Add(new OpcionCombo()
            {
                valor = "Compra",
                texto = "Compra"
            });
            
            cbDocumento.DisplayMember = "texto";
            cbDocumento.ValueMember = "valor";
            cbDocumento.SelectedIndex = 0;

            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtIdProveedor.Text = "0";
            txtIdProducto.Text = "0";
        }

        private void btBusqueda_Click(object sender, EventArgs e)
        {
            using (var modal = new mdProveedor())
            {
                var result = modal.ShowDialog();

                if(result == DialogResult.OK)
                {
                    txtIdProveedor.Text = modal._Proveedor.IdProveedor.ToString();
                    txtDocumento.Text = modal._Proveedor.Documento.ToString();
                    txtDocumento.BackColor = Color.Honeydew;
                    txtRazon.Text = modal._Proveedor.RazonSocial.ToString();
                }
                else
                {
                    txtDocumento.Select();
                }
            }
        }

        private void btBuscarProducto_Click(object sender, EventArgs e)
        {
            using (var modal = new mdProductos())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtIdProducto.Text = modal._Producto.IdProducto.ToString();
                    txtProducto.BackColor = Color.Honeydew;
                    txtCodigo.Text = modal._Producto.Codigo.ToString();
                    txtProducto.Text = modal._Producto.Nombre.ToString();
                    txtCompra.Text = modal._Producto.PrecioCompra.ToString();
                    txtVenta.Text = modal._Producto.PrecioVenta.ToString();
                    NumCantidad.Value = Convert.ToInt32(modal._Producto.Stock.ToString());
                    txtCompra.Select();
                }
                else
                {
                    txtIdProducto.Select();
                }
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            decimal precioCompra = 0;
            decimal precioVenta = 0;
            decimal total = 0;
            bool producto_existe = false;
            if(int.Parse(txtIdProducto.Text) == 0)
            {
                MessageBox.Show("Debes seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            } 
            if(!decimal.TryParse(txtCompra.Text, out precioCompra))
            {
                MessageBox.Show("Precio compra formato incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCompra.Select();
                return;
            }
            if (!decimal.TryParse(txtVenta.Text, out precioVenta))
            {
                MessageBox.Show("Precio venta formato incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCompra.Select();
                return;
            }
            if(dgvDatos.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDatos.Rows)
                {
                    if (row.Cells["IdProducto"].Value.ToString() == txtIdProducto.Text.ToString())
                    {
                        producto_existe = true;
                        break;
                    }
                }
            }
            if (!producto_existe)
            {
                dgvDatos.Rows.Add(new object[]
                {
                    txtIdProducto.Text,
                    txtProducto.Text,
                    precioCompra.ToString("0.00"),
                    precioVenta.ToString("0.00"),
                    NumCantidad.Value.ToString(),
                    (NumCantidad.Value * precioCompra).ToString("0.00")
                });
            }
            
            txtPagar.Text = total.ToString();
        }

        private void btPagar_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                Producto oProducto = new CN_Producto().Listar().Where(p => p.Codigo == txtCodigo.Text && p.Estado == true).FirstOrDefault();
                if(oProducto != null)
                {
                    txtCodigo.BackColor = Color.Honeydew;
                    txtIdProducto.Text = oProducto.IdProducto.ToString();
                    txtProducto.Text = oProducto.Nombre.ToString();
                    txtCompra.Text = oProducto.PrecioCompra.ToString();
                    txtVenta.Text = oProducto.PrecioVenta.ToString();
                    NumCantidad.Value = Convert.ToInt32(oProducto.Stock.ToString());
                    txtCompra.Select();
                }
                else
                {
                    txtCodigo.BackColor= Color.MistyRose;
                    txtIdProducto.Text = "0";
                    txtProducto.Text = "";
                    txtCodigo.Text = "";
                    txtCompra.Text = "0.00";
                    txtVenta.Text = "0.00";
                    NumCantidad.Value = 0;
                    txtProducto.Select();
                }
            }
        }

        private void txtDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Proveedor oProveedor = new CN_Proveedor().Listar().Where(p => p.Documento == txtDocumento.Text && p.Estado == true).FirstOrDefault();
                if (oProveedor != null)
                {
                    txtDocumento.BackColor = Color.Honeydew;
                    txtIdProducto.Text = oProveedor.IdProveedor.ToString();
                    txtDocumento.Text = oProveedor.Documento.ToString();
                    txtRazon.Text = oProveedor.RazonSocial.ToString();
                    txtCodigo.Select();
                }
                else
                {
                    txtDocumento.BackColor = Color.MistyRose;
                    txtIdProveedor.Text = "0";
                    txtDocumento.Text = "";
                    txtRazon.Text = "";
                    txtDocumento.Select();
                }
            }
        }

        private void dgvDatos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 6)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.check.Width - 10;
                var h = Properties.Resources.check.Height - 15;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.bin, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDatos.Columns[e.ColumnIndex].Name == "Vacio")
            {
                MessageBox.Show("Eliminar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
