using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class ImprimirVenta : Form
    {
        StringBuilder linea = new StringBuilder();
        int maxCant = 50;
        private string _codigoVenta = string.Empty;
        public ImprimirVenta(string codigoVenta)
        {
            InitializeComponent();
            _codigoVenta = codigoVenta;
        }

        private void ImprimirVenta_Load(object sender, EventArgs e)
        {
            string tickettexto = Properties.Resources.Ticket.ToString();
            Venta oVenta = new CN_Venta().obtenerVenta(_codigoVenta);
            Negocio oNegocio = new CN_Negocio().obtenerDatos();

            tickettexto = tickettexto.Replace("¡nombreempresa!", oNegocio.Nombre.ToUpper());
            tickettexto = tickettexto.Replace("¡documentoempresa!", oNegocio.RFC);
            tickettexto = tickettexto.Replace("¡correoempresa!", oNegocio.Direccion);
            tickettexto = tickettexto.Replace("!telefonoempresa¡", "");

            tickettexto = tickettexto.Replace("¡tipodocumento!", oVenta.TipoDocumento);
            tickettexto = tickettexto.Replace("¡numerodocumento!", oVenta.NumeroDocumento);
            tickettexto = tickettexto.Replace("¡fechaventa!", oVenta.FechaRegistro);

            StringBuilder tr = new StringBuilder();
            foreach (Venta_Detalle dv in oVenta.oDetalleVenta)
            {
                tr.AppendLine("<tr>");
                tr.AppendLine("<td width=\"20\">" + dv.Cantidad + "</td>");
                tr.AppendLine("<td width=\"180\">" + dv.oProducto.Nombre + "</td>");
                tr.AppendLine("<td style=\"font-size:14px\">" + dv.PrecioVenta.ToString("0.00", new CultureInfo("es-PE")) + "</td>");
                tr.AppendLine("<td style=\"font-size:14px\">" + dv.SubTotal.ToString("0.00", new CultureInfo("es-PE")) + "</td>");
                tr.AppendLine("</tr>");
            }

            tickettexto = tickettexto.Replace("¡detalleventa!", tr.ToString());

            tickettexto = tickettexto.Replace("¡totalpagar!", oVenta.MontoTotal.ToString("0.00", new CultureInfo("es-PE")));
            tickettexto = tickettexto.Replace("¡pagocon!", oVenta.MontoPago.ToString("0.00", new CultureInfo("es-PE")));
            tickettexto = tickettexto.Replace("¡cambio!", oVenta.MontoCambio.ToString("0.00", new CultureInfo("es-PE")));

            webBrowser1.DocumentText = tickettexto;
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintDialog();
        }
    }
}
