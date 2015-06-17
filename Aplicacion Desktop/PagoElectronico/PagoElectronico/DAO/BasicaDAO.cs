﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public abstract class BasicaDAO<TEntity>: AbstractDAO
        where TEntity : class, new()
    {

        public List<TEntity> getListado()
        {
            List<TEntity> lista = new List<TEntity>();
            DataTable data = this.getListaDeBase();
            foreach (DataRow fila in data.Rows)
            {
                TEntity rolModel = this.getModeloBasico(fila);
                lista.Add(rolModel);
            }
            return lista;
        }
        public abstract TEntity getModeloBasico(DataRow fila);

        public TEntity dameTuModelo(Decimal id)
        {
            List<TEntity> lista = new List<TEntity>();
            DataTable data = this.getBasicaDeBasePorID(id);
            foreach (DataRow fila in data.Rows)
            {
                TEntity rolModel = this.getModeloBasico(fila);
                lista.Add(rolModel);
            }
            if (lista.Count > 0)
            {
                return lista.First();
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
            return null;
        }

        protected DataTable getBasicaDeBasePorID(Decimal id)
        {
            DataTable dt = new DataTable();
            using (SqlCommand command = InitializeConnection(this.getProcedureEncontrarPorId()))
            {
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
            if (dt.Rows.Count > 0)
                return dt;
            return null;
        }

        public abstract string getProcedureEncontrarPorId();
        public abstract string getProcedureListar();
    }
}
