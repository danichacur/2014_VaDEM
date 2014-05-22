using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Entidades;
using System.Data;

namespace FrbaCommerce.Datos
{
    class VisibilidadDAO
    {

        /// <summary>
        /// obtiene las visibilidades en base a un script que recibe por parámetro.
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public static List<Visibilidad> obtenerVisibilidades(String clausulaWhere)
        {
            Visibilidad visib;
            List<Visibilidad> visibilidadeses;
            DataTable tblVisibilidades;
            try
            {

                String script = "SELECT * FROM vadem.visibilidad ";
                script += clausulaWhere;

                visibilidadeses = new List<Visibilidad>();
                tblVisibilidades = AccesoDatos.Instance.EjecutarScript(script);

                foreach (DataRow row in tblVisibilidades.Rows)
                {
                    visib = new Visibilidad(
                                   Convert.ToInt32(row["IdVisibilidad"]),
                                   (String)row["Descripcion"],
                                   (float)Convert.ToDecimal(row["CostoFijo"]),
                                   (float)Convert.ToDecimal(row["Comision"]),
                                   Convert.ToInt32(row["LimiteSinBonificar"]),
                                   Convert.ToInt32(row["DiasVigencia"]),
                                   Convert.ToInt32(row["Habilitado"]) == 1 ? true : false
                                 );
                    visibilidadeses.Add(visib);
                    
                }

                return visibilidadeses;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static Visibilidad obtenerVisibilidad(int pIdVisibilidad)
        {
            String script;
            DataTable tblVisibilidades;
            DataRow filaVisib;
            Visibilidad visibilidad;
            try
            {
                script = "SELECT * FROM vadem.visibilidad ";
                script += "WHERE IdVisibilidad = " + pIdVisibilidad;

                tblVisibilidades = AccesoDatos.Instance.EjecutarScript(script);

                if (tblVisibilidades.Rows.Count > 0)
                    filaVisib = tblVisibilidades.Rows[0];
                else
                    return null;

                visibilidad = new Visibilidad(
                               Convert.ToInt32(filaVisib["IdVisibilidad"]),
                               (String)filaVisib["Descripcion"],
                               (float)Convert.ToDecimal(filaVisib["CostoFijo"]),
                               (float)Convert.ToDecimal(filaVisib["Comision"]),
                               Convert.ToInt32(filaVisib["LimiteSinBonificar"]),
                               Convert.ToInt32(filaVisib["DiasVigencia"]),
                               Convert.ToInt32(filaVisib["Habilitado"]) == 1 ? true : false
                             );

                return visibilidad;
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
