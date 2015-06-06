using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Includes;
using DAO;
using System.Data;
using MyExceptions;

namespace Models
{
    public class UserModel
    {

        public Decimal id { get; set; }
        public String nombre { get; set; }
        public String password { get; set; }
        public Boolean habilitado { get; set; }
        public Decimal intentosFallidos { get; set; }
        public List<RolModel> roles { get; set; }
        public UserDao dao { get; set; }
        public RolDao rolDao { get; set; }

        public UserModel() { incializar(); }

        public UserModel(String nombre, String password)
        {
            this.nombre = nombre;
            this.password = password;
            incializar();
        }

        public UserModel(Decimal id, String nombre, String password)
        {
            this.id = id;
            this.nombre = nombre;
            this.password = password;
            incializar();
        }
        
        public UserModel(Decimal id, String nombre, String password, Boolean habilitado, Decimal intentosFallidos)
        {
            this.id = id;
            this.nombre = nombre;
            this.password = password;
            this.habilitado = habilitado;
            this.intentosFallidos = intentosFallidos;
            incializar();
        }

        private void incializar()
        {
            roles = new List<RolModel>();
            dao = new UserDao();
            rolDao = new RolDao();
        }

        //---------------------------------------------------------------------------------------------------------------
        public void getRoles()
        {
            if (rolDao.getRolesByUser(this.id) != null) {
                roles = rolDao.getRolesByUser(this.id);    
            }
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
