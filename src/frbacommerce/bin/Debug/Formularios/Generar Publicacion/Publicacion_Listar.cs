using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Componentes_Comunes;
using FrbaCommerce.Datos;
using FrbaCommerce.Entidades;
using FrbaCommerce.Formularios;


namespace FrbaCommerce.Generar_Publicacion
{
    public partial class Publicacion_Listar : ABM
    {

        #region VariablesDeClase

        private DataGridView dgv;

        #endregion

        #region Eventos
        public Publicacion_Listar()
        {
            InitializeComponent();
        }

        private void Publicacion_Listar_Load(object sender, EventArgs e)
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
        /// Evento del boton Alta. Se abre la ventana de alta. Al regresar de la ventana
        /// valida que el resultado sea satisfactorio, en ese caso refresca la pantalla
        /// </summary>
        public override void btnAlta_Click()
        {
            System.Windows.Forms.DialogResult result;
            try
            {
                Formularios.Generar_Publicacion.Publicacion_Alta formAlta = new Formularios.Generar_Publicacion.Publicacion_Alta();
                result = formAlta.ShowDialog();

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
                if (e.RowIndex < 0 || (e.ColumnIndex != dgv.Columns["Editar"].Index)) return;
                

                if (e.ColumnIndex == dgv.Columns["Editar"].Index)
                {
                    btnModificar_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }

        /// <summary>
        /// Evento boton modificar. Se abre la ventana de modificar con la informacion correspondiente. Al regresar de la ventana
        /// valida que el resultado sea satisfactorio, en ese caso refresca la pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificar_Click(object sender, DataGridViewCellEventArgs e)
        {
            System.Windows.Forms.DialogResult result;
            Publicacion publicacion;
            try
            {
                DataGridViewRow filaPublicacion = dgv.Rows[e.RowIndex];
                publicacion = new Publicacion(Convert.ToInt32(filaPublicacion.Cells["IdPublicacion"].Value),
                    Convert.ToString(filaPublicacion.Cells["Descripcion"].Value),
                    Convert.ToString(filaPublicacion.Cells["Estado"].Value),
                    Convert.ToString(filaPublicacion.Cells["Tipo"].Value),
                    Convert.ToInt32(filaPublicacion.Cells["PrecioInicial"].Value),
                    Convert.ToInt32(filaPublicacion.Cells["Stock"].Value),
                    (filaPublicacion.Cells["Admite_Preguntas"].ToString() == "SI" ? true : false),
                    Convert.ToString(filaPublicacion.Cells["Visibilidad"].Value),
                    Convert.ToDateTime(filaPublicacion.Cells["FechaInicio"].Value),
                    Convert.ToDateTime(filaPublicacion.Cells["FechaFin"].Value));

                Formularios.Generar_Publicacion.Publicacion_Editar formModificar = new Formularios.Generar_Publicacion.Publicacion_Editar(publicacion);
                result = formModificar.ShowDialog();

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
                    List<Filtro> filtrosI = new List<Filtro>();
                    filtrosI.Add(new FiltroComboBox("Tipo", "T.Descripcion", "=", "", obtenerTiposPublicacion(), "descripcion", "descripcion"));
                    filtrosI.Add(new FiltroComboBox("Estado", "P.IdEstado", "=", "0", obtenerEstados(), "IdEstado", "Descripcion"));
                    filtrosI.Add(new FiltroTextBox("Descripcion", "P.Descripcion", "LIKE", ""));


                    List<Filtro> filtrosD = new List<Filtro>();
                    filtrosD.Add(new FiltroComboBox("Visibilidad", "P.IdVisibilidad", "=", "0", obtenerVisibilidadHabilitadas(), "IdVisibilidad", "Descripcion"));
                    valorDefault = Convert.ToDateTime("01/01/1900");
                    filtroFecha = new FiltroFecha("Fecha Fin", "FechaFin", "<=", valorDefault.ToString());
                    filtroFecha.setearDefault(valorDefault);
                    filtrosD.Add(filtroFecha);


                    this.ctrlABM1.cargarFiltros(filtrosI, filtrosD);
                }
         /*       else
                {
                    List<Filtro> filtros = obtenerFiltrosEnPantalla();
                    ((FiltroComboBox)filtros[3]).colocarValor(obtenerVisibilidadHabilitadas());

                }*/
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message + ex.Source);
            }

        }

