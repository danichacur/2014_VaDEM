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

namespace FrbaCommerce.Formularios.Comprar_Ofertar
{
    public partial class Comprar_Ofertar_Publicacion : ABM
    {
        private int IdPublicacion{get;set;}
        public Comprar_Ofertar_Publicacion(int idPublicacion)
        {
            this.IdPublicacion = idPublicacion;
            InitializeComponent();
        }



        private void Comprar_Ofertar_Publicacion_Load(object sender, EventArgs e)
        {
            Publicacion pub = PublicacionDAO.obtenerPublicacion(IdPublicacion);
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
            }
        }

        private void btnPreguntar_Click(object sender, EventArgs e)
        {
            pnlPregunta.Visible = true;
        }

        private void btnAceparPregunta_Click(object sender, EventArgs e)
        {
            Pregunta pregunta = new Pregunta();

            pregunta.IdPublicacion = IdPublicacion;
            pregunta.Fecha = DateTime.Today;
            pregunta.PreguntaDesc = txtPregunta.Text;

            PreguntaDAO.insertar(pregunta);
        }
    }
}
