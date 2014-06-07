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

                String script = "SELECT * FROM vadem.compras " ;
                script += "WHERE IdComprador = " + Session.IdUsuario + " ";
                script += "AND Calificada = 0";
                //script += clausulaWhere;

                compras = new List<Compra>();

                tbl = AccesoDatos.Instance.EjecutarScript(script);

                foreach (DataRow row in tbl.Rows)
                {
                    compra = new Compra(
                                Convert.ToInt32(row["IdCompra"]),
                                new Publicacion(),
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

    }
}
