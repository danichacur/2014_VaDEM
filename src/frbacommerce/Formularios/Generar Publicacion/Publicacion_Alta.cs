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
            try
            {

                camposConErrores = obtenerCamposConErrores();
                if (camposConErrores == "")
                {
                    armarPublicacionConCampos();
                    publicacion.insertar();

                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    Metodos_Comunes.MostrarMensaje("Debe completar todos los campos. Los campos incompletos son: " + camposConErrores);
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

                filtroTxt = new FiltroTextBox("Codigo", "IdPublicacion");
                filtroTxt.setTipoTextoIngresado(FiltroTextBox.TipoTexto.Numerico);
                filtroTxt.setObligatorio(true);
                filtrosI.Add(filtroTxt);

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
                filtrosI.Add(filtroDtp);

                filtroDtp = new FiltroFecha("Fecha Fin", "FechaFin");
                filtroDtp.setObligatorio(true);
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
                publicacion.Id = Convert.ToInt32(campos[1].obtenerValor());
                publicacion.Descripcion = campos[2].obtenerValor().ToString();
                publicacion.Precio = Convert.ToInt32(campos[3].obtenerValor());
                publicacion.Cantidad = Convert.ToInt32(campos[4].obtenerValor());
                publicacion.FechaInicio = Convert.ToDateTime(campos[5].obtenerValor());;
                publicacion.FechaFin = Convert.ToDateTime(campos[6].obtenerValor());;
                publicacion.AdmitePreguntas = (campos[7].obtenerValor().ToString() == "Admite" ? true : false);
                publicacion.Visibilidad = Convert.ToInt32(campos[8].obtenerValor());
                publicacion.Estado = Convert.ToInt32(campos[10].obtenerValor());
                publicacion.AgregarRubros(campos[9].obtenerValor().ToString());


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
                        else
                        {
                            if (Convert.ToInt32(campo.obtenerValor()) == 0)
                                errores += campo.obtenerLabel() + ", ";
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

        #endregion
    }
}
