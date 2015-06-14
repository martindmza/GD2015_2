using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class PaisModel
    {
        public UInt32 id;
        public String nombre;
        public String nacionalidad;


        public PaisModel(UInt32 id, String nombre, String nacionalidad)
        {
            this.id = id;
            this.nombre = nombre;
            this.nacionalidad = nacionalidad;
        }

        public String ToString() {
            return "{ " + id + "; " + nombre + "; " + nacionalidad + " }";
        }
    }
}
