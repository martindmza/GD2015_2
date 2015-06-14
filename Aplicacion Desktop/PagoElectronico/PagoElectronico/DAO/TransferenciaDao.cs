using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace DAO
{
    public class TransferenciaDao
    {
        public TransferenciaModel createTransferencia(TransferenciaModel transferencia){
            transferencia.id = 99;
            return transferencia;
        }
    }
}
