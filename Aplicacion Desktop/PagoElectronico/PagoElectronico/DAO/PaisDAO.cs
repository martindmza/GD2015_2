using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data;
using System.Data.SqlClient;

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

        public override SqlCommand addParametrosParaAgregar(SqlCommand command, PaisModel entity)
        {
            throw new NotImplementedException();
        }

        public override SqlCommand addParametrosParaModificar(SqlCommand command, PaisModel entity)
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

        public DataTable getPaisConMasMovimientos(DateTime inicial, DateTime final)
        {
            DataTable dt = new DataTable();
            using (SqlCommand command = InitializeConnection("Paises_Mayor_Movimiento"))
            {
                command.Parameters.Add("@FechaInic", System.Data.SqlDbType.DateTime).Value = inicial;
                command.Parameters.Add("@FechaFin", System.Data.SqlDbType.DateTime).Value = final;
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
            return dt;
        }

    }
}
