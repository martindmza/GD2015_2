using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace DAO
{
    class CuentaDao
    {

        public List<CuentaModel> getCuentas()
        {

            List<CuentaModel> cuentas = new List<CuentaModel>();

            PaisModel p1 = new PaisModel(1, "Argentina", "Argentino");
            PaisModel p2 = new PaisModel(2, "Chile", "Chileno");
            PaisModel p3 = new PaisModel(3, "Uruguay", "Uruguayo");
            PaisModel p4 = new PaisModel(4, "Paraguay", "Paraguayo");
            PaisModel p5 = new PaisModel(5, "Perú", "Peruano");
            CuentaTipoModel oro = new CuentaTipoModel(1, "oro", 10, 1000);
            CuentaTipoModel plata = new CuentaTipoModel(2, "plata", 10, 500);
            CuentaTipoModel bronce = new CuentaTipoModel(3, "bronce", 10, 200);
            CuentaTipoModel gratarola = new CuentaTipoModel(4, "gratarola", 10, 0);
            EstadoModel e1 = new EstadoModel(1, "abierta");
            EstadoModel e2 = new EstadoModel(2, "cerrada");
            ClienteModel cliente = new ClienteModel(1,"Amaya","Martin");
            ClienteModel cliente2 = new ClienteModel(1, "Pepe", "Hongo");

            CuentaModel c1 = new CuentaModel(1, p1, oro, 1, "dolar", e1, new DateTime(2000, 1, 1), new DateTime(2005, 1, 1), cliente);
            CuentaModel c2 = new CuentaModel(2, p2, plata, 1, "dolar", e2, new DateTime(1999, 1, 1), new DateTime(2001, 1, 1), cliente);
            CuentaModel c3 = new CuentaModel(3, p3, bronce, 1, "dolar", e1, new DateTime(1998, 1, 1), new DateTime(2003, 1, 1), cliente);
            CuentaModel c4 = new CuentaModel(4, p4, gratarola, 1, "dolar", e2, new DateTime(1996, 1, 1), new DateTime(2010, 1, 1), cliente);
            CuentaModel c5 = new CuentaModel(5, p1, oro, 1, "dolar", e1, new DateTime(2000, 1, 1), new DateTime(2005, 1, 1), cliente2);
            CuentaModel c6 = new CuentaModel(6, p2, plata, 1, "dolar", e2, new DateTime(1999, 1, 1), new DateTime(2001, 1, 1), cliente2);
            CuentaModel c7 = new CuentaModel(7, p3, bronce, 1, "dolar", e1, new DateTime(1998, 1, 1), new DateTime(2003, 1, 1), cliente2);
            CuentaModel c8 = new CuentaModel(8, p4, gratarola, 1, "dolar", e2, new DateTime(1996, 1, 1), new DateTime(2010, 1, 1), cliente2);

            c1.saldo = 15000;
            c2.saldo = 90000;

            cuentas.Add(c1);
            cuentas.Add(c2);
            cuentas.Add(c3);
            cuentas.Add(c4);
            cuentas.Add(c5);
            cuentas.Add(c6);
            cuentas.Add(c7);
            cuentas.Add(c8);

            return cuentas;
        }


        public List<CuentaModel> getCuentasByCliente(ClienteModel cliente) {

            List<CuentaModel> cuentas = new List<CuentaModel>();

            PaisModel p1 = new PaisModel(1,"Argentina","Argentino");
            PaisModel p2 = new PaisModel(2, "Chile", "Chileno");
            PaisModel p3 = new PaisModel(3, "Uruguay", "Uruguayo");
            PaisModel p4 = new PaisModel(4, "Paraguay", "Paraguayo");
            PaisModel p5 = new PaisModel(5, "Perú", "Peruano");
            CuentaTipoModel oro = new CuentaTipoModel(1, "oro", 10, 1000);
            CuentaTipoModel plata = new CuentaTipoModel(2, "plata", 10, 500);
            CuentaTipoModel bronce = new CuentaTipoModel(3, "bronce", 10, 200);
            CuentaTipoModel gratarola = new CuentaTipoModel(4, "gratarola", 10, 0);
            EstadoModel e1 = new EstadoModel(1, "abierta");
            EstadoModel e2 = new EstadoModel(2, "cerrada");

            CuentaModel c1 = new CuentaModel(1, p1, oro, 1, "dolar", e1, new DateTime(2000, 1, 1), new DateTime(2005, 1, 1), cliente);
            CuentaModel c2 = new CuentaModel(2, p2, plata, 1, "dolar", e2, new DateTime(1999, 1, 1), new DateTime(2001, 1, 1), cliente);
            CuentaModel c3 = new CuentaModel(3, p3, bronce, 1, "dolar", e1, new DateTime(1998, 1, 1), new DateTime(2003, 1, 1), cliente);
            CuentaModel c4 = new CuentaModel(4, p4, gratarola, 1, "dolar", e2, new DateTime(1996, 1, 1), new DateTime(2000, 1, 1), cliente);
            
            c1.saldo = 15000;
            c2.saldo = 90000;

            cuentas.Add(c1);
            cuentas.Add(c2);
            cuentas.Add(c3);
            cuentas.Add(c4);

            return cuentas;
        }

        public List<CuentaTipoModel> getCuentaTypes()
        {
            List<CuentaTipoModel> tipos = new List<CuentaTipoModel>();

            CuentaTipoModel t1 = new CuentaTipoModel(1, "oro", 10, 1000);
            CuentaTipoModel t2 = new CuentaTipoModel(2, "plata", 10, 500);
            CuentaTipoModel t3 = new CuentaTipoModel(3, "bronce", 10, 200);
            CuentaTipoModel t4 = new CuentaTipoModel(4, "gratarola", 10, 0);

            tipos.Add(t1);
            tipos.Add(t2);
            tipos.Add(t3);
            tipos.Add(t4);

            return tipos;
        }

        public CuentaModel addNewCuenta(CuentaModel cuenta)
        {
            cuenta.id = 99;
            return cuenta;
        }

        public CuentaModel updateCuenta(CuentaModel cuenta)
        {
            //retorna un clienteModel por si al hacer update, algun trigger o SP hace algo sobre el cliente
            return cuenta;
        }

        public CuentaModel unsubscribeCuenta(CuentaModel cuenta)
        {
            cuenta.habilitado = false;
            return cuenta;
        }
    }
}
