using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Entidades;
using System.Data;
using System.Data.SqlClient;

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



        public static Publicacion insertar(Publicacion publicacion)
        {
            
            try
            { // " + publicacion + "


                SqlParameterCollection colparam;// = new SqlParameterCollection();
                
                SqlParameter stock = new SqlParameter();
                stock.ParameterName = "@STOCK";
                stock.SqlDbType = SqlDbType.Int;
                stock.Value = publicacion.Cantidad;


               // script += "," + publicacion.Estado + ",'" + publicacion.Descripcion + "'," + publicacion.Visibilidad;
                //script += ",'" + ConfigurationManager.AppSettings["DateTimeNow"] + "'," + publicacion.Precio + ", " + publicacion.Vendedor;
                //script += ",'" + publicacion.Tipo + "'," + publicacion.AdmitePreguntas + ")";

                //AccesoDatos.Instance.EjecutarScript(script);

                return obtenerPublicacion(Session.IdUsuario);

                // PublicacionDAO.insertarRubros(rubr, Id);

            }
            catch (Exception)
            {
                throw;
            }
        }

        private static Publicacion obtenerPublicacion(int p)
        {
            throw new NotImplementedException();
        }

        public static object insertarRubros(List<Rubro> rubros, int idPublicacion)
        {
               
            try
            {
                String script = "";
             foreach( Rubro miRubro in rubros)
             {
                 script += "INSERT INTO vadem.rubrosPublicacion VALUES (" + idPublicacion + " , " + miRubro + ")";
             }
              
              return AccesoDatos.Instance.EjecutarScript(script);

            }
            catch (Exception)
            {
                throw;
            }


        }


    }
}
