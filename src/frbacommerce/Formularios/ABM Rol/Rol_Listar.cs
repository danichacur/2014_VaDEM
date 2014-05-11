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

        private DataGridView dgv;

        public Rol_Listar()
        {
            InitializeComponent();
        }

        private void ABM_Rol_Load(object sender, EventArgs e)
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

        private void cargaFiltros()
        {
            try
            {
                List<Filtro> filtrosI = new List<Filtro>();
                filtrosI.Add(new FiltroTextBox("Rol", "IdRol", "=", ""));
                filtrosI.Add(new FiltroTextBox("Descripcion", "Descripcion", "LIKE", ""));
                filtrosI.Add(new FiltroComboBox("Habilitado", "Habilitado", "=", "-1", obtenerTablaComboHabilitado(), "id", "descripcion"));

                /*  List<Control> filtrosD = new List<Control>();
                  filtrosD.Add(new FiltroIgual());
                  filtrosD.Add(new FiltroLike());
                */
                this.ctrlABM1.cargarFiltros(filtrosI, null);
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }

        }

        private void cargaInicialGrilla()
        {
            try
            {

                aplicarFiltro("");
                dgv.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }

        }

        public override void aplicarFiltro(String clausulaWhere)
        {
            try
            {
                String script = "SELECT * FROM vadem.rol ";
                script += clausulaWhere;

                Object listaRoles = (Object)RolDAO.obtenerRoles(script);

                DataGridViewColumn[] columnas = obtenerDisenoColumnasGrilla();

                dgv = this.ctrlABM1.cargarGrilla(listaRoles, columnas);

            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
        }


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

        private DataTable obtenerTablaComboHabilitado()
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
                row["id"] = -1; row["descripcion"] = "";
                tbl.Rows.Add(row);

                row = tbl.NewRow();
                row["id"] = 0; row["descripcion"] = "Deshabilitado";
                tbl.Rows.Add(row);

                row = tbl.NewRow();
                row["id"] = 1; row["descripcion"] = "Habilitado";
                tbl.Rows.Add(row);

                return tbl;
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }

        }

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
                MessageBox.Show(ex.Message);
            }
        }

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
                throw ex;
            }
        }

        private void btnEliminar_Click(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Rol rol = (Rol)dgv.Rows[e.RowIndex].DataBoundItem;
                rol.eliminar();
                ctrlABM1.buscar();
            }
            catch (Exception)
            {
                throw;
            }
        }

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
                throw ex;
            }
        }


    }
}
