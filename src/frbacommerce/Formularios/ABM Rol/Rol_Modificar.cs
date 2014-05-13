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

        private Rol rol;

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
            try
            {
                List<Filtro> campos = obtenerCamposEnPantalla();
                rol.Id = Convert.ToInt32(campos[0].obtenerValor());
                rol.Descripcion = campos[1].obtenerValor();
                rol.Habilitado = (campos[2].obtenerValor() == "1" ? true : false);
                rol.modificar();

                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
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
            }
            catch (Exception ex)
            {
                throw ex;
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
                    campos[0].colocarValor(rol.Id);
                    campos[1].colocarValor(rol.Descripcion);
                    campos[2].colocarValor((rol.Habilitado ? 1 : 0));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region MetodosAuxiliares
        #endregion
    }
}
