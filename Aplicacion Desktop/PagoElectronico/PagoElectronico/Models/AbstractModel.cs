using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Models
{
    public abstract class AbstractModel
    {
        public const String ID = "ID";
        public Decimal id;
        public AbstractModel()
        {
        }

        public AbstractModel(DataRow fila)
        {
            this.mapeoFilaAModel(fila);
        }

        public virtual void mapeoFilaAModel(DataRow fila){
            this.id = (Decimal)fila[ID];
        }
    }
}
