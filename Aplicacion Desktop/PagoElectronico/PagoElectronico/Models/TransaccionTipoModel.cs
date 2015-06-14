using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class TransaccionTipoModel
    {
        public UInt32 id;
        public String nombre;

        public TransaccionTipoModel(UInt32 id, String nombre) {
            this.id = id;
            this.nombre = nombre;
        }
    }
}
