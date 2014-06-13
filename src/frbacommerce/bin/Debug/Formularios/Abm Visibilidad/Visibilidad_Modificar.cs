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

namespace FrbaCommerce.Formularios.Abm_Visibilidad
{
    public partial class Visibilidad_Modificar : Visibilidad_Agregar
    {
        #region VariablesDeClase

        #endregion

        #region Eventos
        public Visibilidad_Modificar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Visibilidad_Modificar(Visibilidad pVisib)
        {
            try
            {
                visibilidad = pVisib;
                InitializeComponent();
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }


        /// <summary>
        /// Load de la clase. Lleno los campos con los valores del objeto que recibio por parámetro. 
        /// Habilito los controles solamente de modificación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Visibilidad_Modificar_Load(object sender, EventArgs e)
        {
            try
            {
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
            try
            {
                camposConErrores = obtenerCamposConErrores();
                if (camposConErrores == "")
                {
                    armarVisibilidadConCampos();
                    visibilidad.modificar();

                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    Metodos_Comunes.MostrarMensaje("Debe completar todos los campos. Los campos incompletos son: " + camposConErrores);
                }

            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }

        #endregion

        #region MetodosGenerales

        /// <summary>
        /// Habilito o deshabilito los campos de acuerdo a los que son editables en la Modificacion.
        /// </summary>
        public void habilitaCamposParaModificacion()
        {
            try
            {
                List<Filtro> campos = obtenerCamposEnPantalla();
                campos[0].Enabled = false;
                campos[1].Enabled = true;
                campos[2].Enabled = true;
                campos[3].Enabled = true;
                campos[4].Enabled = true;
                campos[5].Enabled = true;
                campos[6].Enabled = true;
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
                if (visibilidad != null)
                {
                    List<Filtro> campos = obtenerCamposEnPantalla();
                    campos[0].colocarValor(visibilidad.Id);
                    campos[1].colocarValor(visibilidad.Descripcion);
                    campos[2].colocarValor(visibilidad.CostoFijo);
                    campos[3].colocarValor(visibilidad.Comision);
                    campos[4].colocarValor(visibilidad.LimiteSinBonificar);
                    campos[5].colocarValor(visibilidad.DiasVigencia);
                    campos[6].colocarValor((visibilidad.Habilitado ? 1 : 0));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        
        #region MetodosAuxiliares
        #endregion
    }
}
