using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Categoria
    {
        private CD_Categoria oCD_Categoria = new CD_Categoria();
        public List<Categoria> Listar()
        {
            return oCD_Categoria.Listar();
        }
        public int Registrar(Categoria oCategoria, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (oCategoria.Descripcion == string.Empty)
                Mensaje += "Es necesaria la descripción de categoria\n";
            if (Mensaje != string.Empty)
                return 0;
            else
                return oCD_Categoria.Registrar(oCategoria, out Mensaje);
        }
        public bool Editar(Categoria oCategoria, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (oCategoria.Descripcion == string.Empty)
                Mensaje += "Es necesaria la descripción de categoria\n";
            if (Mensaje != string.Empty)
                return false;
            else
                return oCD_Categoria.Editar(oCategoria, out Mensaje);
        }
        public bool Eliminar(Categoria oCategoria, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (oCategoria.Descripcion == string.Empty)
                Mensaje += "Es necesaria la descripción de categoria\n";
            if (Mensaje != string.Empty)
                return false;
            else
                return oCD_Categoria.Eliminar(oCategoria, out Mensaje);
        }
    }
}
