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

namespace FrbaCommerce.ABM_Rol
{
    public partial class ABM_Rol : ABM
    {
        public ABM_Rol()
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

               

                this.ctrlABM1.cargarGrilla(listaRoles);
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
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
    }
}
