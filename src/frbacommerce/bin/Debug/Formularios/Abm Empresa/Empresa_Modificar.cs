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

namespace FrbaCommerce.Formularios.Abm_Empresa
{
    public partial class Empresa_Modificar : Empresa_Agregar
    {
        #region VariablesDeClase
        #endregion

        #region Eventos

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="pEmpresa"></param>
        public Empresa_Modificar(Empresa pEmpresa)
        {
            try
            {
                InitializeComponent();
                empresa = pEmpresa;
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
        private void Empresa_Modificar_Load(object sender, EventArgs e)
        {
            try
            {
                if (empresa.IdUsuario == 1)
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
                    armarEmpresaConCampos();
                    empresa.modificar();

                    if (empresa.IdUsuario != 1)
                        Metodos_Comunes.MostrarMensaje("Gracias, por favor ingrese al sistema con su nueva clave");
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
                if (empresa.IdUsuario == 1)
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
                if (empresa != null)
                {
                    List<Filtro> campos = obtenerCamposEnPantalla();
                    campos[0].colocarValor(empresa.RazonSocial);
                    campos[1].colocarValor(empresa.Cuit);
                    campos[2].colocarValor(empresa.Telefono);
                    campos[3].colocarValor(empresa.Direccion);
                    campos[4].colocarValor(empresa.Numero);
                    campos[5].colocarValor(empresa.Piso);
                    campos[6].colocarValor(empresa.Departamento);
                    campos[7].colocarValor(empresa.Localidad);
                    campos[8].colocarValor(empresa.CodigoPostal);
                    campos[9].colocarValor(empresa.Cuidad);
                    campos[10].colocarValor(empresa.Email);
                    campos[11].colocarValor(empresa.NombreContacto);
                    campos[12].colocarValor(empresa.fechaCreacion);
                    if (empresa.IdUsuario == 1)
                        campos[13].colocarValor((empresa.Habilitado ? "1" : "0"));
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

                this.Height = 96 + 30;
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
        new public void armarEmpresaConCampos()
        {
            try
            {
                base.armarEmpresaConCampos();
                if (empresa.IdUsuario == 1)
                {
                    List<Filtro> campos = obtenerCamposEnPantalla();
                    empresa.Habilitado = (campos[13].obtenerValor().ToString() == "1" ? true : false);
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
