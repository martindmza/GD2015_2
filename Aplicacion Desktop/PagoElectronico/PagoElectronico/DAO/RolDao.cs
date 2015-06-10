using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace DAO
{
    public class RolDao
    {
        public List<RolModel> rolesList = new List<RolModel>();

        //-------------------------------------------------------------------------------------------------------------
        public List<RolModel> getRoles()
        {   
            RolModel rol1 = new RolModel(1, "Administrador", true);
            RolModel rol2 = new RolModel(2, "Cliente", true);
            RolModel rol3 = new RolModel(3, "Nuevo", true);
            RolModel rol4 = new RolModel(4, "Empresa", true);
            rolesList.Add(rol1);
            rolesList.Add(rol2);
            rolesList.Add(rol3);
            rolesList.Add(rol4);
            //List<FuncionalidadModel> funcionalidades1 = new List<FuncionalidadModel>();
            //List<FuncionalidadModel> funcionalidades2 = new List<FuncionalidadModel>();

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


            rol1.funcionalidades.Add(func1);
            rol1.funcionalidades.Add(func2);
            rol1.funcionalidades.Add(func3);
            rol1.funcionalidades.Add(func4);
            rol1.funcionalidades.Add(func5);
            rol1.funcionalidades.Add(func6);
            rol1.funcionalidades.Add(func7);
            rol1.funcionalidades.Add(func8);
            rol1.funcionalidades.Add(func9);
            rol1.funcionalidades.Add(func10);
            rol1.funcionalidades.Add(func11);
            rol1.funcionalidades.Add(func12);

            rol2.funcionalidades.Add(func1);
            rol2.funcionalidades.Add(func2);
            rol2.funcionalidades.Add(func3);
            rol2.funcionalidades.Add(func4);
            rol2.funcionalidades.Add(func10);
            rol2.funcionalidades.Add(func11);
            rol2.funcionalidades.Add(func12);

            rol3.funcionalidades.Add(func1);
            rol3.funcionalidades.Add(func2);
            rol3.funcionalidades.Add(func3);

            rol4.funcionalidades.Add(func1);
            rol4.funcionalidades.Add(func2);
            rol4.funcionalidades.Add(func3);
            rol4.funcionalidades.Add(func4);
            rol4.funcionalidades.Add(func5);
            rol4.funcionalidades.Add(func6);


            return rolesList;
        }
        //-------------------------------------------------------------------------------------------------------------


        //-------------------------------------------------------------------------------------------------------------
        public List<RolModel> getRolesByUser(Decimal userId)
        {

            List<RolModel> rolesList = new List<RolModel>();
            RolModel rol1 = new RolModel(1, "Administrador", true);
            RolModel rol2 = new RolModel(2, "Cliente", true);
            RolModel rol3 = new RolModel(3, "Empresa", true);
            rolesList.Add(rol1);
            rolesList.Add(rol2);
            rolesList.Add(rol3);
            //List<FuncionalidadModel> funcionalidades1 = new List<FuncionalidadModel>();
            //List<FuncionalidadModel> funcionalidades2 = new List<FuncionalidadModel>();

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
           

            rol1.funcionalidades.Add(func1);
            rol1.funcionalidades.Add(func2);
            rol1.funcionalidades.Add(func3);
            rol1.funcionalidades.Add(func4);
            rol1.funcionalidades.Add(func5);
            rol1.funcionalidades.Add(func6);
            rol1.funcionalidades.Add(func7);
            rol1.funcionalidades.Add(func8);
            rol1.funcionalidades.Add(func9);
            rol1.funcionalidades.Add(func10);
            rol1.funcionalidades.Add(func11);
            rol1.funcionalidades.Add(func12);

            rol2.funcionalidades.Add(func1);
            rol2.funcionalidades.Add(func2);
            rol2.funcionalidades.Add(func3);
            rol2.funcionalidades.Add(func4);
            rol2.funcionalidades.Add(func10);
            rol2.funcionalidades.Add(func11);
            rol2.funcionalidades.Add(func12);

            rol3.funcionalidades.Add(func1);
            rol3.funcionalidades.Add(func2);
            rol3.funcionalidades.Add(func3);
            

            return rolesList;
        }
        //-------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------
        public RolModel createRol(RolModel rol){
            rol.habilitado = true;
            rol.id = 99;
            return rol;
        }
        //-------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------
        public RolModel updateRol(RolModel rol)
        {
            return rol;
        }
        //-------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------
        public RolModel disableRol(RolModel rol)
        {
            rol.habilitado = false;
            return rol;
        }
        //-------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------
        public void RolAbmChanges( List<RolModel> rolList)
        {
            
        }
        //-------------------------------------------------------------------------------------------------------------

    }
}
