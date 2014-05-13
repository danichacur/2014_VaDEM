﻿using System;
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

namespace FrbaCommerce.Formularios.ABM_Rol
{
    public partial class Rol_Agregar : Form
    {
        #region VariablesDeClase

        Rol rol;
        
        #endregion
        
        #region Eventos

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Rol_Agregar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load de la clase. Creo el nuevo objeto de la clase. Genero los campos 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AltaModif_Rol_Load(object sender, EventArgs e)
        {
            try
            {
                rol = new Rol();
                generarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Evento del boton Aceptar. 
        /// Cargo en el objeto de la clase los parámetros correspondientes de acuerdo a los campos insertados. Luego persisto en la BD
        /// Cierro la ventana devolviendo un OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Filtro> campos = obtenerCamposEnPantalla();
                rol.Id = Convert.ToInt32(campos[0].obtenerValor());
                rol.Descripcion = campos[1].obtenerValor();
                rol.Habilitado = (campos[2].obtenerValor() == "1" ? true : false);
                rol.insertar();

                DialogResult = System.Windows.Forms.DialogResult.OK;

            }
            catch (Exception ex)
            {
                DialogResult = System.Windows.Forms.DialogResult.Abort;
                MessageBox.Show(ex.Message);
            }
            finally 
            {
                this.Close();
            }
        }

        /// <summary>
        /// Evento del boton Cancelar.
        /// Devuelvo resultado Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                DialogResult = System.Windows.Forms.DialogResult.Abort;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
            }
        }

        #endregion

        #region MetodosGenerales

        /// <summary>
        /// Crea una lista de campos (tipo filtro) y los agrega dinámicamente en el control AltaModificacion.
        /// </summary>
        private void generarCampos()
        {
            try
            {
                List<Filtro> filtros = new List<Filtro>();
                filtros.Add(new FiltroTextBox("Rol", "IdRol", "=", ""));
                filtros.Add(new FiltroTextBox("Descripcion", "Descripcion", "LIKE", ""));
                filtros.Add(new FiltroDgvCheck(obtenerListaFuncionalidades()));

                this.ctrlAltaModificacion1.cargarFiltros(filtros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene del control AltaModificacion los campos que fueron cargados.
        /// </summary>
        /// <returns></returns>
        public List<Filtro> obtenerCamposEnPantalla()
        {
            try
            {
                return ctrlAltaModificacion1.obtenerCamposEnPantalla();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region MetodosAuxiliares

        /// <summary>
        /// Obtiene una lista de Funcionalidades desde la base de datos.
        /// </summary>
        /// <returns></returns>
        private List<Funcionalidad> obtenerListaFuncionalidades()
        {
            try
            {
                return FuncionalidadDAO.obtenerFuncionalidades();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
