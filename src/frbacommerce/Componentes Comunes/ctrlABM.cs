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
        List<Filtro> filtrosEnPantalla;

        public ctrlABM()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Método que hace la carga de los filtros que recibe como parametro en las columnas
        /// Izquiera y Derecha, que son del tipo Filtro.
        /// </summary>
        /// <param name="filtrosIzquierda"></param>
        /// <param name="filtrosDerecha"></param>
        public void cargarFiltros(List<Filtro> filtrosIzquierda, List<Filtro> filtrosDerecha)
        {
            try {
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
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
            
        }

        /// <summary>
        /// Carga la grilla con la tabla que recibe como parámetro
        /// </summary>
        /// <param name="tbl"></param>
        public void cargarGrilla(Object lista, DataGridViewTextBoxColumn[] columnas)
        {
            dgvDatos.Columns.AddRange(columnas);
            dgvDatos.AutoGenerateColumns = false;
            cargarGrilla(lista);
        }

        public void cargarGrilla(Object lista)
        {
            Object listDatos = lista;
            dgvDatos.DataSource = listDatos;
        }
        
        private String armarClausuraWhere() {

            String clausulaWhere = "WHERE ";
            bool aplicaWhere = false;

            foreach (Filtro filtro in filtrosEnPantalla)
            {
                if (filtro.obtenerValor() != filtro.obtenerValorNulo())
                {
                    if (filtro.obtenerModoComparacion() == "LIKE")
                    {
                        clausulaWhere += filtro.obtenerCampo() + " LIKE '%" + filtro.obtenerValor() + "%'";
                    }
                    else
                    {
                        clausulaWhere += filtro.obtenerCampo() + " = '" + filtro.obtenerValor() + "'";
                    }
                    aplicaWhere = true;
                }
            }

            return aplicaWhere ? clausulaWhere : "";
        }



        /// <summary>
        /// Carga la grilla filtrando por los parametros seleccionados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            String clausulaWhere = armarClausuraWhere();
            ((ABM)this.ParentForm).aplicarFiltro(clausulaWhere);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            foreach (Filtro filtro in filtrosEnPantalla)
            {
                filtro.LimpiarContenido();
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedCells.Count > 0)
            {
                if (MessageBox.Show("Está seguro que desea dar de baja el registro seleccionado", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MessageBox.Show("Se borra //IMPLEMENTAR CODIGO");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila para dar de baja");
            }
        }

        private void btnModificacion_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedCells.Count > 0)
            {
                    MessageBox.Show("Se abre ventana para modificar //IMPLEMENTAR CODIGO");
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila para modificar");
            }
        }

        
    }
}
