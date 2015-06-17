using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace DAO
{
    class TranscaccionDao
    {

        public List<TransaccionModel> getTransaccionesPendientesByCliente(ClienteModel cliente) {

            List<TransaccionModel> transacciones = new List<TransaccionModel>();
/*
            PaisModel p1 = new PaisModel(1, "Argentina", "Argentino");
            CuentaTipoModel oro = new CuentaTipoModel(1, "oro", 10, 1000);
            CuentaTipoModel plata = new CuentaTipoModel(2, "plata", 10, 500);
            CuentaTipoModel bronce = new CuentaTipoModel(3, "bronce", 10, 200);
            EstadoModel e1 = new EstadoModel(1, "abierta");
            EstadoModel e2 = new EstadoModel(2, "cerrada");
            CuentaModel c1 = new CuentaModel(1, p1, oro, 1, "dolar", e1, new DateTime(2000, 1, 1), new DateTime(2005, 1, 1), cliente);
            CuentaModel c2 = new CuentaModel(2, p1, plata, 1, "dolar", e2, new DateTime(1999, 1, 1), new DateTime(2001, 1, 1), cliente);

            TransaccionTipoModel t1 = new TransaccionTipoModel(1,"transferencia a otra cuenta");
            TransaccionTipoModel t2 = new TransaccionTipoModel(2,"Suscripción a cuenta Oro");
            TransaccionTipoModel t3 = new TransaccionTipoModel(2,"Cambio de cuenta a Plata");

            transacciones.Add(new TransaccionModel(1,0,c1,t1,1000,DateTime.Today));
            transacciones.Add(new TransaccionModel(2, 0, c1, t2, 1555, DateTime.Today));
            transacciones.Add(new TransaccionModel(3, 0, c2, t3, 600, DateTime.Today));
            transacciones.Add(new TransaccionModel(4, 0, c2, t1, 700, DateTime.Today));
*/
            return transacciones;
        }

    }
}
