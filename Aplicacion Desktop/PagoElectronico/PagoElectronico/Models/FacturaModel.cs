﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Models
{
    public class FacturaModel: BasicaModel
    {
        public static String FECHA = "FECHA";
        public DateTime fecha;
        public List<ItemModel> items;
        public ClienteModel cliente;


        public FacturaModel() { }

        public FacturaModel(DataRow fila):base(fila) {
            items = this.obtenerMisTransacciones();
        }

        private List<ItemModel> obtenerMisTransacciones()
        {
            return new List<ItemModel>();
        }

        public FacturaModel(Decimal id)
            : base(id)
        { 
        }

        public FacturaModel( DateTime fecha, List<ItemModel> transacciones)
        {
            this.fecha = fecha;
            this.items = transacciones;
        }

        public FacturaModel(Decimal id,DateTime fecha, List<ItemModel> transacciones)
        {
            this.id = id;
            this.fecha = fecha;
            this.items = transacciones;
        }

        public override void mapeoFilaAModel(DataRow fila)
        {
            base.mapeoFilaAModel(fila);
            this.fecha = this.mapearFecha(fila[FECHA]);
        }
    }
}
