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

        public RolModel(Decimal id, String nombre, Boolean habilitado) {
            this.id = id;
            this.nombre = nombre;
            this.habilitado = habilitado;
            funcionalidades = new List<FuncionalidadModel>();
        }

        public RolModel(Decimal id, String nombre, Boolean habilitado, List<FuncionalidadModel> funcionalidades) {
            this.id = id;
            this.nombre = nombre;
            this.habilitado = habilitado;
            this.funcionalidades = funcionalidades;
        }
        
        public override void mapeoFilaAModel(DataRow fila)
        {
            base.mapeoFilaAModel(fila);
            Console.WriteLine("Fila de Rol Leida");

            this.habilitado = (Boolean)fila[HABILITADO];
        }
    }
}
