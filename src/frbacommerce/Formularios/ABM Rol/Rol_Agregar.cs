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

namespace FrbaCommerce.Formularios.ABM_Rol
{
    public partial class Rol_Agregar : Form
    {
        Rol rol;
       
        public Rol_Agregar()
        {
            InitializeComponent();
        }

        private void AltaModif_Rol_Load(object sender, EventArgs e)
        {
            try
            {
                rol = new Rol();
                cargarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cargarCampos()
        {
            try
            {
                List<Filtro> filtros = new List<Filtro>();
                filtros.Add(new FiltroTextBox("Rol", "IdRol", "=", ""));
                filtros.Add(new FiltroTextBox("Descripcion", "Descripcion", "LIKE", ""));
                filtros.Add(new FiltroDgvCheck(obtenerListaFuncionalidades()));

                this.ctrlAltaModificacion1.cargarFiltros(filtros);
            }
            catch (Exception ex)
            {
                throw ex;
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

        public List<Filtro> obtenerCamposEnPantalla() {
            try
            {
                return ctrlAltaModificacion1.obtenerCamposEnPantalla();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public virtual void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Filtro> campos = obtenerCamposEnPantalla();
                rol.Id = Convert.ToInt32(campos[0].obtenerValor());
                rol.Descripcion = campos[1].obtenerValor();
                rol.Habilitado = (campos[2].obtenerValor() == "1" ? true : false);
                rol.insertar();

                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public virtual void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private List<Funcionalidad> obtenerListaFuncionalidades() {
            return FuncionalidadDAO.obtenerFuncionalidades();
        }
    }
}
