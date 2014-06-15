using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaCommerce.Entidades;
using System.Data.SqlClient;
using FrbaCommerce.Componentes_Comunes;

namespace FrbaCommerce.Datos
{
    class CalificacionDAO
    {
        public static DataTable CalificacionesRealizadas(int IdUsuario)
        {
            string script;

            script = "select U.Username,P.Descripcion, C.Estrellas,C.Detalle from vadem.calificacion C " +
                     "join vadem.usuario U on C.IdVendedor = U.IdUsuario " +
                     "join vadem.compras CO on CO.IdCompra = C.IdCompra " +
                     "join vadem.publicacion P on P.IdPublicacion = CO.IdPublicacion " +
                     "where IdCalificador = " + IdUsuario;

            return AccesoDatos.Instance.EjecutarScript(script);
        }

        public static DataTable CalificacionesRecibidas(int IdUsuario)
        {
            string script;

            script = "select U.Username,P.Descripcion, C.Estrellas,C.Detalle from vadem.calificacion C " +
                     "join vadem.usuario U on C.IdCalificador = U.IdUsuario " +
                     "join vadem.compras CO on CO.IdCompra = C.IdCompra " +
                     "join vadem.publicacion P on P.IdPublicacion = CO.IdPublicacion " +
                     "where C.IdVendedor = " + IdUsuario;
            return AccesoDatos.Instance.EjecutarScript(script);
        }


        public static Calificacion insertar(Calificacion calificacion)
        {
            String script;
            try
            { // " + calificacion + "
                script = "INSERT INTO vadem.calificacion VALUES (" + calificacion.Id + "," + calificacion.Compra.Id;
                script += "','" + calificacion.Vendedor.IdUsuario + "','" + calificacion.Calificador.IdUsuario + "','" + calificacion.Fecha;
                script += "','" + calificacion.Estrellas + "','" + calificacion.Detalle + "')";

                AccesoDatos.Instance.EjecutarScript(script);

                return calificacion;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable obtenerCalificacionesEstandard()
        {

            try
            {
                string script;

                script = "SELECT * FROM vadem.calificacionesEstandard";
                return AccesoDatos.Instance.EjecutarScript(script);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void insertarCalificacion(int idCompra, int idVendedor, int idCalificador, DateTime FechaActual, int cantidadEstrellas, string detalle)
        {
            String script;
            try
            {
                script = "INSERT INTO vadem.calificacion VALUES ( ";
                script += "(SELECT MAX(IdCalificacion) + 1 FROM vadem.calificaciones), ";
                script += idCompra + ",";
                script += idVendedor + ",";
                script += idCalificador + ",";
                script += "'" + Metodos_Comunes.localDateToSQLDate(FechaActual) + "' ,";
                script += cantidadEstrellas + ",";
                script += "'" + detalle + "'";
                script += ")";

                AccesoDatos.Instance.EjecutarScript(script);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
