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
        public const String CUENTA_ORIGEN = "CUENTA_ORIGEN";
        public const String CUENTA_DESTINO = "CUENTA_DESTINO";
        public const String IMPORTE = "IMPORTE";
        public const String MONEDA = "MONEDA";
        public const String FECHA = "FECHA";
        public const String COSTO = "COSTO";

        public CuentaModel cuentaOrigen;
        public CuentaModel cuentaDestino;
        public Double importe;
        public MonedaModel moneda;
        public DateTime fecha = (new ExtraDao()).getDayToday();
        public Double costo;    

        public TransferenciaModel()
        {
        }

        public TransferenciaModel(DataRow fila):base(fila)
        {
        }

        public TransferenciaModel(CuentaModel cuentaOrigen, CuentaModel cuentaDestino,Double importe,
                                    MonedaModel moneda) {
            this.cuentaOrigen = cuentaOrigen;
            this.cuentaDestino = cuentaDestino;
            this.importe = importe;
            this.moneda = moneda;
        }
        public override void mapeoFilaAModel(DataRow fila)
        {
            base.mapeoFilaAModel(fila);
            this.cuentaOrigen = new CuentaDao().dameTuModelo(this.mapearValor(fila[CUENTA_ORIGEN]));
            this.cuentaDestino = new CuentaDao().dameTuModelo(this.mapearValor(fila[CUENTA_DESTINO]));
            this.importe = this.mapearImporte(fila[IMPORTE]);
            this.moneda = new MonedaDAO().dameTuModelo(this.mapearValor(fila[MONEDA]));
            this.fecha = this.mapearFecha(fila[FECHA]);
            this.costo = this.mapearImporte(fila[COSTO]);
        }
    }
}
