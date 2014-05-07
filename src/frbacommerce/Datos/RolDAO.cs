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
                throw new Exception("Error " + ex.Message);
            }
        }
    }
}
        /*
        public static DataTable obtenerRoles(int idRol, String descripcion, int habilitado)
        {
            SqlParameter sqlParamIdRol;
            SqlParameter sqlParamDescripcion;
            SqlParameter sqlParamHabilitado;

            try
            {
                sqlParamIdRol = new SqlParameter("@IdRol", SqlDbType.Int);
                sqlParamIdRol.Value = idRol;

                sqlParamDescripcion = new SqlParameter("@Descripcion", SqlDbType.VarChar);
                sqlParamDescripcion.Size = 255;
                sqlParamDescripcion.Value = descripcion;

                sqlParamHabilitado = new SqlParameter("@habilitado", SqlDbType.Int);
                sqlParamHabilitado.Value = habilitado;

                SqlParameter[] parametros = new SqlParameter[3];
                parametros[0] = sqlParamIdRol;
                parametros[1] = sqlParamDescripcion;
                parametros[2] = sqlParamHabilitado;

                DataTable tbl = AccesoDatos.Instance.ObtenerDatosComoDataTable("spObtenerRoles", parametros);
                return tbl;
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
        }
        */
        
