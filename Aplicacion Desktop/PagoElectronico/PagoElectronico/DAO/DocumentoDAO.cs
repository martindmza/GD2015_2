using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Models;
using System.Data;

namespace DAO
{
    public class TipoDocumentoDAO:BasicaDAO<TipoDocumentoModel>

    {
        public override TipoDocumentoModel getModeloBasico(DataRow fila)
        {
            return new TipoDocumentoModel(fila);
        }

        public override string getProcedureEncontrarPorId()
        {
            return "Buscar_Documento_ID";            
        }

        public override string getProcedureListar()
        {
            return "Listar_Documento";
        }

        protected override string getProcedureCrearBasica()
        {
            throw new NotImplementedException();
        }

        public override System.Data.SqlClient.SqlCommand addParametrosParaAgregar(System.Data.SqlClient.SqlCommand command, TipoDocumentoModel entity)
        {
            throw new NotImplementedException();
        }

        public override System.Data.SqlClient.SqlCommand addParametrosParaModificar(System.Data.SqlClient.SqlCommand command, TipoDocumentoModel entity)
        {
            throw new NotImplementedException();
        }

        protected override string getProcedureModificarBasica()
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
