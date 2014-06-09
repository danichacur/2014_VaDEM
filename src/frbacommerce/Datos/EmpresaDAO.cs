using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Entidades;
using System.Data;
using FrbaCommerce.Componentes_Comunes;

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
                script += empresa.Numero + "," + (empresa.Piso == "" ? "NULL" : "'" +empresa.Piso + "'") + ",";
                script += (empresa.Departamento == "" ? "NULL" : "'" + empresa.Departamento + "'") + ",'" + empresa.Localidad;
                script +=  "','" + empresa.CodigoPostal + "','" + empresa.Cuidad + "','" + empresa.Email;
                script += "'," + (empresa.NombreContacto == "" ? "NULL" : "'" + empresa.NombreContacto + "'") + ",'" + Componentes_Comunes.Metodos_Comunes.localDateToSQLDate(empresa.fechaCreacion) + "')";


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
                script += "LEFT JOIN vadem.rolesPorUsuario RU ON RU.IdUsuario = U.IdUsuario ";
                script += "LEFT JOIN vadem.rol R ON R.IdRol = RU.IdRol ";
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
                                    (String)row["CUIT"],
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

        public static List<Empresa> obtenerEmpresas(string clausulaWhere)
        {
            try
            {
                Empresa empresa;
                List<Empresa> empresas;
                DataTable tbl;
       
                    String script = "SELECT * FROM vadem.empresa E LEFT JOIN vadem.usuario U ON E.IdEmpresa = U.IdUsuario ";
                script += "LEFT JOIN vadem.rolesPorUsuario RU ON RU.IdUsuario = U.IdUsuario ";
                    script += clausulaWhere;

                    empresas = new List<Empresa>();

                    tbl = AccesoDatos.Instance.EjecutarScript(script);

                    foreach (DataRow row in tbl.Rows)
                    {
                        empresa = new Empresa(
                                        Convert.ToInt32(row["IdUsuario"]),
                                        (String)row["Username"],
                                        Convert.ToInt32(row["IdRol"]),
                                        "",
                                        true,
                                        Convert.ToInt32(row["IntentosFallidos"]),
                                        (bool)row["Bloqueado"],
                                        (bool)row["Habilitado"],
                                        (float)Convert.ToDecimal(row["Reputacion"]),
                                        (String)row["RazonSocial"],
                                        (String)row["CUIT"],
                                        Convert.ToString(row["Telefono"]),
                                        (String)row["Direccion"],
                                        Convert.ToInt32(row["Numero"]),
                                        Convert.ToString(((row["Piso"] == DBNull.Value) ? "" : row["Piso"])),
                                        (String)((row["Dpto"] == DBNull.Value) ? "" : row["Dpto"]),
                                        Convert.ToString(((row["Localidad"] == DBNull.Value) ? "" : row["Localidad"])),
                                        Convert.ToInt32(row["CodPostal"]),
                                        Convert.ToString(((row["Ciudad"] == DBNull.Value) ? "" : row["Ciudad"])),
                                        (String)row["Mail"],
                                        Convert.ToString(((row["NombreContacto"] == DBNull.Value) ? "" : row["NombreContacto"])),
                                        (DateTime)row["FechaCreacion"]
                                      );
                        empresas.Add(empresa);
                    }

                    return empresas;
           }
            catch (Exception)
            {   
                throw;
            }
        }

        public static Empresa modificar(Empresa empresa)
        {
            String script;
            try
            { // " + empresa + "

                script = "UPDATE vadem.empresa ";
                script += "SET [RazonSocial] = '" + empresa.RazonSocial + "' ";
                script += ",[CUIT] = '" + empresa.Cuit+ "' ";
                script += ",[Telefono] = '" + empresa.Telefono+ "' ";
                script += ",[Direccion] = '" + empresa.Direccion+ "' ";
                script += ",[Numero] = '" + empresa.Numero+ "' ";
                script += ",[Piso] = '" + empresa.Piso + "' ";
                script += ",[Dpto] = '" + empresa.Departamento+ "' ";
                script += ",[Localidad] = '" + empresa.Localidad+ "' ";
                script += ",[CodPostal] = '" + empresa.CodigoPostal+ "' ";
                script += ",[Ciudad] = '" + empresa.Cuidad + "' ";
                script += ",[Mail] = '" + empresa.Email+ "' ";
                script += ",[NombreContacto] = '" + empresa.NombreContacto+ "' ";
                script += ",[FechaCreacion] = '" + Metodos_Comunes.localDateToSQLDate(empresa.fechaCreacion) + "' ";
                script += "WHERE [IdEmpresa] = '" + empresa.IdUsuario+ "' ";

                AccesoDatos.Instance.EjecutarScript(script);

                return obtenerEmpresa(empresa.IdUsuario);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
