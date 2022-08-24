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
using ClosedXML.Excel;

namespace CapaPresentacion
{
    public partial class frmReporteVentas : Form
    {
        public frmReporteVentas()
        {
            InitializeComponent();
        }

        private void frmReporteVentas_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dgvDatos.Columns)
            {
                cbBusqueda.Items.Add(new OpcionCombo()
                {
                    valor = column.Name,
                    texto = column.HeaderText,
                });
            }
            cbBusqueda.DisplayMember = "texto";
            cbBusqueda.ValueMember = "valor";
            cbBusqueda.SelectedIndex = 0;
        }

        private void btReporte_Click(object sender, EventArgs e)
        {
            List<ReporteVenta> lista = new CN_Reporte().Venta(txtfechainicio.Text, txtfechafin.Text);
            dgvDatos.Rows.Clear();
            foreach (ReporteVenta i in lista)
            {
                dgvDatos.Rows.Add(new object[]
                {
                    i.FechaRegistro,
                    i.TipoDocumento,
                    i.NumeroDocumento,
                    i.MontoTotal,
                    i.UsuarioRegistro,
                    i.DocumentoCliente,
                    i.NombreCliente,
                    i.CodigoProducto,
                    i.NombreProducto,
                    i.Categoria,
                    i.PrecioVenta,
                    i.Cantidad,
                    i.SubTotal
                });
            }
        }

        private void btBuscar_Click(object sender, EventArgs e)
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

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
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

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            if (dgvDatos.Rows.Count < 1)
                MessageBox.Show("No hay datos por exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn column in dgvDatos.Columns)
                {
                    if (column.HeaderText != "" && column.Visible)
                    {
                        dt.Columns.Add(column.HeaderText, typeof(string));
                    }
                }
                foreach (DataGridViewRow row in dgvDatos.Rows)
                {
                    if (row.Visible)
                    {
                        dt.Rows.Add(new object[]
                        {
                            row.Cells[0].Value.ToString(),
                            row.Cells[1].Value.ToString(),
                            row.Cells[2].Value.ToString(),
                            row.Cells[3].Value.ToString(),
                            row.Cells[4].Value.ToString(),
                            row.Cells[5].Value.ToString(),
                            row.Cells[6].Value.ToString(),
                            row.Cells[7].Value.ToString(),
                            row.Cells[8].Value.ToString(),
                            row.Cells[9].Value.ToString(),
                            row.Cells[10].Value.ToString(),
                            row.Cells[11].Value.ToString(),
                            row.Cells[12].Value.ToString(),

                        });
                    }
                }
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.FileName = string.Format("ReporteVentas_{0}.xlsx", DateTime.Now.ToString("yyyyMMddHHmm"));
                saveFile.Filter = "Excel Files| *.xlsx; *.xlsm; *.xlsb; *.xls; *‌​.xml";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var sheet = wb.Worksheets.Add(dt, "Ventas");
                        sheet.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(saveFile.FileName);
                        MessageBox.Show("Excel generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al generar excel\n" + ex.Message.ToString(), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
    }
}
