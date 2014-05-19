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
    }
}
