using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Security.Cryptography;

namespace FrbaCommerce.Componentes_Comunes
{
    class Metodos_Comunes
    {

        //public enum EnumRoles { Administrador = 1, Cliente, Empresa }

        /// <summary>
        /// Recibe la excepcion y encapsulo el comportamiento para que me muestre el mensaje de error de la siguiente forma
        /// </summary>
        /// <param name="ex"></param>
        public static void MostrarMensajeError(Exception ex){
            String mensaje = "";
            mensaje += "Ha ocurrido el siguiente error: ";
            mensaje += Environment.NewLine;
            mensaje += ex.Message;
            mensaje += Environment.NewLine + Environment.NewLine;
            mensaje += "El error se produjo en: ";
            mensaje += Environment.NewLine;
            mensaje += ex.StackTrace;

            
            MessageBox.Show(mensaje,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }


        /// <summary>
        /// Recibe un texto y encapsulo el comportamiento para que me muestre el mensaje de error de la siguiente forma
        /// </summary>
        /// <param name="ex"></param>
        public static void MostrarMensajeError(String mensaje)
        {
            MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Recibe un texto y encapsulo el comportamiento para que me muestre el mensaje de error de la siguiente forma
        /// </summary>
        /// <param name="mensaje"></param>
        public static void MostrarMensaje(String mensaje)
        {
            MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        /// <summary>
        /// Armo y devuelvo manualmente el contenido del Combo Habilitado ya que no lo obtengo de la BD
        /// </summary>
        /// <returns></returns>
        public static DataTable obtenerTablaComboHabilitado()
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
                row["id"] = 0; row["descripcion"] = "Deshabilitado";
                tbl.Rows.Add(row);

                row = tbl.NewRow();
                row["id"] = 1; row["descripcion"] = "Habilitado";
                tbl.Rows.Add(row);

                return tbl;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Armo y devuelvo manualmente el contenido del Combo Habilitado ya que no lo obtengo de la BD con
        /// </summary>
        /// <returns></returns>
        public static DataTable obtenerTablaComboHabilitadoConVacio()
        {
            DataTable tbl;
            try
            {
                tbl = obtenerTablaComboHabilitado();

                InsertarVacioEnPrimerRegistro(ref tbl);

                return tbl;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// recibo una tabla y la modifico insertandole un registro vacio
        /// </summary>
        /// <returns></returns>
        public static void InsertarVacioEnPrimerRegistro(ref DataTable tbl)
        {
            DataRow row;
            try
            {
                tbl = obtenerTablaComboHabilitado();

                row = tbl.NewRow();
                row["id"] = -1; row["descripcion"] = "";
                tbl.Rows.InsertAt(row, 0);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Devuelve el string parámetro encriptado en sha 256
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String sha256_hash(String value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

        /// <summary>
        /// Lleno el combo de tipo de Documento con los posibles valores. No los obtengo de la BD
        /// </summary>
        public static DataTable obtenerTablaComboTipoDocumento()
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
                row["id"] = 0; row["descripcion"] = "DNI";
                tbl.Rows.Add(row);

                row = tbl.NewRow();
                row["id"] = 1; row["descripcion"] = "L.C.";
                tbl.Rows.Add(row);

                return tbl;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Lleno el combo de tipo de Publicacion con los posibles valores. No los obtengo de la BD
        /// </summary>
        public static DataTable obtenerTablaComboTiposPublicacion()
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
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Lleno el combo de admitir preguntas. No los obtengo de la BD
        /// </summary>
        public static DataTable obtenerTablaComboPreguntas()
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
                row["id"] = 1; row["descripcion"] = "Admite";
                tbl.Rows.Add(row);

                row = tbl.NewRow();
                row["id"] = 2; row["descripcion"] = "No admite";
                tbl.Rows.Add(row);

                return tbl;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Armo y devuelvo manualmente el contenido del Combo Puntajes posibles para calificar ya que no lo obtengo de la BD
        /// </summary>
        /// <returns></returns>
        public static DataTable obtenerTablaComboPuntajes()
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
                row["id"] = 1; row["descripcion"] = "1";
                tbl.Rows.Add(row);

                row = tbl.NewRow();
                row["id"] = 2; row["descripcion"] = "2";
                tbl.Rows.Add(row);

                row = tbl.NewRow();
                row["id"] = 3; row["descripcion"] = "3";
                tbl.Rows.Add(row);

                row = tbl.NewRow();
                row["id"] = 4; row["descripcion"] = "4";
                tbl.Rows.Add(row);

                row = tbl.NewRow();
                row["id"] = 5; row["descripcion"] = "5";
                tbl.Rows.Add(row);
                
                row = tbl.NewRow();
                row["id"] = 6; row["descripcion"] = "6";
                tbl.Rows.Add(row);

                row = tbl.NewRow();
                row["id"] = 7; row["descripcion"] = "7";
                tbl.Rows.Add(row);

                row = tbl.NewRow();
                row["id"] = 8; row["descripcion"] = "8";
                tbl.Rows.Add(row);

                row = tbl.NewRow();
                row["id"] = 9; row["descripcion"] = "9";
                tbl.Rows.Add(row);

                row = tbl.NewRow();
                row["id"] = 10; row["descripcion"] = "10";
                tbl.Rows.Add(row);

                return tbl;
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
