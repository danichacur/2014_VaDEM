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

namespace FrbaCommerce.Formularios.Listado_Estadistico
{
    public partial class Estadisticas : Form
    {
        #region VariablesDeClase
        
        #endregion

        #region Eventos

        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        public Estadisticas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load de la clase. Cargo los filtros Año, Trimestre y Tipo de Listado. Oculto y deshabilito los controles del
        /// primer listado. Deshabilito el boton buscar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Estadisticas_Load(object sender, EventArgs e)
        {
            try
            {
                cargarFiltrosInicio();
                ocultarYDeshabilitarControlesListadoProductosNoVendidos();
                btnGenerar.Enabled = false;
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }

        /// <summary>
        /// Al cambiar el combo reviso que si es el de vendedores de publicaciones con mayor cantidad de prod no vendidos
        /// en ese caso muestro y habilito los controles de visibilidad y de mes, en caso contrario los oculto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboTipoListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (((ComboBox)sender).SelectedValue.Equals("1"))
                {
                    mostrarYHabilitarControlesListadosProductosNoVendidos();
                }
                else
                {
                    ocultarYDeshabilitarControlesListadoProductosNoVendidos();
                }

                habilitaBotonSegunCombosCorrectos();
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }

        /// <summary>
        /// Al cambiar el combo cargo en el combo de meses los meses correspondientes al trimestre seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboTrimestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cargarFiltroMeses(Convert.ToInt32(((ComboBox)sender).SelectedValue));
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }

        /// <summary>
        /// Boton que solo está activado cuando los campos estar correctamente cargados.
        /// Genera en la grilla el reporte solicitado en base a los filtros seleccionados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            int nroReporte;
            DataGridViewColumn[] columnas;
            object registros;
            try
            {
                columnas = null;
                registros = null;

                nroReporte = obtenerNroReporteSeleccionado();
                switch (nroReporte)
                {
                    case 1:
                        columnas = obtenerColumnasReporteVendedoresMayorCantProductosNoVendidos();
                        registros = obtenerRegistrosReporteVendedoresMayorCantProductosNoVendidos();
                        break;
                    case 2:
                        columnas = obtenerColumnasReporteVendedoresMayorFacturacion();
                        registros = obtenerRegistrosReporteVendedoresMayorFacturacion();
                        break;
                    case 3:
                        columnas = obtenerColumnasReporteVendedoresMayoresCalificaciones();
                        registros = obtenerRegistrosReporteVendedoresMayoresCalificaciones();
                        break;
                    case 4:
                        columnas = obtenerColumnasReporteClientesMayorCantPublicacionesSinCalificar();
                        registros = obtenerRegistrosReporteClientesMayorCantPublicacionesSinCalificar();
                        break;
                }
           
                cargarGrilla(columnas, registros);
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }


        private object obtenerRegistrosReporteVendedoresMayorCantProductosNoVendidos()
        {
            try
            {
                return UsuarioDAO.obtenerRegistrosReporteVendedoresMayorCantProductosNoVendidos(
                    Convert.ToInt32(cboAnio.SelectedValue),
                    Convert.ToInt32(cboTrimestre.SelectedValue), 
                    Convert.ToInt32(cboVisibilidad.SelectedValue), 
                    Convert.ToInt32(cboMes.SelectedValue)
                    );
            }
            catch (Exception)
            {   
                throw;
            }
        }

        private object obtenerRegistrosReporteVendedoresMayorFacturacion()
        {
            try
            {
                return UsuarioDAO.obtenerRegistrosReporteVendedoresMayorFacturacion(
                                    Convert.ToInt32(cboAnio.SelectedValue),
                                    Convert.ToInt32(cboTrimestre.SelectedValue)
                                    );
            }
            catch (Exception)
            {
                throw;
            }

        }

        private object obtenerRegistrosReporteVendedoresMayoresCalificaciones()
        {
            try
            {
                return UsuarioDAO.obtenerRegistrosReporteVendedoresMayoresCalificaciones(
                                    Convert.ToInt32(cboAnio.SelectedValue),
                                    Convert.ToInt32(cboTrimestre.SelectedValue)
                                    );
            }
            catch (Exception)
            {
                throw;
            }

        }

