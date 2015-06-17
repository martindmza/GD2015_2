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

        public EstadoModel dameTuModelo(Decimal id)
        {
            List<EstadoModel> lista = new List<EstadoModel>();
            DataTable data = this.getBasicaDeBasePorID(id);
            foreach (DataRow paisBase in data.Rows)
            {
                EstadoModel rolModel = new EstadoModel(paisBase);
                lista.Add(rolModel);
            }
            if (lista.Count > 0)
            {
                return lista.First();
            }
            return null;
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
    }
}
