using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class ClienteModel
    {

        public Decimal id { get; set; }
        public String nombre { get; set; }
        public String apellido {get; set;}
        public Decimal documentoTipo { get; set; }
        public Decimal documentoNumero {get; set;}
        public Decimal paisId {get; set;}
        public String direccionCalle {get; set;}
        public Decimal direccionNumeroCalle {get; set;}
        public Decimal direccionPiso {get; set;}
        public String direccionDepto {get; set;}
        public DateTime nacimiento {get; set;}
        public String email {get; set;}
        public String telefono { get; set; }
        public Decimal localidadId { get; set; }
        public Decimal nacionalidadId { get; set; }
        public Boolean habilitado { get; set; }

        public List<CuentaModel> cuentas = new List<CuentaModel>();
        public UserModel usuario;

        public ClienteModel(Decimal id, String nombre, String apellido, Decimal documentoTipo,
            Decimal documentoNumero, Decimal paisId, String direccionCalle, Decimal direccionNumeroCalle,
            Decimal direccionPiso, String direccionDepto, DateTime nacimiento, String email, String telefono,
            Decimal localidadId, Decimal nacionalidadId, UserModel usuario)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.documentoTipo = documentoTipo;
            this.documentoNumero = documentoNumero;
            this.direccionCalle = direccionCalle;
            this.direccionNumeroCalle = direccionNumeroCalle;
            this.direccionPiso = direccionPiso;
            this.direccionDepto = direccionDepto;
            this.nacimiento = nacimiento;
            this.email = email;
            this.telefono = telefono;
            this.localidadId = localidadId;
            this.paisId = paisId;
            this.nacionalidadId = nacionalidadId;
            this.usuario = usuario;
            this.habilitado = true;
        }

        public ClienteModel(Decimal id, String nombre, String apellido, Decimal documentoTipo, Decimal documentoNumero,
            Decimal localidadId, Decimal nacionalidadId, String email, String telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.documentoTipo = documentoTipo;
            this.documentoNumero = documentoNumero;
            this.email = email;
            this.telefono = telefono;
            this.localidadId = localidadId;
            this.nacionalidadId = nacionalidadId;
            this.habilitado = true;
        }

        public ClienteModel(Decimal id, String nombre, String apellido, Decimal documentoTipo, Decimal documentoNumero,
            Decimal localidadId, Decimal nacionalidadId, String email, String telefono, UserModel usuario)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.documentoTipo = documentoTipo;
            this.documentoNumero = documentoNumero;
            this.email = email;
            this.telefono = telefono;
            this.localidadId = localidadId;
            this.nacionalidadId = nacionalidadId;
            this.usuario = usuario;
            this.habilitado = true;
        }

        public ClienteModel(Decimal id, String nombre, String apellido, Decimal documentoTipo, Decimal documentoNumero,
            String email)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.documentoTipo = documentoTipo;
            this.documentoNumero = documentoNumero;
            this.email = email;
            this.habilitado = true;
        }

        
        public String ToString() { 
            return "{ " + id + "; " + apellido + "; " + nombre + "; " + documentoNumero + "; " + email + " }";
        }

    }
}

