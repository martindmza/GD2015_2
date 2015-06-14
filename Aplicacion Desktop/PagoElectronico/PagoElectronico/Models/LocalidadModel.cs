using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class LocalidadModel
    {
        public UInt32 id {get ;set; }
        public String nombre { get; set; }

        public LocalidadModel(UInt32 id , String nombre) { 
            this.id = id;
            this.nombre = nombre;
        }

        public String ToString()
        {
            return "{ " + id.ToString() + "; " + nombre + " }";
        }
    }
}
