using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Permiso
    {
        public List<Permiso> Listar(int IdUsuario)
        {
            List<Permiso> ls = new List<Permiso>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT P.IdRol, P.NombreMenu FROM PERMISO P ");
                    query.AppendLine("INNER JOIN ROL R ON R.IdRol = P.IdRol ");
                    query.AppendLine("INNER JOIN USUARIO U ON U.IdRol = R.IdRol");
                    query.AppendLine("WHERE U.IdUsuario = @IdUsuario");
         
                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ls.Add(new Permiso()
                            {
                                oRol = new Rol()
                                {
                                    IdRol = Convert.ToInt32(reader["IdRol"].ToString())
                                },
                                NombreMenu = reader["NombreMenu"].ToString()
                            });
                        }
                    }
                    oConexion.Close();
                }
                catch (Exception ex)
                {

                }
            }
            return ls;
        }
    }
}
