using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaCommerce.Entidades;
using System.Data.SqlClient;

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

                String script = "SELECT * FROM vadem.cliente ";
                script += clausulaWhere;

                clientes = new List<Cliente>();
            
                tbl = AccesoDatos.Instance.EjecutarScript(script);

                foreach (DataRow row in tbl.Rows) {
                    cliente = new Cliente(
                                    (long)Convert.ToDouble(row["Documento"]),
                                    (String)row["TipoDocumento"],
                                    (String)row["Nombre"],
                                    (String)row["Apellido"],
                                    (String)row["Mail"],
                                    (String)row["Telefono"],
                                    (String)row["Direccion"],
                                    Convert.ToInt32(row["Numero"]),
                                    (String)((row["Piso"] == DBNull.Value) ? "": row["Piso"].ToString()),
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

        public static Cliente obtenerCliente(int IdUsuario)
        {
            String script;
            DataTable tbl;
            Cliente cliente;
            try
            {
                script = "SELECT * FROM vadem.cliente C LEFT JOIN vadem.usuario U ON C.IdCliente = U.IdUsuario WHERE IdCliente = " + IdUsuario;
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
    }
}