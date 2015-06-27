using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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
        public List<RolModel> getRolesByFilters(Decimal rolId,String rolName)
        {
            List<RolModel> listaRoles = new List<RolModel>();
            //TODO
            return null;
        }
        //-------------------------------------------------------------------------------------------------------------
        public RolModel updateRol(RolModel rol)
        {
            try
            {
                DataTable dt = new DataTable();

                //Seteo la tabla de las funcionalidades
                DataTable funcionalidadesLista = new DataTable();
                funcionalidadesLista.Columns.Add("Id_Funcionalidad", typeof(decimal));
                foreach (FuncionalidadModel f in rol.funcionalidades)
                {
                    funcionalidadesLista.Rows.Add(f.id);
                }

                //Llamo al SP modificar Rol
                SqlCommand command = InitializeConnection("Modificar_Rol");

                command.Parameters.Add("@Id_Rol", System.Data.SqlDbType.Int).Value = rol.id;
                command.Parameters.Add("@Nombre_Rol", System.Data.SqlDbType.NVarChar,255).Value = rol.nombre;
                command.Parameters.Add("@Funcionalidades", System.Data.SqlDbType.Structured).Value = funcionalidadesLista;
                var pOut = command.Parameters.Add("@Respuesta", SqlDbType.Int);
                var pOut2 = command.Parameters.Add("@RespuestaMensaje", SqlDbType.NVarChar, 255);
                pOut.Direction = ParameterDirection.Output;
                pOut2.Direction = ParameterDirection.Output;
                //

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                Int32 value = Convert.IsDBNull(pOut.Value) ? 0 : (Int32)(pOut.Value);
                string value2 = Convert.IsDBNull(pOut2.Value) ? null : (string)pOut2.Value;
                if (value != -1)
                {
                    this.Commit();
                }
                else
                {
                    MessageBox.Show(value2, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    //enviando el id negativo indico que falló
                    rol.id = rol.id * -1;
                    return rol;
                }
            }
            catch (NullReferenceException exepcion) {
                Console.Write(exepcion);
            }
            catch (Exception excepcion)
            {
                Console.Write(excepcion);
                this.RollBack();
                throw excepcion;

            }
            return rol;

        }
        //-------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------
        public RolModel disableRol(RolModel rol)
        {
            //Baja_Rol
            return rol;
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

        public RolModel createRol(RolModel entity)
        {
            try
            {
                DataTable dt = new DataTable();

                SqlCommand command = InitializeConnection("Crear_Rol");

                command.Parameters.Add("Nombre_Rol", System.Data.SqlDbType.NVarChar, 50).Value = entity.nombre;
                //
                var pOut = command.Parameters.Add("Respuesta", SqlDbType.Int);
                var pOut2 = command.Parameters.Add("RespuestaMensaje", SqlDbType.NVarChar, 255);
                pOut.Direction = ParameterDirection.Output;
                pOut2.Direction = ParameterDirection.Output;
                //
                
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                Int32 value = Convert.IsDBNull(pOut.Value) ? 0 : (Int32)(pOut.Value);
                string value2 = Convert.IsDBNull(pOut2.Value) ? null : (string)pOut2.Value;
                if (value != -1)
                {
                    entity.id = value;
                    this.Commit();
                }
                else
                {
                    MessageBox.Show(value2, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                return entity;
            }
            catch (Exception excepcion)
            {
                this.RollBack();
                throw excepcion;

            }
        }

        protected override string getProcedureCrearBasica()
        {
            throw new NotImplementedException();
        }
    }
}
