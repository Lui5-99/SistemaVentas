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
    public class CD_Producto
    {
        public List<Producto> Listar()
        {
            List<Producto> ls = new List<Producto>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("Select p.IdProducto, p.Nombre, p.Codigo, p.Descripcion, c.IdCategoria, c.Descripcion Categoria,  ");
                    query.AppendLine("p.Stock, p.PrecioVenta, p.PrecioCompra, p.estado  ");
                    query.AppendLine("FROM PRODUCTO p ");
                    query.AppendLine("INNER JOIN categoria c on p.IdCategoria = c.IdCategoria ");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ls.Add(new Producto()
                            {
                                IdProducto = Convert.ToInt32(reader["IdProducto"]),
                                Codigo = reader["Codigo"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Descripcion = reader["Descripcion"].ToString(),
                                oCategoria = new Categoria()
                                {
                                    IdCategoria = Convert.ToInt32(reader["IdCategoria"].ToString()),
                                    Descripcion = reader["Categoria"].ToString(),
                                },
                                Stock = Convert.ToInt32(reader["Stock"].ToString()),
                                PrecioCompra = Convert.ToDecimal(reader["PrecioCompra"]),
                                PrecioVenta = Convert.ToDecimal(reader["PrecioVenta"]),
                                Estado = Convert.ToBoolean(reader["Estado"]),
                                
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
        public int Registrar(Producto oProducto, out string Mensaje)
        {
            //@Codigo varchar(20),
            //@Nombre varchar(30),
            //@Descripcion varchar(30),
            //@IdCategoria int,
            //@Estado bit,
            //@Resultado int output,
            //@Mensaje varchar(500) output
            int idProductogenerado = 0;
            Mensaje = String.Empty;
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarProducto", oConexion);
                    cmd.Parameters.AddWithValue("Codigo", oProducto.Codigo);
                    cmd.Parameters.AddWithValue("Nombre", oProducto.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", oProducto.Descripcion);
                    cmd.Parameters.AddWithValue("IdCategoria", oProducto.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("Estado", oProducto.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    idProductogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idProductogenerado = 0;
                Mensaje = ex.Message;
            }
            return idProductogenerado;
        }

        public bool Editar(Producto oProducto, out string Mensaje)
        {
            //@IdProducto int,
            //@Codigo varchar(20),
            //@Nombre varchar(30),
            //@Descripcion varchar(30),
            //@IdCategoria int,
            //@Estado bit,
            //@Resultado int output,
            //@Mensaje varchar(500) output
            bool respuesta = false;
            Mensaje = String.Empty;
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_ModificarProducto", oConexion);
                    cmd.Parameters.AddWithValue("IdProducto", oProducto.IdProducto);
                    cmd.Parameters.AddWithValue("Codigo", oProducto.Codigo);
                    cmd.Parameters.AddWithValue("Nombre", oProducto.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", oProducto.Descripcion);
                    cmd.Parameters.AddWithValue("IdCategoria", oProducto.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("Estado", oProducto.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                    oConexion.Close();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }
            return respuesta;
        }

        public bool Eliminar(Producto oProducto, out string Mensaje)
        {
            // @IdProducto int,
            // @Respuesta bit output,
            // @Mensaje varchar(500) output
            bool respuesta = false;
            Mensaje = String.Empty;
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_EliminarProducto", oConexion);
                    cmd.Parameters.AddWithValue("IdProducto", oProducto.IdProducto);
                    cmd.Parameters.Add("respuesta", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                    oConexion.Close();
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
