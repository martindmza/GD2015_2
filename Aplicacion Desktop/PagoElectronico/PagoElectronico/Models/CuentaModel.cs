using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAO;

namespace Models
{
    public class CuentaModel: BasicaModel
    {
        public const String PAIS = "PAIS";
        public const String CUENTATIPO = "TIPO_CUENTA";
        public const String MONEDA_ID = "MONEDA";
        public const String MONEDA_NOMBRE = "MONEDA";
        public const String ESTADO = "ESTADO";
        public const String FECHA_CREACION = "FECHA_CREACION";
        public const String FECHA_CIERRE = "FECHA_CIERRE";
        public const String PROPIETARIO = "PROPIETARIO";
        public const String SALDO = "SALDO";
        public const String HABILITADO = "HABILITADA";

        public PaisModel pais { get; set; }
        public CuentaTipoModel tipo { get; set; }
        public MonedaModel moneda { get; set; }
       
        public EstadoModel estado { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaCierre { get; set; }
       public ClienteModel propietario { get; set; }
        public Double saldo = 0;

        public CuentaModel() { }
        public CuentaModel(DataRow fila)
            : base(fila)
        {
        }
        public CuentaModel(Decimal id, PaisModel pais, CuentaTipoModel tipo, MonedaModel moneda,
               EstadoModel estado, DateTime fechaCreacion, ClienteModel propietario)
        {
            this.id = id;
            this.pais = pais;
            this.tipo = tipo;
            this.moneda = moneda;
            this.estado = estado;
            this.fechaCreacion = fechaCreacion;
            this.fechaCierre = fechaCierre;
        }

        public CuentaModel(Decimal id, PaisModel pais, CuentaTipoModel tipo, MonedaModel moneda,
               EstadoModel estado, DateTime fechaCreacion, DateTime fechaCierre) { 
         this.id = id;
         this.pais = pais;
         this.tipo = tipo;
         this.moneda = moneda;
         this.estado = estado;
         this.fechaCreacion = fechaCreacion;
         this.fechaCierre = fechaCierre;
        }

        public CuentaModel(Decimal id, PaisModel pais, CuentaTipoModel tipo, MonedaModel moneda, 
              EstadoModel estado, DateTime fechaCreacion, DateTime fechaCierre, ClienteModel propietario)
        {
            this.id = id;
            this.pais = pais;
            this.tipo = tipo;
            this.moneda = moneda;
            this.estado = estado;
            this.fechaCreacion = fechaCreacion;
            this.fechaCierre = fechaCierre;
            this.propietario = propietario;
        }

        public override void mapeoFilaAModel(DataRow fila)
        {
            base.mapeoFilaAModel(fila);
            this.pais = new PaisDAO().dameTuModelo(this.mapearValor(fila[PAIS]));
            this.tipo = new CuentaTipoDAO().dameTuModelo(this.mapearValor(fila[CUENTATIPO]));
            this.moneda = new MonedaDAO().dameTuModelo(this.mapearValor(fila[MONEDA_ID]));
            this.estado= new EstadoDao().dameTuModelo(fila[ESTADO].ToString());
            this.fechaCreacion = fila[FECHA_CREACION] != DBNull.Value ? DateTime.Parse(fila[FECHA_CREACION].ToString()) : DateTime.MinValue;
            this.fechaCierre = fila[FECHA_CIERRE] != DBNull.Value ? DateTime.Parse(fila[FECHA_CIERRE].ToString()) : DateTime.MinValue;
            this.saldo =  Double.Parse(fila[SALDO].ToString());
        }

        public void setPropietario(ClienteModel cliente)
        {
            this.propietario = cliente;
        }
    }
}
