using System;
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

        protected override string getProcedureListarByCliente()
        {
            return "Listar_Transferencia_ID_Cliente";
        }
    }
}
