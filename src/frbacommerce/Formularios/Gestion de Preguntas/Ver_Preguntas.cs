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

namespace FrbaCommerce.Formularios.Gestion_de_Preguntas
{
    public partial class Ver_Preguntas : Form
    {

        #region VariablesDeClase

        private Publicacion Publicacion { get; set; }
      //  private DataGridView dgv;

        #endregion

        #region Eventos

        public Ver_Preguntas(Publicacion Pub)
        {
            Publicacion = Pub;
            
            InitializeComponent();
        }

        private void Ver_Preguntas_Load(object sender, EventArgs e)
        {
            try
            {
                //this.ctrlABM1.ocultarBotonAlta();
                //cargaFiltros();
                cargaInicialGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region MetodosGenerales

        private void cargaInicialGrilla()
        {
            try
            {
                aplicarFiltro("");
               // dgv.CellClick -= new DataGridViewCellEventHandler(dgv_CellClick);
               // dgv.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
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

        }*/

        public void aplicarFiltro(String clausulaWhere)
        {
            try
            {
                
                clausulaWhere += " AND E.Respuesta IS NOT NULL AND P.IdPublicacion = " + Publicacion.Id;
                        
                Object listaPreguntas = (Object)PreguntaDAO.obtenerPreguntas(clausulaWhere);

                DataGridViewColumn[] columnas = obtenerDisenoColumnasGrilla();

                dataGridView1.Columns.Clear();
                if (dataGridView1.Columns.Count == 0)
                {
                    dataGridView1.Columns.AddRange(columnas);
                    dataGridView1.AutoGenerateColumns = false;
                }

                Object listDatos = listaPreguntas;
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = listDatos;
                //dgv = this.ctrlABM1.cargarGrilla(listaPreguntas, columnas);

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
       /* public List<Filtro> obtenerFiltrosEnPantalla()
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
        */
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
                colPublicacion.Visible = false;
                columnas[0] = colPublicacion;

                DataGridViewTextBoxColumn colPregunta = new DataGridViewTextBoxColumn();
                colPregunta.DataPropertyName = "Pregunta"; colPregunta.Name = "Pregunta";
                colPregunta.HeaderText = "Pregunta";
                columnas[3] = colPregunta;

                DataGridViewTextBoxColumn colUsuario = new DataGridViewTextBoxColumn();
                colUsuario.DataPropertyName = "Username"; colUsuario.Name = "Username";
                colUsuario.HeaderText = "Usuario Pregunta";
                columnas[2] = colUsuario;

                DataGridViewTextBoxColumn colFechaPregunta = new DataGridViewTextBoxColumn();
                colFechaPregunta.DataPropertyName = "FechaPregunta"; colFechaPregunta.Name = "FechaPregunta";
                colFechaPregunta.HeaderText = "Fecha Pregunta";
                columnas[1] = colFechaPregunta;

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
                colResponder.Visible = false;
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
