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
    }
}
