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
        public const String ESTADO = "ESTADO";
        public const String FECHA_CREACION = "FECHA_CREACION";
        public const String FECHA_CIERRE = "FECHA_CIERRE";
        public const String PROPIETARIO_ID = "PROPIETARIO_ID";
        public const String PROPIETARIO_APELLIDO = "PROPIETARIO_APELLIDO";
        public const String PROPIETARIO_NOMBRE = "PROPIETARIO_NOMBRE";


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
            this.fechaCreacion = this.mapearFecha(fila[FECHA_CREACION]);
            this.fechaCierre = this.mapearFecha(fila[FECHA_CIERRE]);
            this.propietario = new ClienteModel((Decimal) fila[PROPIETARIO_ID],
                                                fila[PROPIETARIO_APELLIDO].ToString(),
                                                fila[PROPIETARIO_NOMBRE].ToString());
        }
    }
}
