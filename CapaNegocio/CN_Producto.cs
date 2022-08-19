using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Producto
    {
        private CD_Producto oCD_Producto = new CD_Producto();
        public List<Producto> Listar()
        {
            return oCD_Producto.Listar();
        }
        public int Registrar(Producto oProducto, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (oProducto.Codigo == string.Empty)
                Mensaje += "Es necesario el código de producto\n";
            if (oProducto.Nombre == string.Empty)
                Mensaje += "Es necesario el nombre del Producto\n";
            if (Mensaje != string.Empty)
                return 0;
            else
                return oCD_Producto.Registrar(oProducto, out Mensaje);
        }
        public bool Editar(Producto oProducto, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (oProducto.Codigo == string.Empty)
                Mensaje += "Es necesario el código de producto\n";
            if (oProducto.Nombre == string.Empty)
                Mensaje += "Es necesario el nombre del Producto\n";
            if (Mensaje != string.Empty)
                return false;
            else
                return oCD_Producto.Editar(oProducto, out Mensaje);
        }
        public bool Eliminar(Producto oProducto, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (oProducto.Codigo == string.Empty)
                Mensaje += "Es necesario el código de producto\n";
            if (oProducto.Nombre == string.Empty)
                Mensaje += "Es necesario el nombre del Producto\n";
            if (Mensaje != string.Empty)
                return false;
            else
                return oCD_Producto.Eliminar(oProducto, out Mensaje);
        }
    }
}
