﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaEntidad;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class CD_Negocio
    {
        public Negocio obtenerDatos()
        {
            Negocio oNegocio = new Negocio();
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    oConexion.Open();
                    string query = "Select IdNegocio, Nombre, RFC, Direccion, Impresora from Negocio where IdNegocio = 1";
                    SqlCommand cmd = new SqlCommand(query, oConexion);
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            oNegocio = new Negocio()
                            {
                                IdNegocio = Convert.ToInt32(reader["IdNegocio"].ToString()),
                                Nombre = reader["Nombre"].ToString(),
                                RFC = reader["RFC"].ToString(),
                                Direccion = reader["Direccion"].ToString(),
                                Impresora = reader["Impresora"].ToString(),
                            };
                        }
                    }
                    oConexion.Close();
                }
            }
            catch(Exception ex)
            {
                oNegocio = new Negocio();
            }
            return oNegocio;
        }

        public bool GuardarDatos(Negocio oNegocio, out string Mensaje)
        {
            Mensaje = string.Empty;
            bool respuesta = true;
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    oConexion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE NEGOCIO SET Nombre = @Nombre, ");
                    query.AppendLine("RFC = @RFC, ");
                    query.AppendLine("DIRECCION = @DIRECCION ");
                    query.AppendLine("WHERE IdNegocio = 1 ");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("@Nombre", oNegocio.Nombre);
                    cmd.Parameters.AddWithValue("@RFC", oNegocio.RFC);
                    cmd.Parameters.AddWithValue("@DIRECCION", oNegocio.Direccion);
                    cmd.CommandType = CommandType.Text;

                    if(cmd.ExecuteNonQuery() < 1)
                    {
                        Mensaje = "No se pudieron guaradar los datos\n";
                        respuesta = false;
                    }
                    oConexion.Close();
                }
            }
            catch (Exception ex)
            {
                Mensaje += ex.Message + "\n";
                respuesta = false;
            }
            return respuesta;
        }
        public bool GuardarImpresora(Negocio oNegocio, out string Mensaje)
        {
            Mensaje = string.Empty;
            bool respuesta = true;
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    oConexion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE NEGOCIO SET Impresora = @Impresora ");
                    query.AppendLine("WHERE IdNegocio = 1 ");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("@Impresora", oNegocio.Impresora);
                    cmd.CommandType = CommandType.Text;

                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        Mensaje = "No se pudieron guaradar los datos\n";
                        respuesta = false;
                    }
                    oConexion.Close();
                }
            }
            catch (Exception ex)
            {
                Mensaje += ex.Message + "\n";
                respuesta = false;
            }
            return respuesta;
        }

        public byte[] ObtenerLogo(out bool Obtenido)
        {
            Obtenido = true;
            byte[] LogoBytes = new byte[0];
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    oConexion.Open();
                    string query = "Select Logo from Negocio where IdNegocio = 1";
                    SqlCommand cmd = new SqlCommand(query, oConexion);
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LogoBytes = (byte[])reader["Logo"];
                        }
                    }
                    oConexion.Close();
                }
            }
            catch (Exception ex)
            {
               LogoBytes = new byte[0];
            }
            return LogoBytes;
        }

        public bool actualizarLogo(byte[] image, out string Mensaje)
        {
            Mensaje = string.Empty;
            bool respuesta = true;
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    oConexion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE NEGOCIO SET Logo = @imagen ");
                    query.AppendLine("WHERE IdNegocio = 1 ");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("@imagen", image);
                    cmd.CommandType = CommandType.Text;

                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        Mensaje = "No se pudo actualizar el logo\n";
                        respuesta = false;
                    }
                    oConexion.Close();
                }
            }
            catch (Exception ex)
            {
                Mensaje += ex.Message + "\n";
                respuesta = false;
            }
            return respuesta;
        }
    }
}
