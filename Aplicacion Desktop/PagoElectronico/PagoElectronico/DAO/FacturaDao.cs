using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace DAO
{
    public class FacturaDao
    {
        public FacturaModel crearFactura(FacturaModel factura){
            factura.id = 9999;
            return factura;  
        }
    }
}
