using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Componentes_Comunes
{
    public class Filtro : UserControl
    {
        protected String campo;
        protected String modoComparacion;
        protected String valorNulo;

        public virtual String obtenerValor(){
            return "";
        }

        public String obtenerCampo()
        {
            return campo;
        }

        public String obtenerModoComparacion()
        {
            return modoComparacion;
        }

        public String obtenerValorNulo()
        {
            return valorNulo;
        }

        public virtual void LimpiarContenido()
        {            
        }
        
        public virtual void colocarValor(object texto)
        {
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Filtro
            // 
            this.Name = "Filtro";
            this.Size = new System.Drawing.Size(152, 186);
            this.ResumeLayout(false);

        }

        

        public void setlblFiltroBase(Control ctrl, String cadena)
        {
            ctrl.Text = cadena + ":";
        }
    }
}
