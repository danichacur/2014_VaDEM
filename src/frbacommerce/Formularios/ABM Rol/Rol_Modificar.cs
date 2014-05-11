using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Entidades;
using FrbaCommerce.Componentes_Comunes;

namespace FrbaCommerce.Formularios.ABM_Rol
{
    public partial class Rol_Modificar : Rol_Agregar
    {

        private Rol rol;

        public Rol_Modificar(Rol pRol)
        {
            try
            {
                rol = pRol;
                InitializeComponent();
            }
            catch (Exception)
            {
                throw;
            }
        }

        

        private void Rol_Modificar_Load(object sender, EventArgs e)
        {
            try
            {
                llenarCampos();
                habilitaCamposParaModificacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void habilitaCamposParaModificacion()
        {
            try
            {
                List<Filtro> campos = obtenerCamposEnPantalla();
                campos[0].Enabled = false;
                campos[1].Enabled = true;
                campos[2].Enabled = true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void llenarCampos()
        {
            try
            {
                if (rol != null)
                {
                    List<Filtro> campos = obtenerCamposEnPantalla();
                    campos[0].colocarValor(rol.Id);
                    campos[1].colocarValor(rol.Descripcion);
                    campos[2].colocarValor((rol.Habilitado ? 1 : 0));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Filtro> campos = obtenerCamposEnPantalla();
                rol.Id = Convert.ToInt32(campos[0].obtenerValor());
                rol.Descripcion = campos[1].obtenerValor();
                rol.Habilitado = (campos[2].obtenerValor() == "1" ? true : false);
                rol.modificar();

                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
