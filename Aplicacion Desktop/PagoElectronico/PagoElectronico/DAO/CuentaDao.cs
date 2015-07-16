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

        public List<CuentaModel> getCuentasByUsuario(UserModel usuario)
        {
            ClienteModel cliente = usuario.getMiCliente();
            if (cliente == null)
            {
                return new List<CuentaModel>();
            }
            return this.getListadoByCliente(cliente);
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
            return this.modificarBasica(cuenta);
        }

        public CuentaModel unsubscribeCuenta(CuentaModel cuenta)
        {
            this.bajaBasica(cuenta);
            return cuenta;
        }

        public override CuentaModel getModeloBasico(DataRow fila)
        {
            return new CuentaModel(fila);
        }

        protected override string getProcedureCrearBasica()
        {
            return "Crear_Cuenta";
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
            command.Parameters.Add("Pais", System.Data.SqlDbType.Decimal).Value = entity.pais.id;
            command.Parameters.Add("Moneda", System.Data.SqlDbType.Decimal).Value = entity.moneda.id;
            command.Parameters.Add("Fecha", System.Data.SqlDbType.DateTime).Value = entity.fechaCreacion;
            command.Parameters.Add("Tipo", System.Data.SqlDbType.Decimal).Value = entity.tipo.id;
            command.Parameters.Add("Propietario", System.Data.SqlDbType.Decimal).Value = entity.propietario.id;
            return command;
        }

        public override SqlCommand addParametrosParaModificar(SqlCommand command, CuentaModel entity)
        {
            command.Parameters.Add("Estado", System.Data.SqlDbType.Decimal).Value = entity.estado.id;
            command.Parameters.Add("Tipo", System.Data.SqlDbType.Decimal).Value = entity.tipo.id;
            return command;
        }

        protected override string getProcedureModificarBasica()
        {
            return "Modificar_Cuenta";
        }

        protected override SqlCommand addParametrosParaBaja(SqlCommand command, object entity)
        {
            return command;
        }

        protected override string getProcedureBajaBasica()
        {
            return "Baja_Cuenta"; 
        }

        protected override string getProcedureListarByCliente()
        {
            return "Listar_Cuenta_Cliente";
        }

        public DataTable getTotalFacturadoCuenta(DateTime inicial, DateTime final)
        {
            DataTable dt = new DataTable();
            using (SqlCommand command = InitializeConnection("Total_Facturado_Cuentas"))
            {
                command.Parameters.Add("@FechaInic", System.Data.SqlDbType.DateTime).Value = inicial;
                command.Parameters.Add("@FechaFin", System.Data.SqlDbType.DateTime).Value = final;
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
           // if (dt.Rows.Count > 0)
                return dt;
           // return null;
        }

    }
}
