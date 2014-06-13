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

namespace FrbaCommerce.Formularios.ABM_Rol
{
    public partial class Rol_Modificar : Rol_Agregar
    {
        #region VariablesDeClase

        //private Rol rol;

        #endregion

        #region Eventos

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Rol_Modificar(Rol pRol)
        {
            try
            {
                rol = pRol;
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
        private void Rol_Modificar_Load(object sender, EventArgs e)
        {
            try
            {
                ponerCamposNuevos();
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
                    armarRolConCampos();
                    rol.modificar();

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
                campos[0].Enabled = true;
                campos[1].Enabled = true;
                campos[2].Enabled = true;
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
                if (rol != null)
                {
                    List<Filtro> campos = obtenerCamposEnPantalla();
                    campos[0].colocarValor(rol.Descripcion);
                    campos[1].colocarValor((rol.Habilitado ? 1 : 0));
                    campos[2].colocarValor(rol.obtenerFuncionalidadesComoString());
                    
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Se agregan a la pantalla los campos que no se necesitaban para el alta pero sí para la modificación
        /// </summary>
        private void ponerCamposNuevos()
        {
            FiltroComboBox filtroCbo;
            try
            {
                filtroCbo = new FiltroComboBox("Habilitado", "Habilitado", "=", "-1", Metodos_Comunes.obtenerTablaComboHabilitado(), "id", "descripcion");
                filtroCbo.setObligatorio(true);

                this.Height = 225 + this.Controls.Find("funcionalidades", true)[0].Size.Height;
                agregarACamposEnPantalla(filtroCbo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Setea en el rol de la variable de la clase con los campos ingresados por el usuario.
        /// </summary>
        new public void armarRolConCampos()
        {
            try
            {
                List<Filtro> campos = obtenerCamposEnPantalla();
                rol.Descripcion = campos[0].obtenerValor().ToString();
                rol.Habilitado = (campos[1].obtenerValor().ToString() == "1" ? true : false);
                rol.AgregarFuncionalidades(campos[2].obtenerValor().ToString());
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
