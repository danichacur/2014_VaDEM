using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Datos;
using FrbaCommerce.Entidades;
using FrbaCommerce.Componentes_Comunes;
using System.Configuration;

namespace FrbaCommerce.Formularios.Comprar_Ofertar
{
    public partial class Comprar_Ofertar_Comprar : Form
    {
        private Publicacion Publicacion { get; set; }

        public Comprar_Ofertar_Comprar(Publicacion Pub)
        {
            try
            {
                Publicacion = Pub;
            

                InitializeComponent();
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }

        private void Comprar_Ofertar_Comprar_Load(object sender, EventArgs e)
        {
            Cliente cli = ClienteDAO.obtenerCliente(Publicacion.Vendedor);

            if (cli == null)
            {
                Empresa emp = EmpresaDAO.obtenerEmpresa(Publicacion.Vendedor);
                lblNombreRazonSocial.Text = "Nombre: " + emp.RazonSocial;
                lblMail.Text = "Mail: " + emp.Email;
                lblDNIcuit.Text = "CUIT: " + emp.Cuit;
                lblTelefono.Text = "Telefono: " + emp.Telefono;
                lblDireccion.Text = "Dirección: " + emp.Direccion + " " + emp.Numero + " " + emp.Piso + " " + emp.Departamento;
                lblCodPostal.Text = "C.P.: " + emp.CodigoPostal.ToString();
                lblContacto.Text = "Persona de Contacto: " + emp.NombreContacto;
                //lblReputacion.Text = "Reputacion: " + Convert.ToString(emp.Reputacion);
            }
            else
            {
                lblNombreRazonSocial.Text = "Nombre: " + cli.Nombre + " " + cli.Apellido;
                lblMail.Text = "Mail: " + cli.Email;
                lblDNIcuit.Text = "Documento: " + cli.Documento.ToString();
                lblTelefono.Text = "Telefono: " + cli.Telefono;
                lblDireccion.Text = "Dirección: " + cli.Direccion + " " + cli.Numero + " " + cli.Piso + " " + cli.Departamento;
                lblCodPostal.Text = "C.P.: " + cli.CodigoPostal.ToString();
               // lblReputacion.Text = "Reputacion: " + Convert.ToString(cli.Reputacion);

            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (Session.IdUsuario != Publicacion.Vendedor)
            {

                if (Convert.ToInt32(txtCantidad.Text) <= Publicacion.Cantidad)
                {
                    int result = ComprasDAO.Comprar(Publicacion.Id, Session.IdUsuario, Convert.ToDateTime(ConfigurationManager.AppSettings["DateTimeNow"]), Convert.ToInt32(txtCantidad.Text));

                    switch (result)
                    {
                        case 0:
                            Metodos_Comunes.MostrarMensaje("La compra se realizo con exito");
                            break;
                        case 1:
                            Metodos_Comunes.MostrarMensaje("No hay suficiente stock");
                            break;
                        case 2:
                            Metodos_Comunes.MostrarMensaje("Posee 5 compras sin calificar, para poder comprar debera calificar las calificaciones pendientes");
                            break;
                        case 3:
                            Metodos_Comunes.MostrarMensaje("La publicacion se encuentra Pausada");
                            break;
                        default:
                            break;
                    }
                    DialogResult = System.Windows.Forms.DialogResult.OK;

                }
                else
                {
                    Metodos_Comunes.MostrarMensaje("No hay suficiente stock");
                }

            }
            else
            {
                Metodos_Comunes.MostrarMensaje("No puedes comprarte a ti mismo");
            }
        }



 
    }
}
