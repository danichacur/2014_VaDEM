using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Entidades;
using System.Data;

namespace FrbaCommerce.Datos
{
    class UsuarioDAO
    {
        /// <summary>
        /// En base al username obtiene el objeto usuario
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static Usuario obtenerUsuarioPorUsername(string username) {
            string script;
            DataTable tbl;
            Usuario usr;
            try
            {
                script = "SELECT TOP 1 U.IdUsuario, U.Username, U.Password, U.IdRol, U.IntentosFallidos, U.Bloqueado, ";
                script += "U. Habilitado, U.Reputacion, R.Descripcion AS Rol_Descripcion, R.Habilitado AS Rol_Habilitado ";
                script += "FROM vadem.usuario U LEFT JOIN vadem.rol R ON R.IdRol = U.IdRol ";
                script += "WHERE username = '" + username + "'";

                tbl = AccesoDatos.Instance.EjecutarScript(script);
                if (tbl.Rows.Count > 0)
                {
                    usr = new Usuario(Convert.ToInt32(tbl.Rows[0]["IdUsuario"]),
                                        (String)tbl.Rows[0]["Username"],
                                        Convert.ToInt32(tbl.Rows[0]["IdRol"]),
                                        (String)tbl.Rows[0]["Rol_Descripcion"],
                                        Convert.ToInt32(tbl.Rows[0]["Rol_Habilitado"]) == 1 ? true : false,
                                        Convert.ToInt32(tbl.Rows[0]["IntentosFallidos"]),
                                        Convert.ToInt32(tbl.Rows[0]["Bloqueado"]) == 1 ? true : false,
                                        Convert.ToInt32(tbl.Rows[0]["Habilitado"]) == 1 ? true : false,
                                        (float)Convert.ToDecimal(tbl.Rows[0]["Reputacion"])
                                        );

                    return usr;
                }
                else {
                    return null;
                }
            }
            catch (Exception)
            {   
                throw;
            }
        }

        public static Usuario insertar(Usuario usr)
        {
            String script;
            try
            {
                script = "INSERT INTO vadem.usuario VALUES ( '" + usr.Username + "', '";
                script += usr.PasswordEncriptada + "'," + usr.Rol.Id + ",0,0,1,0)";

                AccesoDatos.Instance.EjecutarScript(script);

                return obtenerUsuarioPorUsername(usr.Username);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Se utiliza este método cuando se tiene que hacer un rollback. No se debe usar para las bajas lógicas
        /// </summary>
        /// <param name="usr"></param>
        public static void eliminar(Usuario usr)
        {
            String script;
            try
            {
                script = "DELETE FROM vadem.usuario WHERE IdUsuario = " + usr.IdUsuario;
                
                AccesoDatos.Instance.EjecutarScript(script);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
