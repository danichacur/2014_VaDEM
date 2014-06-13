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
    public partial class FiltroFecha : Filtro
    {

        #region VariablesDeClase
        #endregion

        #region Eventos

        /// <summary>
        /// Constructor vacio de la clase
        /// </summary>
        public FiltroFecha()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="textolbl"></param>
        /// <param name="pCampo"></param>
        /// <param name="pModoComparacion"></param>
        /// <param name="pValorNulo"></param>
        public FiltroFecha(String textolbl, String pCampo, String pModoComparacion, String pValorNulo) {
            InitializeComponent();

            try
            {
                this.Name = pCampo;
                campo = pCampo;
                modoComparacion = pModoComparacion;
                valorNulo = pValorNulo;

                setlblFiltroBase(this.lblFiltro, textolbl);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="textolbl"></param>
        /// <param name="pCampo"></param>
        public FiltroFecha(String textolbl, String pCampo)
        {
            InitializeComponent();

            try
            {
                this.Name = pCampo;
                campo = pCampo;
                
                setlblFiltroBase(this.lblFiltro, textolbl);
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion

        
        #region MetodosGenerales
    
        /// <summary>
        /// Obligatorio de Implementar
        /// Obtiene el valor seleccionado del combobox (El valor, no el texto)
        /// </summary>
        /// <returns></returns>
        public override Object obtenerValor()
        {
            try
            {
                return dtpFecha.Value;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Obligatorio de Implementar
        /// Vuelvo el combo a la primer posicion (posicion vacia)
        /// </summary>
        public override void LimpiarContenido()
        {
            try
            {
                dtpFecha.Text = "";
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Obligatorio de Implementar
        /// Selecciono el valor del combo que coincide con el valor recibido por parámetro.
        /// </summary>
        /// <param name="texto"></param>
        public override void colocarValor(Object texto)
        {
            try
            {
                dtpFecha.Value = Convert.ToDateTime(texto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


    }
}
