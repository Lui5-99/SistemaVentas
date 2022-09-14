using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
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
    public partial class frmDetalleCompra : Form
    {
        public frmDetalleCompra()
        {
            InitializeComponent();
        }

        private void btBusqueda_Click(object sender, EventArgs e)
        {
            using (var modal = new mdCompra())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtBusqueda.Text = modal._Compra.NumeroDocumento.ToString();
                    txtBusqueda.BackColor = Color.Honeydew;

                    Compra oCompra = new CN_Compra().obtenerCompra(txtBusqueda.Text);
                    if (oCompra.IdCompra != 0)
                    {
                        txtBusqueda.BackColor = Color.Honeydew;
                        txtNumeroDocto.Text = oCompra.NumeroDocumento;
                        txtFecha.Text = oCompra.FechaRegistro;
                        txtTipoDocto.Text = oCompra.TipoDocumento;
                        txtUsuario.Text = oCompra.oUsuario.NombreCompleto;
                        txtDocumento.Text = oCompra.oProveedor.Codigo;
                        txtRazon.Text = oCompra.oProveedor.RazonSocial;

                        dgvDatos.Rows.Clear();
                        foreach (Detalle_Compra dc in oCompra.oDetalleCompra)
                        {
                            dgvDatos.Rows.Add(new object[]
                            {
                                dc.oProducto.Nombre,
                                dc.PrecioCompra,
                                dc.Cantidad,
                                dc.MontoTotal
                            });
                        }
                        txtMonto.Text = oCompra.MontoTotal.ToString("0.00");
                    }
                    else
                    {
                        txtBusqueda.BackColor = Color.MistyRose;
                        txtNumeroDocto.Text = "";
                        txtFecha.Text = "";
                        txtTipoDocto.Text = "";
                        txtUsuario.Text = "";
                        txtDocumento.Text = ""; ;
                        txtRazon.Text = "";

                        dgvDatos.Rows.Clear();
                        txtMonto.Text = "0.00";
                    }
                }
                else
                {
                    txtBusqueda.BackColor = Color.MistyRose;
                    txtBusqueda.Select();
                }
            }
            
        }

        private void btPDF_Click(object sender, EventArgs e)
        {
            if(txtTipoDocto.Text == null)
            {
                MessageBox.Show("No se encontraron resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string TextHTML = Properties.Resources.PlantillaCompra.ToString();
            Negocio oNegocio = new CN_Negocio().obtenerDatos();

            TextHTML = TextHTML.Replace("@nombrenegocio", oNegocio.Nombre.ToUpper());
            TextHTML = TextHTML.Replace("@docnegocio", oNegocio.RFC);
            TextHTML = TextHTML.Replace("@direcnegocio", oNegocio.Direccion);

            TextHTML = TextHTML.Replace("@tipodocumento", txtTipoDocto.Text);
            TextHTML = TextHTML.Replace("@numerodocumento", txtNumeroDocto.Text);

            TextHTML = TextHTML.Replace("@docproveedor", txtDocumento.Text);
            TextHTML = TextHTML.Replace("@nombreproveedor", txtRazon.Text);
            TextHTML = TextHTML.Replace("@fecharegistro", txtFecha.Text);
            TextHTML = TextHTML.Replace("@usuarioregistro", txtUsuario.Text);

            string filas = string.Empty;
            foreach (DataGridViewRow row in dgvDatos.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                filas += "<td>" + "$ " + row.Cells["PrecioCompra"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + "$ " + row.Cells["SubTotal"].Value.ToString() + "</td>";
                filas += "</tr>";

            }
            TextHTML = TextHTML.Replace("@filas", filas);

            TextHTML = TextHTML.Replace("@montototal", "$ " + txtMonto.Text.ToString());

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = string.Format("Compra_{0}.pdf", txtNumeroDocto.Text);
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

        private void btLimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtNumeroDocto.Text = "";
            txtFecha.Text = "";
            txtTipoDocto.Text ="";
            txtUsuario.Text = "";
            txtDocumento.Text = "";
            txtRazon.Text = "";
            txtBusqueda.BackColor = Color.White;
            dgvDatos.Rows.Clear();
            txtMonto.Text = "0.00";
            txtBusqueda.Select();
        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                Compra oCompra = new CN_Compra().obtenerCompra(txtBusqueda.Text);
                if (oCompra.IdCompra != 0)
                {
                    txtBusqueda.BackColor = Color.Honeydew;
                    txtNumeroDocto.Text = oCompra.NumeroDocumento;
                    txtFecha.Text = oCompra.FechaRegistro;
                    txtTipoDocto.Text = oCompra.TipoDocumento;
                    txtUsuario.Text = oCompra.oUsuario.NombreCompleto;
                    txtDocumento.Text = oCompra.oProveedor.Codigo;
                    txtRazon.Text = oCompra.oProveedor.RazonSocial;

                    dgvDatos.Rows.Clear();
                    foreach (Detalle_Compra dc in oCompra.oDetalleCompra)
                    {
                        dgvDatos.Rows.Add(new object[]
                        {
                        dc.oProducto.Nombre,
                        dc.PrecioCompra,
                        dc.Cantidad,
                        dc.MontoTotal
                        });
                    }
                    txtMonto.Text = oCompra.MontoTotal.ToString("0.00");
                }
                else
                {
                    txtBusqueda.BackColor = Color.MistyRose;
                    txtNumeroDocto.Text = "";
                    txtFecha.Text = "";
                    txtTipoDocto.Text = "";
                    txtUsuario.Text = "";
                    txtDocumento.Text = ""; ;
                    txtRazon.Text = "";

                    dgvDatos.Rows.Clear();
                    txtMonto.Text = "0.00";
                }
            }
        }
    }
}
