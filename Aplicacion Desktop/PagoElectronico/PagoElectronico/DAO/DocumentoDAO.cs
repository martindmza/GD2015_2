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
    }
}
