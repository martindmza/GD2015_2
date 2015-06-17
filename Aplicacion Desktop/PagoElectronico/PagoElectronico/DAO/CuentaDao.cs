using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class CuentaDao: AbstractDAO
    {

        public List<CuentaModel> getCuentas()
        {

            List<CuentaModel> cuentas = new List<CuentaModel>();
            DataTable dataRoles = this.getCuentasDeBase();
            foreach (DataRow cuentaBase in dataRoles.Rows)
            {
                CuentaModel rolModel = new CuentaModel(cuentaBase);
                cuentas.Add(rolModel);
            }
            return cuentas;
        }


        public List<CuentaModel> getCuentasByCliente(ClienteModel cliente) {
            List<CuentaModel> cuentas = new List<CuentaModel>();
            DataTable dataRoles = this.getCuentasDeBasePorIdCliente(cliente.id);
            foreach(DataRow cuentaBase in dataRoles.Rows){
                CuentaModel rolModel = new CuentaModel(cuentaBase);
                cuentas.Add(rolModel);
            }
            return cuentas;
        }

        public List<CuentaModel> getCuentasByUsuario(UserModel usuario)
        {
            List<CuentaModel> cuentas = new List<CuentaModel>();
            DataTable dataRoles = this.getCuentasDeBasePorIdUsuario(usuario.id);
            if (dataRoles != null)
            {
                foreach (DataRow cuentaBase in dataRoles.Rows)
                {
                    CuentaModel rolModel = new CuentaModel(cuentaBase);
                    cuentas.Add(rolModel);
                }
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
            List<CuentaTipoModel> tipos = new List<CuentaTipoModel>();

            CuentaTipoModel t1 = new CuentaTipoModel(1, "oro", 10, 1000);
            CuentaTipoModel t2 = new CuentaTipoModel(2, "plata", 10, 500);
            CuentaTipoModel t3 = new CuentaTipoModel(3, "bronce", 10, 200);
            CuentaTipoModel t4 = new CuentaTipoModel(4, "gratarola", 10, 0);

            tipos.Add(t1);
            tipos.Add(t2);
            tipos.Add(t3);
            tipos.Add(t4);

            return tipos;
        }

        public CuentaModel addNewCuenta(CuentaModel cuenta)
        {
            cuenta.id = 99;
            return cuenta;
        }

        public CuentaModel updateCuenta(CuentaModel cuenta)
        {
            //retorna un clienteModel por si al hacer update, algun trigger o SP hace algo sobre el cliente
            return cuenta;
        }

        public CuentaModel unsubscribeCuenta(CuentaModel cuenta)
        {
            cuenta.habilitado = false;
            return cuenta;
        }
    }
}
