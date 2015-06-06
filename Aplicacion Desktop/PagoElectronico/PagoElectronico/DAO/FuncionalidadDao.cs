using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace DAO
{
    class FuncionalidadDao
    {
        public List<FuncionalidadModel> getFuncionalidades()
        {

            List<FuncionalidadModel> funcionalidades = new List<FuncionalidadModel>();
            FuncionalidadModel func1 = new FuncionalidadModel(1, "funcionalidad1", true);
            FuncionalidadModel func2 = new FuncionalidadModel(2, "funcionalidad2", true);
            FuncionalidadModel func3 = new FuncionalidadModel(3, "funcionalidad3", true);
            FuncionalidadModel func4 = new FuncionalidadModel(4, "funcionalidad4", true);
            FuncionalidadModel func5 = new FuncionalidadModel(5, "funcionalidad5", true);
            FuncionalidadModel func6 = new FuncionalidadModel(6, "funcionalidad6", true);
            FuncionalidadModel func7 = new FuncionalidadModel(7, "funcionalidad7", true);
            FuncionalidadModel func8 = new FuncionalidadModel(8, "funcionalidad8", true);
            FuncionalidadModel func9 = new FuncionalidadModel(9, "funcionalidad9", true);
            FuncionalidadModel func10 = new FuncionalidadModel(10, "funcionalidad10", true);
            FuncionalidadModel func11 = new FuncionalidadModel(11, "funcionalidad11", true);
            FuncionalidadModel func12 = new FuncionalidadModel(12, "funcionalidad12", true);

            funcionalidades.Add(func1);
            funcionalidades.Add(func2);
            funcionalidades.Add(func3);
            funcionalidades.Add(func4);
            funcionalidades.Add(func5);
            funcionalidades.Add(func6);
            funcionalidades.Add(func7);
            funcionalidades.Add(func8);
            funcionalidades.Add(func9);
            funcionalidades.Add(func10);
            funcionalidades.Add(func11);
            funcionalidades.Add(func12);

            return funcionalidades;
        }
        //-------------------------------------------------------------------------------------------------------------


    }
}
