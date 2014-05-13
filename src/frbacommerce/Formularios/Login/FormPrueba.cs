using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Login
{
    public partial class Form1 : Form
    {
        Control cont1;
        Control cont2;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            cont1 = new UserControl1();
            cont2 = new UserControl2();
            comboBox1.Items.Add("gola");
            comboBox1.Items.Add("aaaaa");
            comboBox1.Items.Add("sssa");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Controls.Contains(cont1))
            {
                
            }
            else {
                

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                this.Controls.Remove(cont1);
                this.Controls.Add(cont2);
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                this.Controls.Remove(cont2);
                this.Controls.Add(cont1);
            }
            else { 
                this.Controls.Remove(cont1);
                this.Controls.Remove(cont2);
            }




        }
    }
}
