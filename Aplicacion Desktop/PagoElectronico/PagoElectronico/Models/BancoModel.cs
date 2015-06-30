using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Models
{
    public class BancoModel: BasicaModel
    {
        public const String DIRECCION = "DIRECCION";
        String direccion;

        public BancoModel()
            : base(){}
        public BancoModel(DataRow fila)
            : base(fila) { }

        public override void mapeoFilaAModel(DataRow fila)
        {
            base.mapeoFilaAModel(fila);
            this.direccion = this.mapearValor(fila[DIRECCION]);
        }
    }
}
