using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class TarjetaDeCreditoModel: BasicaModel
    {
        public String numero {get;set;}
        public String codigoSeguridad {get;set;}
        public DateTime emision {get;set;}
        public DateTime vencimiento { get; set; }
        public Boolean habilitada = true;

        public ClienteModel propietario { get; set; }
        public UserModel emisor { get; set; }
        public TarjetaDeCreditoModel() { }

        public TarjetaDeCreditoModel(String numero, String codigoSeguridad,
                                        DateTime emision, DateTime vencimiento, ClienteModel propietario)
        {
            this.id = id;
            this.numero = numero;
            this.codigoSeguridad = codigoSeguridad;
            this.emision = emision;
            this.vencimiento = vencimiento;
            this.propietario = propietario;
        }

        public TarjetaDeCreditoModel(Decimal id,String numero, String codigoSeguridad,
                                        DateTime emision, DateTime vencimiento, ClienteModel propietario) 
        {
            this.id = id;
            this.numero = numero;
            this.codigoSeguridad = codigoSeguridad;
            this.emision = emision;
            this.vencimiento = vencimiento;
            this.propietario = propietario;
        }

        public TarjetaDeCreditoModel(UInt32 id, String numero, String codigoSeguridad,
                                        DateTime emision, DateTime vencimiento, ClienteModel propietario,
                                        UserModel emisor)
        {
            this.id = id;
            this.numero = numero;
            this.codigoSeguridad = codigoSeguridad;
            this.emision = emision;
            this.vencimiento = vencimiento;
            this.propietario = propietario;
            this.emisor = emisor;
        }


        public String ToString() {

            try
            {
                return "{ " + id.ToString() + "," + numero + "," + codigoSeguridad.ToString() + "," +
                        emision.ToShortDateString() + "," + vencimiento.ToShortDateString() + "," +
                        propietario.ToString() + "," + emisor.nombre + " }";
            }
            catch (Exception err) {
                return "Complete todos lo parametros";
            }

        }

    }
}
