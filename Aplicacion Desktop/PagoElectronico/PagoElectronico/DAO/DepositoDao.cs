using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace DAO
{
    public class DepositoDao
    {
        public DepositoModel createDeposito(DepositoModel deposito){
            
            deposito.id = 99;
            return deposito;
        }
    }
}
