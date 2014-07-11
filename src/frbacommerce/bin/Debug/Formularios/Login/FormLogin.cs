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

namespace FrbaCommerce.Formularios.Login
{
    public partial class FormLogin : Form
    {
        #region VariablesDeClase
        #endregion

        #region Eventos

        /// <summary>
        /// Constructor de la Clase.
        /// </summary>
        public FormLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load del login. Inserto los controles dinámicamente, y el evento keypress en el txtPassword
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormLogin_Load(object sender, EventArgs e)
        {
            Filtro filtro;
            try
            {
                filtro = new FiltroTextBox("Username", "Username", "=", "");
                filtro.Location = new Point(20, 20);
                filtro.TabIndex = 1;
                this.Controls.Add(filtro);

                filtro = new FiltroTextBoxPassword("Password", "Password", "=", "");
                filtro.Location = new Point(20, 60);
                filtro.agregarEventoKeyPress(new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress));
                filtro.TabIndex = 2;
                this.Controls.Add(filtro);
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }

        /// <summary>
        /// Si presiono Enter en el textbox password, se simula un Click en el boton Entrar para ahorrar tiempo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    btnEntrar.PerformClick();
                }
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }

        }

        /// <summary>
        /// Evento Click del boton Entrar
        /// Valido que los controles estan completos, informando en caso de que no lo esten. 
        /// Luego valido que los datos ingresados sean correctos, indicando si no lo son. 
        /// Luego cargo la session con los datos del usuario loggeado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                validarIngreso();
               
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }

        /// <summary>
        /// Evento click del boton Nuevo usuario, abre la ventana correspondiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUsuarioNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                Form regUsuario = new FrbaCommerce.Registro_de_Usuario.registroUsuario();
                regUsuario.ShowDialog();
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }

        #endregion

        #region MetodosGenerales

        private void validarIngreso() 
        {
            Usuario usr;
            System.Windows.Forms.DialogResult result;
            try
            {
                FiltroTextBox txtUsername = (FiltroTextBox)this.Controls.Find("Username", false)[0];
                FiltroTextBoxPassword txtPassword = (FiltroTextBoxPassword)this.Controls.Find("Password", false)[0];

                validarCamposCompletos(txtUsername, txtPassword);
                usr = UsuarioDAO.obtenerUsuarioPorUsername(txtUsername.obtenerValor().ToString());
                
                if (usr == null)
                {
                    Metodos_Comunes.MostrarMensajeError("El usuario ingresado no existe o fue eliminado");
                    return;
                }
                
                if (usr.Bloqueado)
                {
                    Metodos_Comunes.MostrarMensajeError("El usuario ingresado está bloqueado");
                    return;
                }

                if (!LoginDAO.validaUsuarioPassword(txtUsername.obtenerValor().ToString(), Metodos_Comunes.sha256_hash(txtPassword.obtenerValor().ToString())))
                {
                    Metodos_Comunes.MostrarMensajeError("La contraseña no coincide con el usuario");
                    aumentarIntentosFallidos(usr);
                    return;
                }

                if (usr.Rol.Id == 2 || usr.Rol.Id == 3)
                {
                    if (LoginDAO.esPrimerLoggeo(usr.IdUsuario))
                    {
                        Formularios.Registro_de_Usuario.CambiaPassword cambiaPass = new Formularios.Registro_de_Usuario.CambiaPassword(usr);
                        cambiaPass.ShowDialog();
                       
                        if (usr.Rol.Id == 2)
                        {
                            Cliente cliente = new Cliente();
                            cliente = ClienteDAO.obtenerCliente(usr.IdUsuario);
                            Metodos_Comunes.MostrarMensaje("Por unica vez debe validar sus datos.");
                            Formularios.Abm_Cliente.Cliente_Modificar actualizarCli = new Formularios.Abm_Cliente.Cliente_Modificar(cliente);
                            result = actualizarCli.ShowDialog();

                            if (result != System.Windows.Forms.DialogResult.OK)
                            {
                                throw new Exception("Debe validar sus datos para loggearse correctamente");
                            }
                
                        }
                        else
                        {
                            Empresa empresa = new Empresa();
                            empresa = EmpresaDAO.obtenerEmpresa(usr.IdUsuario);
                            Metodos_Comunes.MostrarMensaje("Por unica vez debe validar sus datos.");
                            Formularios.Abm_Empresa.Empresa_Modificar actualizarEmp = new Formularios.Abm_Empresa.Empresa_Modificar(empresa);
                            result = actualizarEmp.ShowDialog();

                            if (result != System.Windows.Forms.DialogResult.OK)
                            {
                                throw new Exception("Debe validar sus datos para loggearse correctamente");
                            }
                        }

                        usr.aumentarCantidadLoggeosSatisfactorios();


                        return;
                    }
                }
                
                Session.IdUsuario = usr.IdUsuario;
                Session.IdRol = usr.Rol.Id;

                usr.loggeoSatisfactorio();

                DialogResult = DialogResult.OK;
                return;
               
                


            }
            catch (Exception)
            {
                throw;
            }
        }

        private void validarCamposCompletos(FiltroTextBox txtUsername, FiltroTextBoxPassword txtPassword) 
        {
            try
            {
                if (txtUsername.obtenerValor().ToString() == "" && txtPassword.obtenerValor().ToString() == "")
                {
                    Metodos_Comunes.MostrarMensajeError("El usuario y contraseña son campos obligatorios");
                    return;
                }
                else if (txtUsername.obtenerValor().ToString() == "")
                {
                    Metodos_Comunes.MostrarMensajeError("El usuario es campo obligatorio");
                    return;
                }
                else if (txtPassword.obtenerValor().ToString() == "")
                {
                    Metodos_Comunes.MostrarMensajeError("El password es campo obligatorio");
                    return;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void aumentarIntentosFallidos(Usuario usr)
        {
            try
            {
                usr.aumentarIntentosFallidos();
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