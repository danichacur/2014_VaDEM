using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Componentes_Comunes
{
    public partial class FiltroComboBox : Filtro
    {
        public FiltroComboBox(String textolbl, String pCampo, String pModoComparacion, String pValorNulo, DataTable itemsCombo, String value, String display)
        {
            InitializeComponent();

            campo = pCampo;
            modoComparacion = pModoComparacion;
            valorNulo = pValorNulo;

            setlblFiltroBase(this.lblFiltro, textolbl);

            cargarCombo(itemsCombo, value, display);
        }

        public override String obtenerValor()
        {
            return cboFiltro.SelectedValue.ToString();
        }

        public override void LimpiarContenido()
        {
            //cboFiltro.Text = "";
            cboFiltro.SelectedIndex = 0;
        }

        private void cargarCombo(DataTable itemsCombo, String value, String display){
            cboFiltro.DataSource = itemsCombo;
            cboFiltro.DisplayMember = display;
            cboFiltro.ValueMember = value;
        }
    }
}
