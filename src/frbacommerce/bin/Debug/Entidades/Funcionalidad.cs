using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Entidades
{
    public class Funcionalidad
    {

        public int Id { get; set; }
        public string Descripcion { get; set; }

         public Funcionalidad() {
            Id = 0;
            Descripcion = "";
        }

         public Funcionalidad(int id, string descripcion)
         {
            Id = id;
            Descripcion = descripcion;
        }
    }
}
