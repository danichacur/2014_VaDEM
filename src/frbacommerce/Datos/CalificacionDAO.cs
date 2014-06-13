using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

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
    }
}
