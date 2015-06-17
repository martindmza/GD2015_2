using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace DAO
{
    public class DepositoDao
    {
        public DepositoModel createDeposito(DepositoModel deposito){
            
            deposito.id = 99;
            return deposito;
        }

        public List<DepositoModel> getDepositosByCuenta(CuentaModel cuenta, int limit)
        {
            List<DepositoModel> depositos = new List<DepositoModel>();

            TarjetaDeCreditoModel t1 = new TarjetaDeCreditoModel(1,"1234567812344450","123",DateTime.Today,new DateTime(2020,1,1),cuenta.propietario,Login.Login.userLogued);

            depositos.Add(new DepositoModel(1,Login.Login.userLogued.cliente,cuenta,20000,1,"dolares",t1,DateTime.Today));
            depositos.Add(new DepositoModel(2, Login.Login.userLogued.cliente, cuenta, 25000, 1, "dolares", t1, DateTime.Today));
            depositos.Add(new DepositoModel(3, Login.Login.userLogued.cliente, cuenta, 256, 1, "dolares", t1, DateTime.Today));
            depositos.Add(new DepositoModel(4, Login.Login.userLogued.cliente, cuenta, 123, 1, "dolares", t1, DateTime.Today));
            depositos.Add(new DepositoModel(5, Login.Login.userLogued.cliente, cuenta, 20000, 1, "dolares", t1, DateTime.Today));
            
            return depositos;
        }
    }
}
