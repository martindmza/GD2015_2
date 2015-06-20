using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Models
{
    public class BancoModel: BasicaModel
    {
        public BancoModel()
            : base(){}
        public BancoModel(Decimal id, String nombre)
            : base(id,nombre) { }
        public BancoModel(DataRow fila)
            : base(fila) { }
        
        
    }
}
