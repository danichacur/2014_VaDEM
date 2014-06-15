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
using System.Configuration;

namespace FrbaCommerce.Formularios.Calificar_Vendedor
{
    public partial class Calificar : Form
    {
        #region VariablesDeClase

        DataGridViewRow publicacionSinCalificar;

        #endregion


        #region Eventos

        public Calificar(DataGridViewRow pPublicacionSinCalificar)
        {
            try
            {
                InitializeComponent();
                publicacionSinCalificar = pPublicacionSinCalificar;
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
            
        }

        private void Calificar_Load(object sender, EventArgs e)
        {
            try
            {
                cargarControles();
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (pasaValidaciones())
                {
                    insertarCalificacion();
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }
        
        #endregion

        #region MetodosGenerales

        /// <summary>
        /// cargo todos los controles, los que se cargan con la información de la publicacion y los que traigo de la BD
        /// </summary>
        private void cargarControles()
        {
            try
            {
                //Estos 3 los cargo con datos que traje de la publicacion seleccionada
                cargarDescripcionPublicacion();
                cargarVendedor();
                cargarMontoTotal();

                //
                cargarComboPuntaje();
                cargarComboSeleccion();
            }
            catch (Exception)
            {
                throw;
            }
        }

        

        /// <summary>
        /// Cargo el combo puntaje con valores del 1 al 10
        /// </summary>
        private void cargarComboPuntaje()
        {
            DataTable listaPuntaje;
            try
            {
                listaPuntaje = Metodos_Comunes.obtenerTablaComboPuntajes();
               Metodos_Comunes.InsertarVacioEnPrimerRegistro(ref listaPuntaje);
               Metodos_Comunes.cargarCombo(cboPuntaje, listaPuntaje, "Id", "Descripcion");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cargarComboSeleccion()
        {
            DataTable listaSeleccion;
            try
            {
                listaSeleccion = CalificacionDAO.obtenerCalificacionesEstandard();
                Metodos_Comunes.InsertarVacioEnPrimerRegistro(ref listaSeleccion);
                Metodos_Comunes.cargarCombo(cboSeleccion, listaSeleccion, "Id", "Descripcion");
            }
            catch (Exception)
            {   
                throw;
            }
        }

        private Boolean pasaValidaciones()
        {
            String camposConErrores;
            Boolean valida;
            try
            {
                camposConErrores = "";

                if (cboPuntaje.SelectedIndex == 0) camposConErrores += "Puntaje, ";

                if (rbtnComboSeleccion.Checked)
                {
                    if (cboSeleccion.SelectedIndex == 0) camposConErrores += "Selección de Detalle, ";
                }
                else if(rbtnTextoLibre.Checked)
                {
                    if (rtxtTextoLibre.Text == "") camposConErrores += "Texto Libre de Detalle, ";
                }
                else
                {
                    camposConErrores += "Opción de Selección o Texto Libre, ";
                }

                if (camposConErrores.Length != 0)
                {
                    camposConErrores = camposConErrores.Substring(0, camposConErrores.Length - 2);
                    valida = false;
                    Metodos_Comunes.MostrarMensaje("No se puede guardar la calificación. Debe completar todos los campos. Los campos faltantes son: " + camposConErrores);
                }
                else
                    valida = true;
                    

                return valida;
            }
            catch (Exception)
            {   
                throw;
            }
        }

        private void insertarCalificacion()
        {
            int idCompra, idVendedor, idCalificador, cantidadEstrellas;
            DateTime FechaActual;
            String detalle;

            try
            {
               idCompra = Convert.ToInt32(publicacionSinCalificar.Cells["IdCompra"].Value);
               idVendedor = Convert.ToInt32(publicacionSinCalificar.Cells["IdVendedor"].Value);
               idCalificador = Session.IdUsuario;
               cantidadEstrellas = Convert.ToInt32(cboPuntaje.SelectedValue);
               FechaActual = Convert.ToDateTime(ConfigurationManager.AppSettings["DateTimeNow"]);
               if (rbtnComboSeleccion.Checked)
                   detalle = cboSeleccion.Text;
               else
                   detalle = rtxtTextoLibre.Text;
               

                CalificacionDAO.insertarCalificacion(idCompra, idVendedor, idCalificador, FechaActual, cantidadEstrellas, detalle);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region MetodosAuxiliares

        private void cargarDescripcionPublicacion()
        {
            try
            {
                rtxtDescripcionPubl.Text = publicacionSinCalificar.Cells["PublicacionDescripcion"].Value.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cargarVendedor()
        {
            try
            {
                txtVendedor.Text = publicacionSinCalificar.Cells["UsernameVendedor"].Value.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cargarMontoTotal()
        {
            try
            {
                txtMontoTotal.Text = publicacionSinCalificar.Cells["MontoTotalPagado"].Value.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


    }
}
