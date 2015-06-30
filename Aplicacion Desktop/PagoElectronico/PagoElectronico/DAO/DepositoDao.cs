using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class DepositoDao : BasicaDAO<DepositoModel>
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
            DataTable dataCuentas = this.getDepositosDeBasePorIdCuenta(cuenta.id);
            foreach (DataRow cuentaBase in dataCuentas.Rows)
            {
                DepositoModel depositoModel = new DepositoModel(cuentaBase);
                depositos.Add(depositoModel);
            }
            return depositos;
        }

        private DataTable getDepositosDeBasePorIdCuenta(decimal p)
        {
            DataTable dt = new DataTable();
            using (SqlCommand command = InitializeConnection("Buscar_Deposito_ID_Cuenta"))
            {
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
            if (dt.Rows.Count > 0)
                return dt;
            return null;
        }


        public override DepositoModel getModeloBasico(DataRow fila)
        {
            return new DepositoModel(fila);
        }

        public override SqlCommand addParametrosParaAgregar(SqlCommand command, DepositoModel entity)
        {
            command.Parameters.Add("@Cuenta", System.Data.SqlDbType.Decimal).Value = entity.cuentaDestino.id;
            command.Parameters.Add("@Importe", System.Data.SqlDbType.Decimal).Value = entity.importe;
            command.Parameters.Add("@Moneda", System.Data.SqlDbType.Decimal).Value = entity.monedaId;
            command.Parameters.Add("@Nro_Tarjeta", System.Data.SqlDbType.Decimal).Value = entity.tarjetaDeCredito.id;
            command.Parameters.Add("@Fecha", System.Data.SqlDbType.DateTime).Value = entity.fecha;
            return command;
        }

        public override SqlCommand addParametrosParaModificar(SqlCommand command, DepositoModel entity)
        {
            throw new NotImplementedException();
        }

        protected override string getProcedureCrearBasica()
        {
            return DEPOSITAR;
        }

        protected override string getProcedureModificarBasica()
        {
            return "Modificar_Deposito";
        }

        public override string getProcedureEncontrarPorId()
        {
            return "Buscar_Deposito_ID";
        }

        public override string getProcedureListar()
        {
            return "Listar_Deposito";
        }
    }
}
