using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Negocio
    {
        private CD_Negocio oCD_Negocio = new CD_Negocio();
        public Negocio obtenerDatos()
        {
            return oCD_Negocio.obtenerDatos();
        }
        public bool GuardarDatos(Negocio oNegocio, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (oNegocio.Nombre == string.Empty)
                Mensaje += "Es necesaria el Nombre\n";
            if (oNegocio.Nombre == string.Empty)
                Mensaje += "Es necesaria el RFC\n";
            if (oNegocio.Direccion == string.Empty)
                Mensaje += "Es necesaria la dirección\n";
            if (Mensaje != string.Empty)
                return false;
            else
                return oCD_Negocio.GuardarDatos(oNegocio, out Mensaje);
        }
        public byte[] ObtenerLogo(out bool obtenido)
        {
            return oCD_Negocio.ObtenerLogo(out obtenido);
        }
        public bool actualizarLogo(byte[] image, out string Mensaje)
        { 
            return oCD_Negocio.actualizarLogo(image, out Mensaje);
        }

    }
}
