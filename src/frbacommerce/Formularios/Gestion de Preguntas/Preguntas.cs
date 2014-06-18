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
using System.Configuration;
using FrbaCommerce.Datos;

namespace FrbaCommerce.Gestion_de_Preguntas
{
    public partial class Preguntas : ABM
    {

        #region VariablesDeClase

        private DataGridView dgv;

        #endregion

        #region Eventos
        public Preguntas()
        {
            InitializeComponent();
        }

        private void Preguntas_Load(object sender, EventArgs e)
        {
            try
            {
                cargaFiltros();
                cargaInicialGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Evento del click en cualquier parte de la grilla. Sólo se hace algo si se hace click en Modificar o Eliminar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Ignora los clicks que no son sobre las columnas con boton  
                if (e.RowIndex < 0 || (e.ColumnIndex != dgv.Columns["Responder"].Index)) return;


                if (e.ColumnIndex == dgv.Columns["Responder"].Index)
                {
                    btnResponder_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }

        /// <summary>
        /// Evento boton responder. Se abre la ventana de responder con la informacion correspondiente. Al regresar de la ventana
        /// valida que el resultado sea satisfactorio, en ese caso refresca la pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResponder_Click(object sender, DataGridViewCellEventArgs e)
        {
            System.Windows.Forms.DialogResult result;
            Pregunta pregunta;
            try
            {
                DataGridViewRow filaPreguntas = dgv.Rows[e.RowIndex];
                pregunta = new Pregunta(Convert.ToInt32(filaPreguntas.Cells["IdPregunta"].Value),
                    Convert.ToInt32(filaPreguntas.Cells["IdPublicacion"].Value), 
                    Convert.ToInt32(filaPreguntas.Cells["IdUsuario"].Value), 
                    Convert.ToDateTime(filaPreguntas.Cells["FechaPregunta"].Value),
                    Convert.ToString(filaPreguntas.Cells["Pregunta"].Value),
                     Convert.ToDateTime(ConfigurationManager.AppSettings["DateTimeNow"]),
                    Convert.ToString(filaPreguntas.Cells["Respuesta"].Value),
                    Convert.ToString(filaPreguntas.Cells["Descripcion"].Value),
                    Convert.ToString(filaPreguntas.Cells["Username"].Value));

                Formularios.Gestion_de_Preguntas.Respuesta formRespuesta = new Formularios.Gestion_de_Preguntas.Respuesta(pregunta);
                result = formRespuesta.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    ctrlABM1.buscar();
                }
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }


        #endregion

        #region MetodosGenerales


        private void cargaInicialGrilla()
        {
            try
            {
                aplicarFiltro("");
                dgv.CellClick -= new DataGridViewCellEventHandler(dgv_CellClick);
                dgv.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cargaFiltros()
        {
            FiltroFecha filtroFecha;
            DateTime valorDefault;
            try
            {
                if (!this.ctrlABM1.existenFiltrosCargados())
                {
                    List<Filtro> filtros = new List<Filtro>();
                    //filtros.Add(new FiltroTextBox("Id", "Id", "=", ""));
                    filtros.Add(new FiltroTextBox("Descripcion", "P.Descripcion", "LIKE", ""));
                    valorDefault = Convert.ToDateTime(ConfigurationManager.AppSettings["DateTimeNow"]);
                    filtroFecha = new FiltroFecha("Fecha Pregunta", "E.FechaPregunta", "=", valorDefault.ToString());
                    filtroFecha.setearDefault(valorDefault);
                    filtros.Add(filtroFecha);

                    this.ctrlABM1.cargarFiltros(filtros, null);
                }
             
            }
            catch (Exception)
            {
                throw;
            }

        }

        public override void aplicarFiltro(String clausulaWhere)
        {
            try
            {

                Object listaPreguntas = (Object)PreguntaDAO.obtenerPreguntas(clausulaWhere);

                DataGridViewColumn[] columnas = obtenerDisenoColumnasGrilla();

                dgv = this.ctrlABM1.cargarGrilla(listaPreguntas, columnas);

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
        public List<Filtro> obtenerFiltrosEnPantalla()
        {
            try
            {
                return ctrlABM1.obtenerFiltrosEnPantalla();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region MetodosAuxiliares

        /// <summary>
        /// Armo y devuelvo la lista de columnas que tendrá la grilla. Incluyo las propiedades de la coleccion que se le pase al 
        /// DataSource de la grilla y los botones
        /// </summary>
        /// <returns></returns>
        private DataGridViewColumn[] obtenerDisenoColumnasGrilla()
        {
            try
            {
                DataGridViewColumn[] columnas = new DataGridViewColumn[10];

                DataGridViewTextBoxColumn colPublicacion = new DataGridViewTextBoxColumn();
                colPublicacion.DataPropertyName = "Descripcion"; colPublicacion.Name = "Descripcion";
                colPublicacion.HeaderText = "Descripcion Publicacion";
                columnas[0] = colPublicacion;

                DataGridViewTextBoxColumn colPregunta = new DataGridViewTextBoxColumn();
                colPregunta.DataPropertyName = "Pregunta"; colPregunta.Name = "Pregunta";
                colPregunta.HeaderText = "Pregunta";
                columnas[1] = colPregunta;

                DataGridViewTextBoxColumn colUsuario = new DataGridViewTextBoxColumn();
                colUsuario.DataPropertyName = "Username"; colUsuario.Name = "Username";
                colUsuario.HeaderText = "Usuario Pregunta";
                columnas[2] = colUsuario;

                DataGridViewTextBoxColumn colFechaPregunta = new DataGridViewTextBoxColumn();
                colFechaPregunta.DataPropertyName = "FechaPregunta"; colFechaPregunta.Name = "FechaPregunta";
                colFechaPregunta.HeaderText = "Fecha Pregunta";
                columnas[3] = colFechaPregunta;

                DataGridViewTextBoxColumn colRespuesta = new DataGridViewTextBoxColumn();
                colRespuesta.DataPropertyName = "Respuesta"; colRespuesta.Name = "Respuesta";
                colRespuesta.HeaderText = "Respuesta";
                columnas[4] = colRespuesta;

                DataGridViewTextBoxColumn colFechaRespuesta = new DataGridViewTextBoxColumn();
                colFechaRespuesta.DataPropertyName = "FechaRespuesta"; colFechaRespuesta.Name = "FechaRespuesta";
                colFechaRespuesta.HeaderText = "Fecha Respuesta";
                columnas[5] = colFechaRespuesta;

                DataGridViewButtonColumn colResponder = new DataGridViewButtonColumn();
                colResponder.Width = 90;
                colResponder.Text = "Ver/Responder";
                colResponder.Name = "Responder";
                colResponder.UseColumnTextForButtonValue = true;
                columnas[6] = colResponder;

                DataGridViewTextBoxColumn colIdP = new DataGridViewTextBoxColumn();
                colIdP.DataPropertyName = "IdPregunta"; colIdP.Name = "IdPregunta";
                colIdP.HeaderText = "IdPregunta";
                colIdP.Visible = false;
                columnas[7] = colIdP;

                DataGridViewTextBoxColumn colIdPubli = new DataGridViewTextBoxColumn();
                colIdPubli.DataPropertyName = "IdPublicacion"; colIdPubli.Name = "IdPublicacion";
                colIdPubli.HeaderText = "IdPublicacion";
                colIdPubli.Visible = false;
                columnas[8] = colIdPubli;

                DataGridViewTextBoxColumn colIdUsu = new DataGridViewTextBoxColumn();
                colIdUsu.DataPropertyName = "IdUsuario"; colIdUsu.Name = "IdUsuario";
                colIdUsu.HeaderText = "IdUsuario";
                colIdUsu.Visible = false;
                columnas[9] = colIdUsu;

                return columnas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
