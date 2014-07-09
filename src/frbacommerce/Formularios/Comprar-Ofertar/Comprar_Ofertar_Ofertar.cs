using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Datos;
using FrbaCommerce.Entidades;
using FrbaCommerce.Componentes_Comunes;
using System.Configuration;

namespace FrbaCommerce.Formularios.Comprar_Ofertar
{
    public partial class Comprar_Ofertar_Ofertar : Form
    {
       
        private Publicacion publicacion { get; set; }
        private Oferta oferta { get; set; }

        public Comprar_Ofertar_Ofertar(int idPublicacion)
        {
            try
            {
                 publicacion = PublicacionDAO.obtenerPublicacion(idPublicacion);
                 oferta = OfertaDAO.ObtenerUltimaOferta(idPublicacion);

                InitializeComponent();
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }

        private void Comprar_Ofertar_Ofertar_Load(object sender, EventArgs e)
        {
            
            try{

            lblVendedor.Text = publicacion.VendedorDesc;
            if (oferta.Importe == 0)
            {
                lblOfertaActual.Text = publicacion.Precio.ToString();
            }
            else
            {
                lblOfertaActual.Text = oferta.Importe.ToString();
            }
                        }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }

        private void btnOfertar_Click(object sender, EventArgs e)
        {
            if (Session.IdUsuario != publicacion.Vendedor)
            {
                if (Convert.ToInt32(txtMonto.Text) > oferta.Importe)
                {
                    Oferta nuevaOferta = new Oferta();
                    nuevaOferta.IdOfertante = Session.IdUsuario;
                    nuevaOferta.IdPublicacion = publicacion.Id;
                    nuevaOferta.Importe = Convert.ToInt32(txtMonto.Text);

                    DateTime fechaActual = Convert.ToDateTime(ConfigurationManager.AppSettings["DateTimeNow"]);
                    fechaActual = fechaActual.AddHours(DateTime.Now.Hour);
                    fechaActual = fechaActual.AddMinutes(DateTime.Now.Minute);
                    fechaActual = fechaActual.AddSeconds(DateTime.Now.Second);
                    
                    nuevaOferta.Fecha = Convert.ToDateTime(fechaActual);

                    if (OfertaDAO.nuevaOferta(nuevaOferta) == 1)
                    {
                        Metodos_Comunes.MostrarMensaje("la Oferta a sido realizada");
                    }
                    else
                    {
                        Metodos_Comunes.MostrarMensaje("el Monto debe ser mayor a la oferta anterior");

                    }
                    actualizarOferta();
                }
                else
                {
                    Metodos_Comunes.MostrarMensaje("el Monto debe ser mayor a la oferta anterior");
                }

            }
            else 
            {
                Metodos_Comunes.MostrarMensaje("No puedes ofertarte a ti mismo");
            }

        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        public void actualizarOferta()
        {
            try
            {
                Oferta oferta = OfertaDAO.ObtenerUltimaOferta(publicacion.Id);
                if (oferta.Importe == 0)
                {
                    lblOfertaActual.Text = publicacion.Precio.ToString();
                }
                else
                {
                    lblOfertaActual.Text = oferta.Importe.ToString();
                }
            }
            catch (Exception ex)
            {

                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }
        
    }
}
