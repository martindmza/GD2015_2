using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class DocumentoModel
    {
        public UInt32 tipo;
        public String nombre;
        public UInt64 numero = 0;

        public DocumentoModel(UInt32 tipo, String nombre) {
            this.tipo = tipo;
            this.nombre = nombre;
        }

        public DocumentoModel(UInt32 tipo, String nombre, UInt64 numero)
        {
            this.tipo = tipo;
            this.nombre = nombre;
            this.numero = numero;
        }

        public String ToString()
        {
            return "{ " + tipo.ToString() + "; " + nombre + "; " + numero.ToString() + " }";
        }
    }
}
