using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Datos;

namespace FrbaCommerce.Entidades
{
    public class Calificacion
    {
        public int Id { get; set; }
        public Compra Compra { get; set; }
        public Usuario Vendedor { get; set; }
        public Usuario Calificador { get; set; }
        public DateTime Fecha { get; set; }
        public int Estrellas { get; set; }
        public string Detalle { get; set; }

        public Calificacion()
        {
            Id = 0;
            Compra = new Compra();
            Vendedor = new Usuario();
            Calificador = new Usuario();
            Fecha = new DateTime(1900, 1, 1);
            Estrellas = 0;
            Detalle = "";
        }

        public Calificacion(int pId, Compra pCompra, Usuario pVendedor, Usuario pCalificador, DateTime pFecha, int pEstrella, string pDetalle)
        {
            Id = pId;
            Compra = pCompra;
            Vendedor = pVendedor;
            Calificador = pCalificador;
            Fecha = pFecha;
            Estrellas = pEstrella;
            Detalle = pDetalle;
        }


        public Calificacion insertar()
        {
            try
            {
                return CalificacionDAO.insertar(this);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
