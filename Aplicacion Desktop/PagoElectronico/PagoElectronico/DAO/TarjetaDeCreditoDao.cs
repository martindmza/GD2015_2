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
                command.Parameters.Add("@Id_Cliente", System.Data.SqlDbType.Decimal).Value = tarjeta.propietario.id;
                command.Parameters.Add("@Nro_Tarjeta", System.Data.SqlDbType.NVarChar, 255).Value = tarjeta.numero;
                command.Parameters.Add("@Id_Emisor", System.Data.SqlDbType.Decimal).Value = tarjeta.emisor.id;
                command.Parameters.Add("@Fecha", System.Data.SqlDbType.DateTime).Value = tarjeta.emision;
                command.Parameters.Add("@Fecha_Venc", System.Data.SqlDbType.DateTime).Value = tarjeta.vencimiento;
                command.Parameters.Add("@Codigo", System.Data.SqlDbType.NVarChar, 255).Value = hash(tarjeta.codigoSeguridad);

                return operacionDml(command);
            }
            catch (Exception excepcion)
            {
                Console.Write(excepcion);
                throw excepcion;
            }
        }

        public Respuesta modificarTarjeta(TarjetaDeCreditoModel tarjeta)
        {

            try
            {
                SqlCommand command = InitializeConnection("Modificar_Tarjeta");
                command.Parameters.Add("@Id_Tarjeta", System.Data.SqlDbType.Decimal).Value = tarjeta.id;
                command.Parameters.Add("@Nro_Tarjeta", System.Data.SqlDbType.NVarChar, 255).Value = tarjeta.numero;
                command.Parameters.Add("@Id_Emisor", System.Data.SqlDbType.Decimal).Value = tarjeta.emisor.id;
                command.Parameters.Add("@Fecha", System.Data.SqlDbType.DateTime).Value = tarjeta.emision;
                command.Parameters.Add("@Fecha_Venc", System.Data.SqlDbType.DateTime).Value = tarjeta.vencimiento;

                return operacionDml(command);
            }
            catch (Exception excepcion)
            {
                Console.Write(excepcion);
                throw excepcion;
            }
        }
        public Respuesta borrarTarjeta(TarjetaDeCreditoModel tarjeta)
        {
            try
            {
                SqlCommand command = InitializeConnection("Baja_Tarjeta");
                command.Parameters.Add("@Id_Tarjeta", System.Data.SqlDbType.Decimal).Value = tarjeta.id;
                return operacionDml(command);
            }
            catch (Exception excepcion)
            {
                Console.Write(excepcion);
                throw excepcion;
            }
        }

        public override TarjetaDeCreditoModel getModeloBasico(System.Data.DataRow fila)
        {
            return new TarjetaDeCreditoModel(fila);
        }

        public override string getProcedureEncontrarPorId()
        {
            return "Buscar_Tarjeta_ID";
        }

        public override string getProcedureListar()
        {
            return "Listar_Tarjeta";
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

        public Respuesta operacionDml(SqlCommand command)
        {
            try
            {
                DataTable dt = new DataTable();
                //
                var pOut = command.Parameters.Add("@Respuesta", SqlDbType.Decimal);
                var pOut2 = command.Parameters.Add("@RespuestaMensaje", SqlDbType.NVarChar, 255);
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


        //--------------------------------------------------------------------
        public static string hash(string input)
        {

            System.Security.Cryptography.SHA256 sha256 = new System.Security.Cryptography.SHA256Managed();
            byte[] sha256Bytes = System.Text.Encoding.Default.GetBytes(input);
            byte[] cryString = sha256.ComputeHash(sha256Bytes);
            string resultEncriptado = string.Empty;
            for (int i = 0; i < cryString.Length; i++)
            {
                resultEncriptado += cryString[i].ToString("X");
            }
            return resultEncriptado;
        }
        //--------------------------------------------------------------------


        protected override SqlCommand addParametrosParaBaja(SqlCommand command, object entity)
        {
            throw new NotImplementedException();
        }

        protected override string getProcedureBajaBasica()
        {
            throw new NotImplementedException();
        }

        protected override string getProcedureListarByCliente()
        {
            return "Buscar_Tarjeta_Cliente_Id";
        }
    }
}
