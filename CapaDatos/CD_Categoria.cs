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
    public class CD_Categoria
    {
        public List<Categoria> Listar()
        {
            List<Categoria> ls = new List<Categoria>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT IdCategoria, Descripcion, Estado FROM CATEGORIA ");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ls.Add(new Categoria()
                            {
                                IdCategoria = Convert.ToInt32(reader["IdCategoria"]),
                                Descripcion = reader["Descripcion"].ToString(),
                                Estado = Convert.ToBoolean(reader["Estado"].ToString()),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return ls;
        }
        public int Registrar(Categoria oCategoria, out string Mensaje)
        {
            // @Descripcion varchar(50),
            // @Estado bit,
            // @Resultado int output,
            // @Mensaje varchar(500) output
            int idCategoriagenerado = 0;
            Mensaje = String.Empty;
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_RegistrarCategoria", oConexion);
                    cmd.Parameters.AddWithValue("Descripcion", oCategoria.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", oCategoria.Estado);
                    cmd.Parameters.Add("resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    idCategoriagenerado = Convert.ToInt32(cmd.Parameters["resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idCategoriagenerado = 0;
                Mensaje = ex.Message;
            }
            return idCategoriagenerado;
        }

        public bool Editar(Categoria oCategoria, out string Mensaje)
        {
            // @IdCategoria int,
            // @Descripcion varchar(50),
            // @Estado bit,
            // @Resultado bit output,
            // @Mensaje varchar(500) output
            bool respuesta = false;
            Mensaje = String.Empty;
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarCategoria", oConexion);
                    cmd.Parameters.AddWithValue("IdCategoria", oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("Descripcion", oCategoria.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", oCategoria.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }
            return respuesta;
        }

        public bool Eliminar(Categoria oCategoria, out string Mensaje)
        {
            // @IdCategoria int,
            // @Respuesta bit output,
            // @Mensaje varchar(500) output
            bool respuesta = false;
            Mensaje = String.Empty;
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarCategoria", oConexion);
                    cmd.Parameters.AddWithValue("IdCategoria", oCategoria.IdCategoria);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }
            return respuesta;
        }
    }
}
