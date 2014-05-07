using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Entidades
{
    abstract class Usuario
    {
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public Rol Rol { get; set; }
        public int IntentosFallidos { get; set; }
        public bool Bloqueado { get; set; }
        public bool Habilitado { get; set; }
        public float Reputacion { get; set; }

        /*public void Usuario() { 
        }

        public void Usuario(int pIdUsuario, string pUsername, int pIdRol, String pDescRol, bool pRolHabil, int pIntentosFallidos, bool pBloqueado, bool pHabilitado, float pReputacion)
        {
            IdUsuario = pIdUsuario;
            Username = pUsername;
            this.Rol = new Rol(pIdRol, pDescRol, pRolHabil);
            IntentosFallidos = pIntentosFallidos;
            Bloqueado = pBloqueado;
            Habilitado = pHabilitado;
            Reputacion = pReputacion;
        }
        */ 
    }
}
