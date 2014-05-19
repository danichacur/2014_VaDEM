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
        public List<Funcionalidad> Funcionalidades { get; set; }

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

        public Rol(int id, string descripcion, bool habilitado, List<Funcionalidad> funcionalidades)
        {
            Id = id;
            Descripcion = descripcion;
            Habilitado = habilitado;
            Funcionalidades = funcionalidades;
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
            catch (Exception)
            {
                throw;
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
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Genera la baja del rol de la base de datos. La baja es lógica.
        /// </summary>
        public void eliminar()
        {
            try
            {
                //Si se da de baja un rol se deben borrar las referencias.
                //TODO

                //Modificar esto, la baja tiene que ser lógica
                String query = "DELETE FROM vadem.rol ";
                query += " WHERE IdRol = " + Id;

                RolDAO.ejecutar(query);
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Retorna la lista de ids de funcionalidades separadas por coma en un String
        /// </summary>
        /// <returns></returns>
        public String obtenerFuncionalidadesComoString()
        {
            String lista;
            try
            {
                lista = "";

                foreach (Funcionalidad func in this.Funcionalidades)
                {
                    lista += func.Id.ToString() + ",";
                }
                lista = lista.Substring(0, lista.Length - 1);
                return lista;
            }
            catch (Exception)
            {   
                throw;
            }
        }
    }
}
