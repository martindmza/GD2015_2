using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Models;
using System.Data;

namespace DAO
{
    public class DocumentoDAO:BasicaDAO<DocumentoModel>

    {
        public override DocumentoModel getModeloBasico(DataRow fila)
        {
            return new DocumentoModel(fila);
        }

        public override string getProcedureEncontrarPorId()
        {
            return "Buscar_Documento_ID";            
        }

        public override string getProcedureListar()
        {
            return "Listar_Documento";
        }
    }
}
