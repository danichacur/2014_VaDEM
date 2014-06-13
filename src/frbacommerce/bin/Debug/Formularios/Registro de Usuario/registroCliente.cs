using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Entidades;
using FrbaCommerce.Componentes_Comunes;

namespace FrbaCommerce.Formularios.Registro_de_Usuario
{
    public partial class registroCliente : UserControl
    {
        #region VariablesDeClase
        #endregion

        #region Eventos

        public registroCliente()
        {
            InitializeComponent();

            CargaComboTipoDocumento();
        }

        /// <summary>
        /// Evento key press de un textbox. Valida que el valor ingresaro sea numérico o que el boton sea retroceso (borrar)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCuil_KeyPress(object sender, KeyPressEventArgs e)
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

                if (txtDocumento.Text == "") camposErroneos += "Documento, ";
                if (txtNombre.Text == "") camposErroneos += "Nombre, ";
                if (txtApellido.Text == "") camposErroneos += "Apellido, ";
                if (txtMail.Text == "") camposErroneos += "Mail, ";
                if (txtTelefono.Text == "") camposErroneos += "Teléfono, ";
                if (txtDireccion.Text == "") camposErroneos += "Dirección, ";
                if (txtNumero.Text == "") camposErroneos += "Número, ";
                if (txtLocalidad.Text == "") camposErroneos += "Localidad, ";
                if (txtCodigoPostal.Text == "") camposErroneos += "Codigo Postal, ";
                if (txtCuil.Text == "") camposErroneos += "CUIL, ";

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
        /// Se genera el objeto cliente en base a los campos y se inserta la misma en la base de datos.
        /// </summary>
        /// <param name="usr"></param>
        public void grabarCliente(Usuario usr)
        {
            Cliente cliente;
            try
            {
                cliente = new Cliente(usr.IdUsuario, usr.Username, usr.Rol.Id, usr.Rol.Descripcion, usr.Rol.Habilitado,
                    usr.IntentosFallidos, usr.Bloqueado, usr.Habilitado, usr.Reputacion,
                    (long)Convert.ToDouble(txtDocumento.Text), cboTipoDocumento.Text,
                    txtNombre.Text, txtApellido.Text, txtMail.Text, txtTelefono.Text, txtDireccion.Text,
                    Convert.ToInt16(txtNumero.Text), txtPiso.Text, txtDepartamento.Text, txtLocalidad.Text,
                    Convert.ToInt16(txtCodigoPostal.Text), dtpFechaNacimiento.Value.Date, (long)Convert.ToDouble(txtCuil.Text));
                cliente.insertar();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region MetodosAuxiliares

        /// <summary>
        /// Lleno el combo de tipo de Documento con los posibles valores. No los obtengo de la BD
        /// </summary>
        private void CargaComboTipoDocumento()
        {
            try
            {
                DataTable tbl;
                DataRow row;
                DataColumn column;

                tbl = new DataTable("id", "descripcion");

                column = new DataColumn();
                column.ColumnName = "id";
                tbl.Columns.Add(column);

                column = new DataColumn();
                column.ColumnName = "descripcion";
                tbl.Columns.Add(column);

                row = tbl.NewRow();
                row["id"] = 0; row["descripcion"] = "DNI";
                tbl.Rows.Add(row);

                row = tbl.NewRow();
                row["id"] = 1; row["descripcion"] = "L.C.";
                tbl.Rows.Add(row);

                cboTipoDocumento.DataSource = Metodos_Comunes.obtenerTablaComboTipoDocumento();
                cboTipoDocumento.DisplayMember = "descripcion";
                cboTipoDocumento.ValueMember = "id";
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion       
    }
}
