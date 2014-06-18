using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Entidades;
using FrbaCommerce.Datos;
using FrbaCommerce.Componentes_Comunes;
using System.Configuration;

namespace FrbaCommerce.Formularios.Gestion_de_Preguntas
{
    public partial class Respuesta : Form_Agregar
    {

        #region VariablesDeClase

        public Pregunta pregunta;

        #endregion


        #region Eventos

        public Respuesta(Pregunta p_pregunta)
        {
            pregunta = p_pregunta;
            InitializeComponent();
        }


        private void Respuesta_Load(object sender, EventArgs e)
        {
            try
            {
                generarCampos();
                llenarCampos();
                habilitaCamposParaModificacion();
            }
            catch (Exception)
            {
                throw;
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
                    String rta_anterior = pregunta.Respuesta;

                    if (rta_anterior == "")
                    {
                        List<Filtro> campos = obtenerCamposEnPantalla();
                        pregunta.Respuesta = campos[4].obtenerValor().ToString();
                        pregunta.FechaRespuesta = Convert.ToDateTime(ConfigurationManager.AppSettings["DateTimeNow"]);
                        pregunta.responder();
                        Metodos_Comunes.MostrarMensaje("La pregunta ha sido respondida correctamente");
                    }
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }else
                    Metodos_Comunes.MostrarMensaje("Debe completar su respuesta.");


            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Evento del boton Cancelar.
        /// Devuelvo resultado Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                //DialogResult = System.Windows.Forms.DialogResult.Abort;
                Metodos_Comunes.MostrarMensajeError(ex);
            }
            finally
            {
                this.Close();
            }
        }

        #endregion

        #region MetodosGenerales

        /// <summary>
        /// Crea una lista de campos (tipo filtro) y los agrega dinámicamente en el control AltaModificacion.
        /// </summary>
        private void generarCampos()
        {
            FiltroTextBox filtroTxt;
            FiltroFecha filtroDtp;

            try
            {

                List<Filtro> filtros = new List<Filtro>();

                filtroTxt = new FiltroTextBox("Descripcion", "Descripcion");
                filtroTxt.setObligatorio(true);
                //  filtroTxt.Enabled = false;
                filtros.Add(filtroTxt);

                filtroDtp = new FiltroFecha("Fecha Pregunta", "FechaPregunta");
                filtroDtp.setObligatorio(true);
                //  filtroDtp.Enabled = false;
                filtros.Add(filtroDtp);

                filtroTxt = new FiltroTextBox("Usuario", "Username");
                filtroTxt.setObligatorio(true);
                //  filtroTxt.Enabled = false;
                filtros.Add(filtroTxt);

                filtroTxt = new FiltroTextBox("Pregunta", "Pregunta");
                filtroTxt.setObligatorio(true);
               // filtroTxt.Enabled = false;
                filtros.Add(filtroTxt);

                filtroTxt = new FiltroTextBox("Respuesta", "Respuesta");
                filtroTxt.setObligatorio(true);
                filtros.Add(filtroTxt);


                this.ctrlAltaModificacion1.cargarFiltros(filtros, null);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene del control AltaModificacion los campos que fueron cargados.
        /// </summary>
        /// <returns></returns>
        public List<Filtro> obtenerCamposEnPantalla()
        {
            try
            {
                return ctrlAltaModificacion1.obtenerCamposEnPantalla();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Habilito o deshabilito los campos de acuerdo a los que son editables.
        /// </summary>
        public void habilitaCamposParaModificacion()
        {
            try
            {
                List<Filtro> campos = obtenerCamposEnPantalla();
                    campos[0].Enabled = false;
                    campos[1].Enabled = false;
                    campos[2].Enabled = false;
                    campos[3].Enabled = false;

                    if (pregunta.Respuesta == "")
                        campos[4].Enabled = true;
                    else
                        campos[4].Enabled = false;

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
                if (pregunta != null)
                {
                    List<Filtro> campos = obtenerCamposEnPantalla();
                    campos[0].colocarValor(pregunta.DescPublicacion);
                    campos[1].colocarValor(pregunta.Fecha);
                    campos[2].colocarValor(pregunta.DescUsuario);
                    campos[3].colocarValor(pregunta.PreguntaDesc);
                    campos[4].colocarValor(pregunta.Respuesta);
                   
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// recorre todos los campos y devuelve un String con los campos con errores separados por coma
        /// </summary>
        /// <returns></returns>
        public String obtenerCamposConErrores()
        {
            String errores;
            try
            {
                errores = "";
                List<Filtro> campos = obtenerCamposEnPantalla();

                foreach (Filtro campo in campos)
                {
                    if (campo.obtenerObligatorio())
                        if (campo.obtenerValor().ToString() == "")
                            errores += campo.obtenerLabel() + ", ";
                }

                if (errores.Length > 0)
                    errores = errores.Substring(0, errores.Length - 2);

                return errores;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


    }
}
