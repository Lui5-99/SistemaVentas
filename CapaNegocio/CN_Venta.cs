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
    public class CN_Venta
    {
        private CD_Venta oCNVenta = new CD_Venta();
        public int obtenerCorrelativo()
        {
            return oCNVenta.obtenerCorrelativo();
        }
        public bool restarStock(int IdProducto, int Cantidad)
        {
            return oCNVenta.restarStock(IdProducto, Cantidad);
        }
        public bool sumarStock(int IdProducto, int Cantidad)
        {
            return oCNVenta.sumarStock(IdProducto, Cantidad);
        }
        public bool Registrar(Venta oVenta, DataTable detalleVenta, out string mensaje)
        {
            return oCNVenta.Registrar(oVenta, detalleVenta, out mensaje);
        }
        public Venta obtenerVenta(string numero)
        {
            Venta oVenta = oCNVenta.obtenerVenta(numero);
            if (oVenta.IdVenta != 0)
            {
                List<Venta_Detalle> ls = oCNVenta.obtenerDetalle(oVenta.IdVenta);
                oVenta.oDetalleVenta = ls;
            }
            return oVenta;
        }
        public List<Venta> Listar()
        {
            return oCNVenta.Listar();
        }
    }
}
