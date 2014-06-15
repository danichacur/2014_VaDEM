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
using FrbaCommerce.Datos;

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
                if (validarRazonSocialYCuil())
                {
                    if (validaTelefono())
                    {
                        if (validaCuitCantidadDigitos())
                        {
                            if (validaCuitDigitoVerificador())
                            {
                                if (validaCuitNoRepetido())
                                {
                                    
                                }
                                else
                                {
                                   throw new Exception("El Cuit ingresado no es válido, ya se encuentra asignado");
                                }
                            }
                            else
                            {
                                throw new Exception("El Cuit ingresado no es válido, el dígito identificador no coincide. Debería ser: " + CalcularDigitoCuit(txtCuit.Text.Substring(0, 10)).ToString());
                            }
                        }
                        else
                        {
                            throw new Exception("El Cuit ingresado no es válido, debe tener 11 dígitos.");
                        }
                    }
                    else
                    {
                        throw new Exception("El teléfono ingresado ya está en uso.");
                    }
                }
                else
                {
                    throw new Exception("La Razon Social y el Cuit ingresados ya están en uso.");
                }

                
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
                    txtRazonSocial.Text, txtCuit.Text, txtTelefono.Text,
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

        /// <summary>
        /// Verifica que el tipo y número de documento ingresado no se encuentre ya registrado en un cliente 
        /// </summary>
        /// <returns></returns>
        public Boolean validarRazonSocialYCuil()
        {
            String razonSocial, nroCuil;
            try
            {
                razonSocial = (String)(txtRazonSocial.Text);
                nroCuil = (String)(txtCuit.Text);

                return EmpresaDAO.verificarRazonSocialYCuil(razonSocial, nroCuil, 0);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Verifica que el teléfono ingresado no se encuentre ya registrado en un cliente o empresa
        /// </summary>
        /// <returns></returns>
        public Boolean validaTelefono()
        {
            String telefonoIngresado;
            try
            {
                telefonoIngresado = txtTelefono.Text;

                return ClienteDAO.verificarTelefonoNoEnUso(telefonoIngresado, 0);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Verifico que la cantidad de dígitos sea igual a 11
        /// </summary>
        /// <returns></returns>
        private Boolean validaCuitCantidadDigitos()
        {
            string cuitIngresado;
            try
            {
                cuitIngresado = txtCuit.Text;
                return cuitIngresado.Length == 11;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Valido que el código identificador se corresponda con el resto del código
        /// </summary>
        /// <returns></returns>
        private Boolean validaCuitDigitoVerificador()
        {
            string cuitIngresado;
           string digitoIdentificadorValido;
            try
            {
                cuitIngresado = txtCuit.Text;
                digitoIdentificadorValido = CalcularDigitoCuit(cuitIngresado.Substring(0, 10)).ToString();
                return cuitIngresado.Substring(10, 1) == digitoIdentificadorValido;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Valida en la tabla de clientes y de empresas que el cuit ingresado no exista
        /// </summary>
        /// <returns></returns>
        private Boolean validaCuitNoRepetido()
        {
            Boolean valida;
            try
            {
                valida = true;
                if (cuitExisteEnClientes())
                    valida = false;
                else if (cuilExisteEnEmpresas())
                    valida = false;

                return valida;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Boolean cuitExisteEnClientes()
        {
            string cuitIngresado;
            try
            {
                cuitIngresado = txtCuit.Text;

                return ClienteDAO.existeCUIT(cuitIngresado);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Boolean cuilExisteEnEmpresas()
        {
            string cuitIngresado;
            try
            {
                cuitIngresado = txtCuit.Text;
                return EmpresaDAO.existeCUIL(cuitIngresado);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Calcula el dígito verificador dado un CUIT completo o sin él.
        /// </summary>
        /// <param name="cuit">El CUIT como String sin guiones</param>
        /// <returns>El valor del dígito verificador calculado.</returns>
        private int CalcularDigitoCuit(string cuit)
        {
            try
            {
                int[] mult = new[] { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
                char[] nums = cuit.ToCharArray();
                int total = 0;
                for (int i = 0; i < mult.Length; i++)
                {
                    total += int.Parse(nums[i].ToString()) * mult[i];
                }
                var resto = total % 11;
                return resto == 0 ? 0 : resto == 1 ? 9 : 11 - resto;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
