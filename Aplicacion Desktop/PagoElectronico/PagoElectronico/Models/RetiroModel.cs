using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAO;

namespace Models
{
    public class RetiroModel : BasicaModel
    {
        public const String CUENTA = "CUENTA";
        public const String IMPORTE = "IMPORTE";
        public const String MONEDA = "MONEDA";
        public const String FECHA = "FECHA";
        public const String CHEQUE = "CHEQUE";
        public const String BANCO = "BANCO";

        public CuentaModel cuenta;
        public Double importe;
        public MonedaModel moneda;
        public DateTime fecha;
        public Decimal chequeId;
        public BancoModel banco;

        public RetiroModel()
        {
        }

        public RetiroModel(DataRow fila): base(fila)
        {
        }

        public RetiroModel(CuentaModel cuenta, Double importe, MonedaModel moneda, 
                                DateTime fecha) 
        {
            this.cuenta = cuenta;
            this.importe = importe;
            this.moneda = moneda;
            this.fecha = fecha;
        }

        public RetiroModel(UInt32 id,CuentaModel cuenta, Double importe, MonedaModel moneda,
                                 DateTime fecha)
        {
            this.id = id;
            this.cuenta = cuenta;
            this.importe = importe;
            this.moneda = moneda;
            this.fecha = fecha;
        }

        public RetiroModel(UInt32 id, CuentaModel cuenta, Double importe, MonedaModel moneda,
                                DateTime fecha, UInt32 chequeId, BancoModel banco)
        {
            this.id = id;
            this.cuenta = cuenta;
            this.importe = importe;
            this.moneda = moneda;
            this.fecha = fecha;
            this.chequeId = chequeId;
            this.banco = banco;
        }

        public override void mapeoFilaAModel(DataRow fila)
        {
            base.mapeoFilaAModel(fila);
            this.banco = new BancoDAO().dameTuModelo(this.mapearValor(fila[BANCO]));
            this.importe = this.mapearImporte(fila[IMPORTE]);
            this.moneda = new MonedaDAO().dameTuModelo(this.mapearValor(fila[MONEDA]));
            this.fecha = this.mapearFecha(fila[FECHA]);
            this.cuenta = new CuentaDao().dameTuModelo(this.mapearValor(fila[CUENTA]));
            this.chequeId = this.mapearNum(fila[CHEQUE]);
        }
    }
}
