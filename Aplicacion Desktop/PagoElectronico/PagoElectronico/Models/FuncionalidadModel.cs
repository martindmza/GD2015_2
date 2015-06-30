using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Models
{
    public class FuncionalidadModel: BasicaModel ,ICloneable
    {
        public Boolean habilitado { get; set; }

        public const String HABILITADA = "HABILITADA";


        public FuncionalidadModel() { }

        public FuncionalidadModel(DataRow fila) : base(fila) { }

        public FuncionalidadModel(Decimal id, String nombre, Boolean habilitado) {
            this.id = id;
            this.nombre = nombre;
            this.habilitado = habilitado;
        }


        public override void mapeoFilaAModel(DataRow fila)
        {
            base.mapeoFilaAModel(fila);
            this.habilitado = (Boolean)fila[HABILITADA];
        }

        public object Clone(){
            return new FuncionalidadModel(this.id,this.nombre,this.habilitado);
        }
            
     }
  }

