﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Models;

namespace DAO
{   
    public abstract class BasicaDAO<TEntity>: AbstractDAO
        where TEntity : BasicaModel , new()
    {

        public List<TEntity> getListadoByCliente(ClienteModel cliente)
        {
            List<TEntity> lista = new List<TEntity>();
            DataTable data = this.getListaDeBaseByCliente(cliente);
            foreach (DataRow fila in data.Rows)
            {
                TEntity model = this.getModeloBasico(fila);
                lista.Add(model);
            }
            return lista;
        }

        protected DataTable getListaDeBaseByCliente(ClienteModel cliente)
        {
            DataTable dt = new DataTable();
            using (SqlCommand command = InitializeConnection(this.getProcedureListarByCliente()))
            {
                command.Parameters.Add("@Id_Cliente", System.Data.SqlDbType.Decimal).Value = cliente.id;
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
            if (dt.Rows.Count > 0)
                return dt;
            return new DataTable();
        }

        protected abstract string getProcedureListarByCliente();


        public List<TEntity> getListado()
        {
            List<TEntity> lista = new List<TEntity>();
            DataTable data = this.getListaDeBase();
            foreach (DataRow fila in data.Rows)
            {
                TEntity model = this.getModeloBasico(fila);
                lista.Add(model);
            }
            return lista;
        }

        public abstract TEntity getModeloBasico(DataRow fila);
        /*
         *Recibe un string para despues transformarlo y poder encontrar y generar una Instancia de su propia
         *caracteristicas
         */
        public TEntity dameTuModelo(String id)
        {
            try
            {
                Decimal decimalId = Decimal.Parse(id);

                List<TEntity> lista = new List<TEntity>();
                DataTable data = this.getBasicaDeBasePorID(decimalId);
                foreach (DataRow fila in data.Rows)
                {
                    TEntity rolModel = this.getModeloBasico(fila);
                    lista.Add(rolModel);
                }
                if (lista.Count > 0)
                {
                    return lista.First();
                }
            }
            catch (FormatException ex)
            {
                return null;
            }
            return null;
        }

        protected DataTable getListaDeBase()
        {
            DataTable dt = new DataTable();
            using (SqlCommand command = InitializeConnection(this.getProcedureListar()))
            {
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
            if (dt.Rows.Count > 0)
                return dt;
            return new DataTable();
        }

        protected DataTable getBasicaDeBasePorID(Decimal id)
        {
            DataTable dt = new DataTable();
            using (SqlCommand command = InitializeConnection(this.getProcedureEncontrarPorId()))
            {
                command.Parameters.Add("@Id", System.Data.SqlDbType.Decimal).Value = id;
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
            if (dt.Rows.Count > 0)
                return dt;
            return new DataTable();
        }

        public TEntity modificarBasica(TEntity entity){
               DataTable dt = new DataTable();
                SqlCommand command = InitializeConnection(this.getProcedureModificarBasica());
                if (!entity.nombre.Equals(BasicaModel.SIN_NOMBRE))
                {
                    command.Parameters.Add("Nombre", System.Data.SqlDbType.NVarChar, 50).Value = entity.nombre;
                }
                command.Parameters.Add("Id", System.Data.SqlDbType.Decimal).Value = entity.id;
                command = addParametrosParaModificar(command,entity);
                var pOut = command.Parameters.Add("Respuesta", SqlDbType.Decimal);
                var pOut2 = command.Parameters.Add("RespuestaMensaje", SqlDbType.NVarChar, 255);
                pOut.Direction = ParameterDirection.Output;
                pOut2.Direction = ParameterDirection.Output;
                //
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                Decimal value = Convert.IsDBNull(pOut.Value) ? 0 : (decimal)(pOut.Value);
                string value2 = Convert.IsDBNull(pOut2.Value) ? null : (string)pOut2.Value;
                if (value != -1)
                {
                    entity.id = value;
                }
                else
                {
                    MessageBox.Show(value2, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                return entity;
        }

        public TEntity agregarBasica(TEntity entity)
        {
            DataTable dt = new DataTable();
            SqlCommand command = InitializeConnection(this.getProcedureCrearBasica());
            if (!entity.nombre.Equals(BasicaModel.SIN_NOMBRE))
            {
                command.Parameters.Add("Nombre", System.Data.SqlDbType.NVarChar, 50).Value = entity.nombre;
            }
            command = addParametrosParaAgregar(command, entity);
            var pOut = command.Parameters.Add("Respuesta", SqlDbType.Decimal);
            var pOut2 = command.Parameters.Add("RespuestaMensaje", SqlDbType.NVarChar, 255);
            pOut.Direction = ParameterDirection.Output;
            pOut2.Direction = ParameterDirection.Output;
            //
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            Decimal value = Convert.IsDBNull(pOut.Value) ? 0 : (decimal)(pOut.Value);
            string value2 = Convert.IsDBNull(pOut2.Value) ? null : (string)pOut2.Value;
            if (value != -1)
            {
                entity.id = value;
            }
            else
            {
                MessageBox.Show(value2, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            return entity;
        }

        public TEntity bajaBasica(TEntity entity)
        {
            DataTable dt = new DataTable();
            SqlCommand command = InitializeConnection(this.getProcedureBajaBasica());
            command.Parameters.Add("Id", System.Data.SqlDbType.Decimal).Value = entity.id;
            command = addParametrosParaBaja(command, entity);
            var pOut = command.Parameters.Add("Respuesta", SqlDbType.Decimal);
            var pOut2 = command.Parameters.Add("RespuestaMensaje", SqlDbType.NVarChar, 255);
            pOut.Direction = ParameterDirection.Output;
            pOut2.Direction = ParameterDirection.Output;
            //
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            Decimal value = Convert.IsDBNull(pOut.Value) ? 0 : (decimal)(pOut.Value);
            string value2 = Convert.IsDBNull(pOut2.Value) ? null : (string)pOut2.Value;
            if (value != -1)
            {
                entity.id = value;
            }
            else
            {
                MessageBox.Show(value2, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            return entity;
        }

        protected abstract SqlCommand addParametrosParaBaja(SqlCommand command, object entity);

        public abstract SqlCommand addParametrosParaAgregar(SqlCommand command, TEntity entity);

        public abstract SqlCommand addParametrosParaModificar(SqlCommand command, TEntity entity);

        protected abstract string getProcedureCrearBasica();

        protected abstract string getProcedureModificarBasica();

        protected abstract string getProcedureBajaBasica();

        public abstract string getProcedureEncontrarPorId();

        public abstract string getProcedureListar();
    }
}
