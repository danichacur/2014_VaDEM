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

namespace FrbaCommerce.Formularios.Abm_Empresa
{
    public partial class Empresa_Listar : ABM
    {

        #region VariablesDeClase

        private DataGridView dgv;

        #endregion

        #region Eventos

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Empresa_Listar()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Load de la clase. Cargo los filtros y la grilla con todos los datos sin filtrar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Empresa_Listar_Load(object sender, EventArgs e)
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
                    Metodos_Comunes.MostrarMensaje("El Rol Empresa se encuentra inhabilitado.");
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
                Empresa empresa = (Empresa)dgv.Rows[e.RowIndex].DataBoundItem;
                Formularios.Abm_Empresa.Empresa_Modificar formModif = new Formularios.Abm_Empresa.Empresa_Modificar(empresa);
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
                Empresa empresa = (Empresa)dgv.Rows[e.RowIndex].DataBoundItem;
                empresa.bajaLogica();
                PublicacionDAO.pausarPublicaciones(empresa.IdUsuario);
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
                Formularios.Abm_Empresa.Empresa_Agregar formAlta = new Formularios.Abm_Empresa.Empresa_Agregar();
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
            FiltroTextBox filtroTxt;
            try
            {
                if (!this.ctrlABM1.existenFiltrosCargados())
                {
                    List<Filtro> filtrosI = new List<Filtro>();
                    filtrosI.Add(new FiltroTextBox("Razón Social", "RazonSocial", "LIKE", ""));

                    filtroTxt = new FiltroTextBox("CUIT", "CUIT", "=", "");
                    filtroTxt.setTipoTextoIngresado(FiltroTextBox.TipoTexto.Numerico);
                    filtrosI.Add(filtroTxt);

                    filtrosI.Add(new FiltroTextBox("Mail", "Mail", "LIKE", ""));

                    this.ctrlABM1.cargarFiltros(filtrosI, null);
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
                }
                Object listaRoles = (Object)EmpresaDAO.obtenerEmpresas(clausulaWhere);

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

                DataGridViewColumn[] columnas = new DataGridViewColumn[16];

                DataGridViewTextBoxColumn colRazonSocial = new DataGridViewTextBoxColumn();
                colRazonSocial.DataPropertyName = "RazonSocial"; colRazonSocial.Name = "RazonSocial";
                colRazonSocial.HeaderText = "Razón Social";
                columnas[0] = colRazonSocial;

                DataGridViewTextBoxColumn colCuit = new DataGridViewTextBoxColumn();
                colCuit.DataPropertyName = "Cuit"; colCuit.Name = "Cuit"; colCuit.HeaderText = "CUIT";
                columnas[1] = colCuit;

                DataGridViewTextBoxColumn colTelefono = new DataGridViewTextBoxColumn();
                colTelefono.DataPropertyName = "Telefono"; colTelefono.Name = "Telefono"; colTelefono.HeaderText = "Teléfono";
                columnas[2] = colTelefono;

               DataGridViewTextBoxColumn colDireccion = new DataGridViewTextBoxColumn();
                colDireccion.DataPropertyName = "Direccion"; colDireccion.Name = "Direccion"; colDireccion.HeaderText = "Dirección";
                columnas[3] = colDireccion;

                DataGridViewTextBoxColumn colNumero = new DataGridViewTextBoxColumn();
                colNumero.DataPropertyName = "Numero"; colNumero.Name = "Numero"; colNumero.HeaderText = "Número";
                columnas[4] = colNumero;

                DataGridViewTextBoxColumn colPiso = new DataGridViewTextBoxColumn();
                colPiso.DataPropertyName = "Piso"; colPiso.Name = "Piso"; colPiso.HeaderText = "Piso";
                columnas[5] = colPiso;

                DataGridViewTextBoxColumn colDepartamento = new DataGridViewTextBoxColumn();
                colDepartamento.DataPropertyName = "Departamento"; colDepartamento.Name = "Departamento";
                colDepartamento.HeaderText = "Departamento";
                columnas[6] = colDepartamento;

                DataGridViewTextBoxColumn colLocalidad = new DataGridViewTextBoxColumn();
                colLocalidad.DataPropertyName = "Localidad"; colLocalidad.Name = "Localidad"; colLocalidad.HeaderText = "Localidad";
                columnas[7] = colLocalidad;

                DataGridViewTextBoxColumn colCodPostal = new DataGridViewTextBoxColumn();
                colCodPostal.DataPropertyName = "CodigoPostal"; colCodPostal.Name = "CodigoPostal";
                colCodPostal.HeaderText = "Código Postal";
                columnas[8] = colCodPostal;

                DataGridViewTextBoxColumn colCuidad = new DataGridViewTextBoxColumn();
                colCuidad.DataPropertyName = "Cuidad"; colCuidad.Name = "Cuidad";
                colCuidad.HeaderText = "Cuidad";
                columnas[9] = colCuidad;

                DataGridViewTextBoxColumn colMail = new DataGridViewTextBoxColumn();
                colMail.DataPropertyName = "Email"; colMail.Name = "E-Mail"; colMail.HeaderText = "E-Mail";
                columnas[10] = colMail;

                DataGridViewTextBoxColumn colNombreContacto = new DataGridViewTextBoxColumn();
                colNombreContacto.DataPropertyName = "NombreContacto"; colNombreContacto.Name = "NombreContacto";
                colNombreContacto.HeaderText = "Nombre Contacto";
                columnas[11] = colNombreContacto;

                DataGridViewTextBoxColumn colFechaCreacion = new DataGridViewTextBoxColumn();
                colFechaCreacion.DataPropertyName = "fechaCreacion"; colFechaCreacion.Name = "fechaCreacion";
                colFechaCreacion.HeaderText = "Fecha Creación";
                columnas[12] = colFechaCreacion;

                DataGridViewCheckBoxColumn colBloqueado = new DataGridViewCheckBoxColumn();
                colBloqueado.DataPropertyName = "Bloqueado"; colBloqueado.Name = "Bloqueado"; colBloqueado.HeaderText = "Bloqueado";
                colBloqueado.FalseValue = "0"; colBloqueado.TrueValue = "1";
                columnas[13] = colBloqueado;

                DataGridViewButtonColumn colModif = new DataGridViewButtonColumn();
                colModif.Width = 60;
                colModif.Text = "Modificar";
                colModif.Name = "Modificar";
                colModif.UseColumnTextForButtonValue = true;
                columnas[14] = colModif;

                DataGridViewButtonColumn colElim = new DataGridViewButtonColumn();
                colElim.Width = 60;
                colElim.Text = "Eliminar";
                colElim.Name = "Eliminar";
                colElim.UseColumnTextForButtonValue = true;
                columnas[15] = colElim;

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
        private Boolean validaRolHabilitado()
        {
            try
            {
                return EmpresaDAO.RolHabilitado();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        
    }
}
