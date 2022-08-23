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

namespace CapaPresentacion
{
    public partial class frmPermisos : Form
    {
        public frmPermisos()
        {
            InitializeComponent();
        }

        private void frmPermisos_Load(object sender, EventArgs e)
        {
            List<Rol> ls = new CN_Rol().Listar();
            foreach (Rol item in ls)
            {
                cbUusario.Items.Add(new OpcionCombo()
                {
                    valor = item.IdRol,
                    texto = item.Descripcion
                });
            }
            cbUusario.DisplayMember = "texto";
            cbUusario.ValueMember = "valor";
            cbUusario.SelectedIndex = 0;

            setChecks();
        }

        private void cbUusario_SelectedIndexChanged(object sender, EventArgs e)
        {
            setChecks();
        }

        private void btGuardarRol_Click(object sender, EventArgs e)
        {
            txtIdRol.Text = "0";
            int count = 0;
            int isLog = 0;
            string mensaje = string.Empty;
            string salida = string.Empty;
            int IdRolDevuelto = 0;
            Rol oRol = new Rol()
            {
                Descripcion = txtRol.Text.ToString().ToUpper()
            };
            int result = new CN_Rol().Registrar(oRol, out mensaje);
            if(result > 0)
            {
                IdRolDevuelto = new CN_Rol().IdRol();
                txtIdRol.Text = IdRolDevuelto.ToString();
                if(IdRolDevuelto == 0)
                {
                    return;
                }
                else
                {
                    List<Permiso> lsPermisos = ListarMenus();
                    foreach (Permiso oPermiso in lsPermisos)
                    {
                        Permiso _auxPermiso = new Permiso()
                        {
                            oRol = new Rol()
                            {
                                IdRol = Convert.ToInt32(txtIdRol.Text.ToString()),
                            },
                            NombreMenu = oPermiso.NombreMenu,
                            Estado = false
                        };
                        count++;
                        int permiso = new CN_Permiso().Registrar(_auxPermiso, out mensaje);
                        if (permiso > 0)
                            isLog++;
                    }
                }
                if (isLog >= 8)
                {
                    MessageBox.Show("Rol agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRol.Text = "";
                    txtIdRol.Text = "0";

                    cbUusario.Items.Clear();
                    List<Rol> ls = new CN_Rol().Listar();
                    foreach (Rol item in ls)
                    {
                        cbUusario.Items.Add(new OpcionCombo()
                        {
                            valor = item.IdRol,
                            texto = item.Descripcion
                        });
                    }
                    cbUusario.DisplayMember = "texto";
                    cbUusario.ValueMember = "valor";
                    cbUusario.SelectedIndex = 0;

                }
                    
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private List<bool> obtenerChecks()
        {
            List<bool> list = new List<bool>();
            list.Add(menuUsuario.Checked);
            list.Add(menuMantenedor.Checked);
            list.Add(menuVentas.Checked);
            list.Add(menuCompras.Checked);
            list.Add(menuClientes.Checked);
            list.Add(menuProveedores.Checked);
            list.Add(menuReportes.Checked);
            list.Add(menuConfiguracion.Checked);
            list.Add(menuAcercade.Checked);
            return list;
        }
        private List<Permiso> ListarMenus()
        {
            List<Permiso> list = new List<Permiso>();
            list.Add(new Permiso() { NombreMenu = "menuUsuario" });
            list.Add(new Permiso() { NombreMenu = "menuMantenedor" });
            list.Add(new Permiso() { NombreMenu = "menuVentas" });
            list.Add(new Permiso() { NombreMenu = "menuCompras" });
            list.Add(new Permiso() { NombreMenu = "menuClientes" });
            list.Add(new Permiso() { NombreMenu = "menuProveedores" });
            list.Add(new Permiso() { NombreMenu = "menuReportes" });
            list.Add(new Permiso() { NombreMenu = "menuConfiguracion" });
            list.Add(new Permiso() { NombreMenu = "menuAcercade" });
            return list;
        }

        private void btGuardarPermiso_Click(object sender, EventArgs e)
        {
            int count = 0;
            int result = 0;
            string mensaje = string.Empty;
            int IdRol = Convert.ToInt32(((OpcionCombo)cbUusario.SelectedItem).valor);
            var dialog =
                    MessageBox.Show("¿Seguro que quieres modificar los permisos de " + ((OpcionCombo)cbUusario.SelectedItem).texto + "?",
                    "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes)
            {
                txtIdRol.Text = IdRol.ToString();
                if (IdRol > 0)
                {
                    List<bool> lsCheck = obtenerChecks();
                    List<Permiso> lsPermisos = ListarMenus();
                    foreach (Permiso oPermiso in lsPermisos)
                    {
                        Permiso _auxPermiso = new Permiso()
                        {
                            oRol = new Rol()
                            {
                                IdRol = Convert.ToInt32(txtIdRol.Text.ToString()),
                            },
                            NombreMenu = oPermiso.NombreMenu,
                            Estado = lsCheck[count]
                        };
                        count++;
                        result = new CN_Permiso().Editar(_auxPermiso, out mensaje);
                    }
                    MessageBox.Show("Permisos actualizados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                cbUusario.SelectedIndex = 0;
            }
            else
            {
                setChecks();
            }
        }
        private void setChecks()
        {
            int IdRol = Convert.ToInt32(((OpcionCombo)cbUusario.SelectedItem).valor);
            List<Permiso> oPermiso = new CN_Permiso().ListarPermisos(IdRol);
            menuUsuario.Checked = oPermiso[0].Estado;
            menuMantenedor.Checked = oPermiso[1].Estado;
            menuVentas.Checked = oPermiso[2].Estado;
            menuCompras.Checked = oPermiso[3].Estado;
            menuClientes.Checked = oPermiso[4].Estado;
            menuProveedores.Checked = oPermiso[5].Estado;
            menuReportes.Checked = oPermiso[6].Estado;
            menuConfiguracion.Checked = oPermiso[7].Estado;
            menuAcercade.Checked = oPermiso[8].Estado;
            txtIdRol.Text = IdRol.ToString();
        }
    }
}
