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
        public static List<Rol> obtenerRoles(String script)
        {
            Rol rol;
            List<Rol> roles;
            DataTable tbl;
            try
            {
                roles = new List<Rol>();
                

                tbl = AccesoDatos.Instance.EjecutarScript(script);

                foreach (DataRow row in tbl.Rows) {
                     rol = new Rol(  
                                    Convert.ToInt32(row["IdRol"]),
                                    (String)row["Descripcion"],
                                    Convert.ToInt32(row["Habilitado"]) == 1 ? true : false
                                  );
                     roles.Add(rol);
                }

                return roles;
            }
            catch (Exception ex)
            {
                throw ex;
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
       