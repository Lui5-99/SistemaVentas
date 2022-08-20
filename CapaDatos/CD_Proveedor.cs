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
    public class CD_Proveedor
    {
        public List<Proveedor> Listar()
        {
            List<Proveedor> ls = new List<Proveedor>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT IdProveedor, Documento, RazonSocial, Correo, Telefono, Estado FROM Proveedor");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ls.Add(new Proveedor()
                                {
                                    IdProveedor = Convert.ToInt32(reader["IdProveedor"]),
                                    Documento = reader["Documento"].ToString(),
                                    RazonSocial = reader["RazonSocial"].ToString(),
                                    Correo = reader["Correo"].ToString(),
                                    Telefono = reader["Telefono"].ToString(),
                                    Estado = Convert.ToBoolean(reader["Estado"]),
                                });
                            }
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
        public int Registrar(Proveedor oProveedor, out string Mensaje)
        {
            //@Documento varchar(50),
            //@RazonSocial varchar(50),
            //@Correo varchar(50),
            //@Telefono varchar(50),
            //@Estado bit,
            //@Resultado int output,
            //@Mensaje varchar(500) output
            int idProveedorgenerado = 0;
            Mensaje = String.Empty;
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarProveedor", oConexion);
                    cmd.Parameters.AddWithValue("Documento", oProveedor.Documento);
                    cmd.Parameters.AddWithValue("RazonSocial", oProveedor.RazonSocial);
                    cmd.Parameters.AddWithValue("Correo", oProveedor.Correo);
                    cmd.Parameters.AddWithValue("Telefono", oProveedor.Telefono);
                    cmd.Parameters.AddWithValue("Estado", oProveedor.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    idProveedorgenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                    oConexion.Close();
                }
            }
            catch (Exception ex)
            {
                idProveedorgenerado = 0;
                Mensaje = ex.Message;
            }
            return idProveedorgenerado;
        }
        public bool Editar(Proveedor oProveedor, out string Mensaje)
        {
            //@IdProveedor int,
            //@Documento varchar(50),
            //@RazonSocial varchar(50),
            //@Correo varchar(50),
            //@Telefono varchar(50),
            //@Estado bit,
            //@Resultado bit output,
            //@Mensaje varchar(500) output
            bool respuesta = false;
            Mensaje = String.Empty;
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_ModificarProveedor", oConexion);
                    cmd.Parameters.AddWithValue("IdProveedor", oProveedor.IdProveedor);
                    cmd.Parameters.AddWithValue("Documento", oProveedor.Documento);
                    cmd.Parameters.AddWithValue("RazonSocial", oProveedor.RazonSocial);
                    cmd.Parameters.AddWithValue("Correo", oProveedor.Correo);
                    cmd.Parameters.AddWithValue("Telefono", oProveedor.Telefono);
                    cmd.Parameters.AddWithValue("Estado", oProveedor.Estado);
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
        public bool Eliminar(Proveedor oProveedor, out string Mensaje)
        {
            // @IdProveedor int,
            // @Respuesta bit output,
            // @Mensaje varchar(500) output
            bool respuesta = false;
            Mensaje = String.Empty;
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarProveedor", oConexion);
                    cmd.Parameters.AddWithValue("IdProveedor", oProveedor.IdProveedor);
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
