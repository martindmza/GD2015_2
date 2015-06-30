using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Models
{
    public class TransaccionModel: BasicaModel
    {
        public UInt32 idFactura;
        public CuentaModel cuenta;
        public TransaccionTipoModel tipo;
        public Double importe;
        public DateTime fecha;
        public Boolean habilitada;

        public TransaccionModel() { }

        public TransaccionModel(DataRow fila):base(fila) { }

        public TransaccionModel(UInt32 id, UInt32 idFactura, CuentaModel cuenta, TransaccionTipoModel tipo,
                                Double importe, DateTime fecha) {

            this.id = id;
            this.idFactura = idFactura;
            this.cuenta = cuenta;
            this.tipo = tipo;
            this.importe = importe;
            this.fecha = fecha;
        }

    }
}
