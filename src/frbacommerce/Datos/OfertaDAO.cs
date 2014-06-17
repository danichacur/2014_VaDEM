using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Entidades;
using System.Data;

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
    }
}
