using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Componentes_Comunes;

namespace FrbaCommerce.Componentes_Comunes
{
    public partial class ctrlABM : UserControl
    {
        #region VariablesDeClase

        List<Filtro> filtrosEnPantalla;

        #endregion

        #region Eventos

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ctrlABM()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento click del boton Buscar. Delega el buscar en el método buscar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                buscar();
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }

        }

        /// <summary>
        /// Vuelve todos los campos al valor nulo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Filtro filtro in filtrosEnPantalla)
                {
                    filtro.LimpiarContenido();
                }
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }

        /// <summary>
        /// Evento del boton Aceptar. Delega la funcionalidad.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                ((ABM)this.ParentForm).btnAlta_Click();
            }
            catch (Exception)
            {
            }

        }

        #endregion

        #region MetodosGenerales

        /// <summary>
        /// Método que hace la carga de los filtros que recibe como parametro en las columnas
        /// Izquiera y Derecha, que son del tipo Filtro.
        /// </summary>
        /// <param name="filtrosIzquierda"></param>
        /// <param name="filtrosDerecha"></param>
        public void cargarFiltros(List<Filtro> filtrosIzquierda, List<Filtro> filtrosDerecha)
        {
            try
            {
                int contador;

                filtrosEnPantalla = new List<Filtro>();

                if (filtrosIzquierda != null)
                {
                    contador = 0;
                    foreach (Filtro filtro in filtrosIzquierda)
                    {
                        filtro.Location = new Point(0, 30 * contador); ;
                        this.Controls.Add(filtro);
                        contador += 1;

                        filtrosEnPantalla.Add(filtro);
                    }
                }

                if (filtrosDerecha != null)
                {
                    contador = 0;
                    foreach (Filtro filtro in filtrosDerecha)
                    {
                        filtro.Location = new Point(200, 30 * contador); ;
                        this.Controls.Add(filtro);
                        contador += 1;

                        filtrosEnPantalla.Add(filtro);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Carga la grilla con la lista que recibe como parámetro y con la estructura de las columnas que recibe
        /// </summary>
        /// <param name="tbl"></param>
        public DataGridView cargarGrilla(Object lista, DataGridViewColumn[] columnas)
        {
            try
            {
                dgvDatos.Columns.Clear();
                if (dgvDatos.Columns.Count == 0)
                {
                    dgvDatos.Columns.AddRange(columnas);
                    dgvDatos.AutoGenerateColumns = false;
                }
                cargarGrilla(lista);

                return dgvDatos;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Carga la grilla con la lista que recibe como parámetro 
        /// </summary>
        /// <param name="lista"></param>
        public void cargarGrilla(Object lista)
        {
            try
            {
                Object listDatos = lista;
                dgvDatos.DataSource = null;
                dgvDatos.DataSource = listDatos;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Recorre los filtros seleccionados y arma la clausula where para el script del SELECT 
        /// </summary>
        /// <returns></returns>
        private String armarClausuraWhere()
        {
            try
            {
                String clausulaWhere = "WHERE ";
                bool aplicaWhere = false;

                foreach (Filtro filtro in filtrosEnPantalla)
                {
                    if (filtro.obtenerValor().ToString() != filtro.obtenerValorNulo().ToString())
                    {
                        if (filtro.obtenerModoComparacion() == "LIKE")
                        {
                            clausulaWhere += filtro.obtenerCampo() + " LIKE '%" + filtro.obtenerValor() + "%'";
                        }
                        else
                        {
                            clausulaWhere += filtro.obtenerCampo() + " = '" + filtro.obtenerValor() + "'";
                        }
                        clausulaWhere += " AND ";
                        aplicaWhere = true;
                    }
                }
                clausulaWhere = clausulaWhere.Substring(0, clausulaWhere.Length - 5);
                return aplicaWhere ? clausulaWhere : "";
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Carga la grilla filtrando por los parametros seleccionados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buscar()
        {
            try
            {
                String clausulaWhere = armarClausuraWhere();
                ((ABM)this.ParentForm).aplicarFiltro(clausulaWhere);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region MetodosAuxiliares
        #endregion
    }
}