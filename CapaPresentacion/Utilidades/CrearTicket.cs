using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace CapaPresentacion.Utilidades
{
    public class CrearTicket
    {
        StringBuilder linea = new StringBuilder();
        int maxCant = 50;
        int _IdVenta;
        private void AgregarCaracter(string c)
        {
            string texto = "";
            for (int i = 0; i < maxCant; i++)
            {
                texto += c;
            }
            linea.AppendLine(texto);
        }
        private void AgregarTextoCentro(string texto)
        {

            if (texto.Length > maxCant)
            {

            }
            else
            {
                decimal agregarespacio = Math.Truncate(Convert.ToDecimal((maxCant - texto.Length) / 2));
                string espacios = "";
                for (int i = 0; i < agregarespacio; i++)
                {
                    espacios += " ";
                }
                linea.AppendLine(espacios + texto);
            }
        }

        private void AgregarDosColumnas(string texto1, string texto2)
        {
            int cantidadtexto = texto1.Length + texto2.Length;
            if (cantidadtexto > maxCant)
            {

            }
            else
            {
                int cantidadespacio = maxCant - cantidadtexto;
                string espacios = "";
                for (int i = 0; i < cantidadespacio; i++)
                {
                    espacios += " ";
                }
                linea.AppendLine(texto1 + espacios + texto2);
            }

        }
    }
}
