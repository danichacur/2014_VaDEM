using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Datos;

namespace FrbaCommerce.Entidades
{
    public class Rol
    {

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }

        public Rol()
        {
            Id = 0;
            Descripcion = "";
            Habilitado = false;
        }

        public Rol(int id, string descripcion, bool habilitado)
        {
            Id = id;
            Descripcion = descripcion;
            Habilitado = habilitado;
        }

        /// <summary>
        /// Genera la inserción del rol en la base da datos de acuerdo a los parámetros de este rol.
        /// </summary>
        public void insertar()
        {
            try
            {
                String query = "INSERT INTO vadem.rol VALUES(";
                query += Id;
                query += ",";
                query += "'" + Descripcion + "'";
                query += ",";
                query += (Habilitado ? 1 : 0);
                query += ")";

                RolDAO.ejecutar(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Genera la modificacion del rol en la base da datos de acuerdo a los parámetros de este rol.
        /// </summary>
        public void modificar()
        {
            try
            {
                String query = "UPDATE vadem.rol SET ";
                query += "Descripcion ='" + Descripcion + "'";
                query += ",";
                query += "Habilitado = " + (Habilitado ? 1 : 0);
                query += " WHERE IdRol = " + Id;

                RolDAO.ejecutar(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Genera la baja del rol de la base de datos. La baja es lógica.
        /// </summary>
        public void eliminar()
        {
            try
            {
                //Modificar esto, la baja tiene que ser lógica
                String query = "DELETE FROM vadem.rol ";
                query += " WHERE IdRol = " + Id;

                RolDAO.ejecutar(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
