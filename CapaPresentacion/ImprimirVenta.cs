using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
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
        private string _codigoVenta = string.Empty;
        public ImprimirVenta(string codigoVenta)
        {
            InitializeComponent();
            _codigoVenta = codigoVenta;
            string titulo = ("Ticket de venta " + _codigoVenta);
            this.Text = titulo;
        }

        private void ImprimirVenta_Load(object sender, EventArgs e)
        {
            webBrowser1.DocumentText = CrearTicket.crearTicketVenta(_codigoVenta);
            btImprimir.Select();
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintDialog();
        }

        private void ImprimirVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                webBrowser1.ShowPrintDialog();
            }
        }
    }
}
