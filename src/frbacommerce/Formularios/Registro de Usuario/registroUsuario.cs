using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Componentes_Comunes;
using FrbaCommerce.Datos;
using FrbaCommerce.Entidades;

namespace FrbaCommerce.Registro_de_Usuario
{
    public partial class registroUsuario : Form
    {
        #region VariablesDeClase

        Control registroCliente, registroEmpresa;

        #endregion

        #region Eventos

        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        public registroUsuario()
        {
            try
            {
                InitializeComponent();
                registroCliente = new FrbaCommerce.Formularios.Registro_de_Usuario.registroCliente();
                registroCliente.Name = "registroCliente";
                registroCliente.Location = new Point(registroCliente.Location.X, 96);

                registroEmpresa = new FrbaCommerce.Formularios.Registro_de_Usuario.registroEmpresa();
                registroEmpresa.Name = "registroEmpresa";
                registroEmpresa.Location = new Point(registroEmpresa.Location.X, 96);

                CargaComboRol();
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }

        /// <summary>
        /// Evento Click del boton Aceptar
        /// En caso de no pasar las validaciones se informan los campos con errores. 
        /// Luego se procede a grabar el Usuario en la BD y si corresponde a un Cliente o Empresa tambien se graba. 
        /// Luego se informa que el proceso fue ejecutado correctamente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Usuario usr = null;
            String camposErroneos;
            try
            {
                //Si no valida los campos informo y detengo
                camposErroneos = camposConErrores();
                if (camposErroneos != "")
                {
                    Metodos_Comunes.MostrarMensajeError("No se puede grabar debido a que debe completar todos los campos obligatorios. Los campos faltantes son: " + camposErroneos);
                    return;
                }

                //Si pasa todas las validaciones anteriores grabo la informacion del usuario y del cliente o empresa
                usr = grabarUsuario();
                grabarTipoUsuario(usr);
                Metodos_Comunes.MostrarMensaje("Se ha creado satisfactoriamente el usuario: " + usr.Username + " bajo el Id: " + usr.IdUsuario);
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);

                //Si ya grabé el usuario pero pinchó en el grabado del tipo de usuario 
                //tengo que volver el cambio para no generar inconsistencia de datos
                if (usr != null)
                {
                    usr.eliminar();
                }
            }
        }

