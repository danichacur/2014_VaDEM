using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaCommerce.Entidades;
using System.Data.SqlClient;

namespace FrbaCommerce.Datos
{
    class RubroDAO
    {
        /// <summary>
        /// Obtiene los rubros en base a un script que recibe por parámetro
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public static List<Rubro> obtenerRubros(String script)
        {
            Rubro rol;
            List<Rubro> rubros;
            DataTable tbl;
            try
            {
                rubros = new List<Rubro>();


                tbl = AccesoDatos.Instance.EjecutarScript(script);

                foreach (DataRow row in tbl.Rows)
                {
                    rol = new Rubro(
                                    Convert.ToInt32(row["IdRubro"]),
                                   (String)row["Descripcion"]
                                 );
                    rubros.Add(rol);
                }

                return rubros;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
