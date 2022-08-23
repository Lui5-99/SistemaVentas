﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;


namespace CapaNegocio
{
    public class CN_Rol
    {
        private CD_Rol oCD_Rol = new CD_Rol();
        public List<Rol> Listar()
        {
            return oCD_Rol.Listar();
        }
        public int Registrar(Rol rol, out string mensaje)
        {
            mensaje = string.Empty;
            if(rol.Descripcion == string.Empty)
            {
                mensaje += "Ingresa un rol";
                return 0;
            }
            else
            {
                return oCD_Rol.Registrar(rol, out mensaje);
            }
        }
        public int IdRol()
        {
            return oCD_Rol.IdRol();
        }
    }
}
