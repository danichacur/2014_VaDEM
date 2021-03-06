﻿using System;
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


namespace FrbaCommerce.Generar_Publicacion
{
    public partial class Listado : ABM
    {
        public Listado()
        {
            InitializeComponent();
        }

        private void Listado_Load(object sender, EventArgs e)
        {
            try
            {
                cargaFiltros();
                cargaInicialGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cargaInicialGrilla()
        {
            try
            {
                aplicarFiltro("");
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }


        }

        private void cargaFiltros()
        {
            try
            {
                List<Filtro> filtrosI = new List<Filtro>();
                filtrosI.Add(new FiltroComboBox("Tipo", "Tipo", "=", "", obtenerTiposPublicacion(), "descripcion", "descripcion"));
                filtrosI.Add(new FiltroComboBox("Estado", "IdEstado", "=", "0", obtenerEstados(), "IdEstado", "Descripcion"));
               

                List<Filtro> filtrosD = new List<Filtro>();
                filtrosD.Add(new FiltroComboBox("Visibilidad", "IdVisibilidad", "=", "0", obtenerVisibilidadHabilitadas(), "IdVisibilidad", "Descripcion"));


                //filtrosI.Add(new FiltroFecha());
               // filtrosI.Add(new FiltroTextBox("Descripcion", "Descripcion", "LIKE", ""));

                this.ctrlABM1.cargarFiltros(filtrosI, filtrosD);
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message + ex.Source);
            }

        }



        private DataTable obtenerTiposPublicacion()
        {
            try
            {
                DataTable tbl;
                DataRow row;
                DataColumn column;

                tbl = new DataTable("id", "descripcion");

                column = new DataColumn();
                column.ColumnName = "id";
                tbl.Columns.Add(column);

                column = new DataColumn();
                column.ColumnName = "descripcion";
                tbl.Columns.Add(column);

                row = tbl.NewRow();
                row["id"] = 0; row["descripcion"] = "";
                tbl.Rows.Add(row);

                row = tbl.NewRow();
                row["id"] = 1; row["descripcion"] = "Compra Inmediata";
                tbl.Rows.Add(row);

                row = tbl.NewRow();
                row["id"] = 2; row["descripcion"] = "Subasta";
                tbl.Rows.Add(row);

                return tbl;
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }

        }

        private DataTable obtenerEstados()
        {
            DataRow fila;
            try
            {
                String script = "SELECT * FROM vadem.estado ";

                DataTable listaEstados = PublicacionDAO.obtenerEstados(script);
                fila = listaEstados.NewRow();
                fila["IdEstado"] = 0;
                fila["Descripcion"] = "";
                listaEstados.Rows.InsertAt(fila, 0);

                return listaEstados;
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }


        }


        private DataTable obtenerVisibilidadHabilitadas()
        {
            DataRow fila;
            try
            {

                String script = "SELECT IdVisibilidad, Descripcion FROM vadem.visibilidad WHERE Habilitado = 1";

                DataTable listaVisibilidad = PublicacionDAO.obtenerVisualizacion(script);

                fila = listaVisibilidad.NewRow();
                fila["IdVisibilidad"] = 0;
                fila["Descripcion"] = "";
                listaVisibilidad.Rows.InsertAt(fila, 0);

                return listaVisibilidad;
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
        }



        public override void aplicarFiltro(String clausulaWhere)
        {
            try
            {
                String script = "SELECT * FROM vadem.publicacion ";
                script += clausulaWhere;

                Object listaPublicaciones = (Object)PublicacionDAO.obtenerPublicaciones(script);


                this.ctrlABM1.cargarGrilla(listaPublicaciones);

            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
        }

    }
}
