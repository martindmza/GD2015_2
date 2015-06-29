using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Models
{
    public class MonedaModel: BasicaModel 
    {
        public MonedaModel() { }
        public MonedaModel(DataRow fila)
            : base(fila)
        {
        }

    }
}
