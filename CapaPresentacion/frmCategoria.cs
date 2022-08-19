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
using CapaEntidad;
using CapaPresentacion.Utilidades;

namespace CapaPresentacion
{
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }

        private void frmCategoria_Load(object sender, EventArgs e)
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

            List<Categoria> lsC = new CN_Categoria().Listar();
            foreach (Categoria item in lsC)
            {
                dgvDatos.Rows.Add(new object[]
                {
                    "",
                    item.IdCategoria,
                    item.Descripcion,
                    item.Estado == true ? 1 : 0,
                    item.Estado == true ? "Activo":"No Activo"
                });
            }

            txtDescripcion.Select();
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;
            Categoria oCategoria = new Categoria()
            {
                IdCategoria = Convert.ToInt32(txtId.Text),
                Descripcion = txtDescripcion.Text,
                Estado = Convert.ToInt32(((OpcionCombo)cbEstado.SelectedItem).valor) == 1 ? true : false
            };
            int IdCategoriagenerado = 0;
            bool respuesta = false;
            if (oCategoria.IdCategoria == 0)
            {
                IdCategoriagenerado = new CN_Categoria().Registrar(oCategoria, out Mensaje);
                if (IdCategoriagenerado != 0)
                {
                    dgvDatos.Rows.Add(new object[]
                    {
                        "",
                        txtId.Text,
                        txtDescripcion.Text,
                        ((OpcionCombo)cbEstado.SelectedItem).valor.ToString(),
                        ((OpcionCombo)cbEstado.SelectedItem).texto.ToString()
                    });
                    MessageBox.Show("Categoría agregada", "Mensaje", MessageBoxButtons.OK);
                    limpiar();
                }
                else
                    MessageBox.Show(Mensaje, "Mensaje", MessageBoxButtons.OK);
            }
            else
            {
                respuesta = new CN_Categoria().Editar(oCategoria, out Mensaje);
                if (respuesta)
                {
                    DataGridViewRow row = dgvDatos.Rows[Convert.ToInt32(lblIndice.Text)];
                    row.Cells["Id"].Value = txtId.Text;
                    row.Cells["Descripcion"].Value = txtDescripcion.Text;
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)cbEstado.SelectedItem).valor.ToString();
                    row.Cells["Estado"].Value = ((OpcionCombo)cbEstado.SelectedItem).texto.ToString();
                    MessageBox.Show("Categoria con el ID " + txtId.Text.ToString() + " actualizada", "Mensaje", MessageBoxButtons.OK);
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
                    "¿Desea eliminar la categoría?",
                    "Mensaje", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                    ) == DialogResult.Yes)
                {
                    Categoria oCategoria = new Categoria()
                    {
                        IdCategoria = Convert.ToInt32(txtId.Text),
                    };
                    bool respuesta = new CN_Categoria().Eliminar(oCategoria, out Mensaje);
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
        private void limpiar()
        {
            lblIndice.Text = "-1";
            txtId.Text = "0";
            txtDescripcion.Text = "";
            cbEstado.SelectedIndex = 0;
            txtDescripcion.Select();
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

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDatos.Columns[e.ColumnIndex].Name == "vacio")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    lblIndice.Text = indice.ToString();
                    txtId.Text = dgvDatos.Rows[indice].Cells["Id"].Value.ToString();
                    txtDescripcion.Text = dgvDatos.Rows[indice].Cells["Descripcion"].Value.ToString();
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

        private void btLimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
        }
    }
}
