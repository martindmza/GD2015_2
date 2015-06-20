using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Models
{
    public class EstadoModel: BasicaModel
    {
        public EstadoModel()
        {
        }
        public EstadoModel(DataRow fila):base(fila) {
        }
    }
}
