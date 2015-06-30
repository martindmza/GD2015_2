using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Models
{
    public class FacturaModel: BasicaModel
    {
        public DateTime fecha;
        public List<TransaccionModel> transacciones;


        public FacturaModel() { }

        public FacturaModel(DataRow fila):base(fila) { }

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
    }
}
