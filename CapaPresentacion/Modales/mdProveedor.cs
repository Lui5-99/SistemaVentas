using CapaEntidad;
using CapaNegocio;
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

namespace CapaPresentacion.Modales
{
    public partial class mdProveedor : Form
    {
        public Proveedor _Proveedor { get; set; }
        public mdProveedor()
        {
            InitializeComponent();
        }

        private void mdProveedor_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dgvDatos.Columns)
            {
                if (column.Visible)
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

            List<Proveedor> lsC = new CN_Proveedor().Listar();
            foreach (Proveedor item in lsC)
            {
                dgvDatos.Rows.Add(new object[]
                {
                    item.IdProveedor,
                    item.Documento,
                    item.RazonSocial,
                });
            }
        }

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iCol = e.ColumnIndex;  
            if(iRow >= 0 && iCol >= 0)
            {
                _Proveedor = new Proveedor()
                {
                    IdProveedor = Convert.ToInt32(dgvDatos.Rows[iRow].Cells["Id"].Value.ToString()),
                    Documento = dgvDatos.Rows[iRow].Cells["Documento"].Value.ToString(),
                    RazonSocial = dgvDatos.Rows[iRow].Cells["RazonSocial"].Value.ToString()

                };
                this.DialogResult = DialogResult.OK;
                this.Close();
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

        private void btLimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            cbBusqueda.SelectedIndex = 0;
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
