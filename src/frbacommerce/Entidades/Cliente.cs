using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Datos;

namespace FrbaCommerce.Entidades
{
    public class Cliente : Usuario
    {
        public long Documento { get; set; }
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

        public Cliente(long pDocumento, String pTipoDocumento, String pNombre, String pApellido, String pEmail, String pTelefono, String pDireccion, int pNumero, String pPiso, String pDepartamento, String pLocalidad, int pCodigoPostal, DateTime pFechaNacimiento, long pCuil)
        {
            //Datos de Cliente
            Documento = pDocumento;
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
           long pDocumento, String pTipoDocumento, String pNombre, String pApellido, String pEmail, String pTelefono, String pDireccion, int pNumero, String pPiso, String pDepartamento, String pLocalidad, int pCodigoPostal, DateTime pFechaNacimiento, long pCuil)
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
            Documento = pDocumento;
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

        public Cliente modificar()
        {
            try
            {
                base.modificar();
                return ClienteDAO.modificar(this);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void bajaLogica()
        {
            try
            {
                Habilitado = false;
                modificar();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void completarDatosDeUsuario()
        {
            Usuario usr;
            try
            {
                usr = ClienteDAO.obtenerDatosUsuarioDesdeCliente(this);
                this.IdUsuario = usr.IdUsuario;
                this.Username = usr.Username;
                this.IntentosFallidos = usr.IntentosFallidos;
                this.Bloqueado = usr.Bloqueado;
                this.Habilitado = usr.Habilitado;
                this.Reputacion = usr.Reputacion;
                this.CantComprasPorRendir = usr.CantComprasPorRendir;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                usr = null;
            }
        }
    }
}
