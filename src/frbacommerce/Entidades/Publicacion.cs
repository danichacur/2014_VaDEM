using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Entidades
{
    public class Publicacion
    {

        public int Id { get; set; }
        public string Descripcion { get; set; }
        

        public Publicacion()
        {
            Id = 0;
            Descripcion = "";
        }

        public Publicacion(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }

    }
}
