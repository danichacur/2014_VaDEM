using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Datos;

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

        public Usuario(string pUsername, string pPassDesencriptada, int pIdRol)
        {
            Username = pUsername;
            PasswordDesencriptada = pPassDesencriptada;
            PasswordEncriptada = FrbaCommerce.Componentes_Comunes.Metodos_Comunes.sha256_hash(pPassDesencriptada);
            this.Rol = new Rol(pIdRol, "", false);
            
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
            }
            catch (Exception)
            {   
                throw;
            }
        }
        
    }
}
