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
                    armarClienteConCampos();
                    insertarUsuarioDefault();
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
        /// Inserta un usuario con datos calculados automáticamente (username y pass)
        /// </summary>
        private void insertarUsuarioDefault()
        {
            Usuario usr;
            String username;
            try
            {
                if (validarUserNameNoEnUso())
                {
                    username = cliente.Documento + "-" + cliente.Apellido;
                }
                else 
                {
                    username = cliente.Documento + "-" + cliente.Apellido + "2";
                }
                
                usr = new Usuario(username, cliente.Apellido, 2); //2 = Rol Cliente
                usr.insertar();

                usr = UsuarioDAO.obtenerUsuarioPorUsername(username);

                cliente.IdUsuario = usr.IdUsuario;
            }
            catch (Exception)
            {   
                throw;
            }
        }


        /// <summary>
        /// Crea una lista de campos (tipo filtro) y los agrega dinámicamente en el control AltaModificacion.
        /// </summary>
        private void generarCampos()
        {
            FiltroTextBox filtroTxt;
            try
            {
                List<Filtro> filtros = new List<Filtro>();

                filtros.Add(new FiltroComboBox("Tipo Doc", "TipoDocumento", "", "", Metodos_Comunes.obtenerTablaComboTipoDocumento(), "id", "descripcion"));

                filtroTxt = new FiltroTextBox("Documento", "Documento");
                filtroTxt.setTipoTextoIngresado(FiltroTextBox.TipoTexto.Numerico); 
                filtros.Add(filtroTxt);

                filtros.Add(new FiltroTextBox("Nombre", "Nombre"));
                filtros.Add(new FiltroTextBox("Apellido", "Apellido"));
                filtros.Add(new FiltroTextBox("Mail", "Email"));

                filtroTxt = new FiltroTextBox("Teléfono", "Telefono");
                filtroTxt.setTipoTextoIngresado(FiltroTextBox.TipoTexto.Numerico);
                filtros.Add(filtroTxt);

                filtros.Add(new FiltroTextBox("Dirección", "Direccion"));

                filtroTxt = new FiltroTextBox("Número", "Numero");
                filtroTxt.setTipoTextoIngresado(FiltroTextBox.TipoTexto.Numerico);
                filtros.Add(filtroTxt);

                filtroTxt = new FiltroTextBox("Piso", "Piso");
                filtroTxt.setTipoTextoIngresado(FiltroTextBox.TipoTexto.Numerico);
                filtros.Add(filtroTxt);

                filtros.Add(new FiltroTextBox("Depto", "Dpto"));
                filtros.Add(new FiltroTextBox("Localidad", "Localidad"));

                filtroTxt = new FiltroTextBox("Cod. Postal", "CodPostal");
                filtroTxt.setTipoTextoIngresado(FiltroTextBox.TipoTexto.Numerico);
                filtros.Add(filtroTxt);

                filtros.Add(new FiltroFecha("Fecha Nac.", "FechaNacimiento"));

                filtroTxt = new FiltroTextBox("CUIL", "CUIL");
                filtroTxt.setTipoTextoIngresado(FiltroTextBox.TipoTexto.Numerico);
                filtros.Add(filtroTxt);

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
        /// Setea en el rol de la variable de la clase con los campos ingresados por el usuario.
        /// </summary>
        public void armarClienteConCampos()
        {
            try
            {
                List<Filtro> campos = obtenerCamposEnPantalla();
                cliente.TipoDocumento = ((FiltroComboBox)campos[0]).obtenerValorText();
                cliente.Documento = Convert.ToInt32(campos[1].obtenerValor());
                cliente.Nombre = campos[2].obtenerValor().ToString();
                cliente.Apellido = campos[3].obtenerValor().ToString();
                cliente.Email = campos[4].obtenerValor().ToString();
                cliente.Telefono = campos[5].obtenerValor().ToString();
                cliente.Direccion = campos[6].obtenerValor().ToString();
                cliente.Numero = Convert.ToInt32(campos[7].obtenerValor());
                cliente.Piso = campos[8].obtenerValor().ToString();
                cliente.Departamento = campos[9].obtenerValor().ToString();
                cliente.Localidad = campos[10].obtenerValor().ToString();
                cliente.CodigoPostal = Convert.ToInt32(campos[11].obtenerValor());
                cliente.FechaNacimiento = Convert.ToDateTime(campos[12].obtenerValor());
                cliente.Cuil = (long)Convert.ToDouble(campos[13].obtenerValor());
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
        private Boolean validarUserNameNoEnUso()
        {
            Boolean valida;
            try
            {
                valida = true;
                //List<Filtro> campos = obtenerCamposEnPantalla();

                if (UsuarioDAO.obtenerUsuarioPorUsername(obtenerIdUsuarioDeCliente()) != null)
                    valida = false;
                
                return valida;
            }
            catch (Exception)
            {
                throw;
            }
        }


        private String obtenerIdUsuarioDeCliente() 
        {
            try
            {
                return cliente.Documento + "-" + cliente.Apellido;
            }
            catch (Exception)
            {   
                throw;
            }
        }
        #endregion


        
    }
}
