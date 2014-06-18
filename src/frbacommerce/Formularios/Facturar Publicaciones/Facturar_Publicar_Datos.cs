using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Entidades;

namespace FrbaCommerce.Formularios.Facturar_Publicaciones
{
    public partial class Facturar_Publicar_Datos : Form
    {
        private List<ItemFacturacion> colItems { get; set; }

        public Facturar_Publicar_Datos()
        {
          
            InitializeComponent();
        }


        private void Facturar_Publicar_Datos_Load(object sender, EventArgs e)
        {
            
            cmbFormaPago.Items.Insert(0, "Efectivo");
            cmbFormaPago.Items.Insert(1, "Tarjeta");

            cmbFormaPago.SelectedIndex = 0;
            
        }
    }
}
