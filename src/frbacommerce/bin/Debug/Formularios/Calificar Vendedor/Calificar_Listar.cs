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

namespace FrbaCommerce.Formularios.Calificar_Vendedor
{
    public partial class Calificar_Listar : ABM
    {
        

        #region VariablesDeClase
        
        private DataGridView dgv;

        #endregion


        #region Eventos

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Calificar_Listar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load de la clase. Cargo los filtros y la grilla con todos los datos sin filtrar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Calificar_Listar_Load(object sender, EventArgs e)
        {
            try
            {
                this.ctrlABM1.ocultarBotonAlta();
                cargaFiltros();
                cargaInicialGrilla();
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }

        /// <summary>
        /// Evento del click en cualquier parte de la grilla. Sólo se hace algo si se hace click en Calificar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Ignora los clicks que no son sobre las columnas con boton  
                if (e.RowIndex < 0 || (e.ColumnIndex != dgv.Columns["Calificar"].Index)) return;

                if (e.ColumnIndex == dgv.Columns["Calificar"].Index)
                {
                    btnCalificar_Click(sender, e);
                }
                
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }

        /// <summary>
        /// Evento boton Calificar. Se abre la ventana de calificacion con la informacion correspondiente. Al regresar de la ventana
        /// valida que el resultado sea satisfactorio, en ese caso refresca la pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalificar_Click(object sender, DataGridViewCellEventArgs e)
        {
            System.Windows.Forms.DialogResult result;
            try
            {
                DataGridViewRow compra = dgv.Rows[e.RowIndex];
                Formularios.Calificar_Vendedor.Calificar formCalificar = new Formularios.Calificar_Vendedor.Calificar(compra);
                result = formCalificar.ShowDialog();

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

        /// <summary>
        /// Se generan dinamicamente los filtros de la pantalla, cada uno con sus parámetros correspondientes.
        /// Se pasa la lista al control del listado que se encarga de acomodarlos.
        /// </summary>
        private void cargaFiltros()
        {
            try
            {
                List<Filtro> filtrosI = new List<Filtro>();
              //  filtrosI.Add(new FiltroFecha("Documento", "Documento", "=", ""));
              //  filtrosI.Add(new FiltroTextBox("Apellido", "Apellido", "LIKE", ""));
                

                this.ctrlABM1.cargarFiltros(filtrosI, null);
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
                aplicarFiltro("");
                dgv.CellClick -= new DataGridViewCellEventHandler(dgv_CellClick);
                dgv.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Cargar la grilla con los registros correspondientes a los filtros seleccionados en ese momento.
        /// </summary>
        /// <param name="clausulaWhere"></param>
        public override void aplicarFiltro(String clausulaWhere)
        {
            try
            {
                Object listaCompras = (Object)ComprasDAO.obtenerCompras(clausulaWhere);

                DataGridViewColumn[] columnas = obtenerDisenoColumnasGrilla();

                dgv = this.ctrlABM1.cargarGrilla(listaCompras, columnas);

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

                DataGridViewColumn[] columnas = new DataGridViewColumn[9];

                DataGridViewTextBoxColumn colIdCompra = new DataGridViewTextBoxColumn();
                colIdCompra.DataPropertyName = "IdCompra"; colIdCompra.Name = "IdCompra";
                colIdCompra.HeaderText = "Id";
                columnas[0] = colIdCompra;

                DataGridViewTextBoxColumn colIdPublicacion = new DataGridViewTextBoxColumn();
                colIdPublicacion.DataPropertyName = "PublicacionDescripcion"; colIdPublicacion.Name = "PublicacionDescripcion";
                colIdPublicacion.HeaderText = "Descripción Publicación";
                columnas[1] = colIdPublicacion;

                DataGridViewTextBoxColumn colFecha = new DataGridViewTextBoxColumn();
                colFecha.DataPropertyName = "Fecha"; colFecha.Name = "Fecha"; colFecha.HeaderText = "Fecha de Compra";
                columnas[2] = colFecha;

                DataGridViewTextBoxColumn colCantidad = new DataGridViewTextBoxColumn();
                colCantidad.DataPropertyName = "Cantidad"; colCantidad.Name = "Cantidad"; colCantidad.HeaderText = "Cantidad";
                columnas[3] = colCantidad;

                DataGridViewCheckBoxColumn colCalificada = new DataGridViewCheckBoxColumn();
                colCalificada.DataPropertyName = "Calificada"; colCalificada.Name = "Calificada"; colCalificada.HeaderText = "Está Calificada";
                colCalificada.FalseValue = "0"; colCalificada.TrueValue = "1";
                columnas[4] = colCalificada;

                DataGridViewTextBoxColumn colIdVendedor = new DataGridViewTextBoxColumn();
                colIdVendedor.DataPropertyName = "IdVendedor"; colIdVendedor.Name = "IdVendedor"; colIdVendedor.HeaderText = "IdVendedor";
                colIdVendedor.Visible = false;
                columnas[5] = colIdVendedor;

                DataGridViewTextBoxColumn colUsernameVendedor = new DataGridViewTextBoxColumn();
                colUsernameVendedor.DataPropertyName = "UsernameVendedor"; colUsernameVendedor.Name = "UsernameVendedor"; 
                colUsernameVendedor.HeaderText = "UsernameVendedor";
                colUsernameVendedor.Visible = false;
                columnas[6] = colUsernameVendedor;

                DataGridViewTextBoxColumn colMontoTotalPagado = new DataGridViewTextBoxColumn();
                colMontoTotalPagado.DataPropertyName = "MontoTotalPagado"; colMontoTotalPagado.Name = "MontoTotalPagado"; colMontoTotalPagado.HeaderText = "MontoTotalPagado";
                colMontoTotalPagado.Visible = false;
                columnas[7] = colMontoTotalPagado;

                DataGridViewButtonColumn colElim = new DataGridViewButtonColumn();
                colElim.Width = 60;
                colElim.Text = "Calificar";
                colElim.Name = "Calificar";
                colElim.UseColumnTextForButtonValue = true;
                columnas[8] = colElim;

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
