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

namespace FrbaCommerce.Formularios.Calificar_Vendedor
{
    public partial class Calificar : Form
    {
        public Calificar()
        {
            InitializeComponent();
        }

        private void Calificar_Load(object sender, EventArgs e)
        {
            try
            {
           //     Compra compra = sender;
                cargarComboPuntaje();
                //cargar descripción publicación
                cargarDescripcionPublicación("14021"); //compra.IdPublicacion );
                //cargar nombre vendedor
                cargarNombreVendedor("14021");
                //total abonado
                cargarTotalAbonado();

            }
            catch (Exception ex)
            {
               Metodos_Comunes.MostrarMensajeError(ex);
            }
        }



        private void cargarComboPuntaje()
        {
            try
            {
                cboPuntaje.DataSource = Metodos_Comunes.obtenerTablaComboPuntajes();
                cboPuntaje.DisplayMember = "Descripcion";
                cboPuntaje.ValueMember = "Id";
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cargarDescripcionPublicación(string idcompra)
        {
            try
            {
                String script = "select p.Descripcion ";
                script += "from vadem.compras c ";
                script += "left join vadem.publicacion p on c.IdPublicacion = p.IdPublicacion ";
                script += "where c.IdCompra = " + idcompra;

                DataTable res = AccesoDatos.Instance.EjecutarScript(script);
                
                txtDescripPublic.Text = Convert.ToString(res.Rows[0][0]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cargarNombreVendedor(string idcompra)
        {
            try
            {
                String script = "select u.Username ";
                script += "from vadem.compras c ";
                script += "left join vadem.publicacion p on c.IdPublicacion = p.IdPublicacion ";
                script += "left join vadem.usuario u on p.IdVendedor = u.IdUsuario ";
                script += "where c.IdCompra = " + idcompra;

                DataTable res = AccesoDatos.Instance.EjecutarScript(script);

                txtNombreVendedor.Text = Convert.ToString(res.Rows[0][0]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cargarTotalAbonado()
        {
            try
            {

            }
            catch (Exception)
            {
                throw;
            }
        }

//        /// <summary>
//        /// Evento del boton Aceptar. 
//        /// Cargo en el objeto de la clase los parámetros correspondientes de acuerdo a los campos insertados. Luego persisto en la BD
//        /// Cierro la ventana devolviendo un OK
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        public override void btnCalificarClick(object sender, EventArgs e)
//        {
//            try
//            {
//   //             if (pasaValidacionesVarias())
//   //             {
//            Calificacion calificacion = new Calificacion(generarId(), compra.id,  Session.IdUsuario, fecha, estrellas, detalle);

//                    DialogResult = System.Windows.Forms.DialogResult.OK;
//    //            }
//            }
//            catch (Exception ex)
//            {
//                Metodos_Comunes.MostrarMensajeError(ex);
//            }
//        }


    }
}
