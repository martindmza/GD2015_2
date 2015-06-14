using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class DepositoModel
    {
        public UInt32 id;
        public ClienteModel depositante;
        public CuentaModel cuentaDestino;
        public Double importe;
        public UInt32 monedaId;
        public String monedaNombre;
        public TarjetaDeCreditoModel tarjetaDeCredito;
        public DateTime fecha;

        public DepositoModel(ClienteModel depositante, CuentaModel cuentaDestino, Double importe, UInt32 monedaId, 
                                String monedaNombre, TarjetaDeCreditoModel tarjetaDeCredito, DateTime fecha) 
        {
            this.depositante = depositante;
            this.cuentaDestino = cuentaDestino;
            this.importe = importe;
            this.monedaId = monedaId;
            this.monedaNombre = monedaNombre;
            this.tarjetaDeCredito = tarjetaDeCredito;
            this.fecha = fecha;
        }
    }
}
