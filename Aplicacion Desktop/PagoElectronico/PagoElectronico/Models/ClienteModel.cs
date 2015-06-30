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
        public const String NACIMIENTO = "FECHA_NACIMIENTO";
        public const String EMAIL = "EMAIL";
        public const String NACIONALIDAD = "NACIONALIDAD";
        public const String DIRECCION_CALLE = "DIRECCION_CALLE";
        public const String DIRECCION_NRO_CALLE = "DIRECCION_NRO";
        public const String DIRECCION_DEPTO = "DIRECCION_DEPTO";
        public const String DIRECCION_PISO = "DIRECCION_PISO";
        public const String LOCALIDAD = "LOCALIDAD";
        public const String PAIS = "PAIS";
        /********************/
        public String apellido { get; set; }
        public DateTime nacimiento { get; set; }
        public String email { get; set; }
        public String direccionCalle {get; set;}
        public Decimal direccionNumeroCalle { get; set; }
        public Decimal direccionPiso { get; set; }
        public String direccionDepto {get; set;}
        public Boolean habilitado = true;

        public PaisModel pais { get; set; }
        public LocalidadModel localidad { get; set; }
        public String nroDocumento { get; set; }
        public TipoDocumentoModel tipoDocumento { get; set; }
        public List<CuentaModel> cuentas = new List<CuentaModel>();
        public UserModel usuario;

        public ClienteModel()
        {
        }
        public ClienteModel(DataRow fila)
            : base(fila)
        {
            this.localidad = this.getLocalidad();
            this.cuentas = this.getListaDeCuentas();
        }

        private LocalidadModel getLocalidad()
        {
            return null;
        }

        private List<CuentaModel> getListaDeCuentas()
        {
            return new CuentaDao().getCuentasByCliente(this);
        }


        public ClienteModel(String apellido, String nombre, TipoDocumentoModel documento,
            DateTime nacimiento, String email, PaisModel nacionalidad, String direccionCalle, UInt32 direccionNumeroCalle,
            UInt32 direccionPiso, String direccionDepto, LocalidadModel localidad, PaisModel pais)
        {
            this.apellido = apellido;
            this.nombre = nombre;
            this.tipoDocumento = documento;
            this.nacimiento = nacimiento;
            this.email = email;
            //this.nacionalidad = nacionalidad;
            this.direccionCalle = direccionCalle;
            this.direccionNumeroCalle = direccionNumeroCalle;
            this.direccionPiso = direccionPiso;
            this.direccionDepto = direccionDepto;
            this.localidad = localidad;
            this.pais = pais;
        }

        public ClienteModel(UInt32 id, String apellido, String nombre, TipoDocumentoModel tipoDocumento,
            DateTime nacimiento, String email, PaisModel nacionalidad, String direccionCalle, UInt32 direccionNumeroCalle,
            UInt32 direccionPiso, String direccionDepto, LocalidadModel localidad, PaisModel pais)
        {
            this.id = id;
            this.apellido = apellido;
            this.nombre = nombre;
            this.tipoDocumento = tipoDocumento;
            this.nacimiento = nacimiento;
            this.email = email;
            //this.nacionalidad = nacionalidad;
            this.direccionCalle = direccionCalle;
            this.direccionNumeroCalle = direccionNumeroCalle;
            this.direccionPiso = direccionPiso;
            this.direccionDepto = direccionDepto;
            this.localidad = localidad;
            this.pais = pais;
        }

        public ClienteModel(UInt32 id, String apellido, String nombre)
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
            this.apellido = this.mapearValor(fila[APELLIDO]);
            this.nacimiento = this.mapearFecha(fila[NACIMIENTO]);
            this.email = this.mapearValor(fila[EMAIL]);
            this.direccionCalle = this.mapearValor(fila[DIRECCION_CALLE]);
            this.direccionNumeroCalle = this.mapearNum(fila[DIRECCION_NRO_CALLE]);
            this.direccionPiso = this.mapearNum(fila[DIRECCION_PISO]);
            this.direccionDepto = this.mapearValor(fila[DIRECCION_DEPTO]);
            this.localidad = new LocalidadDAO().dameTuModelo(this.mapearValor(fila[LOCALIDAD]));
            this.pais = new PaisDAO().dameTuModelo(this.mapearValor(fila[PAIS]));
            this.direccionCalle = this.mapearValor(fila[DIRECCION_CALLE]);
            this.tipoDocumento = new TipoDocumentoDAO().dameTuModelo(this.mapearValor(fila[DOCUMENTO]));
        }
    }
}

