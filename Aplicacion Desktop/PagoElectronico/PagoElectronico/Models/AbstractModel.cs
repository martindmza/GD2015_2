using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Models
{
    public abstract class AbstractModel
    {
        public const String ID = "ID";
        public Decimal id;
        public AbstractModel()
        {
        }

        public AbstractModel(DataRow fila)
        {
            this.mapeoFilaAModel(fila);
        }

        public virtual void mapeoFilaAModel(DataRow fila){
            this.id = (Decimal)fila[ID];
        }

        protected String mapearValor(Object columna)
        {
            String valor = "";
            valor = columna.ToString();
            return valor;
        }

        protected Decimal mapearNum(Object columna)
        {
            Decimal id = new Decimal();
            id = Decimal.Parse(columna.ToString());
            return id;
        }
        protected DateTime mapearFecha(Object columna)
        {
            DateTime fecha =DateTime.MinValue;
            if(columna != DBNull.Value){
                fecha = DateTime.Parse(columna.ToString());
            }
            return fecha;
        }
        protected Double mapearImporte(Object columna)
        {
            Double importe = new Double();
            if (columna != DBNull.Value)
            {
                importe = Double.Parse(columna.ToString());
            }
            return importe;
        }

        protected bool mapearBool(Object columna)
        {
            bool retu ;
            retu = Boolean.Parse(columna.ToString());
            return retu;
        }

    }
}
