using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Models
{
    public class DepositoModel : AbstractModel
    {
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

        public DepositoModel(UInt32 id,ClienteModel depositante, CuentaModel cuentaDestino, Double importe, UInt32 monedaId,
                                String monedaNombre, TarjetaDeCreditoModel tarjetaDeCredito, DateTime fecha)
        {
            this.id = id;
            this.depositante = depositante;
            this.cuentaDestino = cuentaDestino;
            this.importe = importe;
            this.monedaId = monedaId;
            this.monedaNombre = monedaNombre;
            this.tarjetaDeCredito = tarjetaDeCredito;
            this.fecha = fecha;
        }

        public void mapeoFilaAModel(DataRow fila)
        {
            base.mapeoFilaAModel(fila);
        }
    }
}
