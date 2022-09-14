using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Modales
{
    public partial class mdAcercade : Form
    {
        private string _url = "https://github.com/Lui5-99/SistemaVentas";
        public mdAcercade()
        {
            InitializeComponent();
        }

        public void redirect(string url)
        {
            var processStartInfo = new ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = url
            };
            Process.Start(processStartInfo);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            redirect(_url);
        }

        private void mdAcercade_Load_1(object sender, EventArgs e)
        {
            linkLabel1.Text = _url;
        }
    }
}
