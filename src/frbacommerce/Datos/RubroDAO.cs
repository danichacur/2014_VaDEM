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
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
        }
       

        /*
        public static DataTable obtenerRubros(int idRubro, String descripcion)
        {
            SqlParameter sqlParamIdRubro;
            SqlParameter sqlParamDescripcion;
        
            try
            {
                sqlParamIdRubro = new SqlParameter("@IdRubro", SqlDbType.Int);
                sqlParamIdRubro.Value = idRubro;

                sqlParamDescripcion = new SqlParameter("@Descripcion", SqlDbType.VarChar);
                sqlParamDescripcion.Size = 255;
                sqlParamDescripcion.Value = descripcion;

                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = sqlParamIdRubro;
                parametros[1] = sqlParamDescripcion;

                DataTable tbl = AccesoDatos.Instance.ObtenerDatosComoDataTable("spObtenerRubros", parametros);
                return tbl;
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
        }
        */
    }
}
