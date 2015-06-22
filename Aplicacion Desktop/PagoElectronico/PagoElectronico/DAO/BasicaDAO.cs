using System;
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

        public TEntity agregarBasica(TEntity entity){
            try
            {
                DataTable dt = new DataTable();
                SqlCommand command = InitializeConnection(this.getProcedureCrearBasica());

                command.Parameters.Add("Nombre", System.Data.SqlDbType.NVarChar, 50).Value = entity.nombre;
                //
                var pOut = command.Parameters.Add("Respuesta", SqlDbType.Int);
                var pOut2 = command.Parameters.Add("RespuestaMensaje", SqlDbType.NVarChar, 255);
                pOut.Direction = ParameterDirection.Output;
                pOut2.Direction = ParameterDirection.Output;
                //
                
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                Int32 value = Convert.IsDBNull(pOut.Value) ? 0 : (Int32)(pOut.Value);
                string value2 = Convert.IsDBNull(pOut2.Value) ? null : (string)pOut2.Value;
                if (value != -1)
                {
                    entity.id = value;
                    this.Commit();
                }
                else
                {
                    MessageBox.Show(value2, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                return entity;
            }
            catch (Exception excepcion)
            {
                this.RollBack();
                throw excepcion;
            }
        }

        protected abstract string getProcedureCrearBasica();

        public abstract string getProcedureEncontrarPorId();

        public abstract string getProcedureListar();
    }
}
