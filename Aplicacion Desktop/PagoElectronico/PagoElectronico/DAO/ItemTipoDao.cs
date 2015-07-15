using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class ItemTipoDao : BasicaDAO<ItemTipoModel>
    {
        public override ItemTipoModel getModeloBasico(DataRow fila)
        {
            return new ItemTipoModel(fila);
        }

        protected override string getProcedureCrearBasica()
        {
            return "Crear_Tipo_Item";
        }

        public override string getProcedureEncontrarPorId()
        {
            return "Buscar_Tipo_Item_ID";
        }

        public override string getProcedureListar()
        {
            return "Listar_Tipo_Items";
        }

        public override SqlCommand addParametrosParaAgregar(SqlCommand command, ItemTipoModel entity)
        {
            throw new NotImplementedException();
        }

        public override SqlCommand addParametrosParaModificar(SqlCommand command, ItemTipoModel entity)
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
