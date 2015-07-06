using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Models
{
    public class MonedaModel: BasicaModel 
    {

        public MonedaModel() {
            this.id = 1;
            this.nombre = "Dolares";
        }
        
        public MonedaModel(DataRow fila)
            : base(fila)
        {
        }

    }
}
