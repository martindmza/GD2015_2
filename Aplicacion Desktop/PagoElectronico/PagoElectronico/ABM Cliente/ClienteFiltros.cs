using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ABM
{
    public class ClienteFiltros
    {
        public String nombre { get; set; }
        public String apellido { get; set; }
        public UInt32 documentoTipo { get; set; }
        public UInt64 documentoNumero { get; set; }
        public String email { get; set; }
        public Boolean habilitado { get; set; }

        
        public String ToString() { 
            return " { " + nombre + " ; " + apellido + " ; " + documentoTipo + " ; " + documentoNumero + " ; " + email + " ; " + habilitado + " } ";
        }
    }


}
