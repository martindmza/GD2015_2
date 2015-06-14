using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class BancoModel
    {
        public UInt32 id;
        public String nombre;

        public BancoModel(UInt32 id, String nombre) { 
            this.id = id;
            this.nombre = nombre;
        }
    }
}
