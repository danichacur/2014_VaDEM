using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Entidades
{
    class Pregunta
    {
        public int Id { get; set; }
        public int IdPublicacion { get; set; }
        public int UsuarioPregunta { get; set; }
        public DateTime Fecha { get; set; }
        public String PreguntaDesc { get; set; }
        public DateTime FechaRespuesta { get; set; }
        public String Respuesta { get; set; }


        public Pregunta()
        {
 
        }
    }
}
