﻿using System;
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
            try
            {
                labelDescripcion.Text = pub.Descripcion;
                labelFechaIni.Text = pub.FechaInicio.ToString();
                labelFechaFin.Text = pub.FechaFin.ToString();
                labelVendedor.Text = pub.VendedorDesc;
                labelPrecio.Text = pub.Precio.ToString();
                labelStock.Text = pub.Cantidad.ToString();
                labelTipo.Text = pub.Tipo;

                Oferta oferta = OfertaDAO.ObtenerUltimaOferta(pub.Id);
                if ((int)oferta.Importe == 0)
                    lblOfertaMax.Text = pub.Precio.ToString();
                else
                    lblOfertaMax.Text = oferta.Importe.ToString();

                if (pub.Tipo == "Subasta")
                {
                    btnComprar.Visible = false;
                    btnOfertar.Visible = true;
                    mayorOferta.Visible = true;
                    lblOfertaMax.Visible = true;
                }
                else
                {
                    btnOfertar.Visible = false;
                    btnComprar.Visible = true;
                    mayorOferta.Visible = false;
                    lblOfertaMax.Visible = false;
                }

                if (pub.AdmitePreguntas)
                {
                    btnPreguntar.Enabled = true;
                    pnlPregunta.Visible = false;
                    VerPreguntas.Enabled = true;
                }
                else
                {
                    btnPreguntar.Enabled = false;
                    pnlPregunta.Visible = false;
                    VerPreguntas.Enabled = false;
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
            try
            {
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
            System.Windows.Forms.DialogResult result;

            Formularios.Comprar_Ofertar.Comprar_Ofertar_Ofertar formOfertar = new Formularios.Comprar_Ofertar.Comprar_Ofertar_Ofertar(pub.Id);
            result = formOfertar.ShowDialog();

          
                //recalcular
                this.pub = PublicacionDAO.obtenerPublicacion(pub.Id);
                labelStock.Text = pub.Cantidad.ToString();
                if (pub.Tipo == "Subasta")
                {
                    Oferta oferta = OfertaDAO.ObtenerUltimaOferta(pub.Id);
                    if ((int)oferta.Importe == 0)
                        lblOfertaMax.Text = pub.Precio.ToString();
                    else
                        lblOfertaMax.Text = oferta.Importe.ToString();
                }
        
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult result;
            Formularios.Comprar_Ofertar.Comprar_Ofertar_Comprar formComprar = new Formularios.Comprar_Ofertar.Comprar_Ofertar_Comprar(pub);
            result = formComprar.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
               //recalcular
                this.pub = PublicacionDAO.obtenerPublicacion(pub.Id);
                labelStock.Text = pub.Cantidad.ToString();
                if (pub.Tipo == "Subasta")
                {
                    Oferta oferta = OfertaDAO.ObtenerUltimaOferta(pub.Id);
                    if ((int)oferta.Importe == 0)
                        lblOfertaMax.Text = pub.Precio.ToString();
                    else
                        lblOfertaMax.Text = oferta.Importe.ToString();
                }
            }
        }

        private void VerPreguntas_Click(object sender, EventArgs e)
        {
            Formularios.Gestion_de_Preguntas.Ver_Preguntas formPreguntar = new Formularios.Gestion_de_Preguntas.Ver_Preguntas(pub);
            formPreguntar.ShowDialog();

        }
    }
}
