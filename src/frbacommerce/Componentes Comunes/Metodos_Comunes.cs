using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace FrbaCommerce.Componentes_Comunes
{
    class Metodos_Comunes
    {

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
                row["id"] = -1; row["descripcion"] = "";
                tbl.Rows.Add(row);

                row = tbl.NewRow();
                row["id"] = 0; row["descripcion"] = "Deshabilitado";
                tbl.Rows.Add(row);

                row = tbl.NewRow();
                row["id"] = 1; row["descripcion"] = "Habilitado";
                tbl.Rows.Add(row);

                return tbl;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
