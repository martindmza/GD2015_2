using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class RolDao: BasicaDAO<RolModel>
    {
        //-------------------------------------------------------------------------------------------------------------
        public List<RolModel> getRolesByUser(Decimal userId)
        {
            List<RolModel> listaRoles = new List<RolModel>();
            DataTable dataRoles = this.getRolesDeBase(userId);
            foreach(DataRow rolBase in dataRoles.Rows){
                RolModel rolModel = new RolModel(rolBase);
                listaRoles.Add(rolModel);
            }
            return listaRoles;
        }
        //-------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------
        public RolModel createRol(RolModel rol){
            rol.habilitado = true;
            //rol.id = 99;


            return rol;
        }
        //-------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------
        public RolModel updateRol(RolModel rol)
        {
            return rol;
        }
        //-------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------
        public RolModel disableRol(RolModel rol)
        {
            rol.habilitado = false;
            return rol;
        }
        //-------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------
        public void RolAbmChanges( List<RolModel> rolList)
        {
            
        }
        //-------------------------------------------------------------------------------------------------------------

        private DataTable getRolesDeBase(Decimal idUsuario)
        {
            DataTable dt = new DataTable();
            using (SqlCommand command = InitializeConnection("Listar_Rol_Usuario"))
            {
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = idUsuario;
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
            if (dt.Rows.Count > 0)
                return dt;
            return null;
        }



        public override RolModel getModeloBasico(DataRow fila)
        {
            return new RolModel(fila);
        }

        public override string getProcedureEncontrarPorId()
        {
            return "Buscar_Rol_ID";
        }

        public override string getProcedureListar()
        {
            return "Listar_Rol";
        }
    }
}
