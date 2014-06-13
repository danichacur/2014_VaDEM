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

namespace FrbaCommerce.Historial_Cliente
{
    public partial class Historial_Cliente : ABM
    {
        public Historial_Cliente()
        {
            InitializeComponent();
        }

        private void Historial_Cliente_Load(object sender, EventArgs e)
        {
            try
            {
                CargarGrillas();
            }
            catch (Exception ex)
            {
                Metodos_Comunes.MostrarMensajeError(ex);
            }
        }

        private void CargarGrillas()
        {
            try{

                dgCompras = cargarGrillaCompras();
                dgOfertas = cargarGrillaOfertas();
                dgCalificacionesRecibidas = cargarGrillaCalificacionesRecibidas();
                dgCalificacionesRealizadas = cargarGrillaCalificacionesRealizadas();

            }
            catch (Exception)
            {
                throw;
            }
        }

    #region MetodosAuxiliares
        /// <summary>
        /// Armo y devuelvo la lista de columnas que tendrá la grilla.
        /// 
        /// </summary>
        /// <returns></returns>
        private DataGridViewColumn[] obtenerDisenoColumnasGrillaOfertas()
        {
            try
            {

                DataGridViewColumn[] columnas = new DataGridViewColumn[5];

                DataGridViewTextBoxColumn colFecha = new DataGridViewTextBoxColumn();
                colFecha.DataPropertyName = "Fecha"; colFecha.Name = "Fecha";
                colFecha.HeaderText = "Fecha de compra";
                columnas[0] = colFecha;

                DataGridViewTextBoxColumn colImporte = new DataGridViewTextBoxColumn();
                colImporte.DataPropertyName = "Importe"; colImporte.Name = "Importe";
                colImporte.HeaderText = "Importe";
                columnas[1] = colImporte;

                DataGridViewTextBoxColumn colDescripcion = new DataGridViewTextBoxColumn();
                colDescripcion.DataPropertyName = "Descripcion"; colDescripcion.Name = "Descripcion"; 
                colDescripcion.HeaderText = "Descripcion";
                columnas[2] = colDescripcion;

                DataGridViewTextBoxColumn colUsername = new DataGridViewTextBoxColumn();
                colUsername.DataPropertyName = "Username"; colUsername.Name = "Username"; 
                colUsername.HeaderText = "Usuario Vendedor";         
                columnas[3] = colUsername;

                DataGridViewTextBoxColumn colGano = new DataGridViewTextBoxColumn();
                colGano.DataPropertyName = "Gano"; colGano.Name = "Gano"; 
                colGano.HeaderText = "Gano";
                columnas[4] = colGano;

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
        public DataGridView cargarGrillaCompras()
        {
            try
            {
                Object listaCompras = (Object)ComprasDAO.obtenerHistorialCompras(Session.IdUsuario);
                DataGridViewColumn[] columnas = obtenerDisenoColumnasGrillaCompras();

          
                if (dgCompras.Columns.Count == 0)
                {
                    dgCompras.Columns.AddRange(columnas);
                    dgCompras.AutoGenerateColumns = false;
                }
                cargarGrilla(dgCompras, listaCompras);

                return dgCompras;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Armo y devuelvo la lista de columnas que tendrá la grilla.
        /// 
        /// </summary>
        /// <returns></returns>
        private DataGridViewColumn[] obtenerDisenoColumnasGrillaCompras()
        {
            try
            {

                DataGridViewColumn[] columnas = new DataGridViewColumn[5];

                DataGridViewTextBoxColumn colFecha = new DataGridViewTextBoxColumn();
                colFecha.DataPropertyName = "Fecha"; colFecha.Name = "Fecha";
                colFecha.HeaderText = "Fecha de compra";
                columnas[0] = colFecha;

                DataGridViewTextBoxColumn colCantidad = new DataGridViewTextBoxColumn();
                colCantidad.DataPropertyName = "Cantidad"; colCantidad.Name = "Cantidad";
                colCantidad.HeaderText = "Cantidad";
                columnas[1] = colCantidad;

                DataGridViewTextBoxColumn colDescripcion = new DataGridViewTextBoxColumn();
                colDescripcion.DataPropertyName = "Descripcion"; colDescripcion.Name = "Descripcion";
                colDescripcion.HeaderText = "Descripcion";
                columnas[2] = colDescripcion;

                DataGridViewTextBoxColumn colTipo = new DataGridViewTextBoxColumn();
                colTipo.DataPropertyName = "Tipo"; colTipo.Name = "Tipo"; colTipo.HeaderText = "Tipo";
                columnas[3] = colTipo;

                DataGridViewTextBoxColumn colUsername = new DataGridViewTextBoxColumn();
                colUsername.DataPropertyName = "Username"; colUsername.Name = "Username";
                colUsername.HeaderText = "Usuario Vendedor";
                columnas[4] = colUsername;

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
        public DataGridView cargarGrillaOfertas()
        {
            try
            {
                Object listaOfertas = (Object)OfertaDAO.ObtenerHistorialOfertas(Session.IdUsuario);
                DataGridViewColumn[] columnas = obtenerDisenoColumnasGrillaOfertas();

                if (dgCompras.Columns.Count == 0)
                {
                    dgCompras.Columns.AddRange(columnas);
                    dgCompras.AutoGenerateColumns = false;
                }
                cargarGrilla(dgOfertas, listaOfertas);

                return dgOfertas;
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
        public DataGridView cargarGrillaCalificacionesRealizadas()
        {
            try
            {
                Object listaCalificacionesRealizadas = (Object)CalificacionDAO.CalificacionesRecibidas(Session.IdUsuario);
                DataGridViewColumn[] columnas = obtenerDisenoColumnasGrillaCalificaciones();

                if (dgCompras.Columns.Count == 0)
                {
                    dgCompras.Columns.AddRange(columnas);
                    dgCompras.AutoGenerateColumns = false;
                }
                cargarGrilla(dgCalificacionesRealizadas, listaCalificacionesRealizadas);

                return dgCalificacionesRealizadas;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Armo y devuelvo la lista de columnas que tendrá la grilla.
        /// 
        /// </summary>
        /// <returns></returns>
        private DataGridViewColumn[] obtenerDisenoColumnasGrillaCalificaciones()
        {
            try
            {

                DataGridViewColumn[] columnas = new DataGridViewColumn[5];

                DataGridViewTextBoxColumn colUsername = new DataGridViewTextBoxColumn();
                colUsername.DataPropertyName = "Username"; colUsername.Name = "Username";
                colUsername.HeaderText = "Usuario Vendedor";
                columnas[0] = colUsername;

                DataGridViewTextBoxColumn colDescripcion = new DataGridViewTextBoxColumn();
                colDescripcion.DataPropertyName = "Descripcion"; colDescripcion.Name = "Descripcion";
                colDescripcion.HeaderText = "Descripcion";
                columnas[1] = colDescripcion;

                DataGridViewTextBoxColumn colCalificaion = new DataGridViewTextBoxColumn();
                colCalificaion.DataPropertyName = "Estrellas"; colCalificaion.Name = "Estrellas";
                colCalificaion.HeaderText = "Calificacion Otorgada";
                columnas[2] = colCalificaion;


                DataGridViewTextBoxColumn colDetalle = new DataGridViewTextBoxColumn();
                colDetalle.DataPropertyName = "Detalle"; colDetalle.Name = "Detalle";
                colDetalle.HeaderText = "Detalle";
                columnas[3] = colDetalle;


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
        public DataGridView cargarGrillaCalificacionesRecibidas()
        {
            try
            {
                Object listaCalificacionesRecibidas= (Object)CalificacionDAO.CalificacionesRealizadas(Session.IdUsuario);
                DataGridViewColumn[] columnas = obtenerDisenoColumnasGrillaCalificaciones();

                if (dgCompras.Columns.Count == 0)
                {
                    dgCompras.Columns.AddRange(columnas);
                    dgCompras.AutoGenerateColumns = false;
                }
                cargarGrilla(dgCalificacionesRecibidas, listaCalificacionesRecibidas);

                return dgCalificacionesRecibidas;
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
        public void cargarGrilla(DataGridView dg,Object lista)
        {
            try
            {
                Object listDatos = lista;
                dg.DataSource = null;
                dg.DataSource = listDatos;
            }
            catch (Exception)
            {
                throw;
            }

        }
    #endregion
    }
}
