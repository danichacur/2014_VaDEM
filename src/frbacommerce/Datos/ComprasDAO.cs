using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Entidades;
using System.Data;
using System.Data.SqlClient;
namespace FrbaCommerce.Datos
{
    class ComprasDAO
    {

        /// <summary>
        /// obtiene los clientes en base a un script que recibe por parámetro.
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public static DataTable obtenerCompras(String clausulaWhere)
        {
            List<Compra> compras;
            DataTable tbl;
            try
            {


                String script = "SELECT C.IdCompra, ";
                script += "        P.IdVendedor,  ";
                script += "        P.Descripcion AS PublicacionDescripcion,  ";
                script += "        U.Username AS UsernameVendedor,  ";
                script += "        C.Fecha,  ";
                script += "        C.Cantidad,  ";
                script += "        Calificada,  ";
                script += "        PrecioInicial * Cantidad AS MontoTotalPagado ";
                script += " FROM vadem.compras C  ";
                script += " LEFT JOIN vadem.publicacion P ON C.IdPublicacion = P.IdPublicacion  ";
                script += " LEFT JOIN vadem.usuario U ON P.IdVendedor = U.IdUsuario  ";
                script += " WHERE C.IdComprador = " + Session.IdUsuario + " AND Calificada = 0 ";

                if (clausulaWhere != "")
                    script += clausulaWhere.Replace("WHERE", "AND");

                compras = new List<Compra>();

                tbl = AccesoDatos.Instance.EjecutarScript(script);

                return tbl;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene las compras de un usuario para el historial de cliente
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public static DataTable obtenerHistorialCompras(int usuario)
        {
            String script = "select C.Fecha,C.Cantidad,P.Descripcion,P.IdTipo,U.Username from vadem.compras C " +
                            "join vadem.publicacion P on C.IdPublicacion = P.IdPublicacion " +
                            "join vadem.usuario U on P.IdVendedor = U.IdUsuario " +
                            "where IdComprador = " + usuario;

            return AccesoDatos.Instance.EjecutarScript(script);
        }

        public static int Comprar(int idPublicacion, int idComprador, DateTime fecha, int cantidad)
        {
            try
            {
                string script = "vadem.NuevaCompra";
                DataTable dtl;
                List<SqlParameter> colparam = new List<SqlParameter>();

                SqlParameter pIdPublicacion = new SqlParameter();
                pIdPublicacion.SqlDbType = SqlDbType.Int;
                pIdPublicacion.ParameterName = "@IdPublicacion";
                pIdPublicacion.Value = idPublicacion;

                SqlParameter pIdComprador = new SqlParameter();
                pIdComprador.SqlDbType = SqlDbType.Int;
                pIdComprador.ParameterName = "@IdComprador";
                pIdComprador.Value = idComprador;

                SqlParameter pFecha = new SqlParameter();
                pFecha.SqlDbType = SqlDbType.DateTime;
                pFecha.ParameterName = "@Fecha";
                pFecha.Value = fecha;

                SqlParameter pCantidad = new SqlParameter();
                pCantidad.SqlDbType = SqlDbType.Int;
                pCantidad.ParameterName = "@Cantidad";
                pCantidad.Value = cantidad;

                colparam.Add(pIdPublicacion);
                colparam.Add(pIdComprador);
                colparam.Add(pFecha);
                colparam.Add(pCantidad);

                dtl = AccesoDatos.Instance.EjecutarSp(script, colparam);

                return Convert.ToInt32(dtl.Rows[0][0]);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}