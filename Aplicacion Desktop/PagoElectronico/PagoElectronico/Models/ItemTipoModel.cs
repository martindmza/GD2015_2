using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace Models
{
    public class ItemTipoModel : BasicaModel
    {
        public const String IMPORTE = "IMPORTE";
        public Double importe;

        public ItemTipoModel() { }

        public ItemTipoModel(Decimal id, String nombre, Double importe)
        {
            this.id = id;
            this.nombre = nombre;
            this.importe = importe;
        }

        public ItemTipoModel(DataRow fila)
            : base(fila)
        {
        }

        public override void mapeoFilaAModel(DataRow fila)
        {
            base.mapeoFilaAModel(fila);
            this.importe = this.mapearImporte(fila[IMPORTE]);
        }
    }
}
