using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data;

namespace DAO
{
    public class LocalidadDAO:BasicaDAO<LocalidadModel>
    {
        public override string getProcedureEncontrarPorId()
        {
            return "Buscar_Localidad_Id";
        }

        public override string getProcedureListar()
        {
            return "Listar_Localidad";
        }

        public override LocalidadModel getModeloBasico(DataRow fila)
        {
            return new LocalidadModel(fila);
        }

        protected override string getProcedureCrearBasica()
        {
            throw new NotImplementedException();
        }
    }
}
