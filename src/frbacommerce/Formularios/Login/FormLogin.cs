using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Componentes_Comunes;

namespace FrbaCommerce.Formularios.Login
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            Filtro filtro;
            try
            {
                filtro = new FiltroTextBox("Username", "", "=", "");
                filtro.Location = new Point(20, 20); ;
                this.Controls.Add(filtro);

                filtro = new FiltroTextBox("Password", "", "=", "");
                filtro.Location = new Point(20, 60); ;
                this.Controls.Add(filtro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                //Validar

                Session.IdUsuario = 123;
                Session.IdRol = 1;

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
