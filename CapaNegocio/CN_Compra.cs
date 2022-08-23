using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Compra
    {
        private CD_Compra oCNCompra = new CD_Compra();
        public int obtenerCorrelativo()
        {
            return oCNCompra.obtenerCorrelativo();
        }
        public bool Registrar(Compra oCompra, DataTable detalleCompra, out string mensaje)
        {
            return oCNCompra.Registrar(oCompra, detalleCompra, out mensaje);
        }
    }
}
