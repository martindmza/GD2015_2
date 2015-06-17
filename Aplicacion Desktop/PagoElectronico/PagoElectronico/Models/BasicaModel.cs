using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Models
{
    public class BasicaModel: AbstractModel
    {
        public const String ID = "ID";
        public const String NOMBRE = "NOMBRE";

        public Decimal id;
        public String nombre;

        public BasicaModel()
            : base()
        {
        }

        public BasicaModel(DataRow fila)
            : base(fila)
        {
        }

        public override void mapeoFilaAModel(DataRow fila)
        {
            this.id = (Decimal)fila[ID];
            this.nombre = fila[NOMBRE].ToString();
        }

       
    }
}
