using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Datos;

namespace FrbaCommerce.Entidades
{
    public class Publicacion
    {

        public int Id { get; set; }
        public int Vendedor { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
        public bool AdmitePreguntas { get; set; }
        public List<Funcionalidad> Rubros { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int Visibilidad { get; set; }
        public int Estado { get; set; }

        public Publicacion()
        {
            Id = 0;
            Descripcion = "";
            Vendedor = Session.IdUsuario;
            Estado = 1;
        }

        public Publicacion(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }


        /// <summary>
        /// Genera la inserción de la puplicacion en la base de datos.
        /// </summary>
        public void insertar()
        {
            try
            {
                PublicacionDAO.insertar(this);
            }
            catch (Exception)
            {
                throw;
            }
        }



        /// <summary>
        /// Recibo una lista de ids de rubros y los inserto en la lista de rubros, pero sin descripcion
        /// </summary>
        /// <param name="idsRubro"></param>
        public void AgregarRubros(String idsRubro)
        {
            throw new NotImplementedException();
          /*  //System.Windows.Forms.DataGridViewRow row;
            //int idx;
            Rubro rubr;
            try
            {
                rubr = new List<Rubro>();
                //Por cada id  que viene en el texto parámetro, activo el check correspondiente
                foreach (String id in ((String)idsRubro).Split(new Char[] { ',' }))
                {
                    rubr = new Rubro(Convert.ToInt16(id), "");
                    Rubro.Add(rubr);
                }
            }
            catch (Exception)
            {
                throw;
            }*/
        }
    }
}
