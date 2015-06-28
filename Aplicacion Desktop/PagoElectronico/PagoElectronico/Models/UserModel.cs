using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Includes;
using DAO;
using System.Data;
using MyExceptions;

namespace Models
{
    public class UserModel: BasicaModel
    {


        public const String PASSWORD = "PASS";
        public const String INTENTOS_FALLIDOS = "INTENTOS_FALLIDOS";
        public const String FECHA_CREACION = "FECHA_CREACION";
        public const String FECHA_ULT_MODIFICACION = "FECHA_ULT_MODIFICACION";
        public const String PASSWORD_MODIFICADA = "PASS_MODIFICADA";
        public const String HABILITADO = "HABILITADA";
        public const String PREGUNTA = "PREGUNTA";
        public const String RESPUESTA = "RESPUESTA";
        

        public String password { get; set; }
        public Boolean password_modificada { get; set; }
        public String pregunta { get; set; }        
        public String respuesta { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_modificacion { get; set; }
        public Decimal intentosFallidos { get; set; }
        public Boolean habilitado = true;

        public List<RolModel> roles { get; set; }
       
        
        public List<CuentaModel> cuentas { get; set; }
        public ClienteModel cliente { get; set; }

        public UserModel(DataRow fila)
            : base(fila)

        {
            this.roles = this.getMisRoles();
            this.cliente = this.getMiCliente();
            this.cuentas = this.getMisCuentas();
            

        }

        public ClienteModel getMiCliente()
        {
            return new ClienteDao().getClienteByUser(this);
        }

        private List<CuentaModel> getMisCuentas()
        {
            return new CuentaDao().getCuentasByUsuario(this);
        }

        public UserModel() { incializar(); }

        public UserModel(String nombre, String password)
        {
            this.nombre = nombre;
            this.password = password;
            incializar();
        }

        public UserModel(Decimal id, String nombre, String password)
        {
            this.id = id;
            this.nombre = nombre;
            this.password = password;
            incializar();
        }
        
        public UserModel(Decimal id, String nombre, String password, Boolean habilitado, Decimal intentosFallidos)
        {
            this.id = id;
            this.nombre = nombre;
            this.password = password;
            this.habilitado = habilitado;
            this.intentosFallidos = intentosFallidos;
            incializar();
        }

        public UserModel(Decimal id, String nombre, String password, Boolean habilitado, Decimal intentosFallidos,ClienteModel cliente)
        {
            this.id = id;
            this.nombre = nombre;
            this.password = password;
            this.habilitado = habilitado;
            this.intentosFallidos = intentosFallidos;
            this.cliente = cliente;
            incializar();
        }

        private void incializar()
        {
            roles = new List<RolModel>();
            cuentas = new List<CuentaModel>();
        
        }

        //---------------------------------------------------------------------------------------------------------------
        public List<RolModel> getMisRoles()
        {
          return new RolDao().getRolesByUser(this.id);    
        }
        //---------------------------------------------------------------------------------------------------------------




        public override void mapeoFilaAModel(DataRow fila)
        {
            base.mapeoFilaAModel(fila);
            this.password = fila[PASSWORD].ToString();
            this.password_modificada = (Boolean)fila[PASSWORD_MODIFICADA];
            this.habilitado = (Boolean)fila[HABILITADO];
            this.intentosFallidos = (Decimal)fila[INTENTOS_FALLIDOS];
            this.pregunta = fila[PREGUNTA].ToString();
            this.respuesta = fila[RESPUESTA].ToString();
        }
    }
}
