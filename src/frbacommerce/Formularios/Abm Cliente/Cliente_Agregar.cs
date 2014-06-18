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
                if( pasaValidacionesVarias())
                {
                    armarClienteConCampos();
                    insertarUsuarioDefault();
                    cliente.insertar();

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
                    username = obtenerUsernameDeCliente();
                }
                else 
                {
                    username = obtenerUsernameDeCliente() + "2";
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
            FiltroComboBox filtroCbo;
            FiltroFecha filtroDtp;
            try
            {
                List<Filtro> filtros = new List<Filtro>();

                filtroCbo = new FiltroComboBox("Tipo Doc", "TipoDocumento", "", "", Metodos_Comunes.obtenerTablaComboTipoDocumento(), "id", "descripcion");
                filtroCbo.setObligatorio(true);
                filtros.Add(filtroCbo);

                filtroTxt = new FiltroTextBox("Documento", "Documento");
                filtroTxt.setTipoTextoIngresado(FiltroTextBox.TipoTexto.Numerico);
                filtroTxt.setObligatorio(true);
                filtros.Add(filtroTxt);

                filtroTxt = new FiltroTextBox("Nombre", "Nombre");
                filtroTxt.setObligatorio(true);
                filtros.Add(filtroTxt);

                filtroTxt = new FiltroTextBox("Apellido", "Apellido");
                filtroTxt.setObligatorio(true);
                filtros.Add(filtroTxt);

                filtroTxt = new FiltroTextBox("Mail", "Email");
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

                filtroDtp = new FiltroFecha("Fecha Nac.", "FechaNacimiento");
                filtroDtp.setObligatorio(true);
                filtros.Add(filtroDtp);

                filtroTxt = new FiltroTextBox("CUIL", "CUIL");
                filtroTxt.setTipoTextoIngresado(FiltroTextBox.TipoTexto.Numerico);
                filtroTxt.setObligatorio(true);
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
                //cliente.Habilitado = (campos[14].obtenerValor().ToString() == "1" ? true: false);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public Boolean pasaValidacionesVarias() {
            Boolean valida;
            try
            {
                valida = false;
                String camposConErrores;
                camposConErrores = obtenerCamposConErrores();
                if (camposConErrores == "")
                {
                    if (validarTipoYNumeroDeDocumento())
                    {
                        if (validaTelefono())
                        {
                            if (validaInicioYCentroCuil())
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
                                        Metodos_Comunes.MostrarMensaje("El Cuit ingresado no es válido, el dígito identificador no coincide. Debería ser: " + CalcularDigitoCuit(obtenerCamposEnPantalla()[13].obtenerValor().ToString().Substring(0, 10)).ToString());
                                    }
                                }
                                else
                                {
                                    Metodos_Comunes.MostrarMensaje("El Cuit ingresado no es válido, debe tener 11 dígitos.");
                                }
                            }
                        }
                        else
                        {
                            Metodos_Comunes.MostrarMensaje("El teléfono ingresado ya está en uso.");
                        }
                    }
                    else
                    {
                        Metodos_Comunes.MostrarMensaje("El Tipo y Número de Documento ingresados ya están en uso.");
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
                    if (campo.obtenerObligatorio())
                        if (campo.obtenerValor().ToString() == "") 
                            errores += campo.obtenerLabel() + ", ";
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

                if (UsuarioDAO.obtenerUsuarioPorUsername(obtenerUsernameDeCliente()) != null)
                    valida = false;
                
                return valida;
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
        private String obtenerUsernameDeCliente() 
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

        /// <summary>
        /// Verifica que el tipo y número de documento ingresado no se encuentre ya registrado en un cliente 
        /// </summary>
        /// <returns></returns>
        public Boolean validarTipoYNumeroDeDocumento()
        {
            String tipoDocumentoIngresado, nroDocumentoIngresado;
            List<Filtro> campos;
            try
            {
                campos = obtenerCamposEnPantalla();
                tipoDocumentoIngresado = ((FiltroComboBox)campos[0]).obtenerValorText();
                nroDocumentoIngresado = (String)(campos[1].obtenerValor());

                return ClienteDAO.verificarTipoYNumeroDeDocumento(tipoDocumentoIngresado, nroDocumentoIngresado, cliente.IdUsuario);
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
                telefonoIngresado = campos[5].obtenerValor().ToString();

                return ClienteDAO.verificarTelefonoNoEnUso(telefonoIngresado, cliente.IdUsuario);
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
                cuitIngresado = campos[13].obtenerValor().ToString();
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
                cuitIngresado = campos[13].obtenerValor().ToString();
                digitoIdentificadorValido = CalcularDigitoCuit(cuitIngresado.Substring(0,10)).ToString();
                return cuitIngresado.Substring(10,1) == digitoIdentificadorValido;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Valida los 2 primeros digitos y el contenido del CUIL
        /// </summary>
        /// <returns></returns>
        private Boolean validaInicioYCentroCuil()
        {
            string cuilIngresado;
            List<Filtro> campos;
            Boolean inicio = false;
            Boolean fin = false;

            try
            {
                campos = obtenerCamposEnPantalla();
                cuilIngresado = campos[13].obtenerValor().ToString();
                if (cuilIngresado.Length > 10)
                {
                    int primerosDigitos = Convert.ToInt32(cuilIngresado.Substring(0, 2));
                    string mediosDigitos = Convert.ToString(cuilIngresado.Substring(2, 8));

                    if ((primerosDigitos == 27) || (primerosDigitos == 20) || (primerosDigitos == 23) || (primerosDigitos == 24))
                        inicio = true;
                    else
                        Metodos_Comunes.MostrarMensajeError("Los primeros dígitos del CUIL deben ser 23.");


                    String documento = Convert.ToString(campos[1].obtenerValor());
                    if (documento.Length < 8)
                        Metodos_Comunes.MostrarMensajeError("Su documento debe ser de 8 digitos, puede completar el inicio con ceros hasta llegar a los 8.");
                    else
                    {
                        if (Convert.ToString(mediosDigitos) != documento)
                            Metodos_Comunes.MostrarMensajeError("Los dígitos medios del CUIL deben ser iguales a su documento.");
                        else
                            fin = true;
                    }
                    return (inicio & fin);
                }
                else 
                {
                    Metodos_Comunes.MostrarMensajeError("La cantidad de dígitos ingresada en el CUIL es inferior a la permitida.");
                    return false;
                }
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
                cuitIngresado = campos[13].obtenerValor().ToString();

                return ClienteDAO.existeCUIT(cuitIngresado,cliente.IdUsuario);
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
                cuitIngresado = campos[13].obtenerValor().ToString();

                return EmpresaDAO.existeCUIL(cuitIngresado, cliente.IdUsuario);
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
