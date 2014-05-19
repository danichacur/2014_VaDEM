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
    public partial class FiltroTextBoxPassword : FiltroTextBox
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public FiltroTextBoxPassword()
        {
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="textolbl"></param>
        /// <param name="pCampo"></param>
        /// <param name="pModoComparacion"></param>
        /// <param name="pValorNulo"></param>
        public FiltroTextBoxPassword(String textolbl, String pCampo, String pModoComparacion, String pValorNulo) : base(textolbl,pCampo,pModoComparacion,pValorNulo)
        {
            TextBox txt = getTxtFiltro();
            txt.UseSystemPasswordChar = true;
        }

        /// <summary>
        /// Agrego el evento recibido por parámetro a los keypress
        /// </summary>
        /// <param name="evento"></param>
        public override void agregarEventoKeyPress(System.Windows.Forms.KeyPressEventHandler evento)
        {
            ((TextBox)this.getTxtFiltro()).KeyPress += evento;
        }
    }
}
