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
using FrbaCommerce.Formularios;

namespace FrbaCommerce.ABM_Rol
{
    public partial class Rol_Listar : ABM
    {
        #region VariablesDeClase

        private DataGridView dgv;

        #endregion

        #region Eventos 

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Rol_Listar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load de la clase. Cargo los filtros y la grilla con todos los datos sin filtrar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ABM_Rol_Load(object sender, EventArgs e)
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
                Rol rol = (Rol)dgv.Rows[e.RowIndex].DataBoundItem;
                Formularios.ABM_Rol.Rol_Modificar formAlta = new Formularios.ABM_Rol.Rol_Modificar(rol);
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
        /// Se elimina el rol seleccionado. La baja es lógica, pero la misma se define en la clase de la entidad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Rol rol = (Rol)dgv.Rows[e.RowIndex].DataBoundItem;
                rol.eliminar();
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
                Formularios.ABM_Rol.Rol_Agregar formAlta = new Formularios.ABM_Rol.Rol_Agregar();
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
                List<Filtro> filtrosI = new List<Filtro>();
                filtrosI.Add(new FiltroTextBox("Rol", "IdRol", "=", ""));
                filtrosI.Add(new FiltroTextBox("Descripcion", "Descripcion", "LIKE", ""));
                filtrosI.Add(new FiltroComboBox("Habilitado", "Habilitado", "=", "-1", Metodos_Comunes.obtenerTablaComboHabilitadoConVacio(), "id", "descripcion"));

                /*  List<Control> filtrosD = new List<Control>();
                  filtrosD.Add(new FiltroIgual());
                  filtrosD.Add(new FiltroLike());
                */
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
                Object listaRoles = (Object)RolDAO.obtenerRoles(clausulaWhere);

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
                DataGridViewColumn[] columnas = new DataGridViewColumn[5];

                DataGridViewTextBoxColumn colIdRol = new DataGridViewTextBoxColumn();
                colIdRol.DataPropertyName = "Id"; colIdRol.Name = "Id"; colIdRol.HeaderText = "Id";
                columnas[0] = colIdRol;

                DataGridViewTextBoxColumn colDesc = new DataGridViewTextBoxColumn();
                colDesc.DataPropertyName = "Descripcion"; colDesc.Name = "Descripcion"; colDesc.HeaderText = "Descripcion";
                columnas[1] = colDesc;

                DataGridViewCheckBoxColumn colHabilitado = new DataGridViewCheckBoxColumn();
                colHabilitado.DataPropertyName = "Habilitado"; colHabilitado.Name = "Habilitado"; colHabilitado.HeaderText = "Habilitado";
                colHabilitado.FalseValue = "0"; colHabilitado.TrueValue = "1";
                columnas[2] = colHabilitado;

                DataGridViewButtonColumn colModif = new DataGridViewButtonColumn();
                colModif.Width = 60;
                colModif.Text = "Modificar";
                colModif.Name = "Modificar";
                colModif.UseColumnTextForButtonValue = true;
                columnas[3] = colModif;

                DataGridViewButtonColumn colElim = new DataGridViewButtonColumn();
                colElim.Width = 60;
                colElim.Text = "Eliminar";
                colElim.Name = "Eliminar";
                colElim.UseColumnTextForButtonValue = true;
                columnas[4] = colElim;

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