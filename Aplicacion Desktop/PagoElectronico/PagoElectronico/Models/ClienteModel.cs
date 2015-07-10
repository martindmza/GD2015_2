using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAO;

namespace Models
{
    public class ClienteModel: BasicaModel
    {
        public const String APELLIDO = "APELLIDO";
        public const String DOCUMENTO = "DOCUMENTO";
        public const String NRO_DOCUMENTO = "NRO_DOCUMENTO";
        public const String FECHA_NACIMIENTO = "FECHA_NACIMIENTO";
        public const String EMAIL = "EMAIL";
        public const String NACIONALIDAD = "NACIONALIDAD";
        public const String DIRECCION_CALLE = "DIRECCION_CALLE";
        public const String DIRECCION_NRO_CALLE = "DIRECCION_NRO";
        public const String DIRECCION_DEPTO = "DIRECCION_DEPTO";
        public const String DIRECCION_PISO = "DIRECCION_PISO";
        public const String LOCALIDAD = "LOCALIDAD";
        public const String PAIS = "PAIS";
        public const String NACIONALIDAD_ID = "NACIONALIDAD_ID";
        public const String HABILITADA = "HABILITADA";

        /********************/
        public String apellido { get; set; }
        public DateTime nacimiento { get; set; }
        public String email { get; set; }
        public PaisModel nacionalidad { get; set; }
        public String direccionCalle {get; set;}
        public Decimal direccionNumeroCalle { get; set; }
        public Decimal direccionPiso { get; set; }
        public String direccionDepto {get; set;}
        public Boolean habilitado = true;

        public PaisModel pais { get; set; }
        public String localidad { get; set; }
        public Decimal nroDocumento { get; set; }
        public TipoDocumentoModel tipoDocumento { get; set; }
        public List<CuentaModel> cuentas = new List<CuentaModel>();
        public List<TarjetaDeCreditoModel> tarjetas = new List<TarjetaDeCreditoModel>();
        public UserModel usuario;

        public ClienteModel()
        {
        }
        public ClienteModel(DataRow fila)
            : base(fila)
        {
            //this.cuentas = this.getListaDeCuentas();
        }


        private List<CuentaModel> getListaDeCuentas()
        {
            return new CuentaDao().getCuentasByCliente(this);
        }

        public ClienteModel(String apellido, String nombre, TipoDocumentoModel tipoDocumento, Decimal nroDocumento,
            DateTime nacimiento, String email, PaisModel nacionalidad, String direccionCalle, Decimal direccionNumeroCalle,
            Decimal direccionPiso, String direccionDepto, String localidad, PaisModel pais)
        {
            this.apellido = apellido;
            this.nombre = nombre;
            this.tipoDocumento = tipoDocumento;
            this.nroDocumento = nroDocumento;
            this.nacimiento = nacimiento;
            this.email = email;
            this.nacionalidad = nacionalidad;
            this.direccionCalle = direccionCalle;
            this.direccionNumeroCalle = direccionNumeroCalle;
            this.direccionPiso = direccionPiso;
            this.direccionDepto = direccionDepto;
            this.localidad = localidad;
            this.pais = pais;
        }

        public ClienteModel(Decimal id, String apellido, String nombre, TipoDocumentoModel tipoDocumento, Decimal nroDocumento,
            DateTime nacimiento, String email, PaisModel nacionalidad, String direccionCalle, Decimal direccionNumeroCalle,
            Decimal direccionPiso, String direccionDepto, String localidad, PaisModel pais)
        {
            this.id = id;
            this.apellido = apellido;
            this.nombre = nombre;
            this.tipoDocumento = tipoDocumento;
            this.nroDocumento = nroDocumento;
            this.nacimiento = nacimiento;
            this.email = email;
            this.nacionalidad = nacionalidad;
            this.direccionCalle = direccionCalle;
            this.direccionNumeroCalle = direccionNumeroCalle;
            this.direccionPiso = direccionPiso;
            this.direccionDepto = direccionDepto;
            this.localidad = localidad;
            this.pais = pais;
        }

        public ClienteModel(Decimal id, String apellido, String nombre)
        {
            this.id = id;
            this.apellido = apellido;
            this.nombre = nombre;
        }

        public String ToString() {
            return "{ " + id + "; " +
                            apellido + "; " +
                            nombre + "; " +
                            tipoDocumento.nombre + "; " +
                            nroDocumento.ToString() + "; " +
                            nacimiento.ToString() + "; " +
                            email + "; " +
                            pais.nacionalidad.ToString() + "; " +
                            direccionCalle + "; " +
                            direccionNumeroCalle + "; " +
                            direccionPiso + "; " +
                            direccionDepto + "; " +
                            localidad.ToString() + "; " +
                            pais.ToString() + " }";
        }


        public override void mapeoFilaAModel(System.Data.DataRow fila)
        {
            base.mapeoFilaAModel(fila);
            this.apellido = fila[APELLIDO].ToString();
            this.nacimiento = fila[FECHA_NACIMIENTO] != DBNull.Value ? DateTime.Parse(fila[FECHA_NACIMIENTO].ToString()) : DateTime.MinValue;
            this.email = fila[EMAIL].ToString();
            this.nacionalidad = new PaisDAO().dameTuModelo(fila[NACIONALIDAD].ToString());
            this.direccionCalle = fila[DIRECCION_CALLE].ToString();
            this.direccionNumeroCalle = (Decimal)fila[DIRECCION_NRO_CALLE];
            this.direccionPiso = (Decimal)fila[DIRECCION_PISO];
            this.direccionDepto = fila[DIRECCION_DEPTO].ToString();
            this.localidad = fila[LOCALIDAD].ToString();
            this.pais = new PaisDAO().dameTuModelo(fila[PAIS].ToString());
            this.direccionCalle = fila[DIRECCION_CALLE].ToString();
            this.nroDocumento = (Decimal)fila[NRO_DOCUMENTO];
            this.tipoDocumento = new TipoDocumentoDAO().dameTuModelo(fila[DOCUMENTO].ToString());
            this.habilitado = (Boolean) fila[HABILITADA];

        }
    }
}

