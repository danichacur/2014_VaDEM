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
            catch (Exception)
            {
                throw;
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
            Usuario usr;
            try
            {
                FiltroTextBox txtUsername = (FiltroTextBox)this.Controls.Find("Username", false)[0];
                FiltroTextBoxPassword txtPassword = (FiltroTextBoxPassword)this.Controls.Find("Password", false)[0];
                if (txtUsername.obtenerValor() == "" && txtPassword.obtenerValor() == "")
                {
                    Metodos_Comunes.MostrarMensajeError("El usuario y contraseña son campos obligatorios");
                    return;
                }
                else if (txtUsername.obtenerValor() == "")
                {
                    Metodos_Comunes.MostrarMensajeError("El usuario es campo obligatorio");
                    return;
                }
                else if (txtPassword.obtenerValor() == "")
                {
                    Metodos_Comunes.MostrarMensajeError("El password es campo obligatorio");
                    return;
                }


                if (LoginDAO.validaUsuarioPassword(txtUsername.obtenerValor().ToString(), Metodos_Comunes.sha256_hash(txtPassword.obtenerValor().ToString())))
                {
                    usr = UsuarioDAO.obtenerUsuarioPorUsername(txtUsername.obtenerValor().ToString());
                    Session.IdUsuario = usr.IdUsuario;
                    Session.IdRol = usr.Rol.Id;

                    DialogResult = DialogResult.OK;
                    return;
                }
                else
                {
                    Metodos_Comunes.MostrarMensajeError("El usuario o contraseña son inválidos");
                }
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
        #endregion

        #region MetodosAuxiliares
        #endregion
    }
}