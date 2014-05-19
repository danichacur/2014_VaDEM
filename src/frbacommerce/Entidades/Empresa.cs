using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Datos;

namespace FrbaCommerce.Entidades
{
    class Empresa : Usuario
    {
        public String RazonSocial { get; set; }
        public long Cuit { get; set; }
        public String Telefono { get; set; }
        public String Direccion { get; set; }
        public int Numero { get; set; }
        public String Piso { get; set; }
        public String Departamento { get; set; }
        public String Localidad { get; set; }
        public int CodigoPostal { get; set; }
        public String Cuidad { get; set; }
        public String Email { get; set; }
        public String NombreContacto { get; set; }
        public DateTime fechaCreacion { get; set; }


        public Empresa(int pIdUsuario, string pUsername, int pIdRol, String pDescRol, bool pRolHabil, int pIntentosFallidos, bool pBloqueado, bool pHabilitado, float pReputacion)
        {
            //Datos de Usuario
            IdUsuario = pIdUsuario;
            Username = pUsername;
            this.Rol = new Rol(pIdRol, pDescRol, pRolHabil);
            IntentosFallidos = pIntentosFallidos;
            Bloqueado = pBloqueado;
            Habilitado = pHabilitado;
            Reputacion = pReputacion;
        }

        public Empresa(String pRazonSocial, long pCuit, String pTelefono, String pDireccion, int pNumero, String pPiso,
            String pDepartamento, String pLocalidad,
            int pCodigoPostal, String pCuidad, String pEmail, String pNombreContacto, DateTime pFechaCreacion)
        {
            //Datos de la empresa
            RazonSocial = pRazonSocial;
            Cuit = pCuit;
            Telefono = pTelefono;
            Direccion = pDireccion;
            Numero = pNumero;
            Piso = pPiso;
            Departamento = pDepartamento;
            Localidad = pLocalidad;
            CodigoPostal = pCodigoPostal;
            Cuidad = pCuidad;
            Email = pEmail;
            NombreContacto = pNombreContacto;
            fechaCreacion = pFechaCreacion;
        }

        public Empresa(int pIdUsuario, string pUsername, int pIdRol, String pDescRol, bool pRolHabil, int pIntentosFallidos, bool pBloqueado, bool pHabilitado, float pReputacion,
           String pRazonSocial, long pCuit, String pTelefono, String pDireccion, int pNumero, String pPiso,
            String pDepartamento, String pLocalidad,
            int pCodigoPostal, String pCuidad, String pEmail, String pNombreContacto, DateTime pFechaCreacion)
        {
            //Datos de Usuario
            IdUsuario = pIdUsuario;
            Username = pUsername;
            this.Rol = new Rol(pIdRol, pDescRol, pRolHabil);
            IntentosFallidos = pIntentosFallidos;
            Bloqueado = pBloqueado;
            Habilitado = pHabilitado;
            Reputacion = pReputacion;

            //Datos de la empresa
            RazonSocial = pRazonSocial;
            Cuit = pCuit;
            Telefono = pTelefono;
            Direccion = pDireccion;
            Numero = pNumero;
            Piso = pPiso;
            Departamento = pDepartamento;
            Localidad = pLocalidad;
            CodigoPostal = pCodigoPostal;
            Cuidad = pCuidad;
            Email = pEmail;
            NombreContacto = pNombreContacto;
            fechaCreacion = pFechaCreacion;
        }


        public Empresa insertar()
        {
            try
            {
                return EmpresaDAO.insertar(this);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }

    
}
