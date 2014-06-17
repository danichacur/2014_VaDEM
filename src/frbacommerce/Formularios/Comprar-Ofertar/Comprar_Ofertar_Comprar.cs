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
                lblNombreRazonSocial.Text = emp.RazonSocial;
                lblMail.Text = emp.Email;
                lblDNIcuit.Text = emp.Cuit;
                lblTelefono.Text = emp.Telefono;
                lblDireccion.Text = emp.Direccion + " " + emp.Numero + " " + emp.Piso + " " + emp.Departamento;
                lblCodPostal.Text = emp.CodigoPostal.ToString();
                lblContacto.Text = emp.NombreContacto;
            }
            else
            {
                lblNombreRazonSocial.Text = cli.Nombre + " " + cli.Apellido;
                lblMail.Text = cli.Email;
                lblDNIcuit.Text = cli.Documento.ToString();
                lblTelefono.Text = cli.Telefono;
                lblDireccion.Text = cli.Direccion + " " + cli.Numero + " " + cli.Piso + " " + cli.Departamento;
                lblCodPostal.Text = cli.CodigoPostal.ToString();
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
                
            }
            else
            {
                Metodos_Comunes.MostrarMensaje("No hay suficiente stock");
            }
        }



 
    }
}
