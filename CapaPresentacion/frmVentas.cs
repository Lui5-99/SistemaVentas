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
    public partial class frmVentas : Form
    {
        private Usuario _Usuario;
        public frmVentas(Usuario oUsuario = null)
        {
            _Usuario = oUsuario;
            InitializeComponent();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            cbDocumento.Items.Add(new OpcionCombo()
            {
                valor = "Venta",
                texto = "Venta"
            });

            cbDocumento.DisplayMember = "texto";
            cbDocumento.ValueMember = "valor";
            cbDocumento.SelectedIndex = 0;

            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtIdProducto.Text = "0";
            txtPagar.Text = "0.00";
        }

        private void btBusqueda_Click(object sender, EventArgs e)
        {
            using (var modal = new mdCliente())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtCodigoCliente.Text = modal._Cliente.Documento.ToString();
                    txtCodigoCliente.BackColor = Color.Honeydew;
                    txtnombrecliente.Text = modal._Cliente.NombreCompleto.ToString();
                }
                else
                {
                    txtCodigoCliente.BackColor = Color.MistyRose;
                    txtCodigoCliente.Select();
                }
            }
        }

        private void txtCodigoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Cliente oCliente = new CN_Cliente().Listar().Where(p => p.Documento == txtCodigoCliente.Text && p.Estado == true).FirstOrDefault();
                if (oCliente != null)
                {
                    txtCodigoCliente.BackColor = Color.Honeydew;
                    txtCodigoCliente.Text = oCliente.Documento.ToString();
                    txtnombrecliente.Text = oCliente.NombreCompleto.ToString();
                    txtCodigo.Select();
                }
                else
                {
                    txtCodigoCliente.BackColor = Color.MistyRose;
                    txtCodigoCliente.Text = "";
                    txtnombrecliente.Text = "";
                    txtCodigoCliente.Select();
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
                    txtCodigo.BackColor = Color.Honeydew;
                    txtCodigo.Text = modal._Producto.Codigo.ToString();
                    txtProducto.Text = modal._Producto.Nombre.ToString();
                    txtVenta.Text = modal._Producto.PrecioVenta.ToString();
                    txtStock.Text = modal._Producto.Stock.ToString();
                    NumCantidad.Value = 1;
                    txtVenta.Select();
                }
                else
                {
                    txtIdProducto.Select();
                }
            }
        }
        private void limpiarProducto()
        {
            txtIdProducto.Text = "0";
            txtProducto.Text = "";
            txtCodigo.BackColor = Color.White;
            txtCodigo.Text = "";
            txtVenta.Text = "0.00";
            txtStock.Text = "0";
            NumCantidad.Value = 1;
        }
        private void limpiarCliente()
        {
            txtCodigoCliente.Text = "";
            txtCodigoCliente.BackColor = Color.White;
            txtnombrecliente.Text = "";
        }
        private void calcularTotal()
        {
            decimal total = 0;
            if (dgvDatos.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDatos.Rows)
                    total += Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString());
            }
            txtPagar.Text = total.ToString("0.00");
        }

        private void btAdd_Click(object sender, EventArgs e)
        {;
            decimal precioVenta = 0;
            decimal total = 0;
            bool producto_existe = false;
            if (int.Parse(txtIdProducto.Text) == 0)
            {
                MessageBox.Show("Debes seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!decimal.TryParse(txtVenta.Text, out precioVenta))
            {
                MessageBox.Show("Precio venta formato incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                NumCantidad.Select();
                return;
            }
            if (Convert.ToInt32(txtStock.Text) < Convert.ToInt32(NumCantidad.Value))
            {
                MessageBox.Show("Se excedio la cantidad de stock", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                NumCantidad.Select();
                return;
            }
            if (dgvDatos.Rows.Count > 0)
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
                string mensaje = string.Empty;
                bool respuesta = new CN_Venta().restarStock(Convert.ToInt32(txtIdProducto.Text), Convert.ToInt32(NumCantidad.Value));
                if (respuesta)
                {
                    dgvDatos.Rows.Add(new object[]
                    {
                        txtIdProducto.Text,
                        txtProducto.Text,
                        precioVenta.ToString("0.00"),
                        NumCantidad.Value.ToString(),
                        (NumCantidad.Value * precioVenta).ToString("0.00")
                    });
                    limpiarProducto();
                }
            }
            else
            {
                MessageBox.Show("Ya existe este producto en esta compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            calcularTotal();
            txtpagocon.Text = "";
            txtcambio.Text = "";
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Producto oProducto = new CN_Producto().Listar().Where(p => p.Codigo == txtCodigo.Text && p.Estado == true).FirstOrDefault();
                if (oProducto != null)
                {
                    txtCodigo.BackColor = Color.Honeydew;
                    txtIdProducto.Text = oProducto.IdProducto.ToString();
                    txtProducto.Text = oProducto.Nombre.ToString();
                    txtVenta.Text = oProducto.PrecioVenta.ToString();
                    txtStock.Text = oProducto.Stock.ToString();
                }
                else
                {
                    txtCodigo.BackColor = Color.MistyRose;
                    txtIdProducto.Text = "0";
                    txtProducto.Text = "";
                    txtCodigo.Text = "";
                    txtVenta.Text = "0.00";
                    txtStock.Text = "0";
                    NumCantidad.Value = 1;
                    txtProducto.Select();
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
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    bool respueta = new CN_Venta().sumarStock(
                        Convert.ToInt32(dgvDatos.Rows[indice].Cells["IdProducto"].Value.ToString()),
                        Convert.ToInt32(dgvDatos.Rows[indice].Cells["Cantidad"].Value.ToString()));

                    if (respueta)
                    {
                        dgvDatos.Rows.RemoveAt(indice);
                        calcularTotal();
                    }
                }
            }
        }

        private void txtpagocon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                calcularCambio();
            }
        }

        private void txtVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtVenta.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtpagocon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtpagocon.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        private void calcularCambio()
        {
            if(txtpagocon.Text.Trim() == string.Empty)
            {
                return;
            }
            decimal totalCompra = decimal.TryParse(txtPagar.Text.ToString(), out totalCompra) ? totalCompra : 0;
            decimal totalPago = decimal.TryParse(txtpagocon.Text.ToString(), out totalPago) ? totalPago : 0;
            decimal cambio = totalPago - totalCompra;
            txtcambio.Text = cambio.ToString();
        }

        private void btncrearventa_Click(object sender, EventArgs e)
        {
            if (txtpagocon.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Debe ingresar el monto con el que se paga", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (txtCodigoCliente.Text.Trim() == string.Empty)
            {
                txtCodigoCliente.Text = "0000";
            }
            if (txtnombrecliente.Text.Trim() == string.Empty)
            {
                txtnombrecliente.Text = "Ventas Publico";
            }
            if (dgvDatos.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingresar almenos un producto a la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("IdProducto", typeof(int));
            dt.Columns.Add("PrecioVenta", typeof(decimal));
            dt.Columns.Add("Cantidad", typeof(int));
            dt.Columns.Add("SubTotal", typeof(decimal));

            foreach(DataGridViewRow row in dgvDatos.Rows)
            {
                dt.Rows.Add(new object[]
                {
                    row.Cells["IdProducto"].Value.ToString(),
                    row.Cells["Precio"].Value.ToString(),
                    row.Cells["Cantidad"].Value.ToString(),
                    row.Cells["SubTotal"].Value.ToString(),
                });
            }

            int idcorrelativo = new CN_Venta().obtenerCorrelativo();
            string numCorrelativo = string.Format("{0:00000}", idcorrelativo);
            calcularCambio();
            Venta oVenta = new Venta()
            {
                oUsuario = new Usuario()
                {
                    IdUsuario = _Usuario.IdUsuario
                },
                TipoDocumento = ((OpcionCombo)cbDocumento.SelectedItem).texto,
                NumeroDocumento = numCorrelativo,
                DocumentoCliente = txtCodigoCliente.Text,
                NombreCliente = txtnombrecliente.Text,
                MontoPago = Convert.ToDecimal(txtpagocon.Text),
                MontoCambio = Convert.ToDecimal(txtcambio.Text),
                MontoTotal = Convert.ToDecimal(txtPagar.Text),
            };
            string mensaje = string.Empty;
            bool respuesta = new CN_Venta().Registrar(oVenta, dt, out mensaje);
            if (respuesta)
            {
                var result =
                    MessageBox.Show("Número de venta generada:\n" + numCorrelativo + "\n\n¿Desea copiar al portapapeles?",
                    "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                    Clipboard.SetText(numCorrelativo);
                generarTicket(numCorrelativo);
                txtCodigoCliente.BackColor = Color.White;
                txtCodigoCliente.Text = "";
                txtnombrecliente.Text = "";
                dgvDatos.Rows.Clear();
                calcularTotal();
                txtPagar.Text = "0.00";
                txtcambio.Text = "";
                txtpagocon.Text = "";
                limpiarProducto();
            }
            else
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void generarTicket(string codigoVenta)
        {
            if(codigoVenta != null)
            {
                var dialog = MessageBox.Show("La venta fue registrada\n¿Desea imprimir el ticket ahora?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dialog == DialogResult.Yes)
                {
                    ImprimirVenta imp = new ImprimirVenta(codigoVenta);
                    imp.ShowDialog();
                }
            }
        }
    }
}
