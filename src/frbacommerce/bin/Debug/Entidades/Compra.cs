using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Datos;

namespace FrbaCommerce.Entidades
{
    public class Compra
    {

        public int Id { get; set; }
        public Publicacion Publicacion { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        public Boolean Calificada { get; set; }

        public Compra()
        {
            Id = 0;
            Publicacion = new Publicacion();
            Cliente = new Cliente();
            Fecha = new DateTime(1900,1,1);
            Cantidad = 0;
            Calificada = false;

        }

        public Compra(int pId, Publicacion pPublicacion, Cliente pCliente, DateTime pFecha, int pCantidad, Boolean pCalificada)
        {
            Id = pId;
            Publicacion = pPublicacion;
            Cliente = pCliente;
            Fecha = pFecha;
            Cantidad = pCantidad;
            Calificada = pCalificada;
        }

        
        ///// <summary>
        ///// Genera la inserción del rol en la base da datos de acuerdo a los parámetros de este rol.
        ///// </summary>
        //public void insertar()
        //{
        //    try
        //    {
        //        String query = "INSERT INTO vadem.rol VALUES(";
        //        query += Id;
        //        query += ",";
        //        query += "'" + Descripcion + "'";
        //        query += ",";
        //        query += (Habilitado ? 1 : 0);
        //        query += ")";

        //        RolDAO.ejecutar(query);

        //        foreach (Funcionalidad func in Funcionalidades)
        //        {
        //            query = "INSERT INTO vadem.rolPorFuncionalidad VALUES(";
        //            query += Id;
        //            query += ",";
        //            query += func.Id;
        //            query += ")";

        //            RolDAO.ejecutar(query);
        //        }
                
        //    }
        //    catch (Exception)
        //    {
        //        eliminar();
        //        throw;
        //    }

        //}

        ///// <summary>
        ///// Genera la modificacion del rol en la base da datos de acuerdo a los parámetros de este rol.
        ///// </summary>
        //public void modificar()
        //{
        //    String query;
        //    try
        //    {
        //        query = "UPDATE vadem.rol SET ";
        //        query += "Descripcion ='" + Descripcion + "'";
        //        query += ",";
        //        query += "Habilitado = " + (Habilitado ? 1 : 0);
        //        query += " WHERE IdRol = " + Id;

        //        RolDAO.ejecutar(query);

        //        query = "DELETE vadem.rolPorFuncionalidad WHERE IdRol = " + Id;
        //        RolDAO.ejecutar(query);

        //        foreach (Funcionalidad func in Funcionalidades)
        //        {
        //            query = "INSERT INTO vadem.rolPorFuncionalidad VALUES(";
        //            query += Id;
        //            query += ",";
        //            query += func.Id;
        //            query += ")";

        //            RolDAO.ejecutar(query);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        ///// <summary>
        ///// Genera la eliminacion del rol de la base de datos. La baja es física
        ///// Antes se eliminan los registros de la tabla rolPorFuncionalidad que tienen referencia a este Id
        ///// </summary>
        //public void eliminar()
        //{
        //    String query;
        //    try
        //    {
        //        query = "DELETE FROM vadem.rol ";
        //        query += " WHERE IdRol = " + Id;

        //        RolDAO.ejecutar(query);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public void bajaLogica()
        //{
        //    String query;
        //    try
        //    {
        //        query = "UPDATE vadem.rol ";
        //        query += " SET Habilitado = 0 ";
        //        query += " WHERE IdRol = " + Id;

        //        RolDAO.ejecutar(query);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        ///// <summary>
        ///// Retorna la lista de ids de funcionalidades separadas por coma en un String
        ///// </summary>
        ///// <returns></returns>
        //public String obtenerFuncionalidadesComoString()
        //{
        //    String lista;
        //    try
        //    {
        //        lista = "";
        //        if (this.Funcionalidades.Count > 0)
        //        {
        //            foreach (Funcionalidad func in this.Funcionalidades)
        //            {
        //                lista += func.Id.ToString() + ",";
        //            }
        //            lista = lista.Substring(0, lista.Length - 1);
        //        }
        //        return lista;
        //    }
        //    catch (Exception)
        //    {   
        //        throw;
        //    }
        //}

        ///// <summary>
        ///// Recibo una lista de ids de funcionalidades y los inserto en la lista de funcionalidades, pero sin descripcion
        ///// </summary>
        ///// <param name="idsFuncionalidad"></param>
        //public void AgregarFuncionalidades(String idsFuncionalidad)
        //{
        //    //System.Windows.Forms.DataGridViewRow row;
        //    //int idx;
        //    Funcionalidad func;
        //    try
        //    {
        //        Funcionalidades = new List<Funcionalidad>();
        //        //Por cada id  que viene en el texto parámetro, activo el check correspondiente
        //        foreach (String id in ((String)idsFuncionalidad).Split(new Char [] {','}))
        //        {
        //            func = new Funcionalidad(Convert.ToInt16(id), "");
        //            Funcionalidades.Add(func);
        //        }
        //    }
        //    catch (Exception)
        //    {   
        //        throw;
        //    }
        //}
    }
}
