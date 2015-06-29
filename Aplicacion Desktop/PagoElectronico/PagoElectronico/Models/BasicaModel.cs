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
        public const String SIN_NOMBRE = "SIN_NOMBRE";

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

        public override void mapeoFilaAModel(DataRow fila)
        {
            base.mapeoFilaAModel(fila);
            try
            {
                this.nombre = fila[NOMBRE].ToString();
            }
            catch (Exception e)
            {
                this.nombre = SIN_NOMBRE;
            }
        }
    }
}
