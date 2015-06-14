using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class CuentaTipoModel
    {
        public UInt32 id { get; set; }
        public String nombre { get; set; }
        public UInt32 duracionDias { get; set; }
        public Decimal costo { get; set; }

        public CuentaTipoModel(UInt32 id, String nombre, UInt32 duracionDias, Decimal costo)
        {
            this.id = id;
            this.nombre = nombre;
            this.duracionDias = duracionDias;
            this.costo = costo;
        }
    }
}
