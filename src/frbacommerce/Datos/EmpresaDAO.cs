using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Entidades;
using System.Data;

namespace FrbaCommerce.Datos
{
    class EmpresaDAO
    {


        public static Empresa insertar(Empresa empresa)
        {
            String script;
            try
            { // " + empresa + "
                script = "INSERT INTO vadem.empresa VALUES (" + empresa.IdUsuario + ",'" + empresa.RazonSocial;
                script += "','" + empresa.Cuit + "','" + empresa.Telefono + "','" + empresa.Direccion + "', ";
                script += empresa.Numero + "," + (empresa.Piso == "" ? "NULL" : empresa.Piso) + ",";
                script += (empresa.Departamento == "" ? "NULL" : "'" + empresa.Departamento + "'") + ",'" + empresa.Localidad;
                script +=  "','" + empresa.CodigoPostal + "','" + empresa.Cuidad + "','" + empresa.Email;
                script += "'," + (empresa.NombreContacto == "" ? "NULL" : "'" + empresa.NombreContacto + "'") + ",'" + empresa.fechaCreacion + "')";


                AccesoDatos.Instance.EjecutarScript(script);

                return obtenerEmpresa(empresa.IdUsuario);
            }
            catch (Exception)
            {
                throw;
            }
        }



        public static Empresa obtenerEmpresa(int IdUsuario)
        {
            String script;
            DataTable tbl;
            Empresa empresa;
            try
            {
                script = "SELECT *, U.Habilitado AS UsuarioHabilitado, R.Habilitado AS RolHabilitado FROM vadem.empresa E ";
                script += "LEFT JOIN vadem.usuario U ON E.IdEmpresa = U.IdUsuario ";
                script += "LEFT JOIN vadem.rol R ON R.IdRol = U.IdRol ";
                script += "WHERE IdEmpresa = " + IdUsuario;
                tbl = AccesoDatos.Instance.EjecutarScript(script);

                if (tbl.Rows.Count > 0)
                {
                    DataRow row = tbl.Rows[0];

                    empresa = new Empresa(

                                    Convert.ToInt32(row["IdUsuario"]),
                                    (String)row["Username"],
                                    Convert.ToInt32(row["IdRol"]),
                                    (String)row["Descripcion"],
                                    (bool)row["RolHabilitado"],
                                    Convert.ToInt32(row["IntentosFallidos"]),
                                    (bool)row["Bloqueado"],
                                    (bool)row["UsuarioHabilitado"],
                                    (float)Convert.ToDecimal(row["Reputacion"]),
                                    (String)row["RazonSocial"],
                                    (long)Convert.ToDouble(row["CUIT"]),
                                    Convert.ToString(row["Telefono"]),
                                    (String)row["Direccion"],
                                    Convert.ToInt32(row["Numero"]),
                                    Convert.ToString(((row["Piso"] == DBNull.Value) ? "" : row["Piso"])),
                                    (String)((row["Dpto"] == DBNull.Value) ? "" : row["Dpto"]),
                                    (String)row["Localidad"],
                                    Convert.ToInt32(row["CodPostal"]),
                                    (String)row["Ciudad"],
                                    (String)row["Mail"],
                                    (String)row["NombreContacto"],
                                    (DateTime)row["FechaCreacion"]
                                  );
                    return empresa;
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

        internal static object obtenerEmpresas(string clausulaWhere)
        {
            throw new NotImplementedException();
        }
    }
}
