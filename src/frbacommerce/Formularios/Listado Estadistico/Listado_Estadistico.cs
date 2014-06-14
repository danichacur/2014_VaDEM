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

namespace FrbaCommerce.Formularios.Listado_Estadistico
{
    public partial class Listado_Estadistico : ABM
    {
        public Listado_Estadistico()
        {
            InitializeComponent();
        }

        private void Listado_Estadistico_Load(object sender, EventArgs e)
        {

            try
            {
                
                cargarComboTiposEstadisticas();


            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }

        }

        private void cargarComboTiposEstadisticas()
        {
            try
            {
                cboTipoEstadistica.DataSource = Metodos_Comunes.obtenerTablaComboTiposEstadisticas();
                cboTipoEstadistica.DisplayMember = "Descripcion";
                cboTipoEstadistica.ValueMember = "Id";
            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }
}
