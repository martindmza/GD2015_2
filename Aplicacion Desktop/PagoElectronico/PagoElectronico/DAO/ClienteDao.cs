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
        public ClienteDao() 
        {
        }

        public List<ClienteModel> getClientsByFilters(ClienteFiltros filtros)
        {
            return this.getListado();
        }

        public ClienteModel addNewCliente(ClienteModel cliente)
        {
            cliente.id = 99;
            return cliente;
        }

        public ClienteModel updateCliente(ClienteModel cliente){
            //retorna un clienteModel por si al hacer update, algun trigger o SP hace algo sobre el cliente
            return cliente;
        }

        public ClienteModel unsubscribeCliente(ClienteModel cliente)
        {
            cliente.habilitado = false;
            return cliente;
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
    }
}
