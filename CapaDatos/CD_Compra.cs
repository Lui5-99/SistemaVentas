using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Compra
    {
        public int obtenerCorrelativo()
        {
            int idCorrelativo = 0;
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select count(*) + 1 from COMPRA");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();

                    idCorrelativo = Convert.ToInt32(cmd.ExecuteScalar());
                    
                    oConexion.Close();
                }
                catch (Exception ex)
                {
                    idCorrelativo = 0;
                }
            }
            return idCorrelativo;
        }

        public bool Registrar(Compra oCompra, DataTable detalleCompra, out string mensaje)
        {
            //@IdUsuario int,
            //@IdProveedor int,
            //@TipoDocumento varchar(500),
            //@NumeroDocumento varchar(500),
            //@MontoTotal decimal(18, 2),
            //@DetalleCompra[EDetalle_Compra] READONLY,
            //@Resultado bit output,
            //@Mensaje varchar(500) output
            mensaje = string.Empty;
            bool resultado = false;
            using(SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarCompra", oConexion);
                    cmd.Parameters.AddWithValue("IdUsuario", oCompra.oUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("IdProveedor", oCompra.oProveedor.IdProveedor);
                    cmd.Parameters.AddWithValue("TipoDocumento", oCompra.TipoDocumento);
                    cmd.Parameters.AddWithValue("NumeroDocumento", oCompra.NumeroDocumento);
                    cmd.Parameters.AddWithValue("MontoTotal", oCompra.MontoTotal);
                    cmd.Parameters.AddWithValue("DetalleCompra", detalleCompra);

                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                    oConexion.Close();
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                    resultado = false;
                }
            }
            return resultado;
        }
        public Compra obtenerCompra(string numero)
        {
            Compra oCompra = new Compra();
            using(SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT C.IdCompra, U.NombreCompleto, ");
                    query.AppendLine("P.Documento, P.RazonSocial, ");
                    query.AppendLine("C.TipoDocumento, C.NumeroDocumento, ");
                    query.AppendLine("C.MontoTotal, CONVERT(CHAR(10),C.FechaRegistro,103) FechaRegistro ");
                    query.AppendLine("FROM COMPRA C ");
                    query.AppendLine("INNER JOIN USUARIO U ON U.IdUsuario = C.IdUsuario ");
                    query.AppendLine("INNER JOIN PROVEEDOR P ON P.IdProveedor = C.IdProveedor ");
                    query.AppendLine("WHERE C.NumeroDocumento = @NumeroDocumento");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("NumeroDocumento", numero);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            oCompra = new Compra()
                            {
                                IdCompra = Convert.ToInt32(reader["IdCompra"].ToString()),
                                oUsuario = new Usuario()
                                {
                                    NombreCompleto = reader["NombreCompleto"].ToString()
                                },
                                oProveedor = new Proveedor()
                                {
                                    Documento = reader["Documento"].ToString(),
                                    RazonSocial = reader["RazonSocial"].ToString(),
                                },
                                TipoDocumento = reader["TipoDocumento"].ToString(),
                                NumeroDocumento = reader["NumeroDocumento"].ToString(),
                                MontoTotal = Convert.ToDecimal(reader["MontoTotal"].ToString()),
                                FechaRegistro = reader["FechaRegistro"].ToString(),
                            };
                        }
                    }
                }
                catch(Exception ex)
                {
                    oCompra = new Compra();
                }
            }
            return oCompra;
        }

        public List<Detalle_Compra> obtenerDetalle(int id)
        {
            List<Detalle_Compra> ls = new List<Detalle_Compra>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT P.Nombre, DC.PrecioCompra, DC.Cantidad, DC.MontoTotal  ");
                    query.AppendLine("FROM DETALLE_COMPRA DC ");
                    query.AppendLine("INNER JOIN PRODUCTO P ON P.IdProducto = DC.IdProducto ");
                    query.AppendLine("WHERE DC.IdCompra = @Id ");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("Id", id);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ls.Add(new Detalle_Compra()
                            {
                                oProducto = new Producto()
                                {
                                    Nombre = reader["Nombre"].ToString(),
                                },
                                PrecioCompra = Convert.ToDecimal(reader["PrecioCompra"].ToString()),
                                Cantidad = Convert.ToInt32(reader["Cantidad"].ToString()),
                                MontoTotal = Convert.ToDecimal(reader["MontoTotal"].ToString()),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    ls = new List<Detalle_Compra>();
                }
            }
            return ls;
        }
    }
}
