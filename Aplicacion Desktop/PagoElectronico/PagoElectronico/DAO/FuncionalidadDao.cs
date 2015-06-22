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
        public const String LISTAR_FUNCIONALIDAD = "Listar_Funcionalidad";

        public List<FuncionalidadModel> getFuncionalidades()
        {
            return getFuncionalidades(0);
        }

        public List<FuncionalidadModel> getFuncionalidades(Decimal id)
        {
            DataTable tablaFuncionalidad = this.getFuncionalidadesBase(id);
            List<FuncionalidadModel> listaRoles = new List<FuncionalidadModel>();
            if (tablaFuncionalidad != null)
            {
                foreach (DataRow funcionBase in tablaFuncionalidad.Rows)
                {
                    FuncionalidadModel funcionalidadModel = new FuncionalidadModel(funcionBase);
                    listaRoles.Add(funcionalidadModel);
                }
            }
            return listaRoles;
        }
        //-------------------------------------------------------------------------------------------------------------
        public DataTable getFuncionalidadesBase(Decimal idRol)
        {
            DataTable dt = new DataTable();
            //si no tengo filtros, llamo a la vista que retorna todas las funcionalidades
            if (idRol == 0)
            {
                using (SqlCommand command = InitializeConnection(LISTAR_FUNCIONALIDAD))
                {
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                }
            }
            else {
                using (SqlCommand command = InitializeConnection(LISTAR_FUNCIONALIDAD_ROL))
                {
                    command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = idRol;
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                }   
            }
            if (dt.Rows.Count > 0)
                return dt;
            return null;
        }
    }
}
