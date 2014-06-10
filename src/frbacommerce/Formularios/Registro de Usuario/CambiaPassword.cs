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

namespace FrbaCommerce.Formularios.Registro_de_Usuario
{
    public partial class CambiaPassword : Form
    {
        private Usuario usuario;

        public CambiaPassword(Usuario usr)
        {
            try
            {
                InitializeComponent();
                usuario = usr;
                cargarTextBoxUsername();
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
            
        }

        private void cargarTextBoxUsername() {
            try
            {
                txtUsername.Text = usuario.Username;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validaCamposCompletos())
                {
                    usuario.setPasswordDesencriptada(txtPassword.Text);
                    usuario.modificarPassword();
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }

        private Boolean validaCamposCompletos()
        {
            try
            {
                return txtPassword.Text != "";
            }
            catch (Exception)
            {   
                throw;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.Abort;
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }
    }
}
