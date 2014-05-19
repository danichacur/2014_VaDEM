using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Datos;

namespace FrbaCommerce.Entidades
{
    class Cliente : Usuario
    {
        public long Dni { get; set; }
        public String TipoDocumento { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Email { get; set; }
        public String Telefono { get; set; }
        public String Direccion { get; set; }
        public int Numero { get; set; }
        public String Piso { get; set; }
        public String Departamento { get; set; }
        public String Localidad { get; set; }
        public int CodigoPostal { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public long Cuil { get; set; }


        public Cliente()
        {
        }

        public Cliente(int pIdUsuario, string pUsername, int pIdRol, String pDescRol, bool pRolHabil, int pIntentosFallidos, bool pBloqueado, bool pHabilitado, float pReputacion)
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

        public Cliente(long pDni, String pTipoDocumento, String pNombre, String pApellido, String pEmail, String pTelefono, String pDireccion, int pNumero, String pPiso, String pDepartamento, String pLocalidad, int pCodigoPostal, DateTime pFechaNacimiento, long pCuil)
        {
            //Datos de Cliente
            Dni = pDni;
            TipoDocumento = pTipoDocumento;
            Nombre = pNombre;
            Apellido = pApellido;
            Email = pEmail;
            Telefono = pTelefono;
            Direccion = pDireccion;
            Numero = pNumero;
            Piso = pPiso;
            Departamento = pDepartamento;
            Localidad = pLocalidad;
            CodigoPostal = pCodigoPostal;
            FechaNacimiento = pFechaNacimiento;
            Cuil = pCuil;
        }

        public Cliente(int pIdUsuario, string pUsername, int pIdRol, String pDescRol, bool pRolHabil, int pIntentosFallidos, bool pBloqueado, bool pHabilitado, float pReputacion,
           long pDni, String pTipoDocumento, String pNombre, String pApellido, String pEmail, String pTelefono, String pDireccion, int pNumero, String pPiso, String pDepartamento, String pLocalidad, int pCodigoPostal, DateTime pFechaNacimiento, long pCuil)
        {
            //Datos de Usuario
            IdUsuario = pIdUsuario;
            Username = pUsername;
            this.Rol = new Rol(pIdRol, pDescRol, pRolHabil);
            IntentosFallidos = pIntentosFallidos;
            Bloqueado = pBloqueado;
            Habilitado = pHabilitado;
            Reputacion = pReputacion;

            //Datos de Cliente
            Dni = pDni;
            TipoDocumento = pTipoDocumento;
            Nombre = pNombre;
            Apellido = pApellido;
            Email = pEmail;
            Telefono = pTelefono;
            Direccion = pDireccion;
            Numero = pNumero;
            Piso = pPiso;
            Departamento = pDepartamento;
            Localidad = pLocalidad;
            CodigoPostal = pCodigoPostal;
            FechaNacimiento = pFechaNacimiento;
            Cuil = pCuil;
        }

        public Cliente insertar()
        {
            try
            {
                return ClienteDAO.insertar(this);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
