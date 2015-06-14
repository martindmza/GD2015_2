using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class ClienteModel
    {

        public UInt32 id { get; set; }
        public String apellido { get; set; }
        public String nombre { get; set; }
        public DateTime nacimiento { get; set; }
        public String email { get; set; }
        public String direccionCalle {get; set;}
        public UInt32 direccionNumeroCalle { get; set; }
        public UInt32 direccionPiso { get; set; }
        public String direccionDepto {get; set;}
        public Boolean habilitado = true;

        public PaisModel pais { get; set; }
        public PaisModel nacionalidad { get; set; }
        public LocalidadModel localidad { get; set; }
        public DocumentoModel documento { get; set; }
        public List<CuentaModel> cuentas = new List<CuentaModel>();
        public UserModel usuario;

        public ClienteModel(String apellido, String nombre, DocumentoModel documento,
            DateTime nacimiento, String email, PaisModel nacionalidad, String direccionCalle, UInt32 direccionNumeroCalle,
            UInt32 direccionPiso, String direccionDepto, LocalidadModel localidad, PaisModel pais)
        {
            this.apellido = apellido;
            this.nombre = nombre;
            this.documento = documento;
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

        public ClienteModel(UInt32 id, String apellido, String nombre, DocumentoModel documento,
            DateTime nacimiento, String email, PaisModel nacionalidad, String direccionCalle, UInt32 direccionNumeroCalle,
            UInt32 direccionPiso, String direccionDepto, LocalidadModel localidad, PaisModel pais)
        {
            this.id = id;
            this.apellido = apellido;
            this.nombre = nombre;
            this.documento = documento;
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
                            documento.ToString() + "; " +
                            nacimiento.ToString() + "; " +
                            email + "; " +
                            nacionalidad.ToString() + "; " +
                            direccionCalle + "; " +
                            direccionNumeroCalle + "; " +
                            direccionPiso + "; " +
                            direccionDepto + "; " +
                            localidad.ToString() + "; " +
                            pais.ToString() + " }";
        }

    }
}

