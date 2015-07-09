using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Models
{
    public class EmisorModel : BasicaModel
    {

         public EmisorModel()
        {
        }

         public EmisorModel(Decimal id,String nombre)
             : base(id, nombre)
         {
         }


         public EmisorModel(DataRow fila)
             : base(fila)
         {
        }

        public override void mapeoFilaAModel(DataRow fila)
        {
            base.mapeoFilaAModel(fila);

        }
    }
}
