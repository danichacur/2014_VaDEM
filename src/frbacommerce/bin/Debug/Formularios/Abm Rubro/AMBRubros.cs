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

namespace FrbaCommerce.Abm_Rubro
{
    public partial class Abm_Rubro : ABM
    {
        public Abm_Rubro()
        {
            InitializeComponent();
        }

        private void Abm_Rubro_Load(object sender, EventArgs e)
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
                filtrosI.Add(new FiltroTextBox("Rubro", "IdRubro","=",""));
                filtrosI.Add(new FiltroTextBox("Descripcion", "Descripcion","LIKE",""));
               
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
                String script = "SELECT * FROM vadem.rubro ";
                script += clausulaWhere;

                Object listaRubros = RubroDAO.obtenerRubros(script);
                this.ctrlABM1.cargarGrilla(listaRubros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
        }

        

                
    }
}

