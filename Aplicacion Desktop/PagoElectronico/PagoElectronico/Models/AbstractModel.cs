using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Models
{
    public abstract class AbstractModel
    {
        public AbstractModel()
        {
         
        }

        public AbstractModel(DataRow fila)
        {
            this.mapeoFilaAModel(fila);
        }

        public abstract void mapeoFilaAModel(DataRow fila);
    }
}
