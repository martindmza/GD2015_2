using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Models
{
    public class FacturaModel: BasicaModel
    {
        public static String FECHA = "FECHA";
        public DateTime fecha;
        public List<TransaccionModel> transacciones;


        public FacturaModel() { }

        public FacturaModel(DataRow fila):base(fila) {
            transacciones = this.obtenerMisTransacciones();
        }

        private List<TransaccionModel> obtenerMisTransacciones()
        {
            return new List<TransaccionModel>();
        }

        public FacturaModel( DateTime fecha, List<TransaccionModel> transacciones)
        {
            this.fecha = fecha;
            this.transacciones = transacciones;
        }

        public FacturaModel(UInt32 id,DateTime fecha, List<TransaccionModel> transacciones)
        {
            this.id = id;
            this.fecha = fecha;
            this.transacciones = transacciones;
        }

        public override void mapeoFilaAModel(DataRow fila)
        {
            base.mapeoFilaAModel(fila);
            this.fecha = this.mapearFecha(fila[FECHA]);
        }
    }
}
