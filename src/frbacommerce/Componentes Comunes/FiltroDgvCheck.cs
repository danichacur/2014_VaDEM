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
    public partial class FiltroDgvCheck : Filtro
    {
        public FiltroDgvCheck(String textolbl, String pNombre, String pValorNulo, List<Object> items, DataGridViewColumn[] columnas)
        {
            InitializeComponent();

            this.Name = pNombre;
            valorNulo = pValorNulo;
            setlblFiltroBase(this.lblFiltro, textolbl);
            cargarGrilla(items, columnas);

        }

        private void cargarGrilla(List<Object> items, DataGridViewColumn[] columnas)
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.AddRange(columnas);
            dgv.DataSource = items;
            this.Size = new System.Drawing.Size(this.Size.Width, 24 * items.Count);
        }

        /// <summary>
        /// Obligatorio de Implementar
        /// Selecciono el valor del combo que coincide con el valor recibido por parámetro.
        /// </summary>
        /// <param name="texto">por ejemplo 1,2,3</param>
        public override void colocarValor(Object texto)
        {
            DataGridViewRow row;
            int idx;
            Boolean encontrado;
            try
            {
                //Por cada id  que viene en el texto parámetro, activo el check correspondiente
                foreach (String id in ((String)texto).Split(new Char [] {','}))
                {
                    idx = 0;
                    encontrado = false;

                    while (idx <= dgv.RowCount - 1 && !encontrado)
                    {
                        row = dgv.Rows[idx];
                        if (row.Cells["id"].Value.ToString() == id) {
                            row.Cells["check"].Value = true;
                            encontrado = true;
                        }
                        idx++;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obligatorio de Implementar
        /// Obtiene el valor seleccionado del combobox (El valor, no el texto)
        /// </summary>
        /// <returns></returns>
        public override Object obtenerValor()
        {
            DataGridViewRow row;
            int idx;
            String valor;
            try
            {
                idx = 0;
                valor = "";
                while (idx <= dgv.RowCount - 1)
                {
                    row = dgv.Rows[idx];
                    if (row.Cells["check"].Value != null)
                    {
                        if ((bool)row.Cells["check"].Value)
                        {
                            valor += row.Cells["id"].Value.ToString() + ",";
                        }
                    }
                    idx++;
                }
                valor = valor.Substring(0, valor.Length - 1);
                return valor;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
