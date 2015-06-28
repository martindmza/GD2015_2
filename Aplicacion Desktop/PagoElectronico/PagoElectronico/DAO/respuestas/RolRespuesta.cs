using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
    public class RolRespuesta
    {
        public Decimal codigo;
        public String mensaje;


        public RolRespuesta(Decimal codigo, String mensaje) {
            this.codigo = codigo;
            this.mensaje = mensaje;
        }
    }
}
