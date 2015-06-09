using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class ClienteModel
    {

        public UInt32 id { get; set; }
        public String nombre { get; set; }
        public String apellido {get; set;}
        public UInt32 documentoTipo { get; set; }
        public UInt64 documentoNumero { get; set; }
        public UInt32 paisId { get; set; }
        public String direccionCalle {get; set;}
        public UInt32 direccionNumeroCalle { get; set; }
        public UInt32 direccionPiso { get; set; }
        public String direccionDepto {get; set;}
        public DateTime nacimiento {get; set;}
        public String email {get; set;}
        public UInt32 localidadId { get; set; }
        public UInt32 nacionalidadId { get; set; }
        public Boolean habilitado { get; set; }

        public List<CuentaModel> cuentas = new List<CuentaModel>();
        public UserModel usuario;

        public ClienteModel(String apellido, String nombre, UInt32 documentoTipo, UInt64 documentoNumero,
            DateTime nacimiento, String email, UInt32 nacionalidadId, String direccionCalle, UInt32 direccionNumeroCalle,
            UInt32 direccionPiso, String direccionDepto, UInt32 localidadId, UInt32 paisId)
        {
            this.apellido = apellido;
            this.nombre = nombre;
            this.documentoTipo = documentoTipo;
            this.documentoNumero = documentoNumero;
            this.nacimiento = nacimiento;
            this.email = email;
            this.nacionalidadId = nacionalidadId;
            this.direccionCalle = direccionCalle;
            this.direccionNumeroCalle = direccionNumeroCalle;
            this.direccionPiso = direccionPiso;
            this.direccionDepto = direccionDepto;
            this.localidadId = localidadId;
            this.paisId = paisId;
        }

        public ClienteModel(UInt32 id, String apellido, String nombre, UInt32 documentoTipo, UInt64 documentoNumero,
            DateTime nacimiento, String email, UInt32 nacionalidadId, String direccionCalle, UInt32 direccionNumeroCalle,
            UInt32 direccionPiso, String direccionDepto, UInt32 localidadId, UInt32 paisId)
        {
            this.id = id;
            this.apellido = apellido;
            this.nombre = nombre;
            this.documentoTipo = documentoTipo;
            this.documentoNumero = documentoNumero;
            this.nacimiento = nacimiento;
            this.email = email;
            this.nacionalidadId = nacionalidadId;
            this.direccionCalle = direccionCalle;
            this.direccionNumeroCalle = direccionNumeroCalle;
            this.direccionPiso = direccionPiso;
            this.direccionDepto = direccionDepto;
            this.localidadId = localidadId;
            this.paisId = paisId;
        }

        public ClienteModel(UInt32 id, String nombre, String apellido, UInt32 documentoTipo,
            UInt32 documentoNumero, UInt32 paisId, String direccionCalle, UInt32 direccionNumeroCalle,
            UInt32 direccionPiso, String direccionDepto, DateTime nacimiento, String email,
            UInt32 localidadId, UInt32 nacionalidadId, UserModel usuario)
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
            this.localidadId = localidadId;
            this.paisId = paisId;
            this.nacionalidadId = nacionalidadId;
            this.usuario = usuario;
            this.habilitado = true;
        }

        public ClienteModel(UInt32 id, String nombre, String apellido, UInt32 documentoTipo, UInt32 documentoNumero,
            UInt32 localidadId, UInt32 nacionalidadId, String email)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.documentoTipo = documentoTipo;
            this.documentoNumero = documentoNumero;
            this.email = email;
            this.localidadId = localidadId;
            this.nacionalidadId = nacionalidadId;
            this.habilitado = true;
        }

        public ClienteModel(UInt32 id, String nombre, String apellido, UInt32 documentoTipo, UInt32 documentoNumero,
            UInt32 localidadId, UInt32 nacionalidadId, String email, UserModel usuario)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.documentoTipo = documentoTipo;
            this.documentoNumero = documentoNumero;
            this.email = email;
            this.localidadId = localidadId;
            this.nacionalidadId = nacionalidadId;
            this.usuario = usuario;
            this.habilitado = true;
        }

        public ClienteModel(UInt32 id, String nombre, String apellido, UInt32 documentoTipo, UInt32 documentoNumero,
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