        private object obtenerRegistrosReporteClientesMayorCantPublicacionesSinCalificar()
        {
            try
            {
                return UsuarioDAO.obtenerRegistrosReporteClientesMayorCantPublicacionesSinCalificar(
                                    Convert.ToInt32(cboAnio.SelectedValue),
                                    Convert.ToInt32(cboTrimestre.SelectedValue)
                                    );
            }
            catch (Exception)
            {
                throw;
            }
        }

        

        private DataGridViewColumn[] obtenerColumnasReporteVendedoresMayorCantProductosNoVendidos()
        {
            try
            {
                DataGridViewColumn[] columnas = new DataGridViewColumn[6];

                DataGridViewTextBoxColumn colUsername = new DataGridViewTextBoxColumn();
                colUsername.DataPropertyName = "Username"; colUsername.Name = "Username";
                colUsername.HeaderText = "Nombre de Usuario";
                columnas[0] = colUsername;

                DataGridViewTextBoxColumn colCantidad = new DataGridViewTextBoxColumn();
                colCantidad.DataPropertyName = "Cantidad"; colCantidad.Name = "Cantidad"; colCantidad.HeaderText = "Cantidad";
                columnas[1] = colCantidad;

                DataGridViewTextBoxColumn colAnio = new DataGridViewTextBoxColumn();
                colAnio.DataPropertyName = "Año"; colAnio.Name = "Año"; colAnio.HeaderText = "Año";
                columnas[2] = colAnio;

                DataGridViewTextBoxColumn colTrimestre = new DataGridViewTextBoxColumn();
                colTrimestre.DataPropertyName = "Trimestre"; colTrimestre.Name = "Trimestre"; colTrimestre.HeaderText = "Trimestre";
                columnas[3] = colTrimestre;

                DataGridViewTextBoxColumn colMes = new DataGridViewTextBoxColumn();
                colMes.DataPropertyName = "Mes"; colMes.Name = "Mes"; colMes.HeaderText = "Mes";
                columnas[4] = colMes;

                DataGridViewTextBoxColumn colVisibilidad = new DataGridViewTextBoxColumn();
                colVisibilidad.DataPropertyName = "Visibilidad"; colVisibilidad.Name = "Visibilidad"; colVisibilidad.HeaderText = "Visibilidad";
                columnas[5] = colVisibilidad;

            
                return columnas;
            }
            catch (Exception)
            {
                throw;
            }            
        }

