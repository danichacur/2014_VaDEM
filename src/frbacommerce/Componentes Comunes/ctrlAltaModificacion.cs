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
    public partial class ctrlAltaModificacion : UserControl
    {

        #region VariablesDeClase

        private List<Filtro> camposEnPantalla;

        /// <summary>
        /// getter de obtenerCamposEnPantalla
        /// </summary>
        /// <returns></returns>
        public List<Filtro> obtenerCamposEnPantalla()
        {
            return camposEnPantalla;
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ctrlAltaModificacion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento del boton Aceptar. Delega la funcionalidad.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ((Form_Agregar)this.ParentForm).btnAceptar_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Evento del boton Cancelar. Delega la funcionalidad.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                ((Form_Agregar)this.ParentForm).btnCancelar_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region MetodosGenerales

        /// <summary>
        /// Método que hace la carga de los filtros que recibe como parametro 
        /// que son del tipo Filtro.
        /// </summary>
        /// <param name="filtros"></param>
        public void cargarFiltros(List<Filtro> filtros)
        {
            try
            {
                int contador;

                camposEnPantalla = new List<Filtro>();

                if (filtros != null)
                {
                    contador = 0;
                    foreach (Filtro filtro in filtros)
                    {
                        filtro.Location = new Point(40, 60 + 30 * contador); ;
                        this.Controls.Add(filtro);
                        contador += 1;

                        camposEnPantalla.Add(filtro);
                    }

                    ((Form)this.ParentForm).Height = ((Form)this.ParentForm).Height + 30 * contador;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

   }
}