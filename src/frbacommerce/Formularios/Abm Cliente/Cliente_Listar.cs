using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Datos;
using FrbaCommerce.Componentes_Comunes;
using FrbaCommerce.Entidades;

namespace FrbaCommerce.Abm_Cliente
{
    public partial class Cliente_Listar : ABM
    {
        #region VariablesDeClase
        
        private DataGridView dgv;

        #endregion


        #region Eventos

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Cliente_Listar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load de la clase. Cargo los filtros y la grilla con todos los datos sin filtrar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ABM_Cliente_Load(object sender, EventArgs e)
        {
            try
            {
                if (validaRolHabilitado())
                {
                    cargaFiltros();
                    cargaInicialGrilla();
                }
                else
                {
                    Metodos_Comunes.MostrarMensaje("El Rol Cliente se encuentra inhabilitado.");
                    DialogResult = System.Windows.Forms.DialogResult.Abort;
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
                Cliente cliente = (Cliente)dgv.Rows[e.RowIndex].DataBoundItem;
                Formularios.Abm_Cliente.Cliente_Modificar formModificar = new Formularios.Abm_Cliente.Cliente_Modificar(cliente);
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

        /// <summary>
        /// Se elimina el rol seleccionado. La baja es lógica, pero la misma se define en la clase de la entidad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Cliente cliente = (Cliente)dgv.Rows[e.RowIndex].DataBoundItem;
                cliente.bajaLogica();
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
                Formularios.Abm_Cliente.Cliente_Agregar formAlta = new Formularios.Abm_Cliente.Cliente_Agregar();
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
                if (!this.ctrlABM1.existenFiltrosCargados())
                {

                    List<Filtro> filtrosI = new List<Filtro>();
                    filtrosI.Add(new FiltroTextBox("Documento", "Documento", "=", ""));
                    filtrosI.Add(new FiltroTextBox("Nombre", "Nombre", "LIKE", ""));
                    filtrosI.Add(new FiltroTextBox("Telefono", "Telefono", "=", ""));

                    List<Filtro> filtrosD = new List<Filtro>();
                    DataTable tbl = Metodos_Comunes.obtenerTablaComboTipoDocumento();
                    Metodos_Comunes.InsertarVacioEnPrimerRegistro(ref tbl);
                    filtrosD.Add(new FiltroComboBox("Tipo Doc", "TipoDocumento", "=", "-1", tbl, "id", "descripcion"));
                    filtrosD.Add(new FiltroTextBox("Apellido", "Apellido", "LIKE", ""));

                    this.ctrlABM1.cargarFiltros(filtrosI, filtrosD);
                }
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
                if (clausulaWhere != "")
                {
                    clausulaWhere = clausulaWhere.Replace("WHERE", "AND");
                    clausulaWhere = clausulaWhere.Replace("TipoDocumento = '0'", "TipoDocumento = 'DNI'");
                    clausulaWhere = clausulaWhere.Replace("TipoDocumento = '1'", "TipoDocumento = 'L.C.'");
                }
                

                Object listaClientes = (Object)ClienteDAO.obtenerClientes(clausulaWhere);

                DataGridViewColumn[] columnas = obtenerDisenoColumnasGrilla();

                dgv = this.ctrlABM1.cargarGrilla(listaClientes, columnas);

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

                DataGridViewColumn[] columnas = new DataGridViewColumn[17];

                DataGridViewTextBoxColumn colTipoDocumento = new DataGridViewTextBoxColumn();
                colTipoDocumento.DataPropertyName = "TipoDocumento"; colTipoDocumento.Name = "TipoDocumento";
                colTipoDocumento.HeaderText = "Tipo Documento";
                columnas[0] = colTipoDocumento;

                DataGridViewTextBoxColumn colDocumento = new DataGridViewTextBoxColumn();
                colDocumento.DataPropertyName = "Documento";colDocumento.Name = "Documento";colDocumento.HeaderText = "Documento";
                columnas[1] = colDocumento;

                DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
                colNombre.DataPropertyName = "Nombre"; colNombre.Name = "Nombre"; colNombre.HeaderText = "Nombre";
                columnas[2] = colNombre;

                DataGridViewTextBoxColumn colApellido = new DataGridViewTextBoxColumn();
                colApellido.DataPropertyName = "Apellido"; colApellido.Name = "Apellido"; colApellido.HeaderText = "Apellido";
                columnas[3] = colApellido;

                DataGridViewTextBoxColumn colMail = new DataGridViewTextBoxColumn();
                colMail.DataPropertyName = "Email"; colMail.Name = "E-Mail"; colMail.HeaderText = "E-Mail";
                columnas[4] = colMail;

                DataGridViewTextBoxColumn colTelefono = new DataGridViewTextBoxColumn();
                colTelefono.DataPropertyName = "Telefono"; colTelefono.Name = "Telefono"; colTelefono.HeaderText = "Teléfono";
                columnas[5] = colTelefono;

                DataGridViewTextBoxColumn colDireccion = new DataGridViewTextBoxColumn();
                colDireccion.DataPropertyName = "Direccion"; colDireccion.Name = "Direccion"; colDireccion.HeaderText = "Dirección";
                columnas[6] = colDireccion;

                DataGridViewTextBoxColumn colNumero = new DataGridViewTextBoxColumn();
                colNumero.DataPropertyName = "Numero"; colNumero.Name = "Numero"; colNumero.HeaderText = "Número";
                columnas[7] = colNumero;

                DataGridViewTextBoxColumn colPiso = new DataGridViewTextBoxColumn();
                colPiso.DataPropertyName = "Piso"; colPiso.Name = "Piso"; colPiso.HeaderText = "Piso";
                columnas[8] = colPiso;

                DataGridViewTextBoxColumn colDepartamento = new DataGridViewTextBoxColumn();
                colDepartamento.DataPropertyName = "Departamento"; colDepartamento.Name = "Departamento";
                colDepartamento.HeaderText = "Departamento";
                columnas[9] = colDepartamento;

                DataGridViewTextBoxColumn colLocalidad = new DataGridViewTextBoxColumn();
                colLocalidad.DataPropertyName = "Localidad"; colLocalidad.Name = "Localidad"; colLocalidad.HeaderText = "Localidad";
                columnas[10] = colLocalidad;

                DataGridViewTextBoxColumn colCodPostal = new DataGridViewTextBoxColumn();
                colCodPostal.DataPropertyName = "CodigoPostal"; colCodPostal.Name = "CodigoPostal"; 
                colCodPostal.HeaderText = "Código Postal";
                columnas[11] = colCodPostal;

                DataGridViewTextBoxColumn colFechaNacimiento = new DataGridViewTextBoxColumn();
                colFechaNacimiento.DataPropertyName = "FechaNacimiento"; colFechaNacimiento.Name = "FechaNacimiento";
                colFechaNacimiento.HeaderText = "Fecha Nacimiento";
                columnas[12] = colFechaNacimiento;

                DataGridViewTextBoxColumn colCUIL = new DataGridViewTextBoxColumn();
                colCUIL.DataPropertyName = "Cuil"; colCUIL.Name = "Cuil"; colCUIL.HeaderText = "CUIL";
                columnas[13] = colCUIL;

                DataGridViewCheckBoxColumn colBloqueado = new DataGridViewCheckBoxColumn();
                colBloqueado.DataPropertyName = "Bloqueado"; colBloqueado.Name = "Bloqueado"; colBloqueado.HeaderText = "Bloqueado";
                colBloqueado.FalseValue = "0"; colBloqueado.TrueValue = "1";
                columnas[14] = colBloqueado;

                DataGridViewButtonColumn colModif = new DataGridViewButtonColumn();
                colModif.Width = 60;
                colModif.Text = "Modificar";
                colModif.Name = "Modificar";
                colModif.UseColumnTextForButtonValue = true;
                columnas[15] = colModif;

                DataGridViewButtonColumn colElim = new DataGridViewButtonColumn();
                colElim.Width = 60;
                colElim.Text = "Eliminar";
                colElim.Name = "Eliminar";
                colElim.UseColumnTextForButtonValue = true;
                columnas[16] = colElim;

                return columnas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Verifica que el rol se encuentre Habilitado en la base de datos
        /// </summary>
        /// <returns></returns>
        private Boolean validaRolHabilitado() {
            try
            {
                return ClienteDAO.RolHabilitado();
            }
            catch (Exception)
            {   
                throw;
            }
        }

        #endregion
    }
}
