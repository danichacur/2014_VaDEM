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
        #region VariablesDeClase

        public enum TipoTexto { Numerico, NumericoConComa };

        #endregion

        #region Eventos

        /// <summary>
        /// Constructor vacio de la clase
        /// </summary>
        public FiltroTextBox()
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
        public FiltroTextBox(String textolbl, String pCampo, String pModoComparacion, String pValorNulo)
        {
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
        public FiltroTextBox(String textolbl, String pCampo)
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
        /// Recibe los parámetros necesarios a ser seteados
        /// </summary>
        /// <param name="textolbl"></param>
        /// <param name="pCampo"></param>
        /// <param name="pModoComparacion"></param>
        /// <param name="pValorNulo"></param>
        public void setearParametros(String textolbl, String pCampo, String pModoComparacion, String pValorNulo)
        {
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
        /// devuelve el control txtFiltro
        /// </summary>
        /// <returns></returns>
        public TextBox getTxtFiltro()
        {
            return this.txtFiltro;
        }

        /// <summary>
        /// Obligatorio de Implementar
        /// Obtiene el valor seleccionado del combobox (El valor, no el texto)
        /// </summary>
        /// <returns></returns>
        public override Object obtenerValor()
        {
            try
            {
                return txtFiltro.Text;
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
                txtFiltro.Text = "";
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
                txtFiltro.Text = Convert.ToString(texto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void setTipoTextoIngresado(TipoTexto tipo)
        {
            try
            {
                switch (tipo) {
                    case TipoTexto.Numerico:
                        txtFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(numerico_KeyPress);
                        break;
                    case TipoTexto.NumericoConComa:
                        txtFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(numericoConComa_KeyPress);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Evento keyPress. Solo habilita números
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar)) { e.Handled = true; }
        }

        /// <summary>
        /// Evento keyPress. Solo habilita números y la coma
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericoConComa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar) && (e.KeyChar != ',')) { e.Handled = true; }
        }

        #endregion

        #region MetodosAuxiliares
        #endregion
    }
}