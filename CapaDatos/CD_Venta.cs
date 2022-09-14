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
    public class CD_Venta
    {
        public int obtenerCorrelativo()
        {
            int idCorrelativo = 0;
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select count(*) + 1 from Venta");
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

        public bool restarStock(int IdProducto, int Cantidad)
        {
            bool respuesta = false;
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update producto set stock = stock - @cantidad where IdProducto = @IdProducto");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("cantidad", Cantidad);
                    cmd.Parameters.AddWithValue("IdProducto", IdProducto);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();

                    respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;

                    oConexion.Close();
                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
        public bool sumarStock(int IdProducto, int Cantidad)
        {
            bool respuesta = false;
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update producto set stock = stock + @cantidad where IdProducto = @IdProducto");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("cantidad", Cantidad);
                    cmd.Parameters.AddWithValue("IdProducto", IdProducto);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();

                    respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;

                    oConexion.Close();
                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public bool Registrar(Venta oVenta, DataTable detalleVenta, out string mensaje)
        {
            //@IdUsuario int,
            //@TipoDocumento varchar(500),
            //@NumeroDocumento varchar(500),
            //@DocumentoCliente varchar(500),
            //@NombreCliente varchar(500),
            //@MontoPago decimal(18, 2),
            //@MontoCambio decimal(18, 2),
            //@MontoTotal decimal(18, 2),
            //@DetalleVenta[EDetalle_Venta] READONLY,                                      
            //@Resultado bit output,
            //@Mensaje varchar(500) output
            mensaje = string.Empty;
            bool resultado = false;
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarVenta", oConexion);
                    cmd.Parameters.AddWithValue("IdUsuario", oVenta.oUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("TipoDocumento", oVenta.TipoDocumento);
                    cmd.Parameters.AddWithValue("NumeroDocumento", oVenta.NumeroDocumento);
                    cmd.Parameters.AddWithValue("DocumentoCliente", oVenta.DocumentoCliente);
                    cmd.Parameters.AddWithValue("NombreCliente", oVenta.NombreCliente);
                    cmd.Parameters.AddWithValue("MontoPago", oVenta.MontoPago);
                    cmd.Parameters.AddWithValue("MontoCambio", oVenta.MontoCambio);
                    cmd.Parameters.AddWithValue("MontoTotal", oVenta.MontoTotal);
                    cmd.Parameters.AddWithValue("DetalleVenta", detalleVenta);

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
        public Venta obtenerVenta(string numero)
        {
            Venta oVenta = new Venta();
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT V.IdVenta, U.NombreCompleto, ");
                    query.AppendLine("V.TipoDocumento, V.NumeroDocumento, ");
                    query.AppendLine("V.DocumentoCliente, V.NombreCliente, ");
                    query.AppendLine("V.MontoTotal, V.MontoPago, V.MontoCambio, ");
                    query.AppendLine("CONVERT(CHAR(10),V.FechaRegistro,103) FechaRegistro ");
                    query.AppendLine("FROM Venta V  ");
                    query.AppendLine("INNER JOIN USUARIO U ON U.IdUsuario = V.IdUsuario ");
                    query.AppendLine("WHERE V.NumeroDocumento = @NumeroDocumento");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("NumeroDocumento", numero);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            oVenta = new Venta()
                            {
                                IdVenta = Convert.ToInt32(reader["IdVenta"].ToString()),
                                oUsuario = new Usuario()
                                {
                                    NombreCompleto = reader["NombreCompleto"].ToString()
                                },
                                TipoDocumento = reader["TipoDocumento"].ToString(),
                                NumeroDocumento = reader["NumeroDocumento"].ToString(),
                                DocumentoCliente = reader["DocumentoCliente"].ToString(),
                                NombreCliente = reader["NombreCliente"].ToString(),
                                MontoTotal = Convert.ToDecimal(reader["MontoTotal"].ToString()),
                                MontoPago = Convert.ToDecimal(reader["MontoPago"].ToString()),
                                MontoCambio = Convert.ToDecimal(reader["MontoCambio"].ToString()),
                                FechaRegistro = reader["FechaRegistro"].ToString(),
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    oVenta = new Venta();
                }
            }
            return oVenta;
        }

        public List<Venta> Listar()
        {
            List<Venta> oVenta = new List<Venta>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdVenta, NumeroDocumento, TipoDocumento, NombreCliente, MontoPago,");
                    query.AppendLine("MontoCambio, MontoTotal, CONVERT(CHAR(10),FechaRegistro,103) FechaRegistro");
                    query.AppendLine("from venta");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            oVenta.Add(new Venta()
                            {

                                IdVenta = Convert.ToInt32(reader["IdVenta"].ToString()),
                                TipoDocumento = reader["TipoDocumento"].ToString(),
                                NombreCliente = reader["NombreCliente"].ToString(),
                                NumeroDocumento = reader["NumeroDocumento"].ToString(),
                                MontoTotal = Convert.ToDecimal(reader["MontoTotal"].ToString()),
                                MontoPago = Convert.ToDecimal(reader["MontoPago"].ToString()),
                                MontoCambio = Convert.ToDecimal(reader["MontoCambio"].ToString()),
                                FechaRegistro = reader["FechaRegistro"].ToString(),

                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    oVenta = new List<Venta>();
                }
            }
            return oVenta;
        }
        public List<Venta_Detalle> obtenerDetalle(int id)
        {
            List<Venta_Detalle> ls = new List<Venta_Detalle>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT P.Nombre, DV.PrecioVenta, DV.Cantidad, DV.SubTotal    ");
                    query.AppendLine("FROM DETALLE_Venta DV ");
                    query.AppendLine("INNER JOIN PRODUCTO P ON P.IdProducto = DV.IdProducto  ");
                    query.AppendLine("WHERE DV.IdVenta = @Id ");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("Id", id);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ls.Add(new Venta_Detalle()
                            {
                                oProducto = new Producto()
                                {
                                    Nombre = reader["Nombre"].ToString(),
                                },
                                PrecioVenta = Convert.ToDecimal(reader["PrecioVenta"].ToString()),
                                Cantidad = Convert.ToInt32(reader["Cantidad"].ToString()),
                                SubTotal = Convert.ToDecimal(reader["SubTotal"].ToString()),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    ls = new List<Venta_Detalle>();
                }
            }
            return ls;
        }
    }
}
