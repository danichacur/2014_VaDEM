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

namespace FrbaCommerce.Formularios.Abm_Empresa
{
    public partial class Empresa_Agregar : Form_Agregar
    {

        #region VariablesDeClase

        public Empresa empresa;

        #endregion

        #region Eventos

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Empresa_Agregar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load de la clase. Creo el nuevo objeto de la clase. Genero los campos 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Empresa_Agregar_Load(object sender, EventArgs e)
        {
            try
            {
                if (empresa == null)
                {
                    empresa = new Empresa();
                }
                generarCampos();
                redefinirTamanioVentana();
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
                    insertarUsuarioDefault();
                    empresa.insertar();

                    DialogResult = System.Windows.Forms.DialogResult.OK;
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
                    username = obtenerUsernameDeEmpresa();
                }
                else
                {
                    username = obtenerUsernameDeEmpresa() + "2";
                }

                usr = new Usuario(username, empresa.Cuit, 3); //3 = Rol Empresa
                usr.insertar();

                usr = UsuarioDAO.obtenerUsuarioPorUsername(username);

                empresa.IdUsuario = usr.IdUsuario;
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
            FiltroFecha filtroDtp;
            List<Filtro> filtros;
            try
            {
                filtros = new List<Filtro>();

                filtroTxt = new FiltroTextBox("Razón Social", "RazonSocial", "LIKE", "");
                filtroTxt.setObligatorio(true);
                filtros.Add(filtroTxt);

                filtroTxt = new FiltroTextBox("CUIL", "CUIL");
                filtroTxt.setTipoTextoIngresado(FiltroTextBox.TipoTexto.Numerico);
                filtroTxt.setObligatorio(true);
                filtros.Add(filtroTxt);

                filtroTxt = new FiltroTextBox("Teléfono", "Telefono");
                filtroTxt.setTipoTextoIngresado(FiltroTextBox.TipoTexto.Numerico);
                filtroTxt.setObligatorio(true);
                filtros.Add(filtroTxt);

                filtroTxt = new FiltroTextBox("Dirección", "Direccion");
                filtroTxt.setObligatorio(true);
                filtros.Add(filtroTxt);

                filtroTxt = new FiltroTextBox("Número", "Numero");
                filtroTxt.setTipoTextoIngresado(FiltroTextBox.TipoTexto.Numerico);
                filtroTxt.setObligatorio(true);
                filtros.Add(filtroTxt);

                filtroTxt = new FiltroTextBox("Piso", "Piso");
                filtroTxt.setTipoTextoIngresado(FiltroTextBox.TipoTexto.Numerico);
                filtros.Add(filtroTxt);

                filtros.Add(new FiltroTextBox("Depto", "Dpto"));

                filtroTxt = new FiltroTextBox("Localidad", "Localidad");
                filtroTxt.setObligatorio(true);
                filtros.Add(filtroTxt);

                filtroTxt = new FiltroTextBox("Cod. Postal", "CodPostal");
                filtroTxt.setTipoTextoIngresado(FiltroTextBox.TipoTexto.Numerico);
                filtroTxt.setObligatorio(true);
                filtros.Add(filtroTxt);

                filtroTxt = new FiltroTextBox("Ciudad", "Ciudad");
                filtroTxt.setObligatorio(true);
                filtros.Add(filtroTxt);

                filtroTxt = new FiltroTextBox("Mail", "Email");
                filtroTxt.setObligatorio(true);
                filtros.Add(filtroTxt);

                filtroTxt = new FiltroTextBox("Nom. Contacto", "NombreContacto");
                filtroTxt.setObligatorio(true);
                filtros.Add(filtroTxt);

                filtroDtp = new FiltroFecha("Fecha Creación.", "FechaCreacion");
                filtroDtp.setObligatorio(true);
                filtros.Add(filtroDtp);

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
        public void armarEmpresaConCampos()
        {
            try
            {
                List<Filtro> campos = obtenerCamposEnPantalla();
                empresa.RazonSocial = campos[0].obtenerValor().ToString();
                empresa.Cuit = campos[1].obtenerValor().ToString();
                empresa.Telefono = campos[2].obtenerValor().ToString();
                empresa.Direccion = campos[3].obtenerValor().ToString();
                empresa.Numero = Convert.ToInt32(campos[4].obtenerValor());
                empresa.Piso = campos[5].obtenerValor().ToString();
                empresa.Departamento = campos[6].obtenerValor().ToString();
                empresa.Localidad = campos[7].obtenerValor().ToString();
                empresa.CodigoPostal = Convert.ToInt32(campos[8].obtenerValor());
                empresa.Cuidad = campos[9].obtenerValor().ToString();
                empresa.Email = campos[10].obtenerValor().ToString();
                empresa.NombreContacto = campos[11].obtenerValor().ToString();
                empresa.fechaCreacion = Convert.ToDateTime(campos[12].obtenerValor());
                //empresa.Habilitado = (campos[13].obtenerValor().ToString() == "1" ? true : false);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Agrega el filtro parámetro en la pantalla
        /// </summary>
        /// <param name="filtro"></param>
        public void agregarACamposEnPantalla(Filtro filtro)
        {
            try
            {
                List<Filtro> filtros = obtenerCamposEnPantalla();
                filtros.Add(filtro);

                this.ctrlAltaModificacion1.cargarFiltros(filtros);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Boolean pasaValidacionesVarias()
        {
            Boolean valida;
            try
            {
                valida = false;
                String camposConErrores;
                camposConErrores = obtenerCamposConErrores();
                if (camposConErrores == "")
                {
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
                                        valida = true;
                                    }
                                    else
                                    {
                                        Metodos_Comunes.MostrarMensaje("El Cuit ingresado no es válido, ya se encuentra asignado");
                                    }
                                }
                                else
                                {
                                    Metodos_Comunes.MostrarMensaje("El Cuit ingresado no es válido, el dígito identificador no coincide. Debería ser: " + CalcularDigitoCuit(obtenerCamposEnPantalla()[1].obtenerValor().ToString().Substring(0, 10)).ToString());
                                }
                            }
                            else
                            {
                                Metodos_Comunes.MostrarMensaje("El Cuit ingresado no es válido, debe tener 11 dígitos.");
                            }
                        }
                        else
                        {
                            Metodos_Comunes.MostrarMensaje("El teléfono ingresado ya está en uso.");
                        }
                    }
                    else
                    {
                        Metodos_Comunes.MostrarMensaje("La Razon Social y el Cuit ingresados ya están en uso.");
                    }
                }
                else
                {
                    Metodos_Comunes.MostrarMensaje("Debe completar todos los campos. Los campos incompletos son: " + camposConErrores);
                }

                return valida;
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

                if (UsuarioDAO.obtenerUsuarioPorUsername(obtenerUsernameDeEmpresa()) != null)
                    valida = false;

                return valida;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// En caso de que el Id de usuario esté en uso lanzo una excepción e interrumpo.
        /// </summary>
        private void validarUsernameNoEnUso()
        {
            try
            {
                List<Filtro> campos = obtenerCamposEnPantalla();

                if (UsuarioDAO.obtenerUsuarioPorUsername(obtenerUsernameDeEmpresa()) != null)
                {
                    throw new Exception("El Id Empresa ingresado ya está en uso.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna el username default de un cliente
        /// </summary>
        /// <returns></returns>
        private String obtenerUsernameDeEmpresa()
        {
            try
            {
                return empresa.RazonSocial + "-" + empresa.Cuit;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// cambia el tamaño de la pantalla de acuerdo a la cantidad de registros de la grilla de funcionalidades
        /// </summary>
        private void redefinirTamanioVentana()
        {
            int alto;
            try
            {
                alto = 544;
                this.Size = new System.Drawing.Size(this.Size.Width, alto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Verifica que el tipo y número de documento ingresado no se encuentre ya registrado en un cliente 
        /// </summary>
        /// <returns></returns>
        public Boolean validarRazonSocialYCuil()
        {
            String razonSocial, nroCuil;
            List<Filtro> campos;
            try
            {
                campos = obtenerCamposEnPantalla();
                razonSocial = (String)(campos[0].obtenerValor());
                nroCuil = (String)(campos[1].obtenerValor());

                return EmpresaDAO.verificarRazonSocialYCuil(razonSocial, nroCuil, empresa.IdUsuario);
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
            List<Filtro> campos;
            try
            {
                campos = obtenerCamposEnPantalla();
                telefonoIngresado = campos[2].obtenerValor().ToString();

                return ClienteDAO.verificarTelefonoNoEnUso(telefonoIngresado, empresa.IdUsuario);
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
            List<Filtro> campos;
            try
            {
                campos = obtenerCamposEnPantalla();
                cuitIngresado = campos[1].obtenerValor().ToString();
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
            List<Filtro> campos;
            string digitoIdentificadorValido;
            try
            {
                campos = obtenerCamposEnPantalla();
                cuitIngresado = campos[1].obtenerValor().ToString();
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
            List<Filtro> campos;
            try
            {
                campos = obtenerCamposEnPantalla();
                cuitIngresado = campos[1].obtenerValor().ToString();

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
            List<Filtro> campos;
            try
            {
                campos = obtenerCamposEnPantalla();
                cuitIngresado = campos[1].obtenerValor().ToString();

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
