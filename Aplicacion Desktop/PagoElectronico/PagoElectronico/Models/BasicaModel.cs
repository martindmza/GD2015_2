using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Models
{
    public class BasicaModel: AbstractModel
    {
        public const String NOMBRE = "NOMBRE";

        public String nombre;

        public BasicaModel()
            : base()
        {
        }

        public BasicaModel(DataRow fila)
            : base(fila)
        {
        }

        public BasicaModel(Decimal id, String nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public void mapeoFilaAModel(DataRow fila)
        {
            base.mapeoFilaAModel(fila);
            this.nombre = fila[NOMBRE].ToString();
        }
    }
}
