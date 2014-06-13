using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Entidades;

namespace FrbaCommerce.Datos
{
    class PreguntaDAO
    {
        public static void insertar(Pregunta pregunta)
        {
            String script;
            try
            { 
                script = "INSERT INTO vadem.pregunta VALUES (" + pregunta.IdPublicacion + "," + Session.IdUsuario;
                script += ",'" + pregunta.Fecha + "','" + pregunta.PreguntaDesc + "',null,null)" ;

                AccesoDatos.Instance.EjecutarScript(script);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
