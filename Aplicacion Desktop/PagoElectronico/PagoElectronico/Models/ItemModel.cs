using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAO;

namespace Models
{
    public class ItemModel: BasicaModel
    {

        public const String FACTURA_ID = "FACTURA_ID";
        public const String CUENTA_ID = "CUENTA_ID";
        public const String TIPO_ID = "TIPO_ID";
        public const String IMPORTE = "IMPORTE";
        public const String FECHA = "FECHA";


        public FacturaModel factura;
        public CuentaModel cuenta;
        public ItemTipoModel tipo;
        public Double importe;
        public DateTime fecha;

        public ItemModel() { }

        public ItemModel(DataRow fila):base(fila) { }

        public ItemModel(FacturaModel factura, CuentaModel cuenta, ItemTipoModel tipo,
                                Double importe, DateTime fecha) {

            this.id = id;
            this.factura = factura;
            this.cuenta = cuenta;
            this.tipo = tipo;
            this.importe = importe;
            this.fecha = fecha;
        }

        public ItemModel(Decimal id,FacturaModel factura, CuentaModel cuenta, ItemTipoModel tipo,
                                Double importe, DateTime fecha) : base(id)
        {
            this.factura = factura;
            this.cuenta = cuenta;
            this.tipo = tipo;
            this.importe = importe;
            this.fecha = fecha;
        }

        public override void mapeoFilaAModel(DataRow fila)
        {
            base.mapeoFilaAModel(fila);

            if (fila.Table.Columns.Contains(FACTURA_ID))
            {
                this.factura = new FacturaModel(Decimal.Parse(fila[FACTURA_ID].ToString()));
            }

            this.cuenta = new CuentaDao().dameTuModelo(this.mapearValor(fila[CUENTA_ID]));
            this.tipo = new ItemTipoDao().dameTuModelo(this.mapearValor(fila[TIPO_ID]));
            this.importe = this.mapearImporte(fila[IMPORTE]);
            this.fecha = this.mapearFecha(fila[FECHA]);
        }

    }
}
