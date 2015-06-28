using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
    public class Respuesta
    {
        public Decimal codigo;
        public String mensaje;


        public Respuesta(Decimal codigo, String mensaje) {
            this.codigo = codigo;
            this.mensaje = mensaje;
        }
    }
}
