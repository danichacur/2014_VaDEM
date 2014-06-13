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

namespace FrbaCommerce.Formularios.Abm_Cliente
{
    public partial class Cliente_Modificar : Cliente_Agregar
    {
        #region VariablesDeClase
        #endregion

        #region Eventos

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="pCliente"></param>
        public Cliente_Modificar(Cliente pCliente)
        {
            try
            {
                cliente = pCliente;
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
        private void Cliente_Modificar_Load(object sender, EventArgs e)
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
            try
            {
                if (pasaValidacionesVarias())
                {
                    armarClienteConCampos();
                    cliente.modificar();

                    DialogResult = System.Windows.Forms.DialogResult.OK;
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
                campos[3].Enabled = true;
                campos[4].Enabled = true;
                campos[5].Enabled = true;
                campos[6].Enabled = true;
                campos[7].Enabled = true;
                campos[8].Enabled = true;
                campos[9].Enabled = true;
                campos[10].Enabled = true;
                campos[11].Enabled = true;
                campos[12].Enabled = true;
                campos[13].Enabled = true;
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
                if (cliente != null)
                {
                    List<Filtro> campos = obtenerCamposEnPantalla();
                    ((FiltroComboBox)campos[0]).colocarValorTexto(cliente.TipoDocumento);
                    campos[1].colocarValor(cliente.Documento);
                    campos[2].colocarValor(cliente.Nombre);
                    campos[3].colocarValor(cliente.Apellido);
                    campos[4].colocarValor(cliente.Email);
                    campos[5].colocarValor(cliente.Telefono);
                    campos[6].colocarValor(cliente.Direccion);
                    campos[7].colocarValor(cliente.Numero);
                    campos[8].colocarValor(cliente.Piso);
                    campos[9].colocarValor(cliente.Departamento);
                    campos[10].colocarValor(cliente.Localidad);
                    campos[11].colocarValor(cliente.CodigoPostal);
                    campos[12].colocarValor(cliente.FechaNacimiento);
                    campos[13].colocarValor(cliente.Cuil);
                    campos[14].colocarValor((cliente.Habilitado?"1":"0"));
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
        private void ponerCamposNuevos() {
            FiltroComboBox filtroCbo;
            try
            {
                filtroCbo = new FiltroComboBox("Habilitado", "Habilitado", "=", "-1", Metodos_Comunes.obtenerTablaComboHabilitado(), "id", "descripcion");
                filtroCbo.setObligatorio(true);

                this.Height = 96 +30;
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
        new public void armarClienteConCampos()
        {
            try
            {
                base.armarClienteConCampos();
                List<Filtro> campos = obtenerCamposEnPantalla();
                cliente.Habilitado = (campos[14].obtenerValor().ToString() == "1" ? true : false);
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
