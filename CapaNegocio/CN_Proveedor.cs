using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Proveedor
    {
        private CD_Proveedor oCD_Proveedor = new CD_Proveedor();
        public List<Proveedor> Listar()
        {
            return oCD_Proveedor.Listar();
        }
        public int Registrar(Proveedor oProveedor, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (oProveedor.Documento == string.Empty)
                Mensaje += "Es necesario el Proveedor\n";
            if (oProveedor.RazonSocial == string.Empty)
                Mensaje += "Es necesario el nombre del Proveedor\n";
            if (Mensaje != string.Empty)
                return 0;
            else
                return oCD_Proveedor.Registrar(oProveedor, out Mensaje);
        }
        public bool Editar(Proveedor oProveedor, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (oProveedor.Documento == string.Empty)
                Mensaje += "Es necesario el Proveedor\n";
            if (oProveedor.RazonSocial == string.Empty)
                Mensaje += "Es necesario el nombre del Proveedor\n";
            if (Mensaje != string.Empty)
                return false;
            else
                return oCD_Proveedor.Editar(oProveedor, out Mensaje);
        }
        public bool Eliminar(Proveedor oProveedor, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (oProveedor.Documento == string.Empty)
                Mensaje += "Es necesario el Proveedor\n";
            if (oProveedor.RazonSocial == string.Empty)
                Mensaje += "Es necesario el nombre del Proveedor\n";
            if (Mensaje != string.Empty)
                return false;
            else
                return oCD_Proveedor.Eliminar(oProveedor, out Mensaje);
        }
    }
}
