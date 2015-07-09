using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using Logins;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class TarjetaDeCreditoDao: BasicaDAO<TarjetaDeCreditoModel>
    {
        public List<TarjetaDeCreditoModel> getTarjetasByUsuario(UserModel usuario) {

            SqlCommand command = InitializeConnection("Buscar_Tarjeta_Usuario_Id");
            command.Parameters.Add("@Id_Usuario", System.Data.SqlDbType.Decimal).Value = usuario.id;

            return operacionSelect(command);

        }

        public List<TarjetaDeCreditoModel> getTarjetasByClienteAndNumero(ClienteModel cliente, String numero)
        {

           
            
            return null;
        }

        public TarjetaDeCreditoModel crearTarjeta(TarjetaDeCreditoModel tarjeta)
        {

            tarjeta.id = 99;
            return tarjeta;
        }

        public TarjetaDeCreditoModel modificarTarjeta(TarjetaDeCreditoModel tarjeta)
        {

            return tarjeta;
        }
        public TarjetaDeCreditoModel borrarTarjeta(TarjetaDeCreditoModel tarjeta)
        {
            tarjeta.habilitada = false;
            return tarjeta;
        }

        public override TarjetaDeCreditoModel getModeloBasico(System.Data.DataRow fila)
        {
            throw new NotImplementedException();
        }

        public override string getProcedureEncontrarPorId()
        {
            throw new NotImplementedException();
        }

        public override string getProcedureListar()
        {
            throw new NotImplementedException();
        }

        protected override string getProcedureCrearBasica()
        {
            throw new NotImplementedException();
        }

        public override System.Data.SqlClient.SqlCommand addParametrosParaAgregar(System.Data.SqlClient.SqlCommand command, TarjetaDeCreditoModel entity)
        {
            //TODO agregar parametros para agregar
            return command;
        }

        public override System.Data.SqlClient.SqlCommand addParametrosParaModificar(System.Data.SqlClient.SqlCommand command, TarjetaDeCreditoModel entity)
        {
            //TODO agregar parametros para modificar
            return command;
        }

        protected override string getProcedureModificarBasica()
        {
            throw new NotImplementedException();
        }

        private List<TarjetaDeCreditoModel> operacionSelect(SqlCommand command)
        {
            List<TarjetaDeCreditoModel> result = new List<TarjetaDeCreditoModel>();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                TarjetaDeCreditoModel model = new TarjetaDeCreditoModel(row);
                result.Add(model);
            }
            return result;
        }

    }
}
