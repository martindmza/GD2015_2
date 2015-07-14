using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace DAO
{
    public class BancoDAO: BasicaDAO<BancoModel>
    {
        public override BancoModel getModeloBasico(System.Data.DataRow fila)
        {
            return new BancoModel(fila);
        }

        public override System.Data.SqlClient.SqlCommand addParametrosParaAgregar(System.Data.SqlClient.SqlCommand command, BancoModel entity)
        {
            throw new NotImplementedException();
        }

        public override System.Data.SqlClient.SqlCommand addParametrosParaModificar(System.Data.SqlClient.SqlCommand command, BancoModel entity)
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
            return "Buscar_Banco_ID";
        }

        public override string getProcedureListar()
        {
            return "Listar_Banco";
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
