using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAO;

namespace Models
{
    public class RolModel : BasicaModel{
        public const String HABILITADO = "HABILITADO";
        public Boolean habilitado { get; set; }
        public List<FuncionalidadModel> funcionalidades { get; set; }

        public RolModel()
        {
        }

        public RolModel(String nombre)
        {
            this.id = -1;
            this.nombre = nombre;
            funcionalidades = new List<FuncionalidadModel>();
            this.habilitado = true;
        }
        
        public RolModel(DataRow fila): base(fila){
            this.funcionalidades = this.quieroMisFuncionalidades(this.id);
        }

        private List<FuncionalidadModel> quieroMisFuncionalidades(decimal p)
        {
            return new FuncionalidadDao().getFuncionalidades(p);
        }

        public override void mapeoFilaAModel(DataRow fila)
        {
            base.mapeoFilaAModel(fila);
            this.habilitado = (Boolean)fila[HABILITADO];
        }
    }
}
