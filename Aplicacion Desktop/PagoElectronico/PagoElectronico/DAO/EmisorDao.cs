using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class EmisorDao : BasicaDAO<EmisorModel>
    {

        public override string getProcedureEncontrarPorId()
        {
            return "Buscar_Emisor_Id";
        }

        public override string getProcedureListar()
        {
            return "Listar_Emisores";
        }

        public override EmisorModel getModeloBasico(DataRow fila)
        {
            return new EmisorModel(fila);
        }

        protected override string getProcedureCrearBasica()
        {
            throw new NotImplementedException();
        }

        public override SqlCommand addParametrosParaAgregar(SqlCommand command, EmisorModel entity)
        {
            throw new NotImplementedException();
        }

        public override SqlCommand addParametrosParaModificar(SqlCommand command, EmisorModel entity)
        {
            throw new NotImplementedException();
        }

        protected override string getProcedureModificarBasica()
        {
            throw new NotImplementedException();
        }
    }
}
