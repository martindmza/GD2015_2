using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class FuncionalidadModel
    {
        public Decimal id { get; set; }
        public String nombre { get; set; }
        public Boolean habilitado { get; set; }

        public FuncionalidadModel(Decimal id, String nombre, Boolean habilitado) {
            this.id = id;
            this.nombre = nombre;
            this.habilitado = habilitado;
        }

    }
}
