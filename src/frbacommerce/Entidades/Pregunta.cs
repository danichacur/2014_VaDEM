using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Datos;

namespace FrbaCommerce.Entidades
{
    public class Pregunta
    {
        public int Id { get; set; }
        public int IdPublicacion { get; set; }
        public String DescPublicacion { get; set; }
        public int UsuarioPregunta { get; set; }
        public String DescUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public String PreguntaDesc { get; set; }
        public DateTime FechaRespuesta { get; set; }
        public String Respuesta { get; set; }


        public Pregunta(int id, int publicacion, int usuario, DateTime fecha, string pregunta, DateTime f_respuesta, string respuesta, string dPublicacion, string descUsuario)
        {
            Id = id;
            IdPublicacion = publicacion;
            UsuarioPregunta = usuario;
            Fecha = fecha;
            PreguntaDesc = pregunta;
            FechaRespuesta = f_respuesta;
            Respuesta = respuesta;
            DescPublicacion = dPublicacion;
            DescUsuario = descUsuario;

        }

        public Pregunta()
        {
        }


        public Pregunta responder()
        {
            try
            {
                return PreguntaDAO.responder(this);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
