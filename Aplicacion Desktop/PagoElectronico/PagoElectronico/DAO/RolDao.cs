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
        private const String LISTAR_ROL_USUARIO = "Listar_Rol_Usuario";
        private const String LISTAR_ROL_FILTROS = "Buscar_Rol_Filtros";
       

        //-------------------------------------------------------------------------------------------------------------
        public List<RolModel> getRolesByUser(Decimal userId)
        {
            SqlCommand command = InitializeConnection(LISTAR_ROL_USUARIO);
            command.Parameters.Add("@Id", System.Data.SqlDbType.Decimal).Value = userId;
           
            return operacionSelect(command);
        }
        //-------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------
        public List<RolModel> getRolesByUser(Decimal userId,Boolean habilitados)
        { 
            SqlCommand command = InitializeConnection(LISTAR_ROL_USUARIO);
            command.Parameters.Add("@Id", System.Data.SqlDbType.Decimal).Value = userId;
            command.Parameters.Add("@Habilitados", System.Data.SqlDbType.Bit).Value = habilitados;

            return operacionSelect(command);
        }
        //-------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------
        public List<RolModel> getRolesByFilters(Decimal rolId,String rolName)
        {
            SqlCommand command = InitializeConnection(LISTAR_ROL_FILTROS);

            if (rolName.Length != 0 && rolName != null)
            {
                command.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 255).Value = rolName;
            }
            if (rolId != 0)
            {
                command.Parameters.Add("@Id_Rol", System.Data.SqlDbType.Decimal).Value = rolId;
            }

            return operacionSelect(command);
        }
        //-------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------
        public RolRespuesta createRol(RolModel entity)
        {
            try
            {
                SqlCommand command = InitializeConnection("Crear_Rol");
                command.Parameters.Add("Nombre_Rol", System.Data.SqlDbType.NVarChar, 255).Value = entity.nombre;
                return operacionDml(command);
            }
            catch (Exception excepcion)
            {
                Console.Write(excepcion);
                throw excepcion;
            }
        }
        //-------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------
        public RolRespuesta updateRol(RolModel rol)
        {
            try
            {
                //Seteo la tabla de las funcionalidades
                DataTable funcionalidadesLista = new DataTable();
                funcionalidadesLista.Columns.Add("Id_Funcionalidad", typeof(decimal));
                foreach (FuncionalidadModel f in rol.funcionalidades)
                {
                    funcionalidadesLista.Rows.Add(f.id);
                }

                //Llamo al SP modificar Rol
                SqlCommand command = InitializeConnection("Modificar_Rol");

                command.Parameters.Add("@Id_Rol", System.Data.SqlDbType.Decimal).Value = rol.id;
                command.Parameters.Add("@Nombre_Rol", System.Data.SqlDbType.NVarChar,255).Value = rol.nombre;
                command.Parameters.Add("@Funcionalidades", System.Data.SqlDbType.Structured).Value = funcionalidadesLista;
                return operacionDml(command);
            }
            catch (NullReferenceException exepcion) {
                Console.Write(exepcion);
                throw exepcion;
            }
            catch (Exception excepcion)
            {
                Console.Write(excepcion);
                throw excepcion;
            }

        }
        //-------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------
        public RolRespuesta disableRol(RolModel rol)
        {
            try
            {
                SqlCommand command = InitializeConnection("Baja_Rol");
                command.Parameters.Add("@Id_Rol", System.Data.SqlDbType.Decimal).Value = rol.id;
                return operacionDml(command);
            }
            catch (Exception excepcion)
            {
                Console.Write(excepcion);
                throw excepcion;
            }
        }
        //-------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------
        public RolRespuesta enableRol(RolModel rol)
        {
            try
            {
                SqlCommand command = InitializeConnection("Alta_Rol");
                command.Parameters.Add("@Id_Rol", System.Data.SqlDbType.Decimal).Value = rol.id;
                return operacionDml(command);
            }
            catch (Exception excepcion)
            {
                Console.Write(excepcion);
                throw excepcion;
            }
        }
        //-------------------------------------------------------------------------------------------------------------

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


        private List<RolModel> operacionSelect(SqlCommand command)
        {
            List<RolModel> result = new List<RolModel>();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                RolModel rolModel = new RolModel(row);
                result.Add(rolModel);
            }
            return result;
        }
       
        public RolRespuesta operacionDml(SqlCommand command)
        {
            try
            {
                DataTable dt = new DataTable();
                //
                var pOut = command.Parameters.Add("Respuesta", SqlDbType.Decimal);
                var pOut2 = command.Parameters.Add("RespuestaMensaje", SqlDbType.NVarChar, 255);
                pOut.Direction = ParameterDirection.Output;
                pOut2.Direction = ParameterDirection.Output;
                //

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                Decimal value = Convert.IsDBNull(pOut.Value) ? 0 : (Decimal)(pOut.Value);
                String mensaje = Convert.IsDBNull(pOut2.Value) ? null : (string)pOut2.Value;

                return new RolRespuesta(value,mensaje);
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
            
        }

        protected override string getProcedureCrearBasica()
        {
            throw new NotImplementedException();
        }
    }
}
