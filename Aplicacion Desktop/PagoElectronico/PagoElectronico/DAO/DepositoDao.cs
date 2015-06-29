using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class DepositoDao : AbstractDAO
    {
        private const String DEPOSITAR = "Depositar";


        public DepositoModel createDeposito(DepositoModel deposito){

            try
            {
                SqlCommand command = InitializeConnection(DEPOSITAR);

                command.Parameters.Add("@Cuenta", System.Data.SqlDbType.Decimal).Value = deposito.cuentaDestino.id;
                command.Parameters.Add("@Importe", System.Data.SqlDbType.Decimal).Value = deposito.importe;
                command.Parameters.Add("@Moneda", System.Data.SqlDbType.Decimal).Value = deposito.monedaId;
                command.Parameters.Add("@Nro_Tarjeta", System.Data.SqlDbType.Decimal).Value = deposito.tarjetaDeCredito.id;
                command.Parameters.Add("@Fecha", System.Data.SqlDbType.DateTime).Value = deposito.fecha;

                DataTable dt = new DataTable();
                //
                var pOut = command.Parameters.Add("Respuesta", SqlDbType.Decimal);
                var pOut2 = command.Parameters.Add("RespuestaMensaje", SqlDbType.NVarChar, 255);
                pOut.Direction = ParameterDirection.Output;
                pOut2.Direction = ParameterDirection.Output;
                //

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                Decimal value = Convert.IsDBNull(pOut.Value) ? 0 : (Decimal)(pOut.Value);
                String mensaje = Convert.IsDBNull(pOut2.Value) ? null : (string)pOut2.Value;

                return null;
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        public List<DepositoModel> getDepositosByCuenta(CuentaModel cuenta, int limit)
        {
            List<DepositoModel> depositos = new List<DepositoModel>();

            TarjetaDeCreditoModel t1 = new TarjetaDeCreditoModel(1,"1234567812344450","123",DateTime.Today,new DateTime(2020,1,1),cuenta.propietario,Logins.Login.userLogued);
/*
            depositos.Add(new DepositoModel(1,Logins.Login.userLogued.cliente,cuenta,20000,1,"dolares",t1,DateTime.Today));
            depositos.Add(new DepositoModel(2, Logins.Login.userLogued.cliente, cuenta, 25000, 1, "dolares", t1, DateTime.Today));
            depositos.Add(new DepositoModel(3, Logins.Login.userLogued.cliente, cuenta, 256, 1, "dolares", t1, DateTime.Today));
            depositos.Add(new DepositoModel(4, Logins.Login.userLogued.cliente, cuenta, 123, 1, "dolares", t1, DateTime.Today));
            depositos.Add(new DepositoModel(5, Logins.Login.userLogued.cliente, cuenta, 20000, 1, "dolares", t1, DateTime.Today));
  */          
            return depositos;
        }
    }
}
