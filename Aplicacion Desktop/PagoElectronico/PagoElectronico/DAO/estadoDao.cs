using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data;

namespace DAO
{
    public class EstadoDao: BasicaDAO<EstadoModel>
    {
        public List<EstadoModel> getEstados()
        {
            List<EstadoModel> lista = new List<EstadoModel>();
            DataTable data = this.getListaDeBase();
            foreach (DataRow rolBase in data.Rows)
            {
                EstadoModel rolModel = new EstadoModel(rolBase);
                lista.Add(rolModel);
            }
            return lista;
        }

        public override string getProcedureEncontrarPorId()
        {
            return "Buscar_Estado_Id";
        }

        public override string getProcedureListar()
        {
            return "Listar_Estado";
        }

        public override EstadoModel getModeloBasico(DataRow fila)
        {
            return new EstadoModel(fila);
        }

        protected override string getProcedureCrearBasica()
        {
            throw new NotImplementedException();
        }
    }
}
