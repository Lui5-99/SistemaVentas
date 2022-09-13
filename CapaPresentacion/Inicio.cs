using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using CapaPresentacion.Modales;

namespace CapaPresentacion
{
    public partial class Inicio : Form
    {
        private static Usuario usuarioActual;
        private static IconMenuItem menuActivo = null;
        private static Form formularioActivo = null;
        public Inicio(Usuario oUsuario)
        {
            InitializeComponent();
            usuarioActual = oUsuario;
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            Negocio oNegocio = new CN_Negocio().obtenerDatos();
            lblSistema.Text = oNegocio.Nombre != null ? oNegocio.Nombre : "Sistema Ventas";
            List<Permiso> ls = new CN_Permiso().Listar(usuarioActual.IdUsuario);
            foreach (IconMenuItem iconMenu in menu.Items)
            {
                bool encontrado = ls.Any(
                    m => m.NombreMenu == iconMenu.Name && m.Estado == true
                    );
                if (!encontrado) 
                    iconMenu.Visible = false;

            }
            lblUsuario.Text = usuarioActual.NombreCompleto.ToString();
        }

        private void AbrirFormulario(IconMenuItem menu, Form frm)
        {
            if (menuActivo != null)
            {
                menuActivo.BackColor = Color.White;
            }
            menu.BackColor = Color.Silver;
            menuActivo = menu;
            if(formularioActivo != null)
            {
                formularioActivo.Close();
            }
            formularioActivo = frm;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.BackColor = Color.SlateGray;
            contenedor.Controls.Add(frm);
            frm.Show();
            Negocio oNegocio = new CN_Negocio().obtenerDatos();
            lblSistema.Text = oNegocio != null ? oNegocio.Nombre : "Sistema Ventas";
        }

        private void menuUsuario_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmUsuarios());
        }

        private void MenuCategoria_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmCategoria());
        }

        private void MenuProducto_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmProducto());
        }

        private void menuClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmClientes());
        }

        private void menuProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmProveedores());
        }


        private void menuRegistrarVenta_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmVentas(usuarioActual));
        }

        private void menuDetalleVenta_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmDetalleVenta());
        }

        private void menuRegistar_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmCompras(usuarioActual));
        }

        private void menuDetalleCompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmDetalleCompra());
        }

        private void menuConfiguracion_Click(object sender, EventArgs e)
        {
            
        }

        private void menuNegocio_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmConfiguracion());
        }

        private void menuPermiso_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmPermisos());
        }

        private void menuRepVentas_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmReporteVentas());
        }

        private void menuRepCompras_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmReporteCompras());
        }

        private void menuAcercade_Click(object sender, EventArgs e)
        {
            var modal = new mdAcercade();
            var result = modal.ShowDialog();
        }
    }
}
