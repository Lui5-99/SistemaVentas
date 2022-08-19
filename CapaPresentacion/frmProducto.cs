using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            cbEstado.Items.Add(new OpcionCombo()
            {
                valor = 1,
                texto = "Activo"
            });
            cbEstado.Items.Add(new OpcionCombo()
            {
                valor = 0,
                texto = "No activo"
            });
            cbEstado.DisplayMember = "texto";
            cbEstado.ValueMember = "valor";
            cbEstado.SelectedIndex = 0;


            List<Categoria> ls = new CN_Categoria().Listar();
            foreach (Categoria item in ls)
            {
                cbCategoria.Items.Add(new OpcionCombo()
                {
                    valor = item.IdCategoria,
                    texto = item.Descripcion
                });
            }
            cbCategoria.DisplayMember = "texto";
            cbCategoria.ValueMember = "valor";
            cbCategoria.SelectedIndex = 0;

            foreach (DataGridViewColumn column in dgvDatos.Columns)
            {
                if (column.Visible && column.Name != "vacio")
                {
                    cbBusqueda.Items.Add(new OpcionCombo()
                    {
                        valor = column.Name,
                        texto = column.HeaderText
                    });
                }
            }
            cbBusqueda.DisplayMember = "texto";
            cbBusqueda.ValueMember = "valor";
            cbBusqueda.SelectedIndex = 0;

            List<Producto> lsU = new CN_Producto().Listar();
            foreach (Producto item in lsU)
            {
                dgvDatos.Rows.Add(new object[]
                {
                    "",
                    item.IdProducto,
                    item.Codigo,
                    item.Nombre,
                    item.Descripcion,
                    item.oCategoria.IdCategoria,
                    item.oCategoria.Descripcion,
                    item.Estado == true ? 1 : 0,
                    item.Estado == true ? "Activo":"No Activo"
                });
            }
            txtCodigo.Select();
        }

        private void btBusqueda_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cbBusqueda.SelectedItem).valor.ToString();
            if (dgvDatos.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDatos.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBusqueda.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        private void btLimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;
            Producto oProducto = new Producto()
            {
                IdProducto = Convert.ToInt32(txtId.Text),
                Codigo = txtCodigo.Text,
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                oCategoria = new Categoria()
                {
                    IdCategoria = Convert.ToInt32(((OpcionCombo)cbCategoria.SelectedItem).valor),
                    Descripcion = ((OpcionCombo)cbCategoria.SelectedItem).texto
                },
                Estado = Convert.ToInt32(((OpcionCombo)cbEstado.SelectedItem).valor) == 1 ? true : false
            };
            int IdProductogenerado = 0;
            bool respuesta = false;
            if (oProducto.IdProducto == 0)
            {
                IdProductogenerado = new CN_Producto().Registrar(oProducto, out Mensaje);
                if (IdProductogenerado != 0)
                {
                    dgvDatos.Rows.Add(new object[]
                    {
                        "",
                        txtId.Text,
                        txtCodigo.Text,
                        txtNombre.Text,
                        txtDescripcion.Text,
                        ((OpcionCombo)cbCategoria.SelectedItem).valor.ToString(),
                        ((OpcionCombo)cbCategoria.SelectedItem).texto.ToString(),
                        ((OpcionCombo)cbEstado.SelectedItem).valor.ToString(),
                        ((OpcionCombo)cbEstado.SelectedItem).texto.ToString()
                    });
                    MessageBox.Show("Producto agregado", "Mensaje", MessageBoxButtons.OK);
                    limpiar();
                }
                else
                    MessageBox.Show(Mensaje, "Mensaje", MessageBoxButtons.OK);
            }
            else
            {
                respuesta = new CN_Producto().Editar(oProducto, out Mensaje);
                if (respuesta)
                {
                    DataGridViewRow row = dgvDatos.Rows[Convert.ToInt32(lblIndice.Text)];
                    row.Cells["Id"].Value = txtId.Text;
                    row.Cells["Codigo"].Value = txtCodigo.Text;
                    row.Cells["Nombre"].Value = txtNombre.Text;
                    row.Cells["Descripcion"].Value = txtDescripcion.Text;
                    row.Cells["IdCategoria"].Value = ((OpcionCombo)cbCategoria.SelectedItem).valor.ToString();
                    row.Cells["Descripcion"].Value = ((OpcionCombo)cbCategoria.SelectedItem).texto.ToString();
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)cbEstado.SelectedItem).valor.ToString();
                    row.Cells["Estado"].Value = ((OpcionCombo)cbEstado.SelectedItem).texto.ToString();
                    MessageBox.Show("Producto con el ID " + txtId.Text.ToString() + " actualizado", "Mensaje", MessageBoxButtons.OK);
                    limpiar();
                }
                else
                    MessageBox.Show(Mensaje, "Mensaje", MessageBoxButtons.OK);
            }
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;
            if (Convert.ToInt32(txtId.Text) != 0)
            {
                if (MessageBox.Show(
                    "¿Desea eliminar el producto?",
                    "Mensaje", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                    ) == DialogResult.Yes)
                {
                    Producto oProducto = new Producto()
                    {
                        IdProducto = Convert.ToInt32(txtId.Text),
                    };
                    bool respuesta = new CN_Producto().Eliminar(oProducto, out Mensaje);
                    if (respuesta)
                    {
                        dgvDatos.Rows.RemoveAt(Convert.ToInt32(lblIndice.Text));
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show(Mensaje, "Mensaje", MessageBoxButtons.OK);
                    }

                }
            }
        }


        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDatos.Columns[e.ColumnIndex].Name == "vacio")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    lblIndice.Text = indice.ToString();
                    txtId.Text = dgvDatos.Rows[indice].Cells["Id"].Value.ToString();
                    txtCodigo.Text = dgvDatos.Rows[indice].Cells["Codigo"].Value.ToString();
                    txtNombre.Text = dgvDatos.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtDescripcion.Text = dgvDatos.Rows[indice].Cells["Descripcion"].Value.ToString();
                    foreach (OpcionCombo oc in cbCategoria.Items)
                    {
                        if (Convert.ToInt32(oc.valor) == Convert.ToInt32(dgvDatos.Rows[indice].Cells["IdCategoria"].Value.ToString()))
                        {
                            int indiceCombo = cbCategoria.Items.IndexOf(oc);
                            cbCategoria.SelectedIndex = indiceCombo;
                            break;
                        }
                    }
                    foreach (OpcionCombo oc in cbEstado.Items)
                    {
                        if (Convert.ToInt32(oc.valor) == Convert.ToInt32(dgvDatos.Rows[indice].Cells["EstadoValor"].Value.ToString()))
                        {
                            int indiceCombo = cbEstado.Items.IndexOf(oc);
                            cbEstado.SelectedIndex = indiceCombo;
                            break;
                        }
                    }
                }
            }
        }

        private void dgvDatos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.check.Width - 10;
                var h = Properties.Resources.check.Height - 10;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.check, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }
        private void limpiar()
        {
            lblIndice.Text = "-1";
            txtId.Text = "0";
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            cbCategoria.SelectedIndex = 0;
            cbEstado.SelectedIndex = 0;
            txtCodigo.Select();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cbBusqueda.SelectedItem).valor.ToString();
            if (dgvDatos.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDatos.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBusqueda.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }
    }
}
