using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Entidades
{
    class EstadoPublicacion
    {
        public int Id { get; set; }
        public String Descripcion { get; set; }


        public EstadoPublicacion()
        {
        }

        public EstadoPublicacion(int pId, string pDescripcion)
        {
            Id = pId;
            Descripcion = pDescripcion;
            
        }
    }
}
