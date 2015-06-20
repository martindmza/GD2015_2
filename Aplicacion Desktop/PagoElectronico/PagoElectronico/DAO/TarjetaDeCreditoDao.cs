﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace DAO
{
    class TarjetaDeCreditoDao: BasicaDAO<TarjetaDeCreditoModel>
    {
        public List<TarjetaDeCreditoModel> getTarjetasByCliente(ClienteModel cliente) {

            
            List<TarjetaDeCreditoModel> tarjetas = new List<TarjetaDeCreditoModel>();
            tarjetas.Add(new TarjetaDeCreditoModel(1,"1234567812344450","123",DateTime.Today,new DateTime(2020,1,1),cliente,Logins.Login.userLogued));
            tarjetas.Add(new TarjetaDeCreditoModel(2, "1111567812344450", "124", DateTime.Today, new DateTime(2025, 1, 1), cliente, Logins.Login.userLogued));
            tarjetas.Add(new TarjetaDeCreditoModel(3, "1234333812344450", "323", DateTime.Today, new DateTime(2040, 1, 1), cliente, Logins.Login.userLogued));

            return tarjetas;
        }

        public List<TarjetaDeCreditoModel> getTarjetasByClienteAndNumero(ClienteModel cliente, String numero)
        {

            List<TarjetaDeCreditoModel> tarjetas = new List<TarjetaDeCreditoModel>();
            tarjetas.Add(new TarjetaDeCreditoModel(1, "1234567812344450", "123", DateTime.Today, new DateTime(2020, 1, 1), cliente, Logins.Login.userLogued));
            tarjetas.Add(new TarjetaDeCreditoModel(2, "1111567812344450", "124", DateTime.Today, new DateTime(2025, 1, 1), cliente, Logins.Login.userLogued));
            //tarjetas.Add(new TarjetaDeCreditoModel(3, "1234333812344450", "323", DateTime.Today, new DateTime(2040, 1, 1), cliente, Login.Login.userLogued));

            return tarjetas;
        }

        public TarjetaDeCreditoModel crearTarjeta(TarjetaDeCreditoModel tarjeta)
        {

            tarjeta.id = 99;
            return tarjeta;
        }

        public TarjetaDeCreditoModel modificarTarjeta(TarjetaDeCreditoModel tarjeta)
        {

            return tarjeta;
        }
        public TarjetaDeCreditoModel borrarTarjeta(TarjetaDeCreditoModel tarjeta)
        {
            tarjeta.habilitada = false;
            return tarjeta;
        }

        public override TarjetaDeCreditoModel getModeloBasico(System.Data.DataRow fila)
        {
            throw new NotImplementedException();
        }

        public override string getProcedureEncontrarPorId()
        {
            throw new NotImplementedException();
        }

        public override string getProcedureListar()
        {
            throw new NotImplementedException();
        }
    }
}
