using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace Logins
{
    public class UsuarioSingleton
    {
        UserModel usuario;
        RolModel rol;
        private static UsuarioSingleton instance;
        private UsuarioSingleton()
        {
        }

        public static UsuarioSingleton getInstance()
        {
            if (instance == null)
                instance = new UsuarioSingleton();
            return instance;
        }

        public void setUsuario(UserModel usuario)
        {
            this.usuario = usuario;
        }

        public UserModel getUsuario()
        {
            return usuario;
        }

        public void setRol(RolModel rol)
        {
            this.rol = rol;
        }

        public RolModel getRol()
        {
            return rol;
        }

    }
}
