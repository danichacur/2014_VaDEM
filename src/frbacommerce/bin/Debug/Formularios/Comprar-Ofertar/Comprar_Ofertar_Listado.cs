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

namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class Comprar_Ofertar_Listado : ABM
    {

        #region VariablesDeClase

        private DataGridView dgv;
        private DataGridViewColumn[] columnas;
        private Paginar pag;

        #endregion

        #region Eventos
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Comprar_Ofertar_Listado()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load de la clase. Cargo los filtros y la grilla con todos los datos sin filtrar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Comprar_Ofertar_Listado_Load(object sender, EventArgs e)
        {
            try
            {
                cargaFiltros();
                cargaInicialGrilla();
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                cargaInicialGrilla();
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }

        /// <summary>
        /// Evento del click en cualquier parte de la grilla. Sólo se hace algo si se hace click en comprarOfertar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == dgv.Columns["OfertarComprar"].Index)
                {
                    btnComprarOfertar_Click(sender, e);
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
        private void btnComprarOfertar_Click(object sender, DataGridViewCellEventArgs e)
        {
            System.Windows.Forms.DialogResult result;
            try
            {

                int idPublicacion = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["IdPublicacion"].Value);
                Formularios.Comprar_Ofertar.Comprar_Ofertar_Publicacion formComprarOfertar = new Formularios.Comprar_Ofertar.Comprar_Ofertar_Publicacion(idPublicacion);
                result = formComprarOfertar.ShowDialog();

                //if (result == System.Windows.Forms.DialogResult.OK)
                //{
                //    ctrlABM1.buscar();
                //} 
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }
        #endregion


        #region MetodosGenerales
        /// <summary>
        /// Se generan dinamicamente los filtros de la pantalla, cada uno con sus parámetros correspondientes.
        /// Se pasa la lista al control del listado que se encarga de acomodarlos.
        /// </summary>
        private void cargaFiltros()
        {
            try
            {
                DataTable rubros = RubroDAO.obtenerRubros();
                DataRow row;

                row = rubros.NewRow();
                row["IdRubro"] = 0; row["Descripcion"] = "";
                rubros.Rows.InsertAt(row, 0);

                cmbRubro.DataSource = rubros;
                cmbRubro.DisplayMember = "Descripcion";
                cmbRubro.ValueMember = "IdRubro";

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Carga la grilla llamando al método sin pasarle ningun filtro. Se le agrega el comportamiento en el evento click
        /// </summary>
        private void cargaInicialGrilla()
        {
            try
            {
                Object listaPublicaciones = (Object)PublicacionDAO.obtenerPublicacionesActivas(txtDescripcion.Text, (int)cmbRubro.SelectedValue);
                pag = new Paginar(listaPublicaciones, 10);

                columnas = obtenerDisenoColumnasGrilla();

                dgv = cargarGrilla(pag.cargar(), columnas);

                dgv.CellClick -= new DataGridViewCellEventHandler(dgv_CellClick);
                dgv.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);
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

                DataGridViewColumn[] columnas = new DataGridViewColumn[7];

                DataGridViewTextBoxColumn colDescripcion = new DataGridViewTextBoxColumn();
                colDescripcion.DataPropertyName = "Descripcion"; colDescripcion.Name = "Descripcion";
                colDescripcion.HeaderText = "Descripcion";
                columnas[0] = colDescripcion;

                DataGridViewTextBoxColumn colTipo = new DataGridViewTextBoxColumn();
                colTipo.DataPropertyName = "Tipo"; colTipo.Name = "Tipo";
                colTipo.HeaderText = "Tipo";
                columnas[1] = colTipo;

                DataGridViewTextBoxColumn colFechaIni = new DataGridViewTextBoxColumn();
                colFechaIni.DataPropertyName = "FechaInicio"; colFechaIni.Name = "FechaInicio"; colFechaIni.HeaderText = "Fecha de inicio";
                columnas[2] = colFechaIni;

                DataGridViewTextBoxColumn colFechaFin = new DataGridViewTextBoxColumn();
                colFechaFin.DataPropertyName = "FechaFin"; colFechaFin.Name = "FechaFin"; colFechaFin.HeaderText = "Fecha de finalizacion";
                columnas[3] = colFechaFin;

                DataGridViewTextBoxColumn colPrecioInicial = new DataGridViewTextBoxColumn();
                colPrecioInicial.DataPropertyName = "PrecioInicial"; colPrecioInicial.Name = "PrecioInicial"; colPrecioInicial.HeaderText = "Precio Inicial";

                columnas[4] = colPrecioInicial;

                DataGridViewButtonColumn colOfertarComprar = new DataGridViewButtonColumn();
                colOfertarComprar.Width = 100;

                colOfertarComprar.Text = "OfertarComprar";
                colOfertarComprar.Name = "OfertarComprar";
                colOfertarComprar.UseColumnTextForButtonValue = true;
                columnas[5] = colOfertarComprar;

                DataGridViewTextBoxColumn colIdPublicacion = new DataGridViewTextBoxColumn();
                colIdPublicacion.DataPropertyName = "IdPublicacion";
                colIdPublicacion.Name = "IdPublicacion";
                colIdPublicacion.HeaderText = "IdPublicacion";
                colIdPublicacion.Visible = false;
                columnas[6] = colIdPublicacion;

                return columnas;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Carga la grilla con la lista que recibe como parámetro y con la estructura de las columnas que recibe
        /// </summary>
        /// <param name="tbl"></param>
        public DataGridView cargarGrilla(Object lista, DataGridViewColumn[] columnas)
        {
            try
            {

                //dgv.Columns.Clear();
                if (dgvPubliaciones.Columns.Count == 0)
                {
                    dgvPubliaciones.Columns.AddRange(columnas);
                    dgvPubliaciones.AutoGenerateColumns = false;
                }
                cargarGrilla(lista);

                return dgvPubliaciones;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Carga la grilla con la lista que recibe como parámetro 
        /// </summary>
        /// <param name="lista"></param>
        public void cargarGrilla(Object lista)
        {
            try
            {

                Object listDatos = lista;
                dgvPubliaciones.DataSource = null;
                dgvPubliaciones.DataSource = listDatos;
            }
            catch (Exception)
            {
                throw;
            }

        }

        #endregion

        private void btnPrimera_Click(object sender, EventArgs e)
        {
            cargarGrilla(pag.primeraPagina(), columnas);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            cargarGrilla(pag.atras(), columnas);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            cargarGrilla(pag.adelante(), columnas);
        }

        private void btnUltima_Click(object sender, EventArgs e)
        {
            cargarGrilla(pag.ultimaPagina(), columnas);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbRubro.SelectedIndex = 0;
            txtDescripcion.Text = "";

        }



    }
}
