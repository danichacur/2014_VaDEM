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

namespace FrbaCommerce.Abm_Cliente
{
    public partial class ABM_Cliente : ABM
    {
        public ABM_Cliente()
        {
            InitializeComponent();
        }

        private void ABM_Cliente_Load(object sender, EventArgs e)
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
                filtrosI.Add(new FiltroTextBox("DNI", "DNI", "=", ""));
               /* filtrosI.Add(new FiltroTextBox("Descripcion", "Descripcion", "LIKE", ""));
                filtrosI.Add(new FiltroComboBox("Habilitado", "Habilitado", "=", "-1", obtenerTablaComboHabilitado(), "id", "descripcion"));
                */
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
                String script = "SELECT * FROM vadem.cliente ";
                script += clausulaWhere;

                Object listaClientes = (Object)ClienteDAO.obtenerClientes(script);

                DataGridViewTextBoxColumn[] columnas = new DataGridViewTextBoxColumn[1];

                DataGridViewTextBoxColumn colDNI = new DataGridViewTextBoxColumn();
                colDNI.DataPropertyName = "Dni";
                colDNI.Name = "Dni";
                colDNI.HeaderText = "El DNI";
                columnas[0] = colDNI;

                this.ctrlABM1.cargarGrilla(listaClientes, columnas);
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
        }
    }
}
