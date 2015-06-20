using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    class FuncionalidadDao: AbstractDAO
    {
        public const String LISTAR_FUNCIONALIDAD_ROL = "Listar_Funcionalidad_Rol";

        public List<FuncionalidadModel> getFuncionalidades()
        {
            return new List<FuncionalidadModel>();
        }

        public List<FuncionalidadModel> getFuncionalidades(Decimal id)
        {
            DataTable tablaFuncionalidad = this.getFuncionalidadesBase(id);
            List<FuncionalidadModel> listaRoles = new List<FuncionalidadModel>();

            foreach (DataRow funcionBase in tablaFuncionalidad.Rows)
            {
                FuncionalidadModel funcionalidadModel = new FuncionalidadModel(funcionBase);
                listaRoles.Add(funcionalidadModel);
            }
            return listaRoles;
        }
        //-------------------------------------------------------------------------------------------------------------

        public DataTable getFuncionalidadesBase(Decimal idRol)
        {
            DataTable dt = new DataTable();
            using (SqlCommand command = InitializeConnection(LISTAR_FUNCIONALIDAD_ROL))
            {
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = idRol;
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
            if (dt.Rows.Count > 0)
                return dt;
            return null;
        }
    }
}
