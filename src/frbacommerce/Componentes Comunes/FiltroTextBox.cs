﻿using System;
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
        #endregion

        #region Eventos

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="textolbl"></param>
        /// <param name="pCampo"></param>
        /// <param name="pModoComparacion"></param>
        /// <param name="pValorNulo"></param>
        /// <param name="itemsCombo"></param>
        /// <param name="value"></param>
        /// <param name="display"></param>
        public FiltroTextBox(String textolbl, String pCampo, String pModoComparacion, String pValorNulo)
        {
            InitializeComponent();

            campo = pCampo;
            modoComparacion = pModoComparacion;
            valorNulo = pValorNulo;

            setlblFiltroBase(this.lblFiltro, textolbl);
        }

        #endregion

        #region MetodosGenerales

        /// <summary>
        /// Obligatorio de Implementar
        /// Obtiene el valor seleccionado del combobox (El valor, no el texto)
        /// </summary>
        /// <returns></returns>
        public override String obtenerValor()
        {
            try
            {
                return txtFiltro.Text;
            }
            catch (Exception ex)
            {
                throw ex;
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
            catch (Exception ex)
            {
                throw ex;
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region MetodosAuxiliares
        #endregion
    }
}