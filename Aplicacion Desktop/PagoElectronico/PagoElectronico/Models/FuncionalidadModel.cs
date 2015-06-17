using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Models
{
    public class FuncionalidadModel: AbstractModel
    {
        public Decimal id { get; set; }
        public String nombre { get; set; }
        public Boolean habilitado { get; set; }

        public const String ID_FUNCIONALIDAD = "ID";
        public const String NOMBRE = "NOMBRE";
        public const String HABILITADA = "HABILITADA";

        public FuncionalidadModel(DataRow fila) : base(fila) { }

        public FuncionalidadModel(Decimal id, String nombre, Boolean habilitado) {
            this.id = id;
            this.nombre = nombre;
            this.habilitado = habilitado;
        }


        public override void mapeoFilaAModel(DataRow fila)
        {
            this.id = (Decimal)fila[ID_FUNCIONALIDAD];
            this.nombre = fila[NOMBRE].ToString();
            this.habilitado = (Boolean)fila[HABILITADA];
        }
    }
}
