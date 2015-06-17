using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Models
{
    public class LocalidadModel:BasicaModel
    {
        public LocalidadModel()
        {
        }
        public LocalidadModel(DataRow fila):base(fila) { 
        }

        public String ToString()
        {
            return "{ " + id.ToString() + "; " + nombre + " }";
        }
        public LocalidadModel(Decimal id, String nombre)
        {
            this.id = 0;
            this.nombre = nombre;
        }

    }
}
