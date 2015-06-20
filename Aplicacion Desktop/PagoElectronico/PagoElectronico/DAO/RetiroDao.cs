using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace DAO
{
    public class RetiroDao
    {
        public RetiroModel createRetiro(RetiroModel retiro) {

            retiro.chequeId = 1000;
            retiro.banco = new BancoModel(1,"Nación");
            retiro.id = 99;
            return retiro;
        }

        public List<RetiroModel> getRetirosByCuenta(CuentaModel cuenta, int limit)
        {

            List<RetiroModel> retiros = new List<RetiroModel>();

           /* PaisModel p1 = new PaisModel(1, "Argentina", "Argentino");
            CuentaTipoModel oro = new CuentaTipoModel(1, "oro", 10, 1000);
            EstadoModel e1 = new EstadoModel(1, "abierta");
            ClienteModel cliente = new ClienteModel(1, "Pepe", "Martinez");
            CuentaModel c1 = new CuentaModel(1, p1, oro, 1, "dolar", e1, new DateTime(2000, 1, 1), new DateTime(2005, 1, 1), cliente);
            TarjetaDeCreditoModel t1 = new TarjetaDeCreditoModel(1, "1234567812344450", "123", DateTime.Today, new DateTime(2020, 1, 1), cliente, Login.Login.userLogued);

            retiros.Add(new RetiroModel(1,c1,2000,1,"Dolar",DateTime.Today,1,new BancoModel(1,"Nacion")));
            retiros.Add(new RetiroModel(2, c1, 2345, 1, "Dolar", DateTime.Today, 1, new BancoModel(1, "Nacion")));
            retiros.Add(new RetiroModel(3, c1, 2345, 1, "Dolar", DateTime.Today, 1, new BancoModel(1, "Nacion")));
            retiros.Add(new RetiroModel(4, c1, 4321, 1, "Dolar", DateTime.Today, 1, new BancoModel(1, "Frances")));
            retiros.Add(new RetiroModel(5, c1, 5555, 1, "Dolar", DateTime.Today, 1, new BancoModel(1, "Nacion")));
            */
            return retiros;
        }
    }
}
