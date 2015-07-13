using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class RetiroDao:BasicaDAO<RetiroModel>
    {

        private const String RETIRAR = "RetiroEfectivo";


        public Respuesta createRetiro(RetiroModel retiro,TipoDocumentoModel docTipo,Decimal docNum)
        {
            try
            {
                SqlCommand command = InitializeConnection(RETIRAR);

                command.Parameters.Add("@Id_Cuenta", System.Data.SqlDbType.Decimal).Value = retiro.cuenta.id;
                command.Parameters.Add("@Id_Tipo_Documento", System.Data.SqlDbType.Decimal).Value = docTipo.id;
                command.Parameters.Add("@Nro_Documento", System.Data.SqlDbType.Decimal).Value = docNum;
                command.Parameters.Add("@Importe", System.Data.SqlDbType.Decimal).Value = retiro.importe;
                command.Parameters.Add("@Id_Moneda", System.Data.SqlDbType.Decimal).Value = retiro.moneda.id;
                command.Parameters.Add("@Fecha", System.Data.SqlDbType.DateTime).Value = retiro.fecha;
                command.Parameters.Add("@Id_Banco", System.Data.SqlDbType.Decimal).Value = retiro.banco.id;

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

        public override RetiroModel getModeloBasico(System.Data.DataRow fila)
        {
            return new RetiroModel(fila);
        }

        public override System.Data.SqlClient.SqlCommand addParametrosParaAgregar(System.Data.SqlClient.SqlCommand command, RetiroModel entity)
        {
            throw new NotImplementedException();
        }

        public override System.Data.SqlClient.SqlCommand addParametrosParaModificar(System.Data.SqlClient.SqlCommand command, RetiroModel entity)
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
