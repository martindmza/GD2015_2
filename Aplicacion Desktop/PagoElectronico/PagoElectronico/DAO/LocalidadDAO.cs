using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class LocalidadDAO:BasicaDAO<LocalidadModel>
    {
        public override string getProcedureEncontrarPorId()
        {
            return "Buscar_Localidad_Id";
        }

        public override string getProcedureListar()
        {
            return "Listar_Localidad";
        }

        public override LocalidadModel getModeloBasico(DataRow fila)
        {
            return new LocalidadModel(fila);
        }

        protected override string getProcedureCrearBasica()
        {
            throw new NotImplementedException();
        }

        public override SqlCommand addParametrosParaAgregar(SqlCommand command, LocalidadModel entity)
        {
            throw new NotImplementedException();
        }

        public override SqlCommand addParametrosParaModificar(SqlCommand command, LocalidadModel entity)
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
    }
}
