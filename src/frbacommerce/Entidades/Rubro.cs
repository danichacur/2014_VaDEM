using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Entidades
{
    public class Rubro
    {

        public int Id { get; set; }
        public string Descripcion { get; set; }
        
        public Rubro() {
            Id = 0;
            Descripcion = "";
         }

        public Rubro(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }
    }
}
