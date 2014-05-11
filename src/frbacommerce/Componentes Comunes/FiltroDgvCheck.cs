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
        public FiltroDgvCheck(Object items)
        {
            InitializeComponent();
            cargarGrilla(items);
        }

        private void cargarGrilla(Object items)
        {
            dgv.DataSource = items;
        }
    }
}
