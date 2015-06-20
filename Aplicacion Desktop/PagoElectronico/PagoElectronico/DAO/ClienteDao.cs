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

        public List<ClienteModel> getClients()
        {
            List<ClienteModel> clientes = new List<ClienteModel>();
            DataTable dataClients = this.getClientsDeBase();
            foreach (DataRow rolBase in dataClients.Rows)
            {
                ClienteModel rolModel = new ClienteModel(rolBase);
                clientes.Add(rolModel);
            }
            return clientes;
        }

        private DataTable getClientsDeBase()
        {
            DataTable dt = new DataTable();
            using (SqlCommand command = InitializeConnection("Listar_Cliente"))
            {
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
            if (dt.Rows.Count > 0)
                return dt;
            return null;
        }

        public ClienteModel getClienteById(Decimal id)
        {
            List<ClienteModel> clientes = new List<ClienteModel>();
            DataTable dataRoles = this.getClientsDeBasePorId(id);
            foreach (DataRow clienteBase in dataRoles.Rows)
            {
                ClienteModel rolModel = new ClienteModel(clienteBase);
                clientes.Add(rolModel);
            }
            if (clientes.Count > 0)
            {
                return clientes.First();
            }
            return null;
        }

        private DataTable getClientsDeBasePorId(decimal id)
        {
            DataTable dt = new DataTable();
            using (SqlCommand command = InitializeConnection("Listar_Cliente_ID"))
            {
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
            if (dt.Rows.Count > 0)
                return dt;
            return null;
        }

        public List<ClienteModel> getClientsByFilters(ClienteFiltros filtros)
        {
            return this.getClients();
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
            DataTable dataRoles = this.getClientsDeBasePorIdUsuario(userModel.id);
            if (dataRoles != null)
            {
                foreach (DataRow clienteBase in dataRoles.Rows)
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
    }
}
