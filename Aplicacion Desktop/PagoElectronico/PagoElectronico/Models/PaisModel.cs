using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Models
{
    public class PaisModel : BasicaModel
    {
        public String nacionalidad;
        public const String NACIONALIDAD = "NACIONALIDAD";

        public PaisModel()
        {
        }
        public PaisModel(DataRow fila)
            : base(fila)
        {
        }

        public String ToString()
        {
            return "{ " + id + "; " + nombre + "; " + nacionalidad + " }";
        }

        public override void mapeoFilaAModel(DataRow fila)
        {
            base.mapeoFilaAModel(fila);
            //this.nacionalidad = fila[NACIONALIDAD].ToString();
        }
    }
}