        /// <summary>
        /// Cierro la ventana sin hacer nada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = System.Windows.Forms.DialogResult.Abort;
            }
            catch (Exception ex)
            {   
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }

        /// <summary>
        /// Evento index changed del combo de roles
        /// si es Cliente o Empresa, muestro el control correspondiente, en caso contrario los oculto y ajusto el
        /// tamaño del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboRol.Text == "Cliente")
                {
                    this.Size = new System.Drawing.Size(this.Size.Width, 540);
                    this.Controls.Remove(registroEmpresa);
                    this.Controls.Add(registroCliente);
                }
                else if (cboRol.Text == "Empresa")
                {
                    this.Size = new System.Drawing.Size(this.Size.Width, 510);
                    this.Controls.Remove(registroCliente);
                    this.Controls.Add(registroEmpresa);
                }
                else
                {
                    this.Size = new System.Drawing.Size(this.Size.Width, 180);
                    this.Controls.Remove(registroCliente);
                    this.Controls.Remove(registroEmpresa);
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
        /// Devuelve una cadena con todos los campos que tienen errores (que no están completos y son obligatorios) 
        /// en todos los campos de la pantalla.
        /// </summary>
        /// <returns></returns>
        private String camposConErrores()
        {
            String camposIncompletos;
            try
            {
                camposIncompletos = camposConErroresUsuario();
                if (esClienteOEmpresa())
                {
                    camposIncompletos += camposConErroresEspecíficos();
                }
                //Le borro la coma y el espacio ", " que sobra
                if (camposIncompletos.Length > 0) camposIncompletos = camposIncompletos.Substring(0, camposIncompletos.Length - 2);

                return camposIncompletos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Devuelve una cadena con todos los campos que tienen errores (que no están completos y son obligatorios) 
        /// en los campos del Usuario
        /// </summary>
        /// <returns></returns>
        private String camposConErroresUsuario()
        {
            String camposErroneos;
            try
            {
                camposErroneos = "";

                if (txtUsername.Text == "") camposErroneos += "Username, ";
                if (txtPassword.Text == "") camposErroneos += "Password, ";
                if (cboRol.Text == "") camposErroneos += "Rol, ";

                //Valido que el username no coincida con uno ya existente en la BD
                if (txtUsername.Text != "")
                {
                    if (UsuarioDAO.obtenerUsuarioPorUsername(txtUsername.Text) != null)
                    {
                        throw new Exception("El username ingresado ya está en uso.");
                    }
                }

                return camposErroneos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Devuelve una cadena con todos los campos que tienen errores (que no están completos y son obligatorios) 
        /// en los campos del tipo de usuario específico, ya sea Cliente o Empresa
        /// </summary>
        /// <returns></returns>
        private String camposConErroresEspecíficos()
        {
            Control registro;
            String camposConErrores;
            try
            {
                camposConErrores = "";

                //No controlo que la cantidad sea mayor que 0 ya que lo validé anteriormente
                if (esCliente())
                {
                    //Delego en el control la responsabilidad de saber si validan los campos
                    registro = this.Controls.Find("registroCliente", true)[0];
                    camposConErrores = ((FrbaCommerce.Formularios.Registro_de_Usuario.registroCliente)registro).camposConErrores();
                }
                else if (esEmpresa())
                {
                    //Delego en el control la responsabilidad de saber si validan los campos
                    registro = this.Controls.Find("registroEmpresa", true)[0];
                    camposConErrores = ((FrbaCommerce.Formularios.Registro_de_Usuario.registroEmpresa)registro).camposConErrores();
                }

                return camposConErrores;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Se graba el Usuario correspondiente en la BD, sólo en la tabla de Usuarios
        /// </summary>
        /// <returns></returns>
        private Usuario grabarUsuario()
        {
            Usuario usr;
            try
            {
                usr = new Usuario(txtUsername.Text,
                                    txtPassword.Text,
                                    Convert.ToInt16(cboRol.SelectedValue));
                usr = usr.insertar();
                usr.aumentarCantidadLoggeosSatisfactorios();

                return usr;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// En caso de haber seleccionado Cliente o Empresa, se procede a grabar los datos correspondientes en la BD
        /// </summary>
        /// <param name="usr"></param>
        private void grabarTipoUsuario(Usuario usr)
        {
            Control registro;
            try
            {
                if (esClienteOEmpresa())
                {
                    if (esCliente())
                    {
                        //Delego en el control la responsabilidad de grabar
                        registro = this.Controls.Find("registroCliente", true)[0];
                        ((FrbaCommerce.Formularios.Registro_de_Usuario.registroCliente)registro).grabarCliente(usr);
                    }
                    else if (esEmpresa())
                    {
                        //Delego en el control la responsabilidad de grabar
                        registro = this.Controls.Find("registroEmpresa", true)[0];
                        ((FrbaCommerce.Formularios.Registro_de_Usuario.registroEmpresa)registro).grabarEmpresa(usr);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region MetodosAuxiliares

        /// <summary>
        /// Cargo el combo de roles con la info de la BD. Traigo solo los Roles habilitados.
        /// </summary>
        private void CargaComboRol()
        {
            List<Rol> itemsCombo, listaRolesConVacio;
            try
            {
                itemsCombo = RolDAO.obtenerRolesHabilitadosClienteEmpresa();

                listaRolesConVacio = new List<Rol>();
                listaRolesConVacio.Add(new Rol());
                foreach (Rol rol in itemsCombo) { listaRolesConVacio.Add(rol); }

                cboRol.DataSource = listaRolesConVacio;
                cboRol.DisplayMember = "Descripcion";
                cboRol.ValueMember = "Id";
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Devuelve true si está seleccionada la Empresa o el Cliente en el combo
        /// </summary>
        /// <returns></returns>
        private Boolean esClienteOEmpresa()
        {
            try
            {
                if (esCliente())
                    return true;
                else if (esEmpresa())
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Devuelve true si está seleccionada el Cliente en el combo
        /// </summary>
        /// <returns></returns>
        private Boolean esCliente()
        {
            try
            {
                return (cboRol.Text == "Cliente");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Devuelve true si está seleccionada la Empresa en el combo
        /// </summary>
        /// <returns></returns>
        private Boolean esEmpresa()
        {
            try
            {
                return (cboRol.Text == "Empresa");
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
