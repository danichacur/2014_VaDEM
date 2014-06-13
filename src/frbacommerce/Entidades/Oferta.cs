using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Entidades
{
    class Oferta
    {
        public int Id {get;set;}
        public int IdPublicacion { get; set; }
        public int IdOfertante { get; set; }
        public DateTime Fecha { get; set; }
        public int Importe { get; set; }

        public Oferta()
        {
        }

    }
}
