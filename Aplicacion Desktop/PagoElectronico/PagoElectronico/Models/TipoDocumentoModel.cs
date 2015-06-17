using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Models
{
    public class TipoDocumentoModel:BasicaModel
    {
        public TipoDocumentoModel(DataRow fila)
            : base(fila)
        {
        }
    }
}
