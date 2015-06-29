using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data;
using System.Data.SqlClient;

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

        protected override string getProcedureCrearBasica()
        {
            throw new NotImplementedException();
        }

        public override SqlCommand addParametrosParaAgregar(SqlCommand command, CuentaTipoModel entity)
        {
            throw new NotImplementedException();
        }

        public override SqlCommand addParametrosParaModificar(SqlCommand command, CuentaTipoModel entity)
        {
            throw new NotImplementedException();
        }

        protected override string getProcedureModificarBasica()
        {
            throw new NotImplementedException();
        }
    }
}
