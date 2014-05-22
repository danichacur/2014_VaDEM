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

namespace FrbaCommerce.Formularios.Abm_Visibilidad
{
    public partial class Visibilidad_Listar : ABM
    {
        
        #region VariablesDeClase

        private DataGridView dgv;

        #endregion

        #region Eventos 

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Visibilidad_Listar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load de la clase. Cargo los filtros y la grilla con todos los datos sin filtrar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Visibilidad_Listar_Load(object sender, EventArgs e)
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
                if (e.RowIndex < 0 || (e.ColumnIndex != dgv.Columns["Modificar"].Index && e.ColumnIndex != dgv.Columns["Eliminar"].Index)) return;

                if (e.ColumnIndex == dgv.Columns["Modificar"].Index)
                {
                    btnModificar_Click(sender, e);
                }
                else
                {
                    btnEliminar_Click(sender, e);
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
            try
            {
                Visibilidad visib = (Visibilidad)dgv.Rows[e.RowIndex].DataBoundItem;
                Formularios.Abm_Visibilidad.Visibilidad_Modificar formModif = new Formularios.Abm_Visibilidad.Visibilidad_Modificar(visib);
                result = formModif.ShowDialog();

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
        /// Se elimina el rol seleccionado. La baja es lógica, pero la misma se define en la clase de la entidad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Visibilidad visib = (Visibilidad)dgv.Rows[e.RowIndex].DataBoundItem;
                visib.bajaLogica();
                ctrlABM1.buscar();
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
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
                Formularios.Abm_Visibilidad.Visibilidad_Agregar formAlta = new Formularios.Abm_Visibilidad.Visibilidad_Agregar();
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
                List<Filtro> filtros = new List<Filtro>();
                filtros.Add(new FiltroTextBox("Id Visibilidad", "IdVisibilidad", "=", ""));
                filtros.Add(new FiltroTextBox("Descripcion", "Descripcion", "LIKE", ""));
                filtros.Add(new FiltroComboBox("Habilitado", "Habilitado", "=", "-1", Metodos_Comunes.obtenerTablaComboHabilitadoConVacio(), "id", "descripcion"));

                this.ctrlABM1.cargarFiltros(filtros, null);
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
                Object listaRoles = (Object)VisibilidadDAO.obtenerVisibilidades(clausulaWhere);

                DataGridViewColumn[] columnas = obtenerDisenoColumnasGrilla();

                dgv = this.ctrlABM1.cargarGrilla(listaRoles, columnas);

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

                DataGridViewTextBoxColumn colIdVisibilidad = new DataGridViewTextBoxColumn();
                colIdVisibilidad.DataPropertyName = "Id"; colIdVisibilidad.Name = "Id"; colIdVisibilidad.HeaderText = "Id";
                columnas[0] = colIdVisibilidad;

                DataGridViewTextBoxColumn colDesc = new DataGridViewTextBoxColumn();
                colDesc.DataPropertyName = "Descripcion"; colDesc.Name = "Descripcion"; colDesc.HeaderText = "Descripción";
                columnas[1] = colDesc;

                DataGridViewTextBoxColumn colCostoFijo = new DataGridViewTextBoxColumn();
                colCostoFijo.DataPropertyName = "CostoFijo"; colCostoFijo.Name = "CostoFijo"; colCostoFijo.HeaderText = "Costo Fijo";
                columnas[2] = colCostoFijo;

                DataGridViewTextBoxColumn colComision = new DataGridViewTextBoxColumn();
                colComision.DataPropertyName = "Comision"; colComision.Name = "Comision"; colComision.HeaderText = "Comisión";
                columnas[3] = colComision;

                DataGridViewTextBoxColumn colLimite = new DataGridViewTextBoxColumn();
                colLimite.DataPropertyName = "LimiteSinBonificar"; colLimite.Name = "LimiteSinBonificar"; colLimite.HeaderText = "Límite Sin Bonificar";
                columnas[4] = colLimite;

                DataGridViewTextBoxColumn colVigencia = new DataGridViewTextBoxColumn();
                colVigencia.DataPropertyName = "DiasVigencia"; colVigencia.Name = "DiasVigencia"; colVigencia.HeaderText = "Días Vigencia";
                columnas[5] = colVigencia;

                DataGridViewCheckBoxColumn colHabilitado = new DataGridViewCheckBoxColumn();
                colHabilitado.DataPropertyName = "Habilitado"; colHabilitado.Name = "Habilitado"; colHabilitado.HeaderText = "Habilitado";
                colHabilitado.FalseValue = "0"; colHabilitado.TrueValue = "1";
                columnas[6] = colHabilitado;

                DataGridViewButtonColumn colModif = new DataGridViewButtonColumn();
                colModif.Width = 60;
                colModif.Text = "Modificar";
                colModif.Name = "Modificar";
                colModif.UseColumnTextForButtonValue = true;
                columnas[7] = colModif;

                DataGridViewButtonColumn colElim = new DataGridViewButtonColumn();
                colElim.Width = 60;
                colElim.Text = "Eliminar";
                colElim.Name = "Eliminar";
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
