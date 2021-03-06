﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class RetiroDao:BasicaDAO<RetiroModel>
    {
        private const String RETIRAR = "RetiroEfectivo";
        public Respuesta createRetiro(RetiroModel retiro,TipoDocumentoModel docTipo,Decimal docNum)
        {
            try
            {
                SqlCommand command = InitializeConnection(RETIRAR);
                command = this.addParametrosParaAgregar(command,retiro);
                command.Parameters.Add("@Id_Tipo_Documento", System.Data.SqlDbType.Decimal).Value = docTipo.id;
                command.Parameters.Add("@Nro_Documento", System.Data.SqlDbType.Decimal).Value = docNum;

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
                return new Respuesta(value, mensaje);
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        public List<RetiroModel> getRetiroByCuenta(CuentaModel cuenta)
        {
            List<RetiroModel> transf = new List<RetiroModel>();
            DataTable dataCuentas = this.getRetiroDeBaseIdCuenta(cuenta.id);
            foreach (DataRow cuentaBase in dataCuentas.Rows)
            {
                RetiroModel retiroModel = new RetiroModel(cuentaBase);
                transf.Add(retiroModel);
            }
            return transf;
        }


        private DataTable getRetiroDeBaseIdCuenta(decimal p)
        {
            DataTable dt = new DataTable();
            using (SqlCommand command = InitializeConnection("Top5Retiros"))
            {
                command.Parameters.Add("@Cuenta", System.Data.SqlDbType.Decimal).Value = p;
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
            if (dt.Rows.Count > 0)
                return dt;
            return new DataTable();
        }

        public override RetiroModel getModeloBasico(System.Data.DataRow fila)
        {
            return new RetiroModel(fila);
        }

        public override SqlCommand addParametrosParaAgregar(SqlCommand command, RetiroModel retiro)
        {
            command.Parameters.Add("@Id_Cuenta", System.Data.SqlDbType.Decimal).Value = retiro.cuenta.id;
            command.Parameters.Add("@Importe", System.Data.SqlDbType.Decimal).Value = retiro.importe;
            command.Parameters.Add("@Id_Moneda", System.Data.SqlDbType.Decimal).Value = retiro.moneda.id;
            command.Parameters.Add("@Fecha", System.Data.SqlDbType.DateTime).Value = retiro.fecha;
            command.Parameters.Add("@Id_Banco", System.Data.SqlDbType.Decimal).Value = retiro.banco.id;
            return command;
        }

        public override SqlCommand addParametrosParaModificar(SqlCommand command, RetiroModel entity)
        {
            return command;
        }

        protected override string getProcedureCrearBasica()
        {
            return RETIRAR;
        }

        protected override string getProcedureModificarBasica()
        {
            return "Modificar_Retiro";
        }

        public override string getProcedureEncontrarPorId()
        {
            return "Buscar_Retiro_ID";
        }

        public override string getProcedureListar()
        {
            return "Listar_Retiro";
        }

        protected override SqlCommand addParametrosParaBaja(SqlCommand command, object entity)
        {
            return command;
        }

        protected override string getProcedureBajaBasica()
        {
            return "Baja_Retiro";
        }

        protected override string getProcedureListarByCliente()
        {
            return "Listar_Retiro_ID_Cliente";
        }
    }
}
