using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Models
{
    public class TipoDocumentoModel: BasicaModel
    {
        public TipoDocumentoModel()
        {
        }
        public TipoDocumentoModel(DataRow fila):base(fila)
        {
        }

        public TipoDocumentoModel(Decimal tipo, String nombre) {
            this.id = tipo;
            this.nombre = nombre;
        }


        public String ToString()
        {
            return "{ " + id.ToString() + "; " + this.nombre + ";}";
        }
    }
}