        private DataGridViewColumn[] obtenerColumnasReporteVendedoresMayorFacturacion()
        {
            try
            {
                DataGridViewColumn[] columnas = new DataGridViewColumn[4];

                DataGridViewTextBoxColumn colUsername = new DataGridViewTextBoxColumn();
                colUsername.DataPropertyName = "Username"; colUsername.Name = "Username";
                colUsername.HeaderText = "Nombre de Usuario";
                columnas[0] = colUsername;

                DataGridViewTextBoxColumn colCantidad = new DataGridViewTextBoxColumn();
                colCantidad.DataPropertyName = "Total"; colCantidad.Name = "Total"; colCantidad.HeaderText = "Total";
                columnas[1] = colCantidad;

                DataGridViewTextBoxColumn colAnio = new DataGridViewTextBoxColumn();
                colAnio.DataPropertyName = "Año"; colAnio.Name = "Año"; colAnio.HeaderText = "Año";
                columnas[2] = colAnio;

                DataGridViewTextBoxColumn colTrimestre = new DataGridViewTextBoxColumn();
                colTrimestre.DataPropertyName = "Trimestre"; colTrimestre.Name = "Trimestre"; colTrimestre.HeaderText = "Trimestre";
                columnas[3] = colTrimestre;

                return columnas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private DataGridViewColumn[] obtenerColumnasReporteVendedoresMayoresCalificaciones()
        {
            try
            {
                DataGridViewColumn[] columnas = new DataGridViewColumn[4];

                DataGridViewTextBoxColumn colUsername = new DataGridViewTextBoxColumn();
                colUsername.DataPropertyName = "Username"; colUsername.Name = "Username";
                colUsername.HeaderText = "Nombre de Usuario";
                columnas[0] = colUsername;

                DataGridViewTextBoxColumn colCantidad = new DataGridViewTextBoxColumn();
                colCantidad.DataPropertyName = "Calificacion"; colCantidad.Name = "Calificacion";
                colCantidad.HeaderText = "Calificación";
                columnas[1] = colCantidad;

                DataGridViewTextBoxColumn colAnio = new DataGridViewTextBoxColumn();
                colAnio.DataPropertyName = "Año"; colAnio.Name = "Año"; colAnio.HeaderText = "Año";
                columnas[2] = colAnio;

                DataGridViewTextBoxColumn colTrimestre = new DataGridViewTextBoxColumn();
                colTrimestre.DataPropertyName = "Trimestre"; colTrimestre.Name = "Trimestre"; colTrimestre.HeaderText = "Trimestre";
                columnas[3] = colTrimestre;

                return columnas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private DataGridViewColumn[] obtenerColumnasReporteClientesMayorCantPublicacionesSinCalificar()
        {
            try
            {
                DataGridViewColumn[] columnas = new DataGridViewColumn[4];

                DataGridViewTextBoxColumn colUsername = new DataGridViewTextBoxColumn();
                colUsername.DataPropertyName = "Username"; colUsername.Name = "Username";
                colUsername.HeaderText = "Nombre de Usuario";
                columnas[0] = colUsername;

                DataGridViewTextBoxColumn colCantidad = new DataGridViewTextBoxColumn();
                colCantidad.DataPropertyName = "Cantidad"; colCantidad.Name = "Cantidad";
                colCantidad.HeaderText = "Cantidad";
                columnas[1] = colCantidad;

                DataGridViewTextBoxColumn colAnio = new DataGridViewTextBoxColumn();
                colAnio.DataPropertyName = "Año"; colAnio.Name = "Año"; colAnio.HeaderText = "Año";
                columnas[2] = colAnio;

                DataGridViewTextBoxColumn colTrimestre = new DataGridViewTextBoxColumn();
                colTrimestre.DataPropertyName = "Trimestre"; colTrimestre.Name = "Trimestre"; colTrimestre.HeaderText = "Trimestre";
                columnas[3] = colTrimestre;

                return columnas;
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion

         #region MetodosGenerales

         /// <summary>
        /// Carga los 3 filtros que se muestran al abrir la pantalla, los demas se cargan luego
        /// </summary>
        private void cargarFiltrosInicio()
        {
            try
            {
                cargarFiltroAño();
                cargarFiltroTrimestre();
                cargarFiltroTipoListado();
                cargarFiltroVisibilidad();

                 
                this.cboTipoListado.SelectedIndexChanged += new System.EventHandler(this.cboTipoListado_SelectedIndexChanged);
            }
            catch (Exception)
            {   
                throw;
            }
        }

        /// <summary>
        /// Configura los controles de Visibilidad y de mes para que no se vean y esten deshabilitados
        /// </summary>
        private void ocultarYDeshabilitarControlesListadoProductosNoVendidos()
        {
            try
            {
                habilitarControles(lblTipoVisibilidad, cboVisibilidad, false);
                habilitarControles(lblMes, cboMes, false);
            }
            catch (Exception)
            {   
                throw;
            }
        }

        /// <summary>
        /// Configura los controles de Visibilidad y de mes para que  se vean y esten habilitados
        /// </summary>
        private void mostrarYHabilitarControlesListadosProductosNoVendidos()
        {
            try
            {
                habilitarControles(lblTipoVisibilidad, cboVisibilidad, true);
                habilitarControles(lblMes, cboMes, true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void habilitaBotonSegunCombosCorrectos()
        {
            try
            {
                if (verificaComboLlenoSiHabilitado(cboTipoListado)
                    &&
                    verificaComboLlenoSiHabilitado(cboMes)
                    &&
                    verificaComboLlenoSiHabilitado(cboVisibilidad))
                {
                    btnGenerar.Enabled = true;
                }
                else
                {
                    btnGenerar.Enabled = false;
                }
            }
            catch (Exception)
            {   
                throw;
            }
        }

        #endregion

        #region MetodosAuxiliares

        private Boolean verificaComboLlenoSiHabilitado(ComboBox cbo)
        {
            try
            {
                if (cbo.Visible)
                {
                    if (cbo.Text == "")
                        return false;
                    else
                        return true;
                }
                else 
                {
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void habilitarControles(Label lbl, ComboBox cbo, Boolean estado) 
        {
            try
            {
                lbl.Visible = estado;
                cbo.Visible = estado;
                cbo.Enabled = estado;
            }
            catch (Exception)
            {   
                throw;
            }
        }

        /// <summary>
        /// Cargo el combo de año con el 2013 y el 2014
        /// </summary>
        private void cargarFiltroAño()
        {
            DataTable tblAnios;
            DataRow row;
            DataColumn column;
            try
            {
                tblAnios = new DataTable("id", "descripcion");

                column = new DataColumn();
                column.ColumnName = "id";
                tblAnios.Columns.Add(column);

                column = new DataColumn();
                column.ColumnName = "descripcion";
                tblAnios.Columns.Add(column);

                row = tblAnios.NewRow();
                row["id"] = 2013; row["descripcion"] = "2013";
                tblAnios.Rows.Add(row);

                row = tblAnios.NewRow();
                row["id"] = 2014; row["descripcion"] = "2014";
                tblAnios.Rows.Add(row);


                Metodos_Comunes.cargarCombo(cboAnio, tblAnios, "id", "descripcion");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Cargo el combo Trimestre con 1,2,3,4
        /// </summary>
        private void cargarFiltroTrimestre()
        {
            DataTable tblTrimestres;
            DataRow row;
            DataColumn column;
            try
            {
                tblTrimestres = new DataTable("id", "descripcion");

                column = new DataColumn();
                column.ColumnName = "id";
                tblTrimestres.Columns.Add(column);

                column = new DataColumn();
                column.ColumnName = "descripcion";
                tblTrimestres.Columns.Add(column);

                row = tblTrimestres.NewRow();
                row["id"] = 1; row["descripcion"] = "1º Trimestre";
                tblTrimestres.Rows.Add(row);

                row = tblTrimestres.NewRow();
                row["id"] = 2; row["descripcion"] = "2º Trimestre";
                tblTrimestres.Rows.Add(row);

                row = tblTrimestres.NewRow();
                row["id"] = 3; row["descripcion"] = "3º Trimestre";
                tblTrimestres.Rows.Add(row);

                row = tblTrimestres.NewRow();
                row["id"] = 4; row["descripcion"] = "4º Trimestre";
                tblTrimestres.Rows.Add(row);

                Metodos_Comunes.cargarCombo(cboTrimestre, tblTrimestres, "id", "descripcion");
                this.cboTrimestre.SelectedIndexChanged += new System.EventHandler(this.cboTrimestre_SelectedIndexChanged);
                cboTrimestre.SelectedIndex = 1;
                cboTrimestre.SelectedIndex = 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Cargo el combo Listado con los 4 listados
        /// </summary>
        private void cargarFiltroTipoListado()
        {
            DataTable tblListados;
            DataRow row;
            DataColumn column;
            try
            {
                tblListados = new DataTable("id", "descripcion");

                column = new DataColumn();
                column.ColumnName = "id";
                tblListados.Columns.Add(column);

                column = new DataColumn();
                column.ColumnName = "descripcion";
                tblListados.Columns.Add(column);

                row = tblListados.NewRow();
                row["id"] = 0; row["descripcion"] = "";
                tblListados.Rows.Add(row);

                row = tblListados.NewRow();
                row["id"] = 1; row["descripcion"] = "Vendedores Mayor Cant Productos No vendidos";
                tblListados.Rows.Add(row);

                row = tblListados.NewRow();
                row["id"] = 2; row["descripcion"] = "Vendedores Mayor Facturación";
                tblListados.Rows.Add(row);

                row = tblListados.NewRow();
                row["id"] = 3; row["descripcion"] = "Vendedores Mayores Calificaciones";
                tblListados.Rows.Add(row);

                row = tblListados.NewRow();
                row["id"] = 4; row["descripcion"] = "Clientes Mayor Cant Publicaciones sin Calificar";
                tblListados.Rows.Add(row);

                Metodos_Comunes.cargarCombo(cboTipoListado, tblListados, "id", "descripcion");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Cargo el combo de Visibilidad con las Visibilidades de la BD en estado Habilitada
        /// </summary>
        private void cargarFiltroVisibilidad()
        {
            List<Visibilidad> listaVisibilidades;
            try
            {
                listaVisibilidades = VisibilidadDAO.obtenerVisibilidadesHabilitadas();
                Metodos_Comunes.cargarCombo(cboVisibilidad, listaVisibilidades, "id", "descripcion");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Cargo el combo de Meses con los 3 meses pertenecientes al cuatrimestre que recibo de parámetro
        /// </summary>
        /// <param name="nroTrimestre"></param>
        private void cargarFiltroMeses(int nroTrimestre)
        {
            DataTable tblListados;
            DataRow row;
            DataColumn column;
            try
            {

                tblListados = new DataTable("id", "descripcion");

                column = new DataColumn();
                column.ColumnName = "id";
                tblListados.Columns.Add(column);

                column = new DataColumn();
                column.ColumnName = "descripcion";
                tblListados.Columns.Add(column);

                switch (nroTrimestre)
                {
                    case 1:
                        row = tblListados.NewRow();
                        row["id"] = 1; row["descripcion"] = "Enero";
                        tblListados.Rows.Add(row);

                        row = tblListados.NewRow();
                        row["id"] = 2; row["descripcion"] = "Febrero";
                        tblListados.Rows.Add(row);

                        row = tblListados.NewRow();
                        row["id"] = 3; row["descripcion"] = "Marzo";
                        tblListados.Rows.Add(row);

                        break;

                    case 2:
                        row = tblListados.NewRow();
                        row["id"] = 4; row["descripcion"] = "Abril";
                        tblListados.Rows.Add(row);

                        row = tblListados.NewRow();
                        row["id"] = 5; row["descripcion"] = "Mayo";
                        tblListados.Rows.Add(row);

                        row = tblListados.NewRow();
                        row["id"] = 6; row["descripcion"] = "Junio";
                        tblListados.Rows.Add(row);

                        break;

                    case 3:
                        row = tblListados.NewRow();
                        row["id"] = 7; row["descripcion"] = "Julio";
                        tblListados.Rows.Add(row);

                        row = tblListados.NewRow();
                        row["id"] = 8; row["descripcion"] = "Agosto";
                        tblListados.Rows.Add(row);

                        row = tblListados.NewRow();
                        row["id"] = 9; row["descripcion"] = "Septiembre";
                        tblListados.Rows.Add(row);

                        break;

                    case 4:
                        row = tblListados.NewRow();
                        row["id"] = 10; row["descripcion"] = "Octubre";
                        tblListados.Rows.Add(row);

                        row = tblListados.NewRow();
                        row["id"] = 11; row["descripcion"] = "Noviembre";
                        tblListados.Rows.Add(row);

                        row = tblListados.NewRow();
                        row["id"] = 12; row["descripcion"] = "Diciembre";
                        tblListados.Rows.Add(row);

                        break;

                    default:
                        break;
                }


                Metodos_Comunes.cargarCombo(cboMes, tblListados, "id", "descripcion");
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        /// Obtiene el nro del Tipo de Listado, o Tipo Reporte, del combo correspondiente
        /// </summary>
        /// <returns></returns>
        private int obtenerNroReporteSeleccionado()
        {
            try
            {
                return Convert.ToInt32(((ComboBox)cboTipoListado).SelectedValue);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Limpia la Grilla y la carga con las columnas que obtiene de parámetro, con los registros del parámetro.
        /// </summary>
        /// <param name="columnas"></param>
        /// <param name="registros"></param>
        private void cargarGrilla(DataGridViewColumn[] columnas, object registros)
        {
            dgvListado.Columns.Clear();
            if (dgvListado.Columns.Count == 0)
            {
                dgvListado.Columns.AddRange(columnas);
                dgvListado.AutoGenerateColumns = false;
                dgvListado.DataSource = null;
                dgvListado.DataSource = registros;
            }
        }
        #endregion
    }
}
