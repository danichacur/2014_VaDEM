﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Formularios.ABM_Rol;

namespace FrbaCommerce.Componentes_Comunes
{
    public partial class ctrlAltaModificacion : UserControl
    {

        private List<Filtro> camposEnPantalla;

        public ctrlAltaModificacion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Método que hace la carga de los filtros que recibe como parametro en las columnas
        /// que son del tipo Filtro.
        /// </summary>
        /// <param name="filtrosIzquierda"></param>
        /// <param name="filtrosDerecha"></param>
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
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
        }

        public List<Filtro> obtenerCamposEnPantalla() {
            return camposEnPantalla;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ((Rol_Agregar)this.ParentForm).btnAceptar_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                ((Rol_Agregar)this.ParentForm).btnCancelar_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
