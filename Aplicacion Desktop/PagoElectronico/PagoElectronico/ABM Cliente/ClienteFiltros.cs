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
        public Decimal documentoTipo { get; set; }
        public Decimal documentoNumero { get; set; }
        public String email { get; set; }

        
        public String ToString() { 
            return " { " + nombre + " ; " + apellido + " ; " + documentoTipo + " ; " + documentoNumero + " ; " + email + " } ";
        }
    }


}
