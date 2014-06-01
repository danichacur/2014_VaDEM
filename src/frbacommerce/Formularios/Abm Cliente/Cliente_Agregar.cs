using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Componentes_Comunes;
using FrbaCommerce.Entidades;
using FrbaCommerce.Datos;

namespace FrbaCommerce.Formularios.Abm_Cliente
{
    public partial class Cliente_Agregar : Form_Agregar
    {

        #region VariablesDeClase

        public Cliente cliente;

        #endregion

        #region Eventos

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Cliente_Agregar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load de la clase. Creo el nuevo objeto de la clase. Genero los campos 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cliente_Agregar_Load(object sender, EventArgs e)
        {
            try
            {
                if (cliente == null)
                {
                    cliente = new Cliente();
                }
                generarCampos();
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
                    validarIdNoEnUso();

                    armarClienteConCampos();
                    cliente.insertar();

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
            //FiltroTextBox filtroTxt;
            try
            {
              //  List<Filtro> filtros = new List<Filtro>();

                /*filtroTxt = new FiltroTextBox("Id", "IdRol", "=", "");
                ((TextBox)filtroTxt.getTxtFiltro()).KeyPress += (new System.Windows.Forms.KeyPressEventHandler(this.numerico_KeyPress));
                filtros.Add(filtroTxt);

                filtros.Add(new FiltroTextBox("Descripcion", "Descripcion", "LIKE", ""));
                filtros.Add(new FiltroComboBox("Habilitado", "Habilitado", "=", "-1", Metodos_Comunes.obtenerTablaComboHabilitado(), "id", "descripcion"));
                filtros.Add(new FiltroDgvCheck("Funcionalidades", "funcionalidades", "", obtenerListaFuncionalidades(), obtenerFormatoColumnas()));
                */
                this.ctrlAltaModificacion1.cargarControlFiltros(new Formularios.Registro_de_Usuario.registroEmpresa());
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
        /// Setea en el rol de la variable de la clase con los campos ingresados por el usuario.
        /// </summary>
        public void armarClienteConCampos()
        {
            try
            {
                List<Filtro> campos = obtenerCamposEnPantalla();
               /* cliente.Id = Convert.ToInt32(campos[0].obtenerValor());
                cliente.Descripcion = campos[1].obtenerValor().ToString();
                cliente.Habilitado = (campos[2].obtenerValor().ToString() == "1" ? true : false);
                cliente.AgregarFuncionalidades(campos[3].obtenerValor().ToString());
                * */
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region MetodosAuxiliares

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
                    if (campo.obtenerValor().ToString() == "") errores += campo.obtenerLabel() + ", ";
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

        /// <summary>
        /// En caso de que el Id de usuario esté en uso lanzo una excepción e interrumpo.
        /// </summary>
        private void validarIdNoEnUso()
        {
            try
            {
                List<Filtro> campos = obtenerCamposEnPantalla();

                if (ClienteDAO.obtenerCliente(Convert.ToInt16(campos[0].obtenerValor())) != null)
                {
                    throw new Exception("El Id del Cliente ingresado ya está en uso.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        
    }
}
