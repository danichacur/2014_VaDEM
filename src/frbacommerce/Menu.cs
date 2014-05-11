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

        Form abmRol, abmRubro, abmCliente, abmPublicacion, abmFacturacion, formCompras, formHistorial, formCalificar, formResponder, formEstadisticas;

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

        private void btn_Publicacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (abmPublicacion == null)
                {
                    abmPublicacion = new Generar_Publicacion.Listado();
                }
                abmPublicacion.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            try
            {
                if (formEstadisticas == null)
                {
                    formEstadisticas = new Listado_Estadistico.Form1();
                }
                formEstadisticas.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            try
            {
                if (abmFacturacion == null)
                {
                    abmFacturacion = new Facturar_Publicaciones.Form1();
                }
                abmFacturacion.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnResponder_Click(object sender, EventArgs e)
        {
            try
            {
                if (formResponder == null)
                {
                    formResponder = new Gestion_de_Preguntas.Form1();
                }
                formResponder.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCalificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (formCalificar == null)
                {
                    formCalificar = new Calificar_Vendedor.Form1();
                }
                formCalificar.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            try
            {
                if (formHistorial == null)
                {
                    formHistorial = new Historial_Cliente.Form1();
                }
                formHistorial.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnComprar_Ofertar_Click(object sender, EventArgs e)
        {
            try
            {
                if (formCompras == null)
                {
                    formCompras = new Comprar_Ofertar.Form1();
                }
                formCompras.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
