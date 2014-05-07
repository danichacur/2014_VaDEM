using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Entidades
{
    class Rol
    {

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }

        public Rol() {
            Id = 0;
            Descripcion = "";
            Habilitado = false;
        }

        public Rol(int id, string descripcion, bool habilitado) {
            Id = id;
            Descripcion = descripcion;
            Habilitado = habilitado;
        }
    }
}
