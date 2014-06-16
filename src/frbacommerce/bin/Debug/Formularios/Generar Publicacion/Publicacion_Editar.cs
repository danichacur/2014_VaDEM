using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Entidades;
using FrbaCommerce.Componentes_Comunes;
using FrbaCommerce.Datos;
using System.Configuration;

namespace FrbaCommerce.Formularios.Generar_Publicacion
{
    public partial class Publicacion_Editar : Publicacion_Alta
    {

        #region VariablesDeClase

        #endregion


        #region Eventos

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="pCliente"></param>
        public Publicacion_Editar(Publicacion pPublicacion)
        {
            try
            {
                publicacion = pPublicacion;
                InitializeComponent();
            }
            catch (Exception)
            {
                throw;
            }
        }

        
        /// <summary>
        /// Load de la clase. Lleno los campos con los valores del objeto que recibio por parámetro. 
        /// Habilito los controles solamente de modificación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Publicacion_Editar_Load(object sender, EventArgs e)
        {
            try
            {
                publicacion = PublicacionDAO.obtenerPublicacion(publicacion.Id);
                llenarCampos();
                habilitaCamposParaModificacion();
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }

        /// <summary>
        /// Evento del boton Aceptar. 
        /// Cargo en el objeto de la clase los parámetros correspondientes de acuerdo a los campos insertados. Luego persisto en la BD
        /// Cierro la ventana devolviendo un OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnAceptar_Click(object sender, EventArgs e)
        {
             String camposConErrores;
            String camposEnCero;
            String campoParaSubasta;
            String campoEstado = "";
            try
            {

                camposConErrores = obtenerCamposConErrores();
                camposEnCero = obtenerCamposEnCero();
                Boolean campoVisibilidad = obtenerCampoVisibilidad();
                campoParaSubasta = obtenerCampoSubasta();
                if (publicacion.Estado == 1)
                    campoEstado = obtenerCampoEstado();

                if (campoVisibilidad && (campoEstado == "") && (camposConErrores == "") && (camposEnCero == "") && esValidoElEstado() && (campoParaSubasta == ""))
                {
                    armarPublicacionConCamposEdicion();
                    publicacion.modificar();
                    Metodos_Comunes.MostrarMensaje("La publicación " + publicacion.Descripcion+ " ha sido modificada correctamente");
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    if (camposEnCero != "")
                    {
                        Metodos_Comunes.MostrarMensaje("El Precio y la Cantidad deben ser mayores a cero");
                    }
                    if (camposConErrores != "")
                    {
                        Metodos_Comunes.MostrarMensaje("Debe completar todos los campos. Los campos incompletos son: " + camposConErrores);
                    }
                    if (!campoVisibilidad)
                    {
                        Metodos_Comunes.MostrarMensaje("Usted llego al limite de publicaciones gratuitas, por favor elija otro tipo de Visibilidad");
                    }
                    if (campoEstado != "")
                    {
                        Metodos_Comunes.MostrarMensaje("El estado de la publicacion solo puede ser BORRADOR o PUBLICADA");
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region MetodosGenerales

        /// <summary>
        /// Setea en el rol de la variable de la clase con los campos ingresados por el usuario.
        /// </summary>
        public void armarPublicacionConCamposEdicion()
        {
            int estado_nuevo;
            try
            { 

                List<Filtro> campos = obtenerCamposEnPantalla();
                estado_nuevo = Convert.ToInt32(campos[8].obtenerValor());
                if (publicacion.Estado == 1)
                {
                    publicacion.Tipo = ((FiltroComboBox)campos[0]).obtenerValorText();
                    publicacion.Descripcion = campos[1].obtenerValor().ToString();
                    publicacion.Precio = Convert.ToInt32(campos[2].obtenerValor());
                    publicacion.Cantidad = Convert.ToInt32(campos[3].obtenerValor());
                    publicacion.FechaInicio = Convert.ToDateTime(ConfigurationManager.AppSettings["DateTimeNow"]);
                    publicacion.AdmitePreguntas = (campos[6].obtenerValor().ToString() == "Admite" ? true : false);
                    publicacion.Visibilidad = Convert.ToInt32(campos[7].obtenerValor());
                    publicacion.AgregarRubros(campos[9].obtenerValor().ToString());
                    publicacion.Estado = estado_nuevo;
                }
                if (publicacion.Estado == 2)
                {
                    publicacion.Descripcion = campos[1].obtenerValor().ToString();
                    publicacion.Cantidad = Convert.ToInt32(campos[3].obtenerValor());
                    publicacion.Estado = estado_nuevo;
                }
                if (publicacion.Estado == 3)
                {
                    publicacion.Estado = estado_nuevo;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }



        /// <summary>
        /// Habilito o deshabilito los campos de acuerdo a los que son editables en la Modificacion.
        /// </summary>
        public void habilitaCamposParaModificacion()
        {
            try
            {
                List<Filtro> campos = obtenerCamposEnPantalla();
                //Si es borrador, puede modificar todo//
                if (publicacion.Estado == 1)
                {
                    campos[0].Enabled = true;
                    campos[1].Enabled = true;
                    campos[2].Enabled = true;
                    campos[3].Enabled = true;
                    campos[4].Enabled = true;
                    campos[5].Enabled = true;
                    campos[6].Enabled = true;
                    campos[7].Enabled = true;
                    campos[8].Enabled = true;
                    campos[9].Enabled = true;
                }

                //Si está activa, solo puede modificar precio, cantidad y estado//
                if (publicacion.Estado == 2)
                {
                    campos[0].Enabled = false;
                    campos[1].Enabled = true;
                    campos[2].Enabled = false;
                    campos[3].Enabled = true;
                    campos[4].Enabled = false;
                    campos[5].Enabled = false;
                    campos[6].Enabled = false;
                    campos[7].Enabled = false;
                    campos[8].Enabled = true;
                    campos[9].Enabled = false;
                }

                //Si está en pausa, solo puede modificar su estado//
                if (publicacion.Estado == 3)
                {
                    campos[0].Enabled = false;
                    campos[1].Enabled = false;
                    campos[2].Enabled = false;
                    campos[3].Enabled = false;
                    campos[4].Enabled = false;
                    campos[5].Enabled = false;
                    campos[6].Enabled = false;
                    campos[7].Enabled = false;
                    campos[8].Enabled = true;
                    campos[9].Enabled = false;
                }

                //Si está en finalizada, no puede modificar nada//
                if (publicacion.Estado == 4)
                {
                    campos[0].Enabled = false;
                    campos[1].Enabled = false;
                    campos[2].Enabled = false;
                    campos[3].Enabled = false;
                    campos[4].Enabled = false;
                    campos[5].Enabled = false;
                    campos[6].Enabled = false;
                    campos[7].Enabled = false;
                    campos[8].Enabled = false;
                    campos[9].Enabled = false;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Completo los campos con el valor del objeto que fue pasado por parámetro
        /// </summary>
        private void llenarCampos()
        {
            try
            {
                if (publicacion != null)
                {
                    List<Filtro> campos = obtenerCamposEnPantalla();
                    ((FiltroComboBox)campos[0]).colocarValorTexto(publicacion.Tipo);
                    campos[1].colocarValor(publicacion.Descripcion);
                    campos[2].colocarValor(publicacion.Precio);
                    campos[3].colocarValor(publicacion.Cantidad);
                    campos[4].colocarValor(publicacion.FechaInicio);
                    campos[5].colocarValor(publicacion.FechaFin);
                    ((FiltroComboBox)campos[6]).colocarValor(publicacion.AdmitePreguntas == true ? "Admite" : "No Admite");
                    ((FiltroComboBox)campos[7]).colocarValorTexto(publicacion.VisibilidadDesc);
                    ((FiltroComboBox)campos[8]).colocarValor(publicacion.Estado);
                    campos[9].colocarValor(publicacion.obtenerRubrosComoString());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Setea en el rol de la variable de la clase con los campos ingresados por el usuario.
        /// </summary>
        new public void armarPublicacionConCampos()
        {
            try
            {
                base.armarPublicacionConCampos();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


    }
}
