﻿using System;
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
        public const String PROPIETARIO = "PROPIETARIO";
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
                                        EmisorModel emisor)
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

        public override void mapeoFilaAModel(System.Data.DataRow fila)
        {
            base.mapeoFilaAModel(fila);
            this.numero = this.mapearValor(fila[NUMERO]);
            this.codigoSeguridad = this.mapearValor(fila[CODIGO]);
            this.emision = this.mapearFecha(fila[EMISION]);
            this.vencimiento = this.mapearFecha(fila[VENCIMIENTO]);
            this.habilitada = this.mapearBool(fila[HABILITADA]);
            this.emisor = new EmisorModel((Decimal)fila[EMISOR_ID],fila[EMISOR_NOMBRE].ToString());
        }
    }
}
