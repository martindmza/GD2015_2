using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data;

namespace DAO
{
    public class CuentaTipoDAO:BasicaDAO<CuentaTipoModel>
    {
        public override CuentaTipoModel getModeloBasico(DataRow fila)
        {
            return new CuentaTipoModel(fila);
        }

        public override string getProcedureEncontrarPorId()
        {
            return "Buscar_CuentaTipo_ID";
        }

        public override string getProcedureListar()
        {
            return "Listar_CuentaTipo";
        }
    }
}
