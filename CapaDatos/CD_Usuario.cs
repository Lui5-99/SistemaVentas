using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaEntidad;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Usuario
    {
        public  List<Usuario> Listar()
        {
            List<Usuario> ls = new List<Usuario>();
            using(SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "SELECT IdUsuario, Documento, NombreCompleto, Correo, Clave, Estado FROM USUARIO";
                    SqlCommand cmd = new SqlCommand(query, oConexion); 
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ls.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                                Documento = reader["Documento"].ToString(),
                                NombreCompleto = reader["NombreCompleto"].ToString(),
                                Correo = reader["Correo"].ToString(),
                                Clave = reader["Clave"].ToString(),
                                Estado = Convert.ToBoolean(reader["Estado"])
                            });
                        }
                    }
                }
                catch(Exception ex)
                {
                    
                }
            }
            return ls;
        }
    }
}
