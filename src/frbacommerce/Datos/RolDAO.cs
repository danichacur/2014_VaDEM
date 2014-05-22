using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaCommerce.Entidades;
using System.Data.SqlClient;

namespace FrbaCommerce.Datos
{
    class RolDAO
    {
        /// <summary>
        /// obtiene los roles en base a un script que recibe por parámetro.
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public static List<Rol> obtenerRoles(String clausulaWhere)
        {
            Rol rol;
            List<Rol> roles;
            DataTable tblRoles, tblFuncionalidades;
            List<Funcionalidad> listaFuncionalidades;
            try
            {

                String script = "SELECT * FROM vadem.rol ";
                script += clausulaWhere;

                roles = new List<Rol>();
                

                tblRoles = AccesoDatos.Instance.EjecutarScript(script);

                foreach (DataRow datosRol in tblRoles.Rows) {

                    script = "SELECT * FROM vadem.funcionalidad F LEFT JOIN vadem.rolPorFuncionalidad RF ON ";
                    script += "RF.IdFuncion = F.IdFuncion ";
                    script += "WHERE IdRol = " + datosRol["IdRol"];
                    tblFuncionalidades = AccesoDatos.Instance.EjecutarScript(script);
                    listaFuncionalidades = new List<Funcionalidad>();
                    foreach (DataRow datosFuncionalidad in tblFuncionalidades.Rows)
                    {
                        listaFuncionalidades.Add(new Funcionalidad(Convert.ToInt16(datosFuncionalidad["IdFuncion"]), 
                            (String)datosFuncionalidad["Descripcion"]));
                    }

                    
                     rol = new Rol(  
                                    Convert.ToInt32(datosRol["IdRol"]),
                                    (String)datosRol["Descripcion"],
                                    Convert.ToInt32(datosRol["Habilitado"]) == 1 ? true : false,
                                    listaFuncionalidades
                                  );
                     roles.Add(rol);
                }

                return roles;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Rol obtenerRol(int idRol)
        {
            String script;
            DataTable tblRoles;
            try
            {
                script = "SELECT * FROM vadem.rol WHERE IdRol = " + idRol;
                tblRoles = AccesoDatos.Instance.EjecutarScript(script);

                if (tblRoles.Rows.Count > 0)
                    return new Rol(
                                        Convert.ToInt32(tblRoles.Rows[0]["IdRol"]),
                                        (String)tblRoles.Rows[0]["Descripcion"],
                                        Convert.ToInt32(tblRoles.Rows[0]["Habilitado"]) == 1 ? true : false
                                      );
                else
                    return null;

            }
            catch (Exception)
            {   
                throw;
            }
        }

        /// <summary>
        /// obtiene todos los roles habilitados 
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public static List<Rol> obtenerRolesHabilitados()
        {
            String script;
            Rol rol;
            List<Rol> roles;
            DataTable tbl;
            try
            {
                roles = new List<Rol>();

                script = "SELECT * FROM vadem.rol WHERE Habilitado = 1";

                tbl = AccesoDatos.Instance.EjecutarScript(script);

                foreach (DataRow row in tbl.Rows)
                {
                    rol = new Rol(
                                   Convert.ToInt32(row["IdRol"]),
                                   (String)row["Descripcion"],
                                   Convert.ToInt32(row["Habilitado"]) == 1 ? true : false
                                 );
                    roles.Add(rol);
                }

                return roles;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Ejecuta el script parámetro.
        /// </summary>
        /// <param name="script"></param>
        public static void ejecutar(String script)
        {
            try
            {
                AccesoDatos.Instance.EjecutarScript(script);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
       