        public override void aplicarFiltro(String clausulaWhere)
        {
            try
            {

                Object listaPublicaciones = (Object)PublicacionDAO.obtenerPublicaciones(clausulaWhere);

                DataGridViewColumn[] columnas = obtenerDisenoColumnasGrilla();

                dgv = this.ctrlABM1.cargarGrilla(listaPublicaciones, columnas);

            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
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

        private DataTable obtenerTiposPublicacion()
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
                row["id"] = 0; row["descripcion"] = "";
                tbl.Rows.Add(row);

                row = tbl.NewRow();
                row["id"] = 1; row["descripcion"] = "Compra Inmediata";
                tbl.Rows.Add(row);

                row = tbl.NewRow();
                row["id"] = 2; row["descripcion"] = "Subasta";
                tbl.Rows.Add(row);

                return tbl;
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
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
        /// Armo y devuelvo la lista de columnas que tendrá la grilla. Incluyo las propiedades de la coleccion que se le pase al 
        /// DataSource de la grilla y los botones
        /// </summary>
        /// <returns></returns>
        private DataGridViewColumn[] obtenerDisenoColumnasGrilla()
        {
            try
            {

                DataGridViewColumn[] columnas = new DataGridViewColumn[11];

                DataGridViewTextBoxColumn colEstado = new DataGridViewTextBoxColumn();
                colEstado.DataPropertyName = "Estado"; colEstado.Name = "Estado";
                colEstado.HeaderText = "Estado";
                columnas[0] = colEstado;

                DataGridViewTextBoxColumn colDescripcion = new DataGridViewTextBoxColumn();
                colDescripcion.DataPropertyName = "Descripcion"; colDescripcion.Name = "Descripcion";
                colDescripcion.HeaderText = "Descripcion";
                columnas[1] = colDescripcion;

                DataGridViewTextBoxColumn colPrecioInicial = new DataGridViewTextBoxColumn();
                colPrecioInicial.DataPropertyName = "PrecioInicial"; colPrecioInicial.Name = "PrecioInicial";
                colPrecioInicial.HeaderText = "PrecioInicial";
                columnas[2] = colPrecioInicial;

                DataGridViewTextBoxColumn colStock = new DataGridViewTextBoxColumn();
                colStock.DataPropertyName = "Stock"; colStock.Name = "Stock";
                colStock.HeaderText = "Stock";
                columnas[3] = colStock;

                DataGridViewTextBoxColumn colTipo = new DataGridViewTextBoxColumn();
                colTipo.DataPropertyName = "TipoPublicacion"; colTipo.Name = "Tipo"; colTipo.HeaderText = "Tipo";
                columnas[4] = colTipo;

                DataGridViewTextBoxColumn colVisibilidad = new DataGridViewTextBoxColumn();
                colVisibilidad.DataPropertyName = "Visibilidad"; colVisibilidad.Name = "Visibilidad";
                colVisibilidad.HeaderText = "Visibilidad";
                columnas[5] = colVisibilidad;

                DataGridViewTextBoxColumn colAdmitePreguntas = new DataGridViewTextBoxColumn();
                colAdmitePreguntas.DataPropertyName = "Admite_Preguntas"; colAdmitePreguntas.Name = "Admite_Preguntas";
                colAdmitePreguntas.HeaderText = "Admite Preguntas";
                columnas[6] = colAdmitePreguntas;

                DataGridViewTextBoxColumn colFechaInicio = new DataGridViewTextBoxColumn();
                colFechaInicio.DataPropertyName = "FechaInicio"; colFechaInicio.Name = "FechaInicio";
                colFechaInicio.HeaderText = "Fecha Inicio";
                columnas[7] = colFechaInicio;

                DataGridViewTextBoxColumn colFechaFin = new DataGridViewTextBoxColumn();
                colFechaFin.DataPropertyName = "FechaFin"; colFechaFin.Name = "FechaFin"; 
                colFechaFin.HeaderText = "FechaFin";
                columnas[8] = colFechaFin;

                DataGridViewButtonColumn colModificar = new DataGridViewButtonColumn();
                colModificar.Width = 60;
                colModificar.Text = "Editar";
                colModificar.Name = "Editar";
                colModificar.UseColumnTextForButtonValue = true;
                columnas[9] = colModificar;


                DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
                colId.DataPropertyName = "IdPublicacion"; colId.Name = "IdPublicacion";
                colId.HeaderText = "IdPublicacion";
                colId.Visible = false;
                columnas[10] = colId;

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
