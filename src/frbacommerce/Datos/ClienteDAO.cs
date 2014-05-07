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
        public static List<Cliente> obtenerClientes(String script)
        {
            Cliente cliente;
            List<Cliente> clientes;
            DataTable tbl;
            try
            {
                clientes = new List<Cliente>();
                

                tbl = AccesoDatos.Instance.EjecutarScript(script);

                foreach (DataRow row in tbl.Rows) {
                    cliente = new Cliente(
                                    (long)Convert.ToDouble(row["DNI"]),
                                    (String)row["TipoDocumento"],
                                    (String)row["Nombre"],
                                    (String)row["Apellido"],
                                    (String)row["Mail"],
                                    (String)row["Telefono"],
                                    (String)row["Direccion"],
                                    (String)((row["Piso"] == DBNull.Value) ? "": row["Piso"]),
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
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
        }
    }
}