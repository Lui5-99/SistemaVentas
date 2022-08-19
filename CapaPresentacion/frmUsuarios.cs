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
using CapaNegocio;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
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

            List<Rol> ls = new CN_Rol().Listar();
            foreach (Rol item in ls)
            {
                cbRol.Items.Add(new OpcionCombo()
                {
                    valor = item.IdRol,
                    texto = item.Descripcion
                });
            }
            cbRol.DisplayMember = "texto";
            cbRol.ValueMember = "valor";
            cbRol.SelectedIndex = 0;

            foreach(DataGridViewColumn column in dgvDatos.Columns)
            {
                if(column.Visible && column.Name != "vacio")
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
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            dgvDatos.Rows.Add(new object[]
            {
                "",
                txtId.Text,
                txtUsuario.Text,
                txtNombre.Text,
                txtCorreo.Text,
                txtPwd.Text,
                ((OpcionCombo)cbRol.SelectedItem).valor.ToString(),
                ((OpcionCombo)cbRol.SelectedItem).texto.ToString(),
                ((OpcionCombo)cbEstado.SelectedItem).valor.ToString(),
                ((OpcionCombo)cbEstado.SelectedItem).texto.ToString()
            });
            limpiar();
        }
        private void limpiar()
        {
            txtId.Text = "";
            txtUsuario.Text = "";
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtPwd.Text = "";
            txtPwd2.Text = "";
            cbRol.SelectedIndex = 0;
            cbEstado.SelectedIndex = 0;
        }
    }
}
