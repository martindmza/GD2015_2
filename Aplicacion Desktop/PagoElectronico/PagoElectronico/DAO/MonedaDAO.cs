using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class MonedaDAO : BasicaDAO<MonedaModel>
    {
        public override MonedaModel getModeloBasico(DataRow fila)
        {
            return new MonedaModel(fila);
        }

        protected override string getProcedureCrearBasica()
        {
            return "CrearMoneda";
        }

        public override string getProcedureEncontrarPorId()
        {
            return "Buscar_Moneda_ID";
        }

        public override string getProcedureListar()
        {
            return "Listar_Moneda";
        }

        public override SqlCommand addParametrosParaAgregar(SqlCommand command, MonedaModel entity)
        {
            throw new NotImplementedException();
        }

        public override SqlCommand addParametrosParaModificar(SqlCommand command, MonedaModel entity)
        {
            throw new NotImplementedException();
        }

        protected override string getProcedureModificarBasica()
        {
            throw new NotImplementedException();
        }

        protected override SqlCommand addParametrosParaBaja(SqlCommand command, object entity)
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
