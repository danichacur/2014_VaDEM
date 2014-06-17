using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Componentes_Comunes;
using FrbaCommerce.Datos;
using FrbaCommerce.Entidades;
using System.Configuration;

namespace FrbaCommerce.Formularios.Comprar_Ofertar
{
    public partial class Comprar_Ofertar_Publicacion : ABM
    {
        
        private Publicacion pub { get; set; }
        public Comprar_Ofertar_Publicacion(int idPublicacion)
        {
            try
            {


            this.pub = PublicacionDAO.obtenerPublicacion(idPublicacion);
            InitializeComponent();
            }
            catch (Exception ex)
            {

                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }



        private void Comprar_Ofertar_Publicacion_Load(object sender, EventArgs e)
        {
            try{
            labelDescripcion.Text = pub.Descripcion;
            labelFechaIni.Text = pub.FechaInicio.ToString();
            labelFechaFin.Text = pub.FechaFin.ToString();
            labelVendedor.Text = pub.VendedorDesc;
            labelPrecio.Text = pub.Precio.ToString();
            labelStock.Text = pub.Cantidad.ToString();
            labelTipo.Text = pub.Tipo;


            if (pub.Tipo == "Subasta")
            {
                btnComprar.Visible = false;
                btnOfertar.Visible = true;
            }
            else
            {
                btnOfertar.Visible = false;
                btnComprar.Visible = true;
            }

            if (pub.AdmitePreguntas)
            {
                btnPreguntar.Enabled = true;
                pnlPregunta.Visible = false;
            }
            else
            {
                btnPreguntar.Enabled = false;
                pnlPregunta.Visible = false;
            }
            }
            catch (Exception ex)
            {

                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }

        private void btnPreguntar_Click(object sender, EventArgs e)
        {
            pnlPregunta.Visible = true;
        }

        private void btnAceparPregunta_Click(object sender, EventArgs e)
        {
            try{
                if (Session.IdUsuario != pub.Vendedor)
                {
                    Pregunta pregunta = new Pregunta();

                    pregunta.IdPublicacion = pub.Id;
                    pregunta.Fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["DateTimeNow"]);
                    pregunta.PreguntaDesc = txtPregunta.Text;

                    PreguntaDAO.insertar(pregunta);
                    Metodos_Comunes.MostrarMensaje("La pregunta fue realizada");
                    txtPregunta.Text = "";
                }
                else
                {
                    Metodos_Comunes.MostrarMensaje("No puedes preguntarte a ti mismo");
                }
                            }
            catch (Exception ex)
            {
                
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        } 

        private void btnOfertar_Click(object sender, EventArgs e)
        {
            
            Formularios.Comprar_Ofertar.Comprar_Ofertar_Ofertar formOfertar = new Formularios.Comprar_Ofertar.Comprar_Ofertar_Ofertar(pub.Id);
            formOfertar.ShowDialog();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {

            Formularios.Comprar_Ofertar.Comprar_Ofertar_Comprar formComprar= new Formularios.Comprar_Ofertar.Comprar_Ofertar_Comprar(pub);
            formComprar.ShowDialog();
        }
    }
}
