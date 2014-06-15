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
using System.Configuration;

namespace FrbaCommerce.Formularios.Generar_Publicacion
{
    public partial class Publicacion_Alta : Form_Agregar
    {

        #region VariablesDeClase

        public Publicacion publicacion;

        #endregion

        #region Eventos

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Publicacion_Alta()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load de la clase. Creo el nuevo objeto de la clase. Genero los campos 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Publicacion_Alta_Load(object sender, EventArgs e)
        {
            try
            {
                if (publicacion == null)
                {
                    publicacion = new Publicacion();
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

            String camposConErrores;
            String camposEnCero;
            String campoEstado;
            String campoParaSubasta;
            Boolean campoVisibilidad;
            try
            {

                camposConErrores = obtenerCamposConErrores();
                camposEnCero = obtenerCamposEnCero();
                campoEstado = obtenerCampoEstado();
                campoParaSubasta = obtenerCampoSubasta();
                campoVisibilidad = obtenerCampoVisibilidad();

                if (campoVisibilidad && (camposConErrores == "") && (camposEnCero == "") && (campoEstado == "") && (campoParaSubasta == ""))
                {
                    armarPublicacionConCampos();
                    publicacion.insertar();

                    Metodos_Comunes.MostrarMensaje("Felicidades! Ha creado una nueva publicación para el articulo: "+ publicacion.Descripcion);

                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    if (camposEnCero != "")
                    {
                        Metodos_Comunes.MostrarMensaje("El Precio y la Cantidad deben ser mayores a cero");
                    }

                    if (campoEstado != "")
                    {
                        Metodos_Comunes.MostrarMensaje("El estado de la publicacion solo puede ser BORRADOR o ACTIVA");
                    }

                    if (camposConErrores != "")
                    {
                        Metodos_Comunes.MostrarMensaje("Debe completar todos los campos. Los campos incompletos son: " + camposConErrores);
                    }
                    if (!campoVisibilidad)
                    {
                        Metodos_Comunes.MostrarMensaje("Usted llego al limite de publicaciones gratuitas, por favor elija otro tipo de Visibilidad");
                    }
                }
            }
            catch (Exception)
            {
                throw;
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
        /// Crea una lista de campos (tipo filtro) y los agrega dinámicamente en el control AltaModificacion.
        /// </summary>
        private void generarCampos()
        {
            FiltroTextBox filtroTxt;
            FiltroComboBox filtroCbo;
            FiltroFecha filtroDtp;
            FiltroDgvCheck filtroRubros;

            try
            {

                List<Filtro> filtrosI = new List<Filtro>();
                List<Filtro> filtrosD = new List<Filtro>();


                filtroCbo = new FiltroComboBox("Tipo", "Tipo", "=", "", Metodos_Comunes.obtenerTablaComboTiposPublicacion(), "descripcion", "descripcion");
                filtroCbo.setObligatorio(true);
                filtrosI.Add(filtroCbo);

                /*filtroTxt = new FiltroTextBox("Codigo", "IdPublicacion");
                filtroTxt.setTipoTextoIngresado(FiltroTextBox.TipoTexto.Numerico);
                filtroTxt.setObligatorio(true);
                filtrosI.Add(filtroTxt);
                */
                filtroTxt = new FiltroTextBox("Descripcion", "Descripcion");
                filtroTxt.setObligatorio(true);
                filtrosI.Add(filtroTxt);

                filtroTxt = new FiltroTextBox("Precio", "PrecioInicial");
                filtroTxt.setTipoTextoIngresado(FiltroTextBox.TipoTexto.Numerico);
                filtroTxt.setObligatorio(true);
                filtrosI.Add(filtroTxt);

                filtroTxt = new FiltroTextBox("Cantidad", "Stock");
                filtroTxt.setTipoTextoIngresado(FiltroTextBox.TipoTexto.Numerico);
                filtroTxt.setObligatorio(true);
                filtrosI.Add(filtroTxt);
                
                filtroDtp = new FiltroFecha("Fecha Inicio", "FechaInicio");
                filtroDtp.setObligatorio(true);
                filtroDtp.Enabled = false;
                filtrosI.Add(filtroDtp);

                
                filtroDtp = new FiltroFecha("Fecha Fin", "FechaFin");
                filtroDtp.setObligatorio(true);
                filtroDtp.Enabled = false;
                filtrosI.Add(filtroDtp);
                
                filtroCbo = new FiltroComboBox("Admite Preguntas", "AdmitePreguntas", "=", "", Metodos_Comunes.obtenerTablaComboPreguntas(), "descripcion", "descripcion");
                filtroCbo.setObligatorio(true);
                filtrosI.Add(filtroCbo);

                filtroCbo = new FiltroComboBox("Visibilidad", "IdVisibilidad", "=", "0", obtenerVisibilidadHabilitadas(), "IdVisibilidad", "Descripcion");
                filtroCbo.setObligatorio(true);
                filtrosI.Add(filtroCbo);

                filtroRubros = new FiltroDgvCheck("Rubros", "Descripcion", "", obtenerListaRubros(), obtenerFormatoColumnas());
                filtroRubros.setObligatorio(true);
                filtrosD.Add(filtroRubros);

                filtroCbo = new FiltroComboBox("Estado", "IdEstado", "=", "0", obtenerEstados(), "IdEstado", "Descripcion");
                filtroCbo.setObligatorio(true);
                filtrosI.Add(filtroCbo);


                this.ctrlAltaModificacion1.cargarFiltros(filtrosI, filtrosD);

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
        public void armarPublicacionConCampos()
        {
            try
            {
                List<Filtro> campos = obtenerCamposEnPantalla();
                publicacion.Tipo = ((FiltroComboBox)campos[0]).obtenerValorText();
                publicacion.Descripcion = campos[1].obtenerValor().ToString();
                publicacion.Precio = Convert.ToInt32(campos[2].obtenerValor());
                publicacion.Cantidad = Convert.ToInt32(campos[3].obtenerValor());
                publicacion.FechaInicio = Convert.ToDateTime(ConfigurationManager.AppSettings["DateTimeNow"]);
                //Convert.ToDateTime(campos[4].obtenerValor());
                //publicacion.FechaFin = Convert.ToDateTime(campos[5].obtenerValor());
                publicacion.AdmitePreguntas = (campos[6].obtenerValor().ToString() == "Admite" ? true : false);
                publicacion.Visibilidad = Convert.ToInt32(campos[7].obtenerValor());
                publicacion.AgregarRubros(campos[9].obtenerValor().ToString());
                publicacion.Estado = Convert.ToInt32(campos[8].obtenerValor());

                /*
                DateTime fecha_actual = Convert.ToDateTime(ConfigurationManager.AppSettings["DateTimeNow"]);
                if (publicacion.FechaInicio < fecha_actual)
                {
                    publicacion.FechaInicio = fecha_actual;
                }*/


            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion

        #region MetodosAuxiliares

        /// <summary>
        /// Obtiene una lista de Visibilidades desde la base de datos.
        /// </summary>
        /// <returns></returns>
        private DataTable obtenerVisibilidadHabilitadas()
        {
            DataRow fila;
            try
            {

                String script = "SELECT IdVisibilidad, Descripcion FROM vadem.visibilidad WHERE Habilitado = 1";

                DataTable listaVisibilidad = PublicacionDAO.obtenerVisualizacion(script);

                fila = listaVisibilidad.NewRow();
                fila["IdVisibilidad"] = 0;
                fila["Descripcion"] = "";
                listaVisibilidad.Rows.InsertAt(fila, 0);

                return listaVisibilidad;
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene una lista de Rubros desde la base de datos.
        /// </summary>
        /// <returns></returns>
        private List<Object> obtenerListaRubros()
        {
            String script;
            List<Object> lista;
            List<Rubro> listaFunc;
            try
            {
                lista = new List<Object>();
                script = "SELECT * FROM vadem.rubro";
                listaFunc = RubroDAO.obtenerRubros(script);
                foreach (Rubro func in listaFunc)
                {
                    lista.Add((Object)func);
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// resuelve el formato de las columnas de la grilla de Rubros
        /// </summary>
        /// <returns></returns>
        private DataGridViewColumn[] obtenerFormatoColumnas()
        {
            DataGridViewColumn[] columnas;
            try
            {
                columnas = new DataGridViewColumn[2];

                DataGridViewTextBoxColumn colRubroId = new DataGridViewTextBoxColumn();
                colRubroId.DataPropertyName = "Id";
                colRubroId.Name = "Id";
                colRubroId.HeaderText = "ID";
                colRubroId.Visible = false;
                columnas[0] = colRubroId;

                DataGridViewTextBoxColumn colRubroDescripcion = new DataGridViewTextBoxColumn();
                colRubroDescripcion.DataPropertyName = "Descripcion";
                colRubroDescripcion.Name = "Descripcion";
                colRubroDescripcion.HeaderText = "Rubros";
                colRubroDescripcion.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colRubroDescripcion.ReadOnly = true;
                columnas[1] = colRubroDescripcion;

                return columnas;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// recorre todos los campos y devuelve un String con los campos que se cargaron con ceros
        /// </summary>
        /// <returns></returns>
         public String obtenerCamposEnCero()
        {
            String errores = "";
            try
            {
         
                List<Filtro> campos = obtenerCamposEnPantalla();
                int precio = Convert.ToInt32(campos[2].obtenerValor());
                int cantidad = Convert.ToInt32(campos[3].obtenerValor());

                if (precio <= 0)
                {
                    errores += campos[2].obtenerLabel();
                }
                else
                {
                    if (cantidad <= 0)
                    {
                        errores += campos[3].obtenerLabel();
                    }
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
         /// mira el campo elegido de Estado y valida que sea Borrador o Publicada nada mas
         /// </summary>
         /// <returns></returns>
         public Boolean obtenerCampoVisibilidad()
         {
             Boolean errores = true;
             try
             {
          
                 List<Filtro> campos = obtenerCamposEnPantalla();
                 int visibilidad = Convert.ToInt32(campos[7].obtenerValor());

                 if (visibilidad == 10006)  
                     errores = publicacion.validarVisibilidad();                     

                 return errores;
             }
             catch (Exception)
             {
                 throw;
             }
         }


        /// <summary>
         /// mira el campo elegido de Estado y valida que sea Borrador o Publicada nada mas
         /// </summary>
         /// <returns></returns>
         public String obtenerCampoSubasta()
         {
             String errores = "";
             try
             {
          
                 List<Filtro> campos = obtenerCamposEnPantalla();
                 string tipoPublic = ((FiltroComboBox)campos[0]).obtenerValorText();
                 int stock = Convert.ToInt32(campos[3].obtenerValor());

                 if ((tipoPublic == "Subasta") && (stock != 1)) 
                 {
                     errores += "Las subastas solo pueden tener stock 1.";
                     Metodos_Comunes.MostrarMensaje("Las subastas solo pueden tener cantidad = 1.");

                 }

                 return errores;
             }
             catch (Exception)
             {
                 throw;
             }
         }



         /// <summary>
         /// mira el campo elegido de Estado y valida que sea Borrador o Publicada nada mas
         /// </summary>
         /// <returns></returns>
         public String obtenerCampoEstado()
         {
             String errores = "";
             try
             {
          
                 List<Filtro> campos = obtenerCamposEnPantalla();
                 int estado = Convert.ToInt32(campos[8].obtenerValor());

                 if (estado != 1)  
                 {
                     if (estado != 2)
                        errores += campos[8].obtenerLabel();
                 }

                 return errores;
             }
             catch (Exception)
             {
                 throw;
             }
         }

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

        private DataTable obtenerEstados()
        {
            DataRow fila;
            try
            {
                String script = "SELECT * FROM vadem.estado ";

                DataTable listaEstados = PublicacionDAO.obtenerEstados(script);
                fila = listaEstados.NewRow();
                fila["IdEstado"] = 0;
                fila["Descripcion"] = "";
                listaEstados.Rows.InsertAt(fila, 0);

                return listaEstados;
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
        }


        /// <summary>
        /// cambia el tamaño de la pantalla de acuerdo a la cantidad de registros de la grilla de rubros
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

        public Boolean esValidoElEstado()
        {
            Boolean valida = false;
            Boolean stoc = true;
           // String script;
            List<Filtro> campos = obtenerCamposEnPantalla();
            int estado_nuevo = Convert.ToInt32(campos[8].obtenerValor());
            int stock_nuevo = Convert.ToInt32(campos[3].obtenerValor());
            try
            { // " + publicacion + "
              //  script = "SELECT IdEstado FROM vadem.publicacion WHERE IdPublicacion = "+ publicacion.Id;
              //   DataTable res = AccesoDatos.Instance.EjecutarScript(script);

               //  if (res.Rows[0][0] != null)
                // {
                //     estado_viejo = Convert.ToInt32(res.Rows[0][0]);

                     //estaba en estado borrador
                if ((publicacion.Estado == 1) && (estado_nuevo != 3))
                     {
                         valida = true;
                     }

                     // estaba en estado activa
                if ((publicacion.Estado == 2) && (estado_nuevo != 1))
                     {
                         valida = true;
                         // Validacion del stock que no sea menor al actual//
                        // string script2 = "SELECT Stock FROM vadem.publicacion WHERE IdPublicacion = " + publicacion.Id;
                        // DataTable res2 = AccesoDatos.Instance.EjecutarScript(script2);
                         //if (res2.Rows[0][0] != null)
                         //{
                          //   int stock_anterior = Convert.ToInt32(res2.Rows[0][0]);

                             if (stock_nuevo < publicacion.Cantidad)
                             {
                                 stoc = false;
                               Metodos_Comunes.MostrarMensaje("El stock debe ser mayor al actual.");
                         }

                     }

                     //estaba en estado pausada
                if ((publicacion.Estado == 3) && (estado_nuevo !=1))
                     {
                         valida = true;
                     }

                     //estaba en estado finalizada
                if ((publicacion.Estado == 4) && (estado_nuevo == 4))
                     {
                         valida = true;
                     }

                     if (valida == false)
                         Metodos_Comunes.MostrarMensaje("El estado elegido no está permitido.");
            //     }

                return (valida&stoc);
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
                List<Filtro> filtrosI = obtenerCamposEnPantalla();
                filtrosI.Add(filtro);

                this.ctrlAltaModificacion1.cargarFiltros(filtrosI);
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion
    }
}
