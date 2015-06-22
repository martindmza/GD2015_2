using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data;

namespace DAO
{
    public class PaisDAO: BasicaDAO<PaisModel>
    {
        public override string getProcedureEncontrarPorId()
        {
            return "Buscar_Pais_Id";
        }

        public override string getProcedureListar()
        {
            return "Listar_Pais";
        }

        public override PaisModel getModeloBasico(DataRow fila)
        {
            return new PaisModel(fila);
        }

        protected override string getProcedureCrearBasica()
        {
            throw new NotImplementedException();
        }
    }
}
