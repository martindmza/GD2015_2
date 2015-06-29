using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyExceptions;
using Models;
using ABM;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class ClienteDao: BasicaDAO<ClienteModel>
    {
        private const String LISTAR_CLIENTE_FILTROS = "Buscar_Cliente_Filtros";


        public ClienteDao() 
        {
        }

        public List<ClienteModel> getClientsByFilters(ClienteFiltros filtros)
        {
            SqlCommand command = InitializeConnection(LISTAR_CLIENTE_FILTROS);

            if (filtros.apellido != null && filtros.apellido.Trim().Length != 0)
            {
                command.Parameters.Add("@Apellido", System.Data.SqlDbType.NVarChar, 255).Value = filtros.apellido.Trim();
            }
            if (filtros.nombre != null && filtros.nombre.Trim().Length != 0)
            {
                command.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 255).Value = filtros.nombre.Trim();
            }
            if (filtros.email != null && filtros.email.Trim().Length != 0)
            {
                command.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar, 255).Value = filtros.email.Trim();
            }
            if (filtros.documentoTipo != 0)
            {
                command.Parameters.Add("@DocumentoTipo", System.Data.SqlDbType.Decimal).Value = filtros.documentoTipo;
            }
            if (filtros.documentoNumero != 0)
            {
                command.Parameters.Add("@DocumentoNumero", System.Data.SqlDbType.Decimal, 255).Value = filtros.documentoNumero;
            }
            if (filtros.habilitado != null)
            {
                command.Parameters.Add("@Habilitado", System.Data.SqlDbType.Bit).Value = filtros.habilitado;
            }

            return operacionSelect(command);
        }

        public Respuesta addNewCliente(ClienteModel cliente)
        {
            try
            {
                SqlCommand command = InitializeConnection("Crear_Cliente");
                command = llenarParametros(cliente,command);
                return operacionDml(command);
            }
            catch (Exception excepcion)
            {
                Console.Write(excepcion);
                throw excepcion;
            }
        }

        public Respuesta updateCliente(ClienteModel cliente)
        {
            try
            {
                SqlCommand command = InitializeConnection("Modificar_Cliente");
                command = llenarParametros(cliente, command);
                return operacionDml(command);
            }
            catch (Exception excepcion)
            {
                Console.Write(excepcion);
                throw excepcion;
            }
        }

        public Respuesta unsubscribeCliente(ClienteModel cliente)
        {
            try
            {
                SqlCommand command = InitializeConnection("Baja_Cliente");
                command.Parameters.Add("@Id_Cliente", System.Data.SqlDbType.Decimal).Value = cliente.id;
                return operacionDml(command);
            }
            catch (Exception excepcion)
            {
                Console.Write(excepcion);
                throw excepcion;
            }
        }

        public ClienteModel getClienteByUser(UserModel userModel)
        {
            List<ClienteModel> clientes = new List<ClienteModel>();
            DataTable dataClientes = this.getClientsDeBasePorIdUsuario(userModel.id);
            if (dataClientes != null)
            {
                foreach (DataRow clienteBase in dataClientes.Rows)
                {
                    ClienteModel rolModel = new ClienteModel(clienteBase);
                    clientes.Add(rolModel);
                }
            }
            if (clientes.Count > 0)
            {
                return clientes.First();
            }
            return null;
        }

        private DataTable getClientsDeBasePorIdUsuario(decimal p)
        {
            DataTable dt = new DataTable();
            using (SqlCommand command = InitializeConnection("Listar_Cliente_ID_Usuario"))
            {
                command.Parameters.Add("@Id_Usuario", System.Data.SqlDbType.Int).Value = p;
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
            if (dt.Rows.Count > 0)
                return dt;
            return null;
        }

        public override ClienteModel getModeloBasico(DataRow fila)
        {
            return new ClienteModel(fila);
        }

        public override string getProcedureEncontrarPorId()
        {
            return "Buscar_Cliente_ID";
        }

        public override string getProcedureListar()
        {
            return "Listar_Cliente";
        }

        protected override string getProcedureCrearBasica()
        {
            throw new NotImplementedException();
        }


        public Respuesta operacionDml(SqlCommand command)
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
                Decimal value = Convert.IsDBNull(pOut.Value) ? -1 : (Decimal)(pOut.Value);
                String mensaje = Convert.IsDBNull(pOut2.Value) ? null : (string)pOut2.Value;

                return new Respuesta(value, mensaje);
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        private List<ClienteModel> operacionSelect(SqlCommand command)
        {
            List<ClienteModel> result = new List<ClienteModel>();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                ClienteModel model = new ClienteModel(row);
                result.Add(model);
            }
            return result;
        }

        private SqlCommand llenarParametros(ClienteModel cliente, SqlCommand command)
        {

            if (cliente.id != 0)
            {
                command.Parameters.Add("@Id_Cliente", System.Data.SqlDbType.Decimal).Value = cliente.id;
            }
            if (cliente.nombre != null && cliente.nombre.Trim().Length != 0)
            {
                command.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 255).Value = cliente.nombre;
            }
            if (cliente.apellido != null && cliente.apellido.Trim().Length != 0)
            {
                command.Parameters.Add("@Apellido", System.Data.SqlDbType.NVarChar, 255).Value = cliente.apellido;
            }
            if (cliente.tipoDocumento != null)
            {
                command.Parameters.Add("@Tipo_Documento", System.Data.SqlDbType.Decimal).Value = cliente.tipoDocumento;
            }
            if (cliente.nroDocumento != 0)
            {
                command.Parameters.Add("@Nro_Documento", System.Data.SqlDbType.Decimal).Value = cliente.nroDocumento;
            }
            if (cliente.pais.id != 0)
            {
                command.Parameters.Add("@Id_Pais", System.Data.SqlDbType.Decimal).Value = cliente.pais.id;
            }
            if (cliente.direccionCalle != null && cliente.direccionCalle.Trim().Length != 0)
            {
                command.Parameters.Add("@Direccion_Calle", System.Data.SqlDbType.NVarChar, 255).Value = cliente.direccionCalle;
            }
            if (cliente.direccionNumeroCalle != 0)
            {
                command.Parameters.Add("@Direccion_Numero_Calle", System.Data.SqlDbType.Decimal).Value = cliente.direccionNumeroCalle;
            }
            if (cliente.direccionPiso != 0)
            {
                command.Parameters.Add("@Direccion_Piso", System.Data.SqlDbType.Decimal).Value = cliente.direccionPiso;
            }
            if (cliente.direccionDepto != null && cliente.direccionDepto.Trim().Length != 0)
            {
                command.Parameters.Add("@Direccion_Departamento", System.Data.SqlDbType.NVarChar, 10).Value = cliente.direccionDepto;
            }
            if (cliente.nacimiento != null)
            {
                command.Parameters.Add("@Fecha_Nacimiento", System.Data.SqlDbType.DateTime).Value = cliente.nacimiento;
            }
            if (cliente.email != null && cliente.email.Trim().Length != 0)
            {
                command.Parameters.Add("@Mail", System.Data.SqlDbType.NVarChar, 255).Value = cliente.email;
            }
            if (cliente.localidad != null && cliente.localidad.Trim().Length != 0)
            {
                command.Parameters.Add("@Localidad", System.Data.SqlDbType.NVarChar, 255).Value = cliente.localidad;
            }
            if (cliente.nacionalidad != null)
            {
                command.Parameters.Add("@Id_Nacionalidad", System.Data.SqlDbType.Decimal).Value = cliente.nacionalidad;
            }

            return command;
        }

        public override SqlCommand addParametrosParaAgregar(SqlCommand command, ClienteModel entity)
        {
            throw new NotImplementedException();
        }

        public override SqlCommand addParametrosParaModificar(SqlCommand command, ClienteModel entity)
        {
            throw new NotImplementedException();
        }

        protected override string getProcedureModificarBasica()
        {
            throw new NotImplementedException();
        }
    }
}
