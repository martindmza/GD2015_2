using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Models
{
    public class CuentaTipoModel:BasicaModel
    {
        public UInt32 duracionDias { get; set; }
        public Decimal costo { get; set; }

        public CuentaTipoModel() { }
        public CuentaTipoModel(DataRow fila ):base(fila){}

        public CuentaTipoModel(UInt32 id, String nombre, UInt32 duracionDias, Decimal costo)
        {
            this.id = id;
            this.nombre = nombre;
            this.duracionDias = duracionDias;
            this.costo = costo;
        }
    }
}
