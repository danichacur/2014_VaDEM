using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Entidades;
using System.Data;
using FrbaCommerce.Componentes_Comunes;
using System.Data.SqlClient;
using System.Configuration;
namespace FrbaCommerce.Datos
{
    class FacturarDAO
    {
        public static DataTable ObtenerItemFactura(int IdVendedor)
        {
            try
            {


            String script;

            script = "select F.IdItem,F.IdPublicacion,P.Descripcion,F.IdVendedor,F.Costo,F.Cantidad,F.IdFactura,F.EsCompra from vadem.itemFactura  F " +
                      "join vadem.publicacion P on P.IdPublicacion = F.IdPublicacion " +
                      "where IdFactura = " + (-1)*IdVendedor +
                      " and EsCompra = 0 " +
                      "and P.IdVendedor = " + IdVendedor +
                      " order by IdItem ";

            return AccesoDatos.Instance.EjecutarScript(script);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Pagar(List<ItemFacturacion> colItems,string FormaPago , string DatosTarjeta)
        {
            try{
                string script = "[vadem].[NuevaFactura]";

                List<SqlParameter> colParam = new List<SqlParameter>();

                SqlParameter idVendedor = new SqlParameter();
                idVendedor.ParameterName = "@IdVendedor";
                idVendedor.SqlDbType = SqlDbType.Int;
                idVendedor.Value = Session.IdUsuario;

                SqlParameter fecha = new SqlParameter();
                fecha.ParameterName = "@Fecha";
                fecha.SqlDbType = SqlDbType.DateTime;
                fecha.Value = Convert.ToDateTime(ConfigurationManager.AppSettings["DateTimeNow"]);

                SqlParameter formaPago = new SqlParameter();
                formaPago.ParameterName = "@FormaPago";
                formaPago.SqlDbType = SqlDbType.VarChar;
                formaPago.Value = FormaPago;

                SqlParameter datos  = new SqlParameter();
                datos.ParameterName = "@DatosTarjeta";
                datos.SqlDbType = SqlDbType.VarChar;
                datos.Value = DatosTarjeta;


                int tot=0;

                foreach (ItemFacturacion item in colItems)
                {
            		 tot = tot + item.Costo * item.Cantidad;
                }


                SqlParameter total = new SqlParameter();
                total.ParameterName = "@total";
                total.SqlDbType = SqlDbType.Int;
                total.Value = tot ;

                colParam.Add(idVendedor); colParam.Add(fecha); colParam.Add(formaPago); colParam.Add(datos); colParam.Add(total);

               DataTable tbl = AccesoDatos.Instance.EjecutarSp(script, colParam);

               int idFactura = Convert.ToInt32(tbl.Rows[0][0]);

                foreach (ItemFacturacion item in colItems)
                {
                     script = "update vadem.itemFactura set IdFactura = " +idFactura +" where IdItem = " + item.Id; 
                    
                AccesoDatos.Instance.EjecutarScript(script);
                }
                    
            return 1;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
}
