using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Models
{
    public class FuncionalidadModel: BasicaModel
    {
        public Boolean habilitado { get; set; }

        public const String HABILITADA = "HABILITADA";

        public FuncionalidadModel(DataRow fila) : base(fila) { }

        public FuncionalidadModel(Decimal id, String nombre, Boolean habilitado) {
            this.id = id;
            this.nombre = nombre;
            this.habilitado = habilitado;
        }


        public void mapeoFilaAModel(DataRow fila)
        {
            base.mapeoFilaAModel(fila);
            this.habilitado = (Boolean)fila[HABILITADA];
        }
    }
}
