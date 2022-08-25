﻿using System;
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
using System.IO;
using System.Drawing.Printing;

namespace CapaPresentacion
{
    public partial class frmConfiguracion : Form
    {
        public frmConfiguracion()
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
        private void frmConfiguracion_Load(object sender, EventArgs e)
        {
            int count = 0;
            bool obtenido = true;
            byte[] image = new CN_Negocio().ObtenerLogo(out obtenido);
            if (image.Length > 0)
                picLogo.Image = byte2image(image);
            Negocio oNegocio = new CN_Negocio().obtenerDatos();
            txtNombre.Text = oNegocio.Nombre;
            txtRFC.Text = oNegocio.RFC;
            txtDireccion.Text = oNegocio.Direccion;
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                cbImpresora.Items.Add(new OpcionCombo()
                {
                    valor = count,
                    texto = printer,
                });
                count++;
            }
            cbImpresora.DisplayMember = "texto";
            cbImpresora.ValueMember = "valor";
            cbImpresora.SelectedIndex = 0;
        }

        private void btSubir_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Files| *.jpg;*.jpeg;*.png";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                byte[] byteImage = File.ReadAllBytes(openFile.FileName);
                bool respuesta = new CN_Negocio().actualizarLogo(byteImage, out mensaje);
                if (respuesta)
                    picLogo.Image = byte2image(byteImage);
                else
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Negocio oNegocio = new Negocio()
            {
                Nombre = txtNombre.Text,
                RFC = txtRFC.Text,
                Direccion = txtDireccion.Text,
            };
            bool respuesta = new CN_Negocio().GuardarDatos(oNegocio, out mensaje);
            if(respuesta)
                MessageBox.Show("Datos Actualizados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btImpresora_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Negocio oNegocio = new Negocio()
            {
                Impresora = ((OpcionCombo)cbImpresora.SelectedItem).texto
            };
            bool respuesta = new CN_Negocio().GuardarImpresora(oNegocio, out mensaje);
            if (respuesta)
                MessageBox.Show("Datos Actualizados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
