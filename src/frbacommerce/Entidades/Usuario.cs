using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Datos;
using FrbaCommerce.Componentes_Comunes;

namespace FrbaCommerce.Entidades
{
     public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public string PasswordEncriptada { get; set; }
        public string PasswordDesencriptada { get; set; }
        public Rol Rol { get; set; }
        public int IntentosFallidos { get; set; }
        public bool Bloqueado { get; set; }
        public bool Habilitado { get; set; }
        public float Reputacion { get; set; }
        public float CantComprasPorRendir { get; set; }

        public Usuario() { 
        }

        public Usuario(int pIdUsuario, string pUsername, int pIdRol, String pDescRol, bool pRolHabil, int pIntentosFallidos, bool pBloqueado, bool pHabilitado, float pReputacion)
        {
            IdUsuario = pIdUsuario;
            Username = pUsername;
            PasswordEncriptada = "";
            PasswordDesencriptada = "";
            this.Rol = new Rol(pIdRol, pDescRol, pRolHabil);
            IntentosFallidos = pIntentosFallidos;
            Bloqueado = pBloqueado;
            Habilitado = pHabilitado;
            Reputacion = pReputacion;
        }

        public Usuario(int pIdUsuario, string pUsername, int pIdRol, String pDescRol, bool pRolHabil, int pIntentosFallidos, bool pBloqueado, bool pHabilitado, float pReputacion, float pCantComprasPorRendir)
        {
            IdUsuario = pIdUsuario;
            Username = pUsername;
            PasswordEncriptada = "";
            PasswordDesencriptada = "";
            this.Rol = new Rol(pIdRol, pDescRol, pRolHabil);
            IntentosFallidos = pIntentosFallidos;
            Bloqueado = pBloqueado;
            Habilitado = pHabilitado;
            Reputacion = pReputacion;
            CantComprasPorRendir = pCantComprasPorRendir;
        }

        public Usuario(string pUsername, string pPassDesencriptada, int pIdRol)
        {
            Username = pUsername;
            PasswordDesencriptada = pPassDesencriptada;
            PasswordEncriptada = FrbaCommerce.Componentes_Comunes.Metodos_Comunes.sha256_hash(pPassDesencriptada);
            this.Rol = new Rol(pIdRol, "", false);
            Habilitado = true;
            Bloqueado = false;
            Reputacion = 0;
            CantComprasPorRendir = 0;
        }

        public Usuario(int pIdUsuario, string pUsername, int pIntentosFallidos, bool pBloqueado, bool pHabilitado, float pReputacion)
        {
            IdUsuario = pIdUsuario;
            Username = pUsername;
            PasswordEncriptada = "";
            PasswordDesencriptada = "";
            IntentosFallidos = pIntentosFallidos;
            Bloqueado = pBloqueado;
            Habilitado = pHabilitado;
            Reputacion = pReputacion;
        }

        public Usuario insertar()
        {
            try
            {
                return UsuarioDAO.insertar(this);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario modificar()
        {
            try
            {
                return UsuarioDAO.modificar(this);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario modificarPassword()
        {
            try
            {
                return UsuarioDAO.modificarPassword(this);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void eliminar()
        {
            try
            {
                UsuarioDAO.eliminar(this);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void aumentarIntentosFallidos()
        {
            try
            {
                IntentosFallidos += 1;

                if (excedeIntentos())
                {
                    bloquear();
                }

                modificar();

            }
            catch (Exception)
            {   
                throw;
            }
        }


        public Boolean excedeIntentos() {
            try
            {
                return IntentosFallidos >= 3;
            }
            catch (Exception)
            {   
                throw;
            }
        }

        public void bloquear()
        {
            try
            {
                Metodos_Comunes.MostrarMensaje("El usuario " + Username + " fue bloqueado");
                Bloqueado = true;
            }
            catch (Exception)
            {   
                throw;
            }
        }

        public void loggeoSatisfactorio() 
        {
            try
            {
                IntentosFallidos = 0;
                Bloqueado = false;
                
                modificar();
                aumentarCantidadLoggeosSatisfactorios();
            }
            catch (Exception)
            {   
                throw;
            }
        }


        public void setPasswordDesencriptada(string passDesencriptada)
        {
            try
            {
                PasswordDesencriptada = passDesencriptada;
                PasswordEncriptada = Metodos_Comunes.sha256_hash(passDesencriptada);
            }
            catch (Exception)
            {   
                throw;
            }
        }

        public void aumentarCantidadLoggeosSatisfactorios() 
        {
            UsuarioDAO.aumentaCantidadLoggeosSatisfactorios(this);
        }
    }
}
