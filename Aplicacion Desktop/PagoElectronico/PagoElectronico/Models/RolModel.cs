using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class RolModel {

        public Decimal id { get; set; }
        public String nombre { get; set; }
        public Boolean habilitado { get; set; }
        public List<FuncionalidadModel> funcionalidades { get; set; }

        public RolModel(String nombre)
        {
            this.nombre = nombre;
            funcionalidades = new List<FuncionalidadModel>();
        }

        public RolModel(Decimal id, String nombre, Boolean habilitado) {
            this.id = id;
            this.nombre = nombre;
            this.habilitado = habilitado;
            funcionalidades = new List<FuncionalidadModel>();
        }

        public RolModel(Decimal id, String nombre, Boolean habilitado, List<FuncionalidadModel> funcionalidades) {
            this.id = id;
            this.nombre = nombre;
            this.habilitado = habilitado;
            this.funcionalidades = funcionalidades;
        }

    }
}
