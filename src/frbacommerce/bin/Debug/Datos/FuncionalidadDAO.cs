using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaCommerce.Entidades;
using System.Data.SqlClient;

namespace FrbaCommerce.Datos
{
    class FuncionalidadDAO
    {

        /// <summary>
        /// obtiene todas las funcionalidades.
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public static List<Funcionalidad> obtenerFuncionalidades()
        {
            String script;
            Funcionalidad funcionalidad;
            List<Funcionalidad> funcionalidades;
            DataTable tbl;
            
            try
            {
                funcionalidades = new List<Funcionalidad>();

                script = "SELECT * FROM vadem.funcionalidad";

                tbl = AccesoDatos.Instance.EjecutarScript(script);

                foreach (DataRow row in tbl.Rows)
                {
                    funcionalidad = new Funcionalidad(
                                   Convert.ToInt32(row["IdFuncion"]),
                                   (String)row["Descripcion"]
                                 );
                    funcionalidades.Add(funcionalidad);
                }

                return funcionalidades;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Devuelve la lista de funcionalidades permitidas de acuerdo al rol recibido por parámetro
        /// </summary>
        /// <param name="pIdRol"></param>
        /// <returns></returns>
        public static List<Funcionalidad> obtenerFuncionalidadesPorRol(int pIdRol)
        {
            String script;
            Funcionalidad funcionalidad;
            List<Funcionalidad> funcionalidades;
            DataTable tbl;

            try
            {
                script = "SELECT F.* FROM vadem.funcionalidad F ";
                script += "LEFT JOIN vadem.rolPorFuncionalidad RF ";
                script += "ON RF.IdFuncion = F.IdFuncion ";
                script += "WHERE RF.IdRol = ";
                script += Convert.ToString(pIdRol);
                script += "ORDER BY F.IdFuncion";


                tbl = AccesoDatos.Instance.EjecutarScript(script);

                funcionalidades = new List<Funcionalidad>();

                foreach (DataRow row in tbl.Rows)
                {
                    funcionalidad = new Funcionalidad(
                                   Convert.ToInt32(row["IdFuncion"]),
                                   (String)row["Descripcion"]
                                 );
                    funcionalidades.Add(funcionalidad);
                }


                return funcionalidades;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                funcionalidades = null;
            }
        }
    }
}
