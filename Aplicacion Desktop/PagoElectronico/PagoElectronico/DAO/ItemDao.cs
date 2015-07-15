using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    class ItemDao:BasicaDAO<ItemModel>
    {

        public List<ItemModel> getTransaccionesPendientesByCliente(ClienteModel cliente) {

            //Lleno el parametro cuentas que es una lista
            DataTable cuentasLista = new DataTable();
            cuentasLista.Columns.Add("Id_Fila", typeof(decimal));
            CuentaDao cuentaDao = new CuentaDao();
            List<CuentaModel> cuentas = new List<CuentaModel>();
            cuentas = cuentaDao.getListadoByCliente(cliente);
            foreach (CuentaModel f in cuentas)
            {
                cuentasLista.Rows.Add(f.id);
            }

            SqlCommand command = InitializeConnection("Listar_Items_Deuda");
            command.Parameters.Add("@Id_Cuentas", System.Data.SqlDbType.Structured).Value = cuentasLista;

            List<ItemModel> result = new List<ItemModel>();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                ItemModel model = new ItemModel(row);
                result.Add(model);
            }
            return result;
        }

        public ItemModel insertTransaccion(ItemModel transaccion, FacturaModel factura) { 

            transaccion.id = 99;
            return transaccion;
        }


        public override ItemModel getModeloBasico(System.Data.DataRow fila)
        {
            throw new NotImplementedException();
        }

        public override System.Data.SqlClient.SqlCommand addParametrosParaAgregar(System.Data.SqlClient.SqlCommand command, ItemModel entity)
        {
            throw new NotImplementedException();
        }

        public override System.Data.SqlClient.SqlCommand addParametrosParaModificar(System.Data.SqlClient.SqlCommand command, ItemModel entity)
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
