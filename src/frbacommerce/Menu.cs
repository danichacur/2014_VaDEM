using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace FrbaCommerce
{
    public partial class Menu : Form
    {

        Form abmRol, abmRubro, abmCliente;

        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (abmRol == null)
                {
                    abmRol = new ABM_Rol.Rol_Listar();
                }
                abmRol.ShowDialog();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (abmRubro == null)
                {
                    abmRubro = new Abm_Rubro.Abm_Rubro();
                }
                abmRubro.ShowDialog();
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            try
            {
                if (abmCliente == null)
                {
                    abmCliente = new Abm_Cliente.ABM_Cliente();
                }
                abmCliente.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
