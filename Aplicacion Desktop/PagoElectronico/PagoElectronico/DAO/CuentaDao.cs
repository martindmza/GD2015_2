using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class CuentaDao: BasicaDAO<CuentaModel>
    {
       public List<CuentaModel> getCuentasByCliente(ClienteModel cliente) {
            List<CuentaModel> cuentas = new List<CuentaModel>();
            DataTable dataCuentas = this.getCuentasDeBasePorIdCliente(cliente.id);
            foreach (DataRow cuentaBase in dataCuentas.Rows)
            {
                CuentaModel cuentaModel = new CuentaModel(cuentaBase);
                cuentas.Add(cuentaModel);
            }
            return cuentas;
        }

        public List<CuentaModel> getCuentasByUsuario(UserModel usuario)
        {
            ClienteModel cliente = usuario.getMiCliente();
            if (cliente == null)
            {
                return new List<CuentaModel>();
            }
            return this.getCuentasByCliente(cliente);
        }

        public List<CuentaModel> getCuentas()
        {
            List<CuentaModel> cuentas = new List<CuentaModel>();
            DataTable dataCuentas = this.getCuentasDeBase();
            foreach (DataRow cuentaBase in dataCuentas.Rows)
            {
                CuentaModel cuentaModel = new CuentaModel(cuentaBase);
                cuentas.Add(cuentaModel);
            }
            return cuentas;

        }

        private DataTable getCuentasDeBase()
        {
            DataTable dt = new DataTable();
            using (SqlCommand command = InitializeConnection("Listar_Cuenta"))
            {
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
            if (dt.Rows.Count > 0)
                return dt;
            return null;
        }

        private DataTable getCuentasDeBasePorIdCliente(decimal idCliente)
        {
            DataTable dt = new DataTable();
            using (SqlCommand command = InitializeConnection("Listar_Cuenta_Cliente"))
            {
                command.Parameters.Add("@Id_Cliente", System.Data.SqlDbType.Int).Value = idCliente;
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
            if (dt.Rows.Count > 0)
                return dt;
            return null;
        }

        private DataTable getCuentasDeBasePorIdUsuario(decimal idUsuario)
        {
            DataTable dt = new DataTable();
            using (SqlCommand command = InitializeConnection("Listar_Cuenta_Usuario"))
            {
                command.Parameters.Add("@Id_Usuario", System.Data.SqlDbType.Int).Value = idUsuario;
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
            if (dt.Rows.Count > 0)
                return dt;
            return null;
        }

        public List<CuentaTipoModel> getCuentaTypes()
        {
            return new CuentaTipoDAO().getListado();
        }

        public CuentaModel addNewCuenta(CuentaModel entity)
        {
            return this.agregarBasica(entity);
        }

        public CuentaModel updateCuenta(CuentaModel cuenta)
        {
            //retorna un clienteModel por si al hacer update, algun trigger o SP hace algo sobre el cliente
            return cuenta;
        }

        public CuentaModel unsubscribeCuenta(CuentaModel cuenta)
        {
            //cuenta.habilitado = false;
            return cuenta;
        }

        public override CuentaModel getModeloBasico(DataRow fila)
        {
            return new CuentaModel(fila);
        }

        protected override string getProcedureCrearBasica()
        {
            return "CrearCuenta";
        }

        public override string getProcedureEncontrarPorId()
        {
            return "Buscar_Cuenta_ID";
        }

        public override string getProcedureListar()
        {
            return "Listar_Cuenta";
        }

        public override SqlCommand addParametrosParaAgregar(SqlCommand command, CuentaModel entity)
        {
            command.Parameters.Add("Estado", System.Data.SqlDbType.NVarChar, 255).Value = entity.estado.id;
            command.Parameters.Add("Estado", System.Data.SqlDbType.NVarChar, 255).Value = entity.estado.id;
            command.Parameters.Add("Estado", System.Data.SqlDbType.NVarChar, 255).Value = entity.estado.id;
            command.Parameters.Add("Estado", System.Data.SqlDbType.NVarChar, 255).Value = entity.estado.id;
            command.Parameters.Add("Estado", System.Data.SqlDbType.NVarChar, 255).Value = entity.estado.id;
            return command;
        }

        public override SqlCommand addParametrosParaModificar(SqlCommand command, CuentaModel entity)
        {
            throw new NotImplementedException();
        }

        protected override string getProcedureModificarBasica()
        {
            throw new NotImplementedException();
        }
    }
}
