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

namespace FrbaCommerce.Generar_Publicacion
{
    public partial class Listado : Form
    {
        public Listado()
        {
            InitializeComponent();
        }

        private void Listado_Load(object sender, EventArgs e)
        {
            try
            {
                cargaFiltros();
               // cargaInicialGrilla();
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
                filtrosI.Add(new FiltroComboBox("Tipo", "IdTipo", "=", "0", obtenerTiposPublicacion(), "id", "descripcion"));
                filtrosI.Add(new FiltroComboBox("Estado", "IdEstado", "=", "0", obtenerEstados(), "IdEstado", "Descripcion"));
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


        private DataTable obtenerTiposPublicacion()
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
                row["id"] = 0; row["descripcion"] = "";
                tbl.Rows.Add(row);

                row = tbl.NewRow();
                row["id"] = 1; row["descripcion"] = "Compra Inmediata";
                tbl.Rows.Add(row);

                row = tbl.NewRow();
                row["id"] = 2; row["descripcion"] = "Subasta";
                tbl.Rows.Add(row);

                return tbl;
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
        }

        private DataTable obtenerEstados()
        {
            try
            {

                String script = "SELECT * FROM vadem.estado ";

                DataTable listaEstados = EstadoPublicacionDAO.obtenerEstados(script);
                return listaEstados;
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }


        }
    }
}
