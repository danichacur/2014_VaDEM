using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Entidades;
using FrbaCommerce.Componentes_Comunes;

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
                script += ",'" + Metodos_Comunes.localDateToSQLDate(pregunta.Fecha) + "','" + pregunta.PreguntaDesc + "',null,null)" ;

                AccesoDatos.Instance.EjecutarScript(script);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static object obtenerPreguntas(string clausulaWhere)
        {
            String script;
            try
            {
                script = " SELECT E.IdPregunta, P.Descripcion, P.IdPublicacion, U.IdUsuario, E.Pregunta, U.Username, E.FechaPregunta, E.Respuesta, E.FechaRespuesta ";
                script += " FROM vadem.pregunta E, vadem.publicacion P, vadem.usuario U";
                script += " WHERE E.IdPublicacion = P.IdPublicacion";
	            script += " AND E.UsuarioPregunta = U.IdUsuario";
                script += " AND P.IdVendedor = " + Session.IdUsuario + " ";

                if (clausulaWhere != "")
                    clausulaWhere = clausulaWhere.Replace("WHERE","AND");

                script += clausulaWhere;
                script += " ORDER BY E.IdPregunta DESC ";


                return AccesoDatos.Instance.EjecutarScript(script);

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal static Pregunta responder(Pregunta pregunta)
        {
            String script;
            try
            { 
                script = "UPDATE vadem.pregunta " +
                       "     SET [FechaRespuesta] = '" + Metodos_Comunes.localDateToSQLDate(pregunta.FechaRespuesta) + "'" +
                       "   ,[Respuesta] =  '" + pregunta.Respuesta + "'" +
                       " WHERE IdPregunta = " + pregunta.Id;

                AccesoDatos.Instance.EjecutarScript(script);

                return pregunta;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
