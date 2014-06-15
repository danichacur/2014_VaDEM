using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Entidades;
using System.Data;

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
                    script += "AND " + clausulaWhere;

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
            String script = "select C.Fecha,C.Cantidad,P.Descripcion,P.Tipo,U.Username from vadem.compras C " +
                            "join vadem.publicacion P on C.IdPublicacion = P.IdPublicacion " +
                            "join vadem.usuario U on P.IdVendedor = U.IdUsuario " +
                            "where IdComprador = " + usuario;
                            
            return AccesoDatos.Instance.EjecutarScript(script);
        }

    }
}
