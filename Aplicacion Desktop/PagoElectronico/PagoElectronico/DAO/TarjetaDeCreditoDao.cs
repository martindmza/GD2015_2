using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace DAO
{
    class TarjetaDeCreditoDao
    {
        public List<TarjetaDeCreditoModel> getTarjetasByCliente(ClienteModel cliente) {
            
            List<TarjetaDeCreditoModel> tarjetas = new List<TarjetaDeCreditoModel>();
            tarjetas.Add(new TarjetaDeCreditoModel(1,"1234567812344450","Oro","123",DateTime.Today,new DateTime(2020,1,1),cliente,Login.Login.userLogued));
            tarjetas.Add(new TarjetaDeCreditoModel(2, "1111567812344450", "Plata", "124", DateTime.Today, new DateTime(2025, 1, 1), cliente, Login.Login.userLogued));
            tarjetas.Add(new TarjetaDeCreditoModel(3, "1234333812344450", "Platinium", "323", DateTime.Today, new DateTime(2040, 1, 1), cliente, Login.Login.userLogued));

            return tarjetas;
        }
    }
}
