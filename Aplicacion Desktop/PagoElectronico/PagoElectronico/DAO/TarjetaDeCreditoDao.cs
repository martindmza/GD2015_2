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
        public List<TarjetaDeCreditoModel> getTarjetasByCliente(ClienteModel cliente) {
            SqlCommand command = InitializeConnection("Buscar_Tarjeta_Cliente_Id");
            command.Parameters.Add("@Id_Cliente", System.Data.SqlDbType.Decimal).Value = cliente.id;

            return operacionSelect(command);

        }

        public List<TarjetaDeCreditoModel> getTarjetasByClienteAndNumero(ClienteModel cliente, String numero)
        {
            SqlCommand command = InitializeConnection("Buscar_Tarjeta_Cliente_Id");
            command.Parameters.Add("@Id_Cliente", System.Data.SqlDbType.Decimal).Value = cliente.id;
            command.Parameters.Add("@Numero", System.Data.SqlDbType.Decimal).Value = numero;

            return operacionSelect(command);

        }

        public Respuesta crearTarjeta(TarjetaDeCreditoModel tarjeta)
        {
            try
            {
                SqlCommand command = InitializeConnection("Crear_Tarjeta");
                command = llenarParametros(tarjeta, command);
                return operacionDml(command);
            }
            catch (Exception excepcion)
            {
                Console.Write(excepcion);
                throw excepcion;
            }
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

        private SqlCommand llenarParametros(TarjetaDeCreditoModel tarjeta, SqlCommand command)
        {
            if (tarjeta.id != 0)
            {
                command.Parameters.Add("@Id_Tarjeta", System.Data.SqlDbType.Decimal).Value = tarjeta.id;
            }
            if (tarjeta.propietario != null)
            {
                command.Parameters.Add("@Id_Cliente", System.Data.SqlDbType.Decimal).Value = tarjeta.propietario.id;
            }
            if (tarjeta.numero != null && tarjeta.numero.Trim().Length != 0)
            {
                command.Parameters.Add("@Nro_Tarjeta", System.Data.SqlDbType.NVarChar, 255).Value = tarjeta.numero;
            }
            if (tarjeta.emision != null)
            {
                command.Parameters.Add("@Fecha", System.Data.SqlDbType.DateTime).Value = tarjeta.emision;
            }
            if (tarjeta.vencimiento != null)
            {
                command.Parameters.Add("@Fecha_Venc", System.Data.SqlDbType.DateTime).Value = tarjeta.vencimiento;
            }
            if (tarjeta.codigoSeguridad != null && tarjeta.codigoSeguridad.Trim().Length != 0)
            {
                command.Parameters.Add("@Codigo", System.Data.SqlDbType.NVarChar, 255).Value = tarjeta.codigoSeguridad;
            }

            return command;
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

    }
}
