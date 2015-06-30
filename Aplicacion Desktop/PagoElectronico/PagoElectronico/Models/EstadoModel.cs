using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Models
{
    public class EstadoModel: BasicaModel
    {
        public static String HABILITADA = "Habilitada";
        public static String CERRADA = "Cerrada";
        public static String PENDIENTE = "Pendiente de activación";
        public static String INHABILITADA = "Inhabilitada";
        
        public EstadoModel()
        {
        }
        public EstadoModel(DataRow fila):base(fila) {
        }

        public override void mapeoFilaAModel(DataRow fila)
        {
            base.mapeoFilaAModel(fila);

        }
    }
}
