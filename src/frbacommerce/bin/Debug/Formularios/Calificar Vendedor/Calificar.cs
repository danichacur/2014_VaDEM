using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Componentes_Comunes;

namespace FrbaCommerce.Formularios.Calificar_Vendedor
{
    public partial class Calificar : Form
    {
        public Calificar()
        {
            InitializeComponent();
        }

        private void Calificar_Load(object sender, EventArgs e)
        {
            try
            {
                cargarComboPuntaje();
            }
            catch (Exception ex)
            {
               Metodos_Comunes.MostrarMensajeError(ex);
            }
        }

        private void cargarComboPuntaje()
        {
            try
            {
                cboPuntaje.DataSource = Metodos_Comunes.obtenerTablaComboPuntajes();
                cboPuntaje.DisplayMember = "Descripcion";
                cboPuntaje.ValueMember = "Id";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
