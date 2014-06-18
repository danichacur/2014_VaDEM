using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Entidades
{
    class ItemFacturacion
    {
        public int Id { get; set; }
        public int IdPublicacion { get; set; }
        public string DescPublicacion { get; set; }

        public int IdVendedor { get; set; }
        public string DescVendedor { get; set; }
        public int Costo { get; set; }
        public int Cantidad { get; set; }
        public int IdFactura { get; set; }
        public bool EsCompra { get; set; }

        public ItemFacturacion()
        {

        }
    }
}
