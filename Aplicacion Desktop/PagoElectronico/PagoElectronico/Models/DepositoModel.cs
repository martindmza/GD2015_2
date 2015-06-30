using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAO;

namespace Models
{
    public class DepositoModel : BasicaModel

    {
        public const String DEPOSITANTE = "DEPOSITANTE";
        public const String CUENTA_DESTINO = "CUENTA_DESTINO";
        public const String IMPORTE = "IMPORTE";
        public const String MONEDA = "MONEDA";
        public const String TARJETA = "TARJETA";
        public const String FECHA = "FECHA";

        public ClienteModel depositante;
        public CuentaModel cuentaDestino;
        public Double importe;
        public MonedaModel monedaId;
        public TarjetaDeCreditoModel tarjetaDeCredito;
        public DateTime fecha;


        public DepositoModel() { 
        }

        public DepositoModel(DataRow fila):base(fila) { 
        
        }

        public override void mapeoFilaAModel(DataRow fila)
        {
            base.mapeoFilaAModel(fila);
            this.depositante = new ClienteDao().dameTuModelo(this.mapearValor(fila[DEPOSITANTE]));
            this.cuentaDestino = new CuentaDao().dameTuModelo(this.mapearValor(fila[CUENTA_DESTINO]));
            this.importe = this.mapearImporte(fila[CUENTA_DESTINO]);
            this.monedaId = new MonedaDAO().dameTuModelo(this.mapearValor(fila[MONEDA]));
            this.tarjetaDeCredito = new TarjetaDeCreditoDao().dameTuModelo(this.mapearValor(fila[TARJETA]));
            this.fecha = this.mapearFecha(fila[FECHA]);
        }
    }
}
