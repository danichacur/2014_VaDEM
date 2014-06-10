using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FrbaCommerce.Datos
{
    class LoginDAO
    {

        /// <summary>
        /// Valida que el usuario exista y corresponda con la password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="passwordEncriptada"></param>
        /// <returns></returns>
        public static Boolean validaUsuarioPassword(string username, string passwordEncriptada) {
            String script;
            DataTable tbl;
            try
            {
                script = "SELECT TOP 1 1 ";
                script += "FROM vadem.usuario ";
                script += "WHERE username = '" + username + "' AND password = '" + passwordEncriptada + "'";

                tbl = AccesoDatos.Instance.EjecutarScript(script);

                return tbl.Rows.Count > 0;
            }
            catch (Exception)
            {   
                throw;
            }
        }

        public static bool esPrimerLoggeo(int IdUsuario)
        {
            String script;
            DataTable tbl;
            try
            {
                script = "SELECT TOP 1 * ";
                script += "FROM vadem.usuario ";
                script += "WHERE IdUsuario = " + IdUsuario + " ";

                tbl = AccesoDatos.Instance.EjecutarScript(script);

                return Convert.ToInt32(tbl.Rows[0]["CantidadLoggeos"]) == 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
