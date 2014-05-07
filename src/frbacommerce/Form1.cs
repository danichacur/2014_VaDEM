using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Entidades;

namespace FrbaCommerce
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Rol> roles = new List<Rol>();

            roles.Add(new Rol(1,"asaa",true));
            roles.Add(new Rol(2,"aasadsaa",true));
            roles.Add(new Rol(3,"asazczxcza",false));

            cargarTabla((Object) roles);
        }

        public void cargarTabla(Object lista) {
            dataGridView1.DataSource = lista;
        }
    }
}
