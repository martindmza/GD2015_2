using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using System.Data;

namespace Models
{
    public class TransferenciaModel:BasicaModel
    {

        public CuentaModel cuentaOrigen;
        public CuentaModel cuentaDestino;
        public Double importe;
        public UInt32 monedaId;
        public String monedaNombre;
        public DateTime fecha = (new ExtraDao()).getDayToday();
        public Double costo;

        public TransferenciaModel()
        {
        }

        public TransferenciaModel(DataRow fila):base(fila)
        {
        }

        public TransferenciaModel(CuentaModel cuentaOrigen, CuentaModel cuentaDestino,Double importe,
                                    UInt32 monedaId, String monedaNombre) {
            this.cuentaOrigen = cuentaOrigen;
            this.cuentaDestino = cuentaDestino;
            this.importe = importe;
            this.monedaId = monedaId;
            this.monedaNombre = monedaNombre;
        }
    }
}
