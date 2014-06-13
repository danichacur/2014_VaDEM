using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FrbaCommerce
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Formularios.Login.FormLogin login = new Formularios.Login.FormLogin();
            System.Windows.Forms.DialogResult result = login.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Application.Run(new Menu());
            }
            //new FrbaCommerce.Formularios.Login.FormLogin()

            
            //Application.Run(new Form1());
        }
    }
}
