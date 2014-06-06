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

namespace FrbaCommerce.Formularios.Abm_Empresa
{
    public partial class Empresa_Agregar : Form_Agregar
    {

        #region VariablesDeClase

        public Empresa empresa;

        #endregion

        #region Eventos

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Empresa_Agregar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load de la clase. Creo el nuevo objeto de la clase. Genero los campos 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Empresa_Agregar_Load(object sender, EventArgs e)
        {
            try
            {
                if (empresa == null)
                {
                    empresa = new Empresa();
                }
                generarCampos();
                redefinirTamanioVentana();
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
                    
                    armarEmpresaConCampos();
                    empresa.insertar();

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
           // FiltroTextBox filtroTxt;
            try
            {
             //   List<Filtro> filtros = new List<Filtro>();

                //filtros.Add(new FiltroTextBox("Razón Social", "RazonSocial", "LIKE", ""));
                //filtros.Add(new FiltroTextBox("Direc Calle", "Direccion", "LIKE", ""));
                //filtros.Add(new FiltroTextBox("Departamento", "Dpto", "=", ""));
                //filtros.Add(new FiltroTextBox("Telefono", "Telefono", "=", ""));
                //filtros.Add(new FiltroTextBox("Piso", "Piso", "=", ""));
                
                this.ctrlAltaModificacion1.cargarControlFiltros(new Registro_de_Usuario.registroEmpresa());
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
        public void armarEmpresaConCampos()
        {
            try
            {
                List<Filtro> campos = obtenerCamposEnPantalla();
                /*empresa.Id = Convert.ToInt32(campos[0].obtenerValor());
                empresa.Descripcion = campos[1].obtenerValor().ToString();
                empresa.Habilitado = (campos[2].obtenerValor().ToString() == "1" ? true : false);
                empresa.AgregarFuncionalidades(campos[3].obtenerValor().ToString());
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

                if (EmpresaDAO.obtenerEmpresa(Convert.ToInt16(campos[0].obtenerValor())) != null)
                {
                    throw new Exception("El Id Empresa ingresado ya está en uso.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// cambia el tamaño de la pantalla de acuerdo a la cantidad de registros de la grilla de funcionalidades
        /// </summary>
        private void redefinirTamanioVentana()
        {
            int alto;
            try
            {
                alto = 225;
                this.Size = new System.Drawing.Size(this.Size.Width, alto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
       
    }
}
