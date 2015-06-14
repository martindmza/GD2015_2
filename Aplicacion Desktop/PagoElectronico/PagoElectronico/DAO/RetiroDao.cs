using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace DAO
{
    public class RetiroDao
    {
        public RetiroModel createRetiro(RetiroModel retiro) {

            retiro.chequeId = 1000;
            retiro.banco = new BancoModel(1,"Nación");
            retiro.id = 99;
            return retiro;
        } 
    }
}
