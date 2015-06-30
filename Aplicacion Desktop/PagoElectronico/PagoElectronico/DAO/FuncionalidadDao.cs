using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    class FuncionalidadDao: BasicaDAO<FuncionalidadModel>
    {
        public const String LISTAR_FUNCIONALIDAD_ROL = "Listar_Funcionalidad_Rol";
        public const String LISTAR_FUNCIONALIDAD = "Listar_Funcionalidad";

        //-------------------------------------------------------------------------------------------------------------
        public List<FuncionalidadModel> getFuncionalidades()
        {
            SqlCommand command = InitializeConnection(LISTAR_FUNCIONALIDAD);

            return operacionSelect(command);
        }
        //-------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------
        public List<FuncionalidadModel> getFuncionalidades(Decimal idRol)
        {

            SqlCommand command = InitializeConnection(LISTAR_FUNCIONALIDAD_ROL);
            command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = idRol;

            return operacionSelect(command);
        }
        //-------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------
        public List<FuncionalidadModel> getFuncionalidades(Decimal idRol,Boolean habilitadas)
        {
            SqlCommand command = InitializeConnection(LISTAR_FUNCIONALIDAD_ROL);
            command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = idRol;
            command.Parameters.Add("@Habilitados", System.Data.SqlDbType.Bit).Value = habilitadas;

            return operacionSelect(command);
        }
        //-------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------
        private List<FuncionalidadModel> operacionSelect(SqlCommand command)
        {
            List<FuncionalidadModel> result = new List<FuncionalidadModel>();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                FuncionalidadModel rolModel = new FuncionalidadModel(row);
                result.Add(rolModel);
            }
            return result;
        }
        //-------------------------------------------------------------------------------------------------------------

        public override FuncionalidadModel getModeloBasico(DataRow fila)
        {
            throw new NotImplementedException();
        }

        public override SqlCommand addParametrosParaAgregar(SqlCommand command, FuncionalidadModel entity)
        {
            throw new NotImplementedException();
        }

        public override SqlCommand addParametrosParaModificar(SqlCommand command, FuncionalidadModel entity)
        {
            throw new NotImplementedException();
        }

        protected override string getProcedureCrearBasica()
        {
            throw new NotImplementedException();
        }

        protected override string getProcedureModificarBasica()
        {
            throw new NotImplementedException();
        }

        public override string getProcedureEncontrarPorId()
        {
            throw new NotImplementedException();
        }

        public override string getProcedureListar()
        {
            throw new NotImplementedException();
        }
    }
}
