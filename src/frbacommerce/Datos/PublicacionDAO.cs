using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Entidades;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

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

       // public static object obtenerPublicaciones(int tipo, int estado, int visibilidad, DateTime fecha, string descripcion)
         public static object obtenerPublicaciones(string clausulaWhere)
       
        {
            try
            {

                String script = "SELECT(SELECT Descripcion FROM vadem.estado E WHERE E.IdEstado = P.IdEstado) AS 'Estado',";
                script += "Descripcion, PrecioInicial, Stock, Tipo, ";
                script += "(SELECT Descripcion FROM vadem.visibilidad V WHERE V.IdVisibilidad = P.IdVisibilidad) AS 'Visibilidad',";
                script += "CASE WHEN AdmitePreguntas = 1 THEN 'SI' ELSE 'NO' END AS 'Admite Preguntas',";
                script += "CONVERT (nvarchar(10),FechaInicio,101) AS 'Fecha Inicio', ";
                script += "CONVERT (nvarchar(10),FechaFin,101) AS 'Fecha Fin' FROM vadem.publicacion P";

              //  script += "WHERE P.Tipo = " + tipo + "AND P.IdEstado = "+ estado;
              //  script += " AND P.FechaFin <= " + fecha + "AND P.Descripcion = " + descripcion;
                script += clausulaWhere;

                return AccesoDatos.Instance.EjecutarScript(script);


            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
       
        }



        public static int insertar(Publicacion publicacion)
        {
            
            try
            { 

                String script = "[vadem].[insertPublicaciones]";
                List<SqlParameter> colparam = new List<SqlParameter>();
                
                SqlParameter stock = new SqlParameter();
                stock.ParameterName = "@STOCK";
                stock.SqlDbType = SqlDbType.Int;
                stock.Value = publicacion.Cantidad;
                colparam.Add(stock);

                SqlParameter estado = new SqlParameter();
                estado.ParameterName = "@ESTADO";
                estado.SqlDbType = SqlDbType.Int;
                estado.Value = publicacion.Estado;
                colparam.Add(estado);

                SqlParameter descripcion = new SqlParameter();
                descripcion.ParameterName = "@DESCRIPCION";
                descripcion.SqlDbType = SqlDbType.VarChar;
                descripcion.Value = publicacion.Descripcion;
                colparam.Add(descripcion);

                SqlParameter visibilidad = new SqlParameter();
                visibilidad.ParameterName = "@VISIBILIDAD";
                visibilidad.SqlDbType = SqlDbType.Int;
                visibilidad.Value = publicacion.Visibilidad;
                colparam.Add(visibilidad);

                SqlParameter fecha = new SqlParameter();
                fecha.ParameterName = "@FECHA_INI";
                fecha.SqlDbType = SqlDbType.DateTime;
                fecha.Value = publicacion.FechaInicio;
                colparam.Add(fecha);

                SqlParameter precio = new SqlParameter();
                precio.ParameterName = "@PRECIO";
                precio.SqlDbType = SqlDbType.Int;
                precio.Value = publicacion.Precio;
                colparam.Add(precio);

                SqlParameter vendedor = new SqlParameter();
                vendedor.ParameterName = "@VENDEDOR";
                vendedor.SqlDbType = SqlDbType.Int;
                vendedor.Value = publicacion.Vendedor;
                colparam.Add(vendedor);

                SqlParameter tipo = new SqlParameter();
                tipo.ParameterName = "@TIPO";
                tipo.SqlDbType = SqlDbType.VarChar;
                tipo.Value = publicacion.Tipo;
                colparam.Add(tipo);

                SqlParameter preguntas = new SqlParameter();
                preguntas.ParameterName = "@PREGUNTAS";
                preguntas.SqlDbType = SqlDbType.Bit;
                preguntas.Value = publicacion.AdmitePreguntas;
                colparam.Add(preguntas);



                DataTable res = AccesoDatos.Instance.EjecutarSp(script,colparam);

                if (res.Rows[0][0] != null)
                {
                    publicacion.Id = Convert.ToInt32(res.Rows[0][0]);
                    publicacion.FechaFin = Convert.ToDateTime(res.Rows[0][1]);
                    PublicacionDAO.insertarRubros(publicacion.Rubros, publicacion.Id);
                }
                return publicacion.Id;

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
                 script += "INSERT INTO vadem.rubrosPublicacion VALUES (" + idPublicacion + " , " + miRubro.Id + ") ";
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



        public static Publicacion modificar(Publicacion publicacion)
        {
            String script;
            try
            { // " + publicacion + "
                script = "SELECT IdEstado FROM vadem.publicacion WHERE IdPublicacion = "+ publicacion.Id;

                        script = "UPDATE vadem.publicacion " +
                               "     SET [Stock] = " + publicacion.Cantidad +
                               "   ,[IdEstado] = " + publicacion.Estado +
                               "   ,[Descripcion] = " + publicacion.Descripcion +
                               "   ,[IdVisibilidad] = " + publicacion.Visibilidad +
                               "   ,[FechaInicio] = " + publicacion.FechaInicio +
                               "   ,[FechaFin] = DATEADD(D,(SELECT DiasVigencia FROM vadem.visibilidad " + 
					                           "WHERE IdVisibilidad = " + publicacion.Visibilidad + ")," + publicacion.FechaInicio + ")," + 
                               "   ,[PrecioInicial] = " + publicacion.Precio +
                               "   ,[Tipo] = " + publicacion.Tipo + 
                               "   ,[AdmitePreguntas] =  " + publicacion.AdmitePreguntas + 
                               "WHERE IdPublicacion = " + publicacion.Id;
                        
                        AccesoDatos.Instance.EjecutarScript(script);
                     return obtenerPublicacion(publicacion.Id);
                

            }
            catch (Exception)
            {
                throw;
            }
        }

       
    }
}
