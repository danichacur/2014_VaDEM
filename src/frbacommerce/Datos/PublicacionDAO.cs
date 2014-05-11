using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Entidades;
using System.Data;

namespace FrbaCommerce.Datos
{
    class PublicacionDAO
    {

        public static DataTable obtenerEstados(String script)
        {
            //EstadoPublicacion estado;
            //List<EstadoPublicacion> estados;
            //DataTable tbl;
            try
            {
                //estados = new List<EstadoPublicacion>();



                return AccesoDatos.Instance.EjecutarScript(script);

                //foreach (DataRow row in tbl.Rows)
                //{
                //    estado = new EstadoPublicacion(
                //                   Convert.ToInt32(row["IdEstado"]),
                //                   (String)row["Descripcion"]
                //                 );
                //    estados.Add(estado);
                //}

                //return estados;
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
        }




        public static DataTable obtenerVisualizacion(string script)
        {
            try
            {
                
                return AccesoDatos.Instance.EjecutarScript(script);

              
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
       

        }

        public static object obtenerPublicaciones(string script)
        {
            try
            {

                return AccesoDatos.Instance.EjecutarScript(script);


            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
       
        }
    }
}
