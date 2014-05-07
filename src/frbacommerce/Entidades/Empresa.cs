using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Entidades
{
    class Empresa : Usuario
    {
        public String RazonSocial { get; set; }
        public long Cuit { get; set; }
        public String Telefono { get; set; }
        public String Direccion { get; set; }
        public String Piso { get; set; }
        public String Departamento { get; set; }
        public String Localidad { get; set; }
        public int CodigoPostal { get; set; }
        public String Cuidad { get; set; }
        public String Email { get; set; }
        public String NombreContacto { get; set; }
        public DateTime fechaCreacion { get; set; }
        
    }
}
