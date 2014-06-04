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

namespace FrbaCommerce.Formularios.Abm_Visibilidad
{
    public partial class Visibilidad_Agregar : Form_Agregar
    {
        #region VariablesDeClase

        public Visibilidad visibilidad;

        #endregion

        #region Eventos
        
        public Visibilidad_Agregar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load de la clase. Creo el nuevo objeto de la clase. Genero los campos 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Visibilidad_Agregar_Load(object sender, EventArgs e)
        {
            try
            {
                if (visibilidad == null)
                {
                    visibilidad = new Visibilidad();
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
                
                    armarVisibilidadConCampos();
                    visibilidad.insertar();

                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    Metodos_Comunes.MostrarMensaje("Los siguientes campos contienen errores o están vacíos: " + camposConErrores);
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
            FiltroTextBox filtroTxt;
            try
            {
                List<Filtro> filtros = new List<Filtro>();
                filtroTxt = new FiltroTextBox("Id", "IdVisibilidad", "=", "");
                filtroTxt.setTipoTextoIngresado(FiltroTextBox.TipoTexto.Numerico);
                filtros.Add(filtroTxt);

                filtros.Add(new FiltroTextBox("Descripcion", "Descripcion", "LIKE", ""));

                filtroTxt = new FiltroTextBox("Costo Fijo", "CostoFijo", "=", "");
                filtroTxt.setTipoTextoIngresado(FiltroTextBox.TipoTexto.NumericoConComa);
                filtros.Add(filtroTxt);

                filtroTxt = new FiltroTextBox("Comision", "Comision", "=", "");
                filtroTxt.setTipoTextoIngresado(FiltroTextBox.TipoTexto.NumericoConComa);
                filtros.Add(filtroTxt);

                filtroTxt = new FiltroTextBox("Limite Sin Bonificar", "LimiteSinBonificar", "=", "");
                filtroTxt.setTipoTextoIngresado(FiltroTextBox.TipoTexto.Numerico);
                filtros.Add(filtroTxt);

                filtroTxt = new FiltroTextBox("Dias Vigencia", "DiasVigencia", "=", "");
                filtroTxt.setTipoTextoIngresado(FiltroTextBox.TipoTexto.Numerico);
                filtros.Add(filtroTxt);
                
                filtros.Add(new FiltroComboBox("Habilitado", "Habilitado", "=", "-1", Metodos_Comunes.obtenerTablaComboHabilitado(), "id", "descripcion"));
             
                this.ctrlAltaModificacion1.cargarFiltros(filtros);
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
        /// Setea en la visibilidad de la variable de la clase con los campos ingresados por el usuario.
        /// </summary>
        public void armarVisibilidadConCampos()
        {
            try
            {
                List<Filtro> campos = obtenerCamposEnPantalla();
                visibilidad.Id = Convert.ToInt32(campos[0].obtenerValor());
                visibilidad.Descripcion = campos[1].obtenerValor().ToString();
                visibilidad.CostoFijo = (float)Convert.ToDecimal(campos[2].obtenerValor());
                visibilidad.Comision = (float)Convert.ToDecimal(campos[3].obtenerValor());
                visibilidad.LimiteSinBonificar = Convert.ToInt16(campos[4].obtenerValor().ToString());
                visibilidad.DiasVigencia = Convert.ToInt16(campos[5].obtenerValor().ToString());
                visibilidad.Habilitado = (campos[6].obtenerValor().ToString() == "1" ? true : false);
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
                    if (campo.obtenerValor().ToString() == "") 
                        errores += campo.obtenerLabel() + ", ";
                    else
                    {
                        String cadena = campo.obtenerValor().ToString();
                        if (cadena.Length - cadena.Replace(",", "").Length > 1)
                        {
                            errores += campo.obtenerLabel() + ", ";
                        }
                    }
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

                if (VisibilidadDAO.obtenerVisibilidad(Convert.ToInt16(campos[0].obtenerValor())) != null)
                {
                    throw new Exception("El Id Visibilidad ingresado ya está en uso.");
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
