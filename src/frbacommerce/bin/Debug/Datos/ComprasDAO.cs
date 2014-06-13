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
        public static List<Compra> obtenerCompras(String clausulaWhere)
        {
            Compra compra;
            List<Compra> compras;
            DataTable tbl;
            try
            {

                String script = "SELECT * FROM vadem.compras C left join vadem.publicacion P on C.IdPublicacion = P.IdPublicacion ";
                script += "WHERE C.IdComprador = " + Session.IdUsuario + " ";
                //script += "AND Calificada = 0";
                //script += clausulaWhere;

                compras = new List<Compra>();

                tbl = AccesoDatos.Instance.EjecutarScript(script);

                foreach (DataRow row in tbl.Rows)
                {
                    compra = new Compra(
                                Convert.ToInt32(row["IdCompra"]),
                                new Publicacion(Convert.ToInt32(row["IdPublicacion"]),
                                                (String)row["Descripcion"]),
                                new Cliente(),
                                (DateTime)row["Fecha"],
                                Convert.ToInt32(row["Cantidad"]),
                                Convert.ToInt32(row["Calificada"]) == 1 ? true : false
                                    );
                    compras.Add(compra);
                }

                return compras;
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
