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
    public partial class FiltroTextBox : Filtro
    {
        public FiltroTextBox(String textolbl, String pCampo, String pModoComparacion, String pValorNulo)
        {
            InitializeComponent();

            campo = pCampo;
            modoComparacion = pModoComparacion;
            valorNulo = pValorNulo;

            setlblFiltroBase(this.lblFiltro, textolbl);
        }

        public override String obtenerValor()
        {
            return txtFiltro.Text;
        }

        public override void LimpiarContenido()
        {
            txtFiltro.Text = "";
        }

        public override void colocarValor(Object texto)
        {
            txtFiltro.Text = Convert.ToString(texto);
        }
      
    }
}
