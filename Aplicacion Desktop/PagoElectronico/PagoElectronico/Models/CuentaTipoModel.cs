using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Models
{
    public class CuentaTipoModel:BasicaModel
    {
        public const String COSTO = "COSTO";
        public const String VIGENCIA = "VIGENCIA";

        public Decimal duracionDias { get; set; }
        public Double costo { get; set; }

        public CuentaTipoModel() { }
        public CuentaTipoModel(DataRow fila ):base(fila)
        {
        }

        public CuentaTipoModel(Decimal id, String nombre, UInt32 duracionDias, Double costo)
        {
            this.id = id;
            this.nombre = nombre;
            this.duracionDias = duracionDias;
            this.costo = costo;
        }

        public override void mapeoFilaAModel(DataRow fila)
        {
            base.mapeoFilaAModel(fila);
            this.costo = this.mapearImporte(fila[COSTO]);
            this.duracionDias = this.mapearNum(fila[VIGENCIA]);
        }

    }
}
