using CapaEntidad;
using CapaNegocio;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmDetalleVenta : Form
    {
        public frmDetalleVenta()
        {
            InitializeComponent();
        }

        private void frmDetalleVenta_Load(object sender, EventArgs e)
        {
            
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btLimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtBusqueda.BackColor = Color.White;
            txtNumDocto.Text = "";
            txtFecha.Text = "";
            txtTipoDocto.Text = "";
            txtUsuario.Text = "";
            txtDocumento.Text = "";
            txtRazon.Text = "";
            txtBusqueda.Text = "";
            dgvDatos.Rows.Clear();
            txtMontoTotal.Text = "0.00";
            txtMontoPago.Text = "0.00";
            txtMontoCambio.Text = "0.00";
            txtBusqueda.Select();
        }

        private void btPDF_Click(object sender, EventArgs e)
        {
            if (txtTipoDocto.Text == null)
            {
                MessageBox.Show("No se encontraron resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string TextHTML = Properties.Resources.PlantillaVenta.ToString();
            Negocio oNegocio = new CN_Negocio().obtenerDatos();

            TextHTML = TextHTML.Replace("@nombrenegocio", oNegocio.Nombre.ToUpper());
            TextHTML = TextHTML.Replace("@docnegocio", oNegocio.RFC);
            TextHTML = TextHTML.Replace("@direcnegocio", oNegocio.Direccion);

            TextHTML = TextHTML.Replace("@tipodocumento", txtTipoDocto.Text);
            TextHTML = TextHTML.Replace("@numerodocumento", txtNumDocto.Text);

            TextHTML = TextHTML.Replace("@doccliente", txtDocumento.Text);
            TextHTML = TextHTML.Replace("@nombrecliente", txtRazon.Text);
            TextHTML = TextHTML.Replace("@fecharegistro", txtFecha.Text);
            TextHTML = TextHTML.Replace("@usuarioregistro", txtUsuario.Text);

            string filas = string.Empty;
            foreach (DataGridViewRow row in dgvDatos.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                filas += "<td>" + "$ " + row.Cells["Precio"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + "$ " + row.Cells["SubTotal"].Value.ToString() + "</td>";
                filas += "</tr>";

            }
            TextHTML = TextHTML.Replace("@filas", filas);

            TextHTML = TextHTML.Replace("@montototal", "$ " + txtMontoTotal.Text.ToString());
            TextHTML = TextHTML.Replace("@pagocon", "$ " + txtMontoPago.Text.ToString());
            TextHTML = TextHTML.Replace("@cambio", "$ " + txtMontoCambio.Text.ToString());

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = string.Format("Venta_{0}.pdf", txtNumDocto.Text);
            saveFile.Filter = "Pdf Files| *.pdf";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream str = new FileStream(saveFile.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, str);
                    pdfDoc.Open();
                    bool obtenido = true;
                    byte[] byteImage = new CN_Negocio().ObtenerLogo(out obtenido);
                    if (byteImage.Length > 0)
                    {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteImage);
                        img.ScaleToFit(60, 60);
                        img.Alignment = iTextSharp.text.Image.UNDERLYING;
                        img.SetAbsolutePosition(pdfDoc.Left, pdfDoc.GetTop(51));
                        pdfDoc.Add(img);
                    }
                    using (StringReader sr = new StringReader(TextHTML))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }
                    pdfDoc.Close();
                    str.Close();
                    MessageBox.Show("Documento PDF generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btBusqueda_Click(object sender, EventArgs e)
        {
            Venta oVenta = new CN_Venta().obtenerVenta(txtBusqueda.Text);
            if (oVenta.IdVenta != 0)
            {
                txtBusqueda.BackColor = Color.Honeydew;
                txtNumDocto.Text = oVenta.NumeroDocumento;
                txtFecha.Text = oVenta.FechaRegistro;
                txtTipoDocto.Text = oVenta.TipoDocumento;
                txtUsuario.Text = oVenta.oUsuario.NombreCompleto;
                txtDocumento.Text = oVenta.DocumentoCliente;
                txtRazon.Text = oVenta.NombreCliente;

                dgvDatos.Rows.Clear();
                foreach (Venta_Detalle dc in oVenta.oDetalleVenta)
                {
                    dgvDatos.Rows.Add(new object[]
                    {
                        dc.oProducto.Nombre,
                        dc.PrecioVenta,
                        dc.Cantidad,
                        dc.SubTotal
                    });
                }
                txtMontoTotal.Text = oVenta.MontoTotal.ToString("0.00");
                txtMontoPago.Text = oVenta.MontoPago.ToString("0.00");
                txtMontoCambio.Text = oVenta.MontoCambio.ToString("0.00");
            }
            else
            {
                txtBusqueda.BackColor = Color.MistyRose;
                txtNumDocto.Text = "";
                txtFecha.Text = ""; 
                txtTipoDocto.Text = ""; 
                txtUsuario.Text = ""; 
                txtDocumento.Text = ""; 
                txtRazon.Text = "";

                dgvDatos.Rows.Clear();

                txtMontoTotal.Text = "0.00";
                txtMontoPago.Text = "0.00";
                txtMontoCambio.Text = "0.00";
            }
        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Venta oVenta = new CN_Venta().obtenerVenta(txtBusqueda.Text);
                if (oVenta.IdVenta != 0)
                {
                    txtBusqueda.BackColor = Color.Honeydew;
                    txtNumDocto.Text = oVenta.NumeroDocumento;
                    txtFecha.Text = oVenta.FechaRegistro;
                    txtTipoDocto.Text = oVenta.TipoDocumento;
                    txtUsuario.Text = oVenta.oUsuario.NombreCompleto;
                    txtDocumento.Text = oVenta.DocumentoCliente;
                    txtRazon.Text = oVenta.NombreCliente;

                    dgvDatos.Rows.Clear();
                    foreach (Venta_Detalle dc in oVenta.oDetalleVenta)
                    {
                        dgvDatos.Rows.Add(new object[]
                        {
                        dc.oProducto.Nombre,
                        dc.PrecioVenta,
                        dc.Cantidad,
                        dc.SubTotal
                        });
                    }
                    txtMontoTotal.Text = oVenta.MontoTotal.ToString("0.00");
                    txtMontoPago.Text = oVenta.MontoPago.ToString("0.00");
                    txtMontoCambio.Text = oVenta.MontoCambio.ToString("0.00");
                }
                else
                {
                    txtBusqueda.BackColor = Color.MistyRose;
                    txtNumDocto.Text = "";
                    txtFecha.Text = ""; 
                    txtTipoDocto.Text = ""; 
                    txtUsuario.Text = ""; 
                    txtDocumento.Text = ""; 
                    txtRazon.Text = "";

                    dgvDatos.Rows.Clear();

                    txtMontoTotal.Text = "0.00";
                    txtMontoPago.Text = "0.00";
                    txtMontoCambio.Text = "0.00";
                }
            }
        }
    }
}
