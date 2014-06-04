using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Entidades;

namespace FrbaCommerce.Formularios.Registro_de_Usuario
{
    public partial class registroEmpresa : UserControl
    {
        #region VariablesDeClase
        #endregion

        #region Eventos

        public registroEmpresa()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento key press de un textbox. Valida que el valor ingresaro sea numérico o que el boton sea retroceso (borrar)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar)) { e.Handled = true; }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar)) { e.Handled = true; }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar)) { e.Handled = true; }
        }

        private void txtPiso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar)) { e.Handled = true; }
        }

        private void txtCodigoPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar)) { e.Handled = true; }
        }

        #endregion

        #region MetodosGenerales

        /// <summary>
        /// Devuelve una cadena con todos los campos que tienen errores (que no están completos y son obligatorios) 
        /// </summary>
        /// <returns></returns>
        public String camposConErrores()
        {
            String camposErroneos;
            try
            {
                camposErroneos = "";

                if (txtRazonSocial.Text == "") camposErroneos += "Razón Social, ";
                if (txtCuit.Text == "") camposErroneos += "CUIT, ";
                if (txtTelefono.Text == "") camposErroneos += "Teléfono, ";
                if (txtDireccion.Text == "") camposErroneos += "Dirección, ";
                if (txtNumero.Text == "") camposErroneos += "Número, ";
                if (txtLocalidad.Text == "") camposErroneos += "Localidad, ";
                if (txtCodigoPostal.Text == "") camposErroneos += "Codigo Postal, ";
                if (txtMail.Text == "") camposErroneos += "Mail, ";
                if (txtRazonSocial.Text == "") camposErroneos += "Social, ";

                //Valido que el teléfono ingresado no coincida con uno ya existente
                //TODO

                return camposErroneos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Se genera el objeto empresa en base a los campos y se inserta la misma en la base de datos.
        /// </summary>
        /// <param name="usr"></param>
        public void grabarEmpresa(Usuario usr)
        {
            Empresa empresa;
            try
            {
                empresa = new Empresa(usr.IdUsuario, usr.Username, usr.Rol.Id, usr.Rol.Descripcion, usr.Rol.Habilitado, usr.IntentosFallidos,
                    usr.Bloqueado, usr.Habilitado, usr.Reputacion,
                    txtRazonSocial.Text, (long)Convert.ToDouble(txtCuit.Text), txtTelefono.Text,
                    txtDireccion.Text, Convert.ToInt32(txtNumero.Text), txtPiso.Text, txtDepartamento.Text, txtLocalidad.Text,
                    Convert.ToInt32(txtCodigoPostal.Text), txtCiudad.Text, txtMail.Text, txtNombreContacto.Text,
                    dtpFechaNacimiento.Value);
                empresa.insertar();
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
