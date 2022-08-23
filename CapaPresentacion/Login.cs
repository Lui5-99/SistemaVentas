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
using System.IO;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public Image byte2image(byte[] imageByte)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(imageByte, 0, imageByte.Length);
            Image image = new Bitmap(ms);

            return image;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btIngresar_Click(object sender, EventArgs e)
        {
            Usuario oUsuario = new CN_Usuario().Listar().Where(
                u => u.Documento == txtUser.Text && u.Clave == txtPwd.Text
                ).FirstOrDefault();

            if(oUsuario != null)
            {
                Inicio oInicio = new Inicio(oUsuario);
                oInicio.Show();
                this.Hide();
                oInicio.FormClosing += frm_FormClosing;
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña invalida", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtUser.Text = "";
            txtPwd.Text = "";
            Negocio oNegocio = new CN_Negocio().obtenerDatos();
            lblSistema.Text = oNegocio != null ? oNegocio.Nombre : "Sistema Ventas";
            bool obtenido = true;
            byte[] image = new CN_Negocio().ObtenerLogo(out obtenido);
            if (image.Length > 0)
            {
                picLogo.Image = byte2image(image);
                picLogo.Visible = true;
                picDefault.Visible = false;
            }
            else
            {
                picLogo.Visible = false;
                picDefault.Visible = true;
            }
            this.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUser.Select();
            Negocio oNegocio = new CN_Negocio().obtenerDatos();
            lblSistema.Text = oNegocio.Nombre != null ? oNegocio.Nombre : "Sistema Ventas";
            bool obtenido = true;
            byte[] image = new CN_Negocio().ObtenerLogo(out obtenido);
            if (image.Length > 0)
            {
                picLogo.Image = byte2image(image);
                picLogo.Visible = true;
                picDefault.Visible = false;
            }
            else
            {
                picLogo.Visible = false;
                picDefault.Visible = true;
            }
                
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                txtPwd.Select();
            }
        }

        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btIngresar_Click(sender, e);
            }
        }
    }
}
