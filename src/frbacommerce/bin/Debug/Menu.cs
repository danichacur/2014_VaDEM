using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Componentes_Comunes;
using FrbaCommerce.Entidades;
using FrbaCommerce.Datos;


namespace FrbaCommerce
{
    public partial class Menu : Form
    {
        #region VariablesDeClase

        Point posicionBoton = new Point(0, 0);

        #endregion

        #region Eventos

        public Menu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento load del formulario.
        /// Obtengo las funcionalidades del usuario Loggeado, y en base a estas creo los botones y redefino el tamaño
        /// de la pantalla.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Load(object sender, EventArgs e)
        {
            List<Funcionalidad> funcionalidades;
            try
            {
                funcionalidades = obtenerFuncionalidadesPorUsuarioLogueado();
                generarBotonesPorFuncionalidades(funcionalidades);
                redefinirTamanioPantalla(funcionalidades.Count());
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
            finally
            {
                funcionalidades = null;
            }
        }

        /// <summary>
        /// Evento de los botones que redirijen a los respectivos AMB. El AMB correspondiente se encuentra en la variable
        /// tag del boton.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRedirigir_click(object sender, EventArgs e)
        {
            try
            {
                Form pantalla = (Form)((Button)sender).Tag;
                pantalla.ShowDialog();
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }

        #endregion

        #region MetodosGenerales

        /// <summary>
        /// En base a la lista de funcionalidades por el Rol del usuario loggeado, se crean dinámicamente los botones
        /// para acceder a cada una de esas funcionalidades. Se guarda en el tag de cada boton el objeto AMB que le corresponde
        /// </summary>
        /// <param name="funcionalidades"></param>
        private void generarBotonesPorFuncionalidades(List<Funcionalidad> funcionalidades)
        {
            Button boton;
            try
            {
                foreach (Funcionalidad funcionalidad in funcionalidades)
                {

                    Form pantalla = agregarFuncionalidadAListaDeABMs(funcionalidad);

                    if (posicionBoton == new Point(0, 0))
                    {
                        posicionBoton = new Point(20, 60);
                    }
                    else
                    {
                        posicionBoton = new Point(posicionBoton.X, posicionBoton.Y + 30);
                    }


                    boton = new Button();
                    boton.Size = new System.Drawing.Size(300, boton.Size.Height);
                    boton.Text = funcionalidad.Descripcion;
                    boton.Location = posicionBoton;
                    boton.Tag = pantalla;
                    boton.Click += btnRedirigir_click;
                    this.Controls.Add(boton);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// De acuerdo a la funcionalidad parámetro (que dependia del Rol) creo una instancia del AMB correspondiente y lo
        /// retorno para que sea vinculada al click de cada boton.
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        private Form agregarFuncionalidadAListaDeABMs(Funcionalidad func)
        {
            Form pantalla = new Form();
            try
            {
                switch (func.Descripcion)
                {
                    case "AMB_ROLES":
                        pantalla = new ABM_Rol.Rol_Listar();
                        break;
                    case "REGISTRO_USUARIO":
                        pantalla = new FrbaCommerce.Registro_de_Usuario.registroUsuario();
                        break;
                    case "ABM_CLIENTE":
                        pantalla = new Abm_Cliente.Cliente_Listar();
                        break;
                    case "AMB_EMPRESA":
                        pantalla = new Formularios.Abm_Empresa.Empresa_Listar();
                        break;
                    case "AMB_RUBRO":
                        pantalla = new Abm_Rubro.Abm_Rubro();
                        break;
                    case "AMB_VISIBILIDAD":
                        pantalla = new Formularios.Abm_Visibilidad.Visibilidad_Listar();
                        break;
                    case "PUBLICACIONES":
                        pantalla = new Generar_Publicacion.Publicacion_Listar();
                        break;
                    //case "EDITA_PUBLICACION":
                    //    pantalla = new ;
                    //    break;
                    case "GESTIONA_PREGUNTAS":
                        pantalla = new Gestion_de_Preguntas.Preguntas();
                        break;
                    case "COMPRA_OFERTA":
                        pantalla = new Comprar_Ofertar.Comprar_Ofertar_Listado();
                        break;
                    case "HISTORIA_CLIENTE":
                        pantalla = new Historial_Cliente.Historial_Cliente() ;
                        break;
                    case "CALIFICAR":
                        pantalla = new Formularios.Calificar_Vendedor.Calificar_Listar();
                        break;
                    //case "FACTURAR":
                    //    pantalla = new ;
                    //    break;
                    case "LISTADO_ESTADISTICO":
                        pantalla = new Formularios.Listado_Estadistico.Estadisticas();
                        break;
                    default:
                        //Metodos_Comunes.MostrarMensajeError("Existe una funcionalidad (" + func.Descripcion + ") en la base de datos que no está definida en el código");
                        break;
                }

                return pantalla;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region MetodosAuxiliares

        /// <summary>
        /// Obtiene y devuelve la lista de funcionalidades por el rol del usuario loggeado
        /// </summary>
        /// <returns></returns>
        private List<Funcionalidad> obtenerFuncionalidadesPorUsuarioLogueado()
        {
            try
            {
                return FuncionalidadDAO.obtenerFuncionalidadesPorRol(Session.IdRol);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Cambia el tamaño de la pantalla de acuerdo a la cantidad de botones que contiene.
        /// </summary>
        /// <param name="cantidadBotones"></param>
        private void redefinirTamanioPantalla(int cantidadBotones)
        {
            try
            {
                int alto = 98 + 30 * cantidadBotones;
                this.Size = new System.Drawing.Size(this.Size.Width, alto);
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion        
    }
}
