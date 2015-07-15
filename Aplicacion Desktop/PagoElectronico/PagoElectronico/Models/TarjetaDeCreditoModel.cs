using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using System.Data;

namespace Models
{
    public class TarjetaDeCreditoModel: BasicaModel

    {
        public const String NUMERO = "NUMERO";
        public const String CODIGO = "CODIGO";
        public const String EMISION = "EMISION";
        public const String VENCIMIENTO = "VENCIMIENTO";
        public const String HABILITADA = "HABILITADA";
        public const String EMISOR_ID = "EMISOR_ID";
        public const String EMISOR_NOMBRE = "EMISOR_NOMBRE";
        
        public String numero {get;set;}
        public String codigoSeguridad {get;set;}
        public DateTime emision {get;set;}
        public DateTime vencimiento { get; set; }
        public Boolean habilitada = true;
        public ClienteModel propietario { get; set; }
        public EmisorModel emisor { get; set; }


        public TarjetaDeCreditoModel() { }

        public TarjetaDeCreditoModel(DataRow fila) : base(fila) { }


        public TarjetaDeCreditoModel(String numero, String codigoSeguridad, EmisorModel emisor,
                                        DateTime emision, DateTime vencimiento)
        {
            this.id = id;
            this.numero = numero;
            this.codigoSeguridad = codigoSeguridad;
            this.emisor = emisor;
            this.emision = emision;
            this.vencimiento = vencimiento;
        }

        public TarjetaDeCreditoModel(Decimal id, String numero, String codigoSeguridad, EmisorModel emisor,
                                        DateTime emision, DateTime vencimiento) 
        {
            this.id = id;
            this.numero = numero;
            this.codigoSeguridad = codigoSeguridad;
            this.emisor = emisor;
            this.emision = emision;
            this.vencimiento = vencimiento;
        }

        public TarjetaDeCreditoModel(UInt32 id, String numero, String codigoSeguridad, 
                                        DateTime emision, DateTime vencimiento,
                                        EmisorModel emisor)
        {
            this.id = id;
            this.numero = numero;
            this.codigoSeguridad = codigoSeguridad;
            this.emision = emision;
            this.vencimiento = vencimiento;
            this.emisor = emisor;
        }


        public override void mapeoFilaAModel(System.Data.DataRow fila)
        {
            base.mapeoFilaAModel(fila);
            String cadenaNumero = this.mapearValor(fila[NUMERO]);
            int lcadenaNumero = cadenaNumero.Length-4;
            this.numero = "XXXX-XXXX-XXXX-" + cadenaNumero.Substring(lcadenaNumero, 4);
            this.codigoSeguridad = this.mapearValor(fila[CODIGO]);
            this.emision = this.mapearFecha(fila[EMISION]);
            this.vencimiento = this.mapearFecha(fila[VENCIMIENTO]);
            this.habilitada = this.mapearBool(fila[HABILITADA]);
            this.emisor = new EmisorModel((Decimal)fila[EMISOR_ID],fila[EMISOR_NOMBRE].ToString());
        }
    }
}
