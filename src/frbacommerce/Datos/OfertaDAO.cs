using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Entidades;
using System.Data;
using FrbaCommerce.Componentes_Comunes;
using System.Data.SqlClient;

namespace FrbaCommerce.Datos
{
    class OfertaDAO
    {
        public static DataTable ObtenerHistorialOfertas(int IdUsuario)
        {
            string script;

            script = "select O.Fecha,O.Importe,P.Descripcion,U.Username ,isnull((select 'SI' from vadem.compras where IdPublicacion = O.IdPublicacion and O.IdOfertante = IdComprador),'NO') as Gano " +
                      "from vadem.ofertas O join vadem.publicacion P on P.IdPublicacion = O.IdPublicacion join vadem.usuario U on U.IdUsuario = P.IdVendedor " +
                      "where O.IdOfertante = " + IdUsuario;

            return AccesoDatos.Instance.EjecutarScript(script);
        }

        public static Oferta ObtenerUltimaOferta(int idPublicacion)
        {
            DataTable tbl;
            string script;
            Oferta oferta = new Oferta();

            script = "select IdPublicacion,MAX( Importe ) as Importe from vadem.ofertas  " +
                       "where IdPublicacion = " + 63597 +
                       " group by IdPublicacion";
            
            tbl = AccesoDatos.Instance.EjecutarScript(script);
            if (tbl.Rows.Count > 0)
            {
                oferta.Importe = Convert.ToInt32(tbl.Rows[0]["Importe"]);

                return oferta;
            }
            else
            {
                oferta.Importe = 0;
                return  oferta;
            }
        }


        public static int nuevaOferta(Oferta oferta)
        {
            DataTable tbl;
            string script;


            List<SqlParameter> colParam = new List<SqlParameter>();

            SqlParameter idPublicacion = new SqlParameter();
            idPublicacion.SqlDbType = SqlDbType.Int;
            idPublicacion.ParameterName = "@IdPublicacion";
            idPublicacion.Value = oferta.IdPublicacion;

            SqlParameter idOfertante = new SqlParameter();
            idOfertante.SqlDbType = SqlDbType.Int;
            idOfertante.ParameterName = "@IdOfertante";
            idOfertante.Value = oferta.IdOfertante;

            SqlParameter fecha = new SqlParameter();
            fecha.SqlDbType = SqlDbType.DateTime;
            fecha.ParameterName = "@Fecha";
            fecha.Value = oferta.Fecha;

            SqlParameter Importe = new SqlParameter();
            Importe.SqlDbType = SqlDbType.Int;
            Importe.ParameterName = "@Importe";
            Importe.Value = oferta.Importe;

            colParam.Add(idPublicacion);
            colParam.Add(idOfertante);
            colParam.Add(fecha);
            colParam.Add(Importe);

            script = "vadem.NuevaOferta";

            tbl =  AccesoDatos.Instance.EjecutarSp(script,colParam);

          return Convert.ToInt32(tbl.Rows[0][0]);

         
        }
      
    }
}
