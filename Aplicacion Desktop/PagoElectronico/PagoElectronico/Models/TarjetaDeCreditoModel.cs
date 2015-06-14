﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class TarjetaDeCreditoModel
    {
        public UInt32 id {get;set;}
        public String numero {get;set;}
        public String tipo {get;set;}
        public String codigoSeguridad {get;set;}
        public DateTime emision {get;set;}
        public DateTime vencimiento { get; set; }
        public Boolean habilitada = true;

        public ClienteModel propietario { get; set; }
        public UserModel emisor { get; set; }

        public TarjetaDeCreditoModel(UInt32 id,String numero, String tipo, String codigoSeguridad,
                                        DateTime emision, DateTime vencimiento) 
        {
            this.id = id;
            this.numero = numero;
            this.tipo = tipo;
            this.codigoSeguridad = codigoSeguridad;
            this.emision = emision;
            this.vencimiento = vencimiento;
        }

        public TarjetaDeCreditoModel(UInt32 id, String numero, String tipo, String codigoSeguridad,
                                        DateTime emision, DateTime vencimiento, ClienteModel propietario,
                                        UserModel emisor)
        {
            this.id = id;
            this.numero = numero;
            this.tipo = tipo;
            this.codigoSeguridad = codigoSeguridad;
            this.emision = emision;
            this.vencimiento = vencimiento;
        }

    }
}