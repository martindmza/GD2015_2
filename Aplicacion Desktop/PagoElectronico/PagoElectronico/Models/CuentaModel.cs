using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAO;

namespace Models
{
    public class CuentaModel: AbstractModel
    {
        public const String ID = "ID";
        public const String PAIS = "PAIS";
        public const String CUENTATIPO = "TIPO_CUENTA";
        public const String MONEDA_ID = "MONEDA";
        public const String MONEDA_NOMBRE = "MONEDA_NOMBRE";
        public const String ESTADO = "ESTADO";
        public const String FECHA_CREACION = "FECHA_CREACION";
        public const String FECHA_CIERRE = "FECHA_CIERRE";
        public const String PROPIETARIO = "PROPIETARIO";
        public const String SALDO = "SALDO";
        public const String HABILITADO = "HABILITADO";

        public Decimal id { get; set; }
        public PaisModel pais { get; set; }
        public CuentaTipoModel tipo { get; set; }
        public Decimal monedaId { get; set; }
        public String monedaNombre { get; set; }
        public EstadoModel estado { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaCierre { get; set; }
        public ClienteModel propietario { get; set; }
        public Double saldo = 0;
        public bool habilitado = true;

        public CuentaModel(DataRow fila)
            : base(fila)
        {
        }
        public CuentaModel(Decimal id, PaisModel pais, CuentaTipoModel tipo, UInt32 monedaId, String monedaNombre,
               EstadoModel estado, DateTime fechaCreacion, ClienteModel propietario)
        {
            this.id = id;
            this.pais = pais;
            this.tipo = tipo;
            this.monedaId = monedaId;
            this.monedaNombre = monedaNombre;
            this.estado = estado;
            this.fechaCreacion = fechaCreacion;
            this.fechaCierre = fechaCierre;
        }

        public CuentaModel(Decimal id, PaisModel pais, CuentaTipoModel tipo, UInt32 monedaId, String monedaNombre,
               EstadoModel estado, DateTime fechaCreacion, DateTime fechaCierre) { 
         this.id = id;
         this.pais = pais;
         this.tipo = tipo;
         this.monedaId = monedaId;
         this.monedaNombre = monedaNombre;
         this.estado = estado;
         this.fechaCreacion = fechaCreacion;
         this.fechaCierre = fechaCierre;
        }

        public CuentaModel(Decimal id, PaisModel pais, CuentaTipoModel tipo, UInt32 monedaId, String monedaNombre,
              EstadoModel estado, DateTime fechaCreacion, DateTime fechaCierre, ClienteModel propietario)
        {
            this.id = id;
            this.pais = pais;
            this.tipo = tipo;
            this.monedaId = monedaId;
            this.monedaNombre = monedaNombre;
            this.estado = estado;
            this.fechaCreacion = fechaCreacion;
            this.fechaCierre = fechaCierre;
            this.propietario = propietario;
        }

        public override void mapeoFilaAModel(DataRow fila)
        {
            this.id = (decimal)fila[ID];
            this.pais = new PaisDAO().dameTuModelo((decimal)fila[PAIS]);
          /*  if (fila[CUENTATIPO] != null && fila[CUENTATIPO] != "")
            {
                this.tipo = new CuentaTipoDAO().dameTuModelo((decimal)fila[CUENTATIPO]);
            }*/
            this.monedaId = (decimal)fila[MONEDA_ID];
            this.monedaNombre = fila[MONEDA_NOMBRE].ToString();
            this.estado= new EstadoDao().dameTuModelo((decimal)fila[ESTADO]);
            this.fechaCreacion = fila[FECHA_CREACION] != DBNull.Value ? DateTime.Parse(fila[FECHA_CREACION].ToString()) : DateTime.MinValue;
            this.fechaCierre = fila[FECHA_CIERRE] != DBNull.Value ? DateTime.Parse(fila[FECHA_CIERRE].ToString()) : DateTime.MinValue;
            this.propietario = new ClienteDao().getClienteById((decimal)fila[PROPIETARIO]);
            this.saldo = (double)fila[SALDO];
            this.habilitado = (Boolean)fila[HABILITADO];

        }
    }
}
