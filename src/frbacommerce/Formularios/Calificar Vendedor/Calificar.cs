using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Componentes_Comunes;

namespace FrbaCommerce.Formularios.Calificar_Vendedor
{
    public partial class Calificar : Form
    {
        public Calificar()
        {
            InitializeComponent();
        }

        private void Calificar_Load(object sender, EventArgs e)
        {
            try
            {
                cargarComboPuntaje();
                //cargar descripción publicación
                cargarDescripcionPublicación();
                //cargar nombre vendedor
                cargarNombreVendedor();
                //total abonado
                cargarTotalAbonado();

            }
            catch (Exception ex)
            {
               Metodos_Comunes.MostrarMensajeError(ex);
            }
        }



        private void cargarComboPuntaje()
        {
            try
            {
                cboPuntaje.DataSource = Metodos_Comunes.obtenerTablaComboPuntajes();
                cboPuntaje.DisplayMember = "Descripcion";
                cboPuntaje.ValueMember = "Id";
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cargarDescripcionPublicación()
        {
            try
            {

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cargarNombreVendedor()
        //{
        //    DataRow fila;
        //    try
        //    {
        //        String script = "SELECT idUsuario FROM vadem.compras ";

        //        DataTable listaEstados = PublicacionDAO.obtenerEstados(script);
        //        fila = listaEstados.NewRow();
        //        fila["IdEstado"] = 0;
        //        fila["Descripcion"] = "";
        //        listaEstados.Rows.InsertAt(fila, 0);

        //        return listaEstados;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error " + ex.Message);
        //    }


        //}
        {
            try
            {

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cargarTotalAbonado()
        {
            try
            {

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
