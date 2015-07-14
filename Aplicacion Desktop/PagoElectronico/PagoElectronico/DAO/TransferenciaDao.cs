﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class TransferenciaDao: BasicaDAO<TransferenciaModel>
    {
        private const String TRANSFERIR = "TransferenciaEntreCuentas";

        public Respuesta createTransferencia(TransferenciaModel transferencia){

            try
            {
                SqlCommand command = InitializeConnection(TRANSFERIR);

                command.Parameters.Add("@Cuenta_Origen", System.Data.SqlDbType.Decimal).Value = transferencia.cuentaOrigen.id;
                command.Parameters.Add("@Cuenta_Destino", System.Data.SqlDbType.Decimal).Value = transferencia.cuentaDestino.id;
                command.Parameters.Add("@Importe", System.Data.SqlDbType.Decimal).Value = transferencia.importe;
                command.Parameters.Add("@Fecha", System.Data.SqlDbType.DateTime).Value = transferencia.fecha;

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

                return new Respuesta(value, mensaje);
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }

        }

        public List<TransferenciaModel> getTransferenciasByCuenta(CuentaModel cuenta,int limit)
        {

            List<TransferenciaModel> transf = new List<TransferenciaModel>();

        /*    PaisModel p1 = new PaisModel(1, "Argentina", "Argentino");
            CuentaTipoModel oro = new CuentaTipoModel(1, "oro", 10, 1000);
            EstadoModel e1 = new EstadoModel(1, "abierta");
            ClienteModel cliente = new ClienteModel(1, "Pepe", "Martinez");
            ClienteModel cliente2 = new ClienteModel(1, "Rolando", "Juan");
            CuentaModel c1 = new CuentaModel(1, p1, oro, 1, "dolar", e1, new DateTime(2000, 1, 1), new DateTime(2005, 1, 1), cliente);
            CuentaModel c2 = new CuentaModel(2, p1, oro, 1, "dolar", e1, new DateTime(2000, 1, 1), new DateTime(2005, 1, 1), cliente2);
            TarjetaDeCreditoModel t1 = new TarjetaDeCreditoModel(1, "1234567812344450", "123", DateTime.Today, new DateTime(2020, 1, 1), cliente, Login.Login.userLogued);

            transf.Add(new TransferenciaModel(1, c1, c2, 20000, 1, "dolar", 123));
            transf.Add(new TransferenciaModel(2, c1, c2, 20000, 1, "dolar", 123));
            transf.Add(new TransferenciaModel(3, c1, c2, 20000, 1, "dolar", 123));
            transf.Add(new TransferenciaModel(4, c1, c2, 20000, 1, "dolar", 123));
            transf.Add(new TransferenciaModel(5, c1, c2, 20000, 1, "dolar", 123));
            transf.Add(new TransferenciaModel(6, c1, c2, 657, 1, "dolar", 123));
            transf.Add(new TransferenciaModel(7, c1, c2, 5465, 1, "dolar", 123));
            transf.Add(new TransferenciaModel(8, c1, c2, 342, 1, "dolar", 123));
            transf.Add(new TransferenciaModel(9, c1, c2, 7545, 1, "dolar", 123));
            transf.Add(new TransferenciaModel(10, c1, c2, 20000, 1, "dolar", 123));
          */  
            return transf;
        }

        public override TransferenciaModel getModeloBasico(System.Data.DataRow fila)
        {
            throw new NotImplementedException();
        }

        public override System.Data.SqlClient.SqlCommand addParametrosParaAgregar(System.Data.SqlClient.SqlCommand command, TransferenciaModel entity)
        {
            throw new NotImplementedException();
        }

        public override System.Data.SqlClient.SqlCommand addParametrosParaModificar(System.Data.SqlClient.SqlCommand command, TransferenciaModel entity)
        {
            throw new NotImplementedException();
        }

        protected override string getProcedureCrearBasica()
        {
            throw new NotImplementedException();
        }

        protected override string getProcedureModificarBasica()
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

        protected override System.Data.SqlClient.SqlCommand addParametrosParaBaja(System.Data.SqlClient.SqlCommand command, object entity)
        {
            throw new NotImplementedException();
        }

        protected override string getProcedureBajaBasica()
        {
            throw new NotImplementedException();
        }
    }
}
