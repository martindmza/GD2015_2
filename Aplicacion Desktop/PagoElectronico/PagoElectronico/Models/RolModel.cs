using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAO;

namespace Models
{
    public class RolModel : AbstractModel{

        public Decimal id { get; set; }
        public String nombre { get; set; }
        public Boolean habilitado { get; set; }
        public List<FuncionalidadModel> funcionalidades { get; set; }

        public const String ID_ROL = "ID";
        public const String NOMBRE = "NOMBRE";
        

         public RolModel(String nombre)
        {
            this.nombre = nombre;
            funcionalidades = new List<FuncionalidadModel>();
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
            this.id = (Decimal)fila[ID_ROL];
            this.nombre = fila[NOMBRE].ToString();
        }
    }
}
