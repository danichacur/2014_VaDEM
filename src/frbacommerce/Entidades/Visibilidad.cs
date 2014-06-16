using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Datos;

namespace FrbaCommerce.Entidades
{
    public class Visibilidad
    {

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public float CostoFijo { get; set; }
        public float Comision { get; set; }
        public int LimiteSinBonificar { get; set; }
        public int DiasVigencia { get; set; }
        public bool Habilitado { get; set; }

        public Visibilidad() 
        {
        }

        public Visibilidad(int pId, string pDescripcion, float pCostoFijo, float pComision, int pLimiteSinBonificar, 
            int pDiasVigencia, bool pHabilitado)
        {

            Id = pId;
            Descripcion = pDescripcion;
            CostoFijo = pCostoFijo;
            Comision = pComision;
            LimiteSinBonificar = pLimiteSinBonificar;
            DiasVigencia = pDiasVigencia;
            Habilitado = pHabilitado;
        }

        public void insertar()
        {
            try
            {
                String query = "INSERT INTO vadem.visibilidad VALUES(";
                query += "(SELECT MAX(IdVisibilidad)+1 FROM vadem.visibilidad)";
                query += ",";
                query += "'" + Descripcion + "'";
                query += ",";
                query += CostoFijo.ToString().Replace(",", ".");
                query += ",";
                query += Comision.ToString().Replace(",",".");
                query += ",";
                query += LimiteSinBonificar;
                query += ",";
                query += DiasVigencia;
                query += ",";
                query += (Habilitado ? 1 : 0);
                query += ")";

                VisibilidadDAO.ejecutar(query);
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
            String query;
            try
            {
                query = "UPDATE vadem.visibilidad SET ";
                query += "Descripcion ='" + Descripcion + "'";
                query += ",";
                query += "CostoFijo = " + CostoFijo.ToString().Replace(",", ".") + " ";
                query += ",";
                query += "Comision = " + Comision.ToString().Replace(",", ".") + " ";
                query += ",";
                query += "LimiteSinBonificar = " + LimiteSinBonificar + " ";
                query += ",";
                query += "DiasVigencia = " + DiasVigencia + " ";
                query += ",";
                query += "Habilitado = " + (Habilitado ? 1 : 0);
                query += " WHERE IdVisibilidad = " + Id;

                VisibilidadDAO.ejecutar(query);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void bajaLogica()
        {
            String query;
            try
            {
                query = "UPDATE vadem.visibilidad ";
                query += " SET Habilitado = 0 ";
                query += " WHERE IdVisibilidad = " + Id;

                VisibilidadDAO.ejecutar(query);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
