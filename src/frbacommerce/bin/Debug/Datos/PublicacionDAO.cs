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



        public static Publicacion insertar(Publicacion publicacion)
        {
            String script;
            try
            { // " + publicacion + "
                script = "INSERT INTO vadem.publicacion VALUES (" + publicacion.Id + "," + publicacion.Cantidad;
                script += "," + publicacion.Estado + ",'" + publicacion.Descripcion + "'," + publicacion.Visibilidad;
                script += ",'" + publicacion.FechaInicio + "','" + publicacion.FechaFin + "'," + publicacion.Precio + ", " + publicacion.Vendedor;
                script += ",'" + publicacion.Tipo + "'," + publicacion.AdmitePreguntas + ")";

                AccesoDatos.Instance.EjecutarScript(script);

                //String scr = "SELECT * FROM vadem.publicacion WHERE IdPublicacion = " + publicacion.Id;
                return obtenerPublicacion(Session.IdUsuario);

                // PublicacionDAO.insertarRubros(rubr, Id);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Publicacion obtenerPublicacion(int p)
        {
            try
            {
                String script = "";
                script = "select P.* ,V.Descripcion as VisibilidadDesc,U.Username " +
                         "from vadem.publicacion P " +
                         "join vadem.visibilidad V on V.IdVisibilidad = P.IdVisibilidad " +
                         "join vadem.rubrosPublicacion R on R.IdPublicacion = P.IdPublicacion " +
                         "join vadem.usuario U on U.IdUsuario = P.IdVendedor " +
                         "where P.IdPublicacion = " + p;

                DataTable dt = AccesoDatos.Instance.EjecutarScript(script);

                Publicacion publicacion = new Publicacion();
                publicacion.Id = Convert.ToInt32(dt.Rows[0]["IdPublicacion"]);
                publicacion.Descripcion = Convert.ToString(dt.Rows[0]["Descripcion"]);
                publicacion.FechaInicio = (DateTime)dt.Rows[0]["FechaInicio"];
                publicacion.FechaFin = (DateTime)dt.Rows[0]["FechaFin"];
                publicacion.Vendedor = Convert.ToInt32(dt.Rows[0]["IdVendedor"]);
                publicacion.VendedorDesc = Convert.ToString(dt.Rows[0]["Username"]);
                publicacion.Precio = Convert.ToInt32(dt.Rows[0]["PrecioInicial"]);
                publicacion.Cantidad = Convert.ToInt32(dt.Rows[0]["Stock"]);
                publicacion.Tipo = Convert.ToString(dt.Rows[0]["Tipo"]);
                publicacion.Visibilidad = Convert.ToInt32(dt.Rows[0]["IdVisibilidad"]);
                publicacion.VisibilidadDesc = Convert.ToString(dt.Rows[0]["VisibilidadDesc"]);
                publicacion.AdmitePreguntas = (bool)dt.Rows[0]["AdmitePreguntas"];

                return publicacion;
            }
            catch (Exception)
            {
                throw;
            }
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

        public static object obtenerPublicacionesActivas(string Descripcion, int Rubro)
        {
            try
            {

                string script = "select P.* from vadem.publicacion P " +
                       " join vadem.visibilidad V on V.IdVisibilidad = P.IdVisibilidad " +
                       "join vadem.rubrosPublicacion R on R.IdPublicacion = P.IdPublicacion " +
                       "where P.idEstado <> 2 " +
                       "/*and (GETDATE() between FechaInicio and FechaFin)*/ " +
                       "and ( (P.Tipo = 'Compra Inmediata' and P.Stock > 0) or P.Tipo ='Subasta' ) " +
                       "and (P.Descripcion like '%'+'" + Descripcion + "'+'%') " +
                       "and (R.IdRubro =" + Rubro + " or " + Rubro + " =0 ) " +
                       "order by V.IdVisibilidad";

                return AccesoDatos.Instance.EjecutarScript(script);


            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }

        }


    }
}
