﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Componentes_Comunes
{
    public class Filtro : UserControl
    {
        #region VariablesDeClase

        protected String campo;
        protected String modoComparacion;
        protected String valorNulo;
        protected Boolean obligatorio = false;

        #endregion

        #region Getters

        public virtual Object obtenerValor()
        {
            return null;
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

        public Boolean obtenerObligatorio()
        {
            return obligatorio;
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Filtro
            // 
            this.Name = "Filtro";
            this.Size = new System.Drawing.Size(578, 28);
            this.ResumeLayout(false);

        }

        #endregion

        #region MetodosGenerales

        /// <summary>
        /// Delega la funcionalidad en la implementacion
        /// </summary>
        public virtual void LimpiarContenido()
        {
        }

        /// <summary>
        /// Delega la funcionalidad en la implementacion
        /// </summary>
        public virtual void colocarValor(object texto)
        {
        }

        /// <summary>
        /// Setteo si es obligatorio o no completar el campo para seguir
        /// </summary>
        public virtual void setObligatorio(Boolean esObligatorio)
        {
            try
            {
                obligatorio = esObligatorio;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual void agregarEventoKeyPress(System.Windows.Forms.KeyPressEventHandler evento)
        {
        }

        /// <summary>
        /// <summary>
        /// Retorna el String del Label
        /// </summary>
        /// <returns></returns>
        public  String obtenerLabel()
        {
            try
            {
                return this.Name;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region MetodosAuxiliares

        public void setlblFiltroBase(Control ctrl, String cadena)
        {
            ctrl.Text = cadena + ":";
        }
        
        #endregion
    }
}
