using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaCommerce.Entidades;
using System.Data.SqlClient;
using FrbaCommerce.Componentes_Comunes;

namespace FrbaCommerce.Datos
{
    class ClienteDAO
    {
        /// <summary>
        /// obtiene los clientes en base a un script que recibe por parámetro.
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public static List<Cliente> obtenerClientes(String clausulaWhere)
        {
            Cliente cliente;
            List<Cliente> clientes;
            DataTable tbl;
            try
            {

                String script = "SELECT * FROM vadem.cliente C LEFT JOIN vadem.usuario U ON C.IdCliente = U.IdUsuario ";
                script += "LEFT JOIN vadem.rolesPorUsuario RU ON RU.IdUsuario = U.IdUsuario ";
                script += clausulaWhere;

                clientes = new List<Cliente>();
            
                tbl = AccesoDatos.Instance.EjecutarScript(script);

                foreach (DataRow row in tbl.Rows) {
                    cliente = new Cliente(
                                    Convert.ToInt32(row["IdUsuario"]),
                                    (String)row["Username"],
                                    Convert.ToInt32(row["IdRol"]),
                                    "",
                                    true,
                                    Convert.ToInt32(row["IntentosFallidos"]),
                                    Convert.ToInt32(row["Bloqueado"]) == 1 ? true : false,
                                    Convert.ToInt32(row["Habilitado"]) == 1 ? true : false,
                                    (float)Convert.ToDecimal(row["Reputacion"]),
                                    (long)Convert.ToDouble(row["Documento"]),
                                    (String)row["TipoDocumento"],
                                    (String)row["Nombre"],
                                    (String)row["Apellido"],
                                    (String)row["Mail"],
                                    (String)row["Telefono"],
                                    (String)row["Direccion"],
                                    Convert.ToInt32(row["Numero"]),
                                    Convert.ToString(((row["Piso"] == DBNull.Value) ? "" : row["Piso"])),
                                    (String)((row["Dpto"] == DBNull.Value) ? "" : row["Dpto"]),
                                    (String)row["Localidad"],
                                    Convert.ToInt32(row["CodPostal"]),
                                    (DateTime)row["FechaNacimiento"],
                                    (long)Convert.ToDouble(row["CUIL"])
                                  );
                    clientes.Add(cliente);
                }

                return clientes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Cliente insertar(Cliente cliente)
        {
            String script;
            try
            { // " + cliente + "
                script = "INSERT INTO vadem.cliente VALUES (" + cliente.IdUsuario + "," + cliente.Documento;
                script += ",'" + cliente.TipoDocumento + "','" + cliente.Nombre + "','" + cliente.Apellido;
                script += "','" + cliente.Email + "','" + cliente.Telefono + "','" + cliente.Direccion + "', " + cliente.Numero;
                script += "," + (cliente.Piso == "" ? "NULL" : cliente.Piso) + "," + (cliente.Departamento == "" ? "NULL" : "'" + cliente.Departamento + "'") + ",'" + cliente.Localidad + "','" + cliente.CodigoPostal;
                script += "','" + cliente.FechaNacimiento + "','" + cliente.Cuil + "')";
                
                AccesoDatos.Instance.EjecutarScript(script);

                return obtenerCliente(cliente.IdUsuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Cliente modificar(Cliente cliente)
        {
            String script;
            try
            { // " + cliente + "
                script = "UPDATE vadem.cliente ";
                script += "SET [Documento] = " + cliente.Documento + " ";
                script += ",[TipoDocumento] = '" + cliente.TipoDocumento + "' ";
                script += ",[Nombre] = '" + cliente.Nombre + "' ";
                script += ",[Apellido] = '" + cliente.Apellido + "' ";
                script += ",[Mail] = '" + cliente.Email + "' ";
                script += ",[Telefono] = '" + cliente.Telefono + "' ";
                script += ",[Direccion] = '" + cliente.Direccion + "' ";
                script += ",[Numero] = " + cliente.Numero + " ";
                script += ",[Piso] = " + (cliente.Piso == "" ? "NULL" : cliente.Piso) + " ";
                script += ",[Dpto] = " + (cliente.Departamento == "" ? "NULL" : "'" + cliente.Departamento + "'") + " ";
                script += ",[Localidad] = '" + cliente.Localidad + "' ";
                script += ",[CodPostal] = '" + cliente.CodigoPostal + "' ";
                script += ",[FechaNacimiento] = '" + cliente.FechaNacimiento + "' ";
                script += ",[CUIL] = " + cliente.Cuil + " ";
                script += "WHERE [IdCliente] = " + cliente.IdUsuario;


                AccesoDatos.Instance.EjecutarScript(script);

                return obtenerCliente(cliente.IdUsuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Cliente obtenerCliente(int IdUsuario)
        {
            String script;
            DataTable tbl;
            Cliente cliente;
            try
            {
                script = "SELECT * FROM vadem.cliente C LEFT JOIN vadem.usuario U ON C.IdCliente = U.IdUsuario ";
                script += "LEFT JOIN vadem.rolesPorUsuario RU ON RU.IdUsuario = U.IdUsuario WHERE IdCliente = " + IdUsuario;
                tbl = AccesoDatos.Instance.EjecutarScript(script);

                if (tbl.Rows.Count > 0)
                {
                    DataRow row = tbl.Rows[0];

                    cliente = new Cliente(
                                    Convert.ToInt32(row["IdUsuario"]),
                                    (String)row["Username"],
                                    Convert.ToInt32(row["IdRol"]),
                                    "",
                                    true,
                                    Convert.ToInt32(row["IntentosFallidos"]),
                                    Convert.ToInt32(row["Bloqueado"]) == 1 ? true : false,
                                    Convert.ToInt32(row["Habilitado"]) == 1 ? true : false,
                                    (float)Convert.ToDecimal(row["Reputacion"]),
                                    (long)Convert.ToDouble(row["Documento"]),
                                    (String)row["TipoDocumento"],
                                    (String)row["Nombre"],
                                    (String)row["Apellido"],
                                    (String)row["Mail"],
                                    (String)row["Telefono"],
                                    (String)row["Direccion"],
                                    Convert.ToInt32(row["Numero"]),
                                    Convert.ToString(((row["Piso"] == DBNull.Value) ? "" : row["Piso"])),
                                    (String)((row["Dpto"] == DBNull.Value) ? "" : row["Dpto"]),
                                    (String)row["Localidad"],
                                    Convert.ToInt32(row["CodPostal"]),
                                    (DateTime)row["FechaNacimiento"],
                                    (long)Convert.ToDouble(row["CUIL"])
                                  );
                    return cliente;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Usuario obtenerDatosUsuarioDesdeCliente(Cliente cliente)
        {
            String script;
            DataTable tbl;
            Usuario usr;
            try
            {
                script = "SELECT U.* FROM vadem.usuario U";
                script += " LEFT JOIN vadem.cliente C";
                script += " ON C.IdCliente = U.IdUsuario";
                script += " WHERE C.TipoDocumento = '" + cliente.TipoDocumento + "'";
                script += " AND C.Documento = " + cliente.Documento;

                tbl = AccesoDatos.Instance.EjecutarScript(script);

                if (tbl.Rows.Count > 0)
                {
                    usr = new Usuario(Convert.ToInt32(tbl.Rows[0]["IdUsuario"]),
                                        (String)tbl.Rows[0]["Username"],
                                        Convert.ToInt32(tbl.Rows[0]["IntentosFallidos"]),
                                        Convert.ToInt32(tbl.Rows[0]["Bloqueado"]) == 1 ? true : false,
                                        Convert.ToInt32(tbl.Rows[0]["Habilitado"]) == 1 ? true : false,
                                        (float)Convert.ToDecimal(tbl.Rows[0]["Reputacion"])
                                        );

                    return usr;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}