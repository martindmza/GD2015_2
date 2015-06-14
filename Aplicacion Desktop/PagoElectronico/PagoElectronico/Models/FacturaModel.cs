using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class FacturaModel
    {
        public UInt32 id;
        public DateTime fecha;
        public List<TransaccionModel> transacciones;
        public Double total;

        public FacturaModel( DateTime fecha, List<TransaccionModel> transacciones,Double total)
        {
            this.fecha = fecha;
            this.transacciones = transacciones;
            this.total = total;
        }
    }
}
