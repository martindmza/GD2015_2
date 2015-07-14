using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace DAO
{
    class TransaccionDao:BasicaDAO<TransaccionModel>
    {

        public List<TransaccionModel> getTransaccionesPendientesByCliente(ClienteModel cliente) {

            List<TransaccionModel> transacciones = new List<TransaccionModel>();
            return transacciones;
        }

        public TransaccionModel insertTransaccion(TransaccionModel transaccion, FacturaModel factura) { 

            transaccion.id = 99;
            return transaccion;
        }


        public override TransaccionModel getModeloBasico(System.Data.DataRow fila)
        {
            throw new NotImplementedException();
        }

        public override System.Data.SqlClient.SqlCommand addParametrosParaAgregar(System.Data.SqlClient.SqlCommand command, TransaccionModel entity)
        {
            throw new NotImplementedException();
        }

        public override System.Data.SqlClient.SqlCommand addParametrosParaModificar(System.Data.SqlClient.SqlCommand command, TransaccionModel entity)
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
            throw new NotImplementedException();
        }
    }
}
