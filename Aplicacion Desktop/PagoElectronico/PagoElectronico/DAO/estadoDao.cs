using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace DAO
{
    class estadoDao
    {
        public List<EstadoModel> getEstados()
        {

            List<EstadoModel> estados = new List<EstadoModel>();
            EstadoModel e1 = new EstadoModel(1, "abierta");
            EstadoModel e2 = new EstadoModel(2, "cerrada");

            estados.Add(e1);
            estados.Add(e1);
            return estados;
        }

        public EstadoModel getEstadoById(UInt32 id)
        {

            List<EstadoModel> estados = new List<EstadoModel>();
            EstadoModel e1 = new EstadoModel(1, "abierta");
            EstadoModel e2 = new EstadoModel(2, "cerrada");

            estados.Add(e1);
            estados.Add(e1);
            return estados[(int)id];
        }
    }
}
