using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class RetiroModel
    {
        public UInt32 id;
        public CuentaModel cuenta;
        public Double importe;
        public UInt32 monedaId;
        public String monedaNombre;
        public DateTime fecha;

        public UInt32 chequeId;
        public BancoModel banco;

        public RetiroModel(CuentaModel cuenta, Double importe, UInt32 monedaId, 
                                String monedaNombre, DateTime fecha) 
        {
            this.cuenta = cuenta;
            this.importe = importe;
            this.monedaId = monedaId;
            this.monedaNombre = monedaNombre;
            this.fecha = fecha;
        }
    }
}
