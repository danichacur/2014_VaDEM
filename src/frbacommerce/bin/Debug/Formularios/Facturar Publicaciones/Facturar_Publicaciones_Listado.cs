using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Componentes_Comunes;
using FrbaCommerce.Datos;
using FrbaCommerce.Entidades;

namespace FrbaCommerce.Formularios.Facturar_Publicaciones
{
    public partial class Facturar_Publicaciones_Listado : Form
    {

        private DataGridView dgv;
        private DataGridViewColumn[] columnas;

        public Facturar_Publicaciones_Listado()
        {
            InitializeComponent();
        }

        private void Facturar_Publicaciones_Listado_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session.IdUsuario == 1)
                {
                    vendedor.Visible = true;
                    comboBoxVend.Visible = true;
                    cargarVendedores();
                    comboBoxVend.SelectedIndex = 0;
                }
                else
                {
                    vendedor.Visible = false;
                    comboBoxVend.Visible = false;
                }
                cmbFormaPago.Items.Insert(0, "Efectivo");
                cmbFormaPago.Items.Insert(1, "Tarjeta");

                cmbFormaPago.SelectedIndex = 0;
            
                cargaInicialGrilla();
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }

        private void cargarVendedores()
        {
            try
            {

                comboBoxVend.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBoxVend.Text = "Username";

                comboBoxVend.DataSource = obtenerVendedores();
                comboBoxVend.DisplayMember = "Username";
                comboBoxVend.ValueMember = "IdUsuario";
            }
            catch (Exception)
            {                
                throw;
            }
        }


        private DataTable obtenerVendedores()
        {
            DataRow fila;
            try
            {
                String script = "SELECT IdUsuario, Username FROM vadem.usuario where IdUsuario <> 1 ";

                DataTable listaVendedores = PublicacionDAO.obtenerEstados(script);
                fila = listaVendedores.NewRow();
                fila["IdUsuario"] = 0;
                fila["Username"] = "";
                listaVendedores.Rows.InsertAt(fila, 0);

                return listaVendedores;
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }


        }



        /// <summary>
        /// Carga la grilla llamando al método sin pasarle ningun filtro. 
        /// </summary>
        private void cargaInicialGrilla()
        {
            try
            {
                Object listaPublicaciones = (Object)FacturarDAO.ObtenerItemFactura(Session.IdUsuario);
            

                columnas = obtenerDisenoColumnasGrilla();

                dgv = cargarGrilla(listaPublicaciones, columnas);

        
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Armo y devuelvo la lista de columnas que tendrá la grilla. Incluyo las propiedades de la coleccion que se le pase al 
        /// DataSource de la grilla y los botones
        /// </summary>
        /// <returns></returns>
        private DataGridViewColumn[] obtenerDisenoColumnasGrilla()
        {
            try
            {

                DataGridViewColumn[] columnas = new DataGridViewColumn[7];

                DataGridViewTextBoxColumn colDescripcion = new DataGridViewTextBoxColumn();
                colDescripcion.DataPropertyName = "Descripcion"; colDescripcion.Name = "Descripcion";
                colDescripcion.HeaderText = "Descripcion";
                columnas[0] = colDescripcion;

                DataGridViewTextBoxColumn colCosto = new DataGridViewTextBoxColumn();
                colCosto.DataPropertyName = "Costo"; colCosto.Name = "Costo";
                colCosto.HeaderText = "Costo";
                columnas[1] = colCosto;

                DataGridViewTextBoxColumn colCantidad = new DataGridViewTextBoxColumn();
                colCantidad.DataPropertyName = "Cantidad"; colCantidad.Name = "Cantidad"; colCantidad.HeaderText = "Cantidad";
                columnas[2] = colCantidad;




                DataGridViewCheckBoxColumn colPagar = new DataGridViewCheckBoxColumn();
               // colPagar.Width = 100;

                //colPagar.Text = "Pagar";
                colPagar.Name = "Pagar";
                //colPagar.UseColumnTextForButtonValue = true;
                columnas[3] = colPagar;

                DataGridViewTextBoxColumn colIdPublicacion = new DataGridViewTextBoxColumn();
                colIdPublicacion.DataPropertyName = "IdPublicacion";
                colIdPublicacion.Name = "IdPublicacion";
                colIdPublicacion.HeaderText = "IdPublicacion";
                colIdPublicacion.Visible = false;
                columnas[4] = colIdPublicacion;


                DataGridViewTextBoxColumn colIdItem = new DataGridViewTextBoxColumn();
                colIdItem.DataPropertyName = "IdItem";
                colIdItem.Name = "IdItem";
                colIdItem.HeaderText = "IdItem";
                colIdItem.Visible = false;
                columnas[5] = colIdItem;

                DataGridViewTextBoxColumn colEsCompra = new DataGridViewTextBoxColumn();
                colEsCompra.DataPropertyName = "EsCompra";
                colEsCompra.Name = "EsCompra";
                colEsCompra.HeaderText = "Es Compra";
                colEsCompra.Visible = true;
                columnas[6] = colEsCompra;

                return columnas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Carga la grilla con la lista que recibe como parámetro y con la estructura de las columnas que recibe
        /// </summary>
        /// <param name="tbl"></param>
        public DataGridView cargarGrilla(Object lista, DataGridViewColumn[] columnas)
        {
            try
            {

                //dgv.Columns.Clear();
                if (dgFacturacion.Columns.Count == 0)
                {
                    dgFacturacion.Columns.AddRange(columnas);
                    dgFacturacion.AutoGenerateColumns = false;
                }

                DataGridViewColumn[] columnas1 = obtenerDisenoColumnasGrilla();
             

                cargarGrilla(lista);

                return dgFacturacion;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Carga la grilla con la lista que recibe como parámetro 
        /// </summary>
        /// <param name="lista"></param>
        public void cargarGrilla(Object lista)
        {
            try
            {

                Object listDatos = lista;
                dgFacturacion.DataSource = null;
                dgFacturacion.DataSource = listDatos;
            }
            catch (Exception)
            {
                throw;
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<ItemFacturacion> colitems = new List<ItemFacturacion>();
                int i =0;
                foreach (DataGridViewRow item in dgFacturacion.Rows )
                {
                    if (Convert.ToBoolean(item.Cells["Pagar"].Value))
                    {
                        ItemFacturacion itemFac = new ItemFacturacion();
                        itemFac.Id = Convert.ToInt32(item.Cells["IdItem"].Value);
                        itemFac.IdPublicacion = Convert.ToInt32( item.Cells["IdPublicacion"].Value);
                        itemFac.Cantidad = Convert.ToInt32(item.Cells["Cantidad"].Value);
                        itemFac.Costo = Convert.ToInt32(item.Cells["Costo"].Value);
                        itemFac.EsCompra = Convert.ToBoolean(item.Cells["EsCompra"].Value.ToString() == "SI");

                        colitems.Add(itemFac);
                        
                        if (i != 0)
                        {
                            if (!Convert.ToBoolean(dgFacturacion.Rows[i - 1].Cells["Pagar"].Value) && Convert.ToString(dgFacturacion.Rows[i - 1].Cells["EsCompra"].Value)=="SI")
                            {
                                Metodos_Comunes.MostrarMensaje("No puede saltearse ningun item");
                                colitems = new List<ItemFacturacion>();
                                break;
                            }
                        }

                    }

                    i++;
                }
                if (colitems.Count > 0)
                {
                    if ((cmbFormaPago.SelectedIndex == 1 && txtDatosTarjeta.Text == "") )
                    {
                        Metodos_Comunes.MostrarMensaje("Debe Cargar los Datos De Tarjeta");
                    }
                    else
                    {
                        if (cmbFormaPago.SelectedIndex == 0 && txtDatosTarjeta.Text != "")
                        {
                            Metodos_Comunes.MostrarMensaje("Seleccione el medio de pago adecuado");
                        }
                        else
                        {
                            if (Session.IdUsuario == 1)
                                FacturarDAO.Pagar(colitems, cmbFormaPago.Text.ToString(), txtDatosTarjeta.Text, (int)comboBoxVend.SelectedValue);
                            else
                                FacturarDAO.Pagar(colitems, cmbFormaPago.Text.ToString(), txtDatosTarjeta.Text, Session.IdUsuario);
                            
                            Metodos_Comunes.MostrarMensaje("Ha pagado con exito");
                            cargaInicialGrilla();
                            comboBoxVend.SelectedIndex = 0;
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }
        
        private void comboBoxVend_SelectionChangeCommitted(object sender, EventArgs e)
        {

            try
            {
                Object listaPublicaciones = (Object)FacturarDAO.ObtenerItemFactura((int) comboBoxVend.SelectedValue);
                columnas = obtenerDisenoColumnasGrilla();
                dgv = cargarGrilla(listaPublicaciones, columnas);


            }
            catch (Exception)
            {
                throw;
            }

        }



    }
}
