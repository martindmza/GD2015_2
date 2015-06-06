using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class CuentaModel
    {
        public Decimal id { get; set; }
        public Decimal paisId { get; set; }
        public Decimal cuentaTipo { get; set; }
        public Decimal monedaId { get; set; }
        public Int32 estado { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaCierre { get; set; }

        public CuentaModel(Decimal id, Decimal paisId,Decimal cuentaTipo,Decimal monedaId, Int32 estado,
                DateTime fechaCreacion, DateTime fechaCierre) { 
         this.id = id;
         this.paisId = paisId;
         this.cuentaTipo = cuentaTipo;
         this.monedaId = monedaId;
         this.estado = estado;
         this.fechaCreacion = fechaCreacion;
         this.fechaCierre = fechaCierre;
        }

        public CuentaModel(Decimal id, Decimal paisId, Decimal cuentaTipo, Decimal monedaId, Int32 estado)
        {
            this.id = id;
            this.paisId = paisId;
            this.cuentaTipo = cuentaTipo;
            this.monedaId = monedaId;
            this.estado = estado;
            this.fechaCreacion = DateTime.Today;
            this.fechaCierre = DateTime.Today;
        }
    }
}
