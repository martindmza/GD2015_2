using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Models
{
    public class RetiroModel : BasicaModel
    {
        public UInt32 id;
        public CuentaModel cuenta;
        public Double importe;
        public UInt32 monedaId;
        public String monedaNombre;
        public DateTime fecha;

        public UInt32 chequeId;
        public BancoModel banco;

        public RetiroModel()
        {
        }

        public RetiroModel(DataRow fila): base(fila)
        {
        }

        public RetiroModel(CuentaModel cuenta, Double importe, UInt32 monedaId, 
                                String monedaNombre, DateTime fecha) 
        {
            this.cuenta = cuenta;
            this.importe = importe;
            this.monedaId = monedaId;
            this.monedaNombre = monedaNombre;
            this.fecha = fecha;
        }

        public RetiroModel(UInt32 id,CuentaModel cuenta, Double importe, UInt32 monedaId,
                                String monedaNombre, DateTime fecha)
        {
            this.id = id;
            this.cuenta = cuenta;
            this.importe = importe;
            this.monedaId = monedaId;
            this.monedaNombre = monedaNombre;
            this.fecha = fecha;
        }

        public RetiroModel(UInt32 id, CuentaModel cuenta, Double importe, UInt32 monedaId,
                                String monedaNombre, DateTime fecha, UInt32 chequeId, BancoModel banco)
        {
            this.id = id;
            this.cuenta = cuenta;
            this.importe = importe;
            this.monedaId = monedaId;
            this.monedaNombre = monedaNombre;
            this.fecha = fecha;
            this.chequeId = chequeId;
            this.banco = banco;
        }
    }
}
