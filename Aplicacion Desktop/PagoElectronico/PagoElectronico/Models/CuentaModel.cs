using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class CuentaModel
    {
        public UInt32 id { get; set; }
        public PaisModel pais { get; set; }
        public CuentaTipoModel tipo { get; set; }
        public UInt32 monedaId { get; set; }
        public String monedaNombre { get; set; }
        public EstadoModel estado { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaCierre { get; set; }
        public ClienteModel propietario { get; set; }
        public Double saldo = 0;
        public bool habilitado = true;

        public CuentaModel(UInt32 id, PaisModel pais, CuentaTipoModel tipo, UInt32 monedaId, String monedaNombre,
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

        public CuentaModel(UInt32 id, PaisModel pais, CuentaTipoModel tipo, UInt32 monedaId, String monedaNombre,
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

        public CuentaModel(UInt32 id, PaisModel pais, CuentaTipoModel tipo, UInt32 monedaId, String monedaNombre,
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
    }
}
