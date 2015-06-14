using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyExceptions;
using Models;
using ABM;

namespace DAO
{
    public class ClienteDao
    {

        public ClienteDao() 
        {
            //this.connector = Conexion.getInstance();
        }

        public List<ClienteModel> getClients()
        {

            List<ClienteModel> clientes = new List<ClienteModel>();

            PaisModel p1 = new PaisModel(1, "Argentina", "Argentino");
            PaisModel p2 = new PaisModel(2, "Chile", "Chileno");
            PaisModel p3 = new PaisModel(3, "Uruguay", "Uruguayo");
            PaisModel p4 = new PaisModel(4, "Paraguay", "Paraguayo");
            PaisModel p5 = new PaisModel(5, "Perú", "Peruano");
            LocalidadModel l1 = new LocalidadModel(1, "Haedo");
            LocalidadModel l2 = new LocalidadModel(2, "Moron");
            LocalidadModel l3 = new LocalidadModel(3, "Liniers");
            LocalidadModel l4 = new LocalidadModel(4, "Palermo");
            LocalidadModel l5 = new LocalidadModel(5, "Belgrano");

            DocumentoModel d1 = new DocumentoModel(1, "DNI", 34284433);
            DocumentoModel d2 = new DocumentoModel(1, "DNI", 34281111);
            DocumentoModel d3 = new DocumentoModel(2, "Pasaporte", 1231231236);
            DocumentoModel d4 = new DocumentoModel(3, "Pasaporte",321312123);
            DocumentoModel d5 = new DocumentoModel(2, "Cedula", 34284433);
            DocumentoModel d6 = new DocumentoModel(3, "Cedula", 34284431);

            /*
            String apellido, String nombre, DocumentoModel documento,
            DateTime nacimiento, String email, PaisModel nacionalidad, String direccionCalle, UInt32 direccionNumeroCalle,
            UInt32 direccionPiso, String direccionDepto, LocalidadModel localidad, PaisModel pais
            */

            ClienteModel c1 = new ClienteModel(1, "Amaya", "Hector", d1,new DateTime(1995,1,1),"martin.d.mza@gmail.com",p1, "Calle1", 111, 1, "A", l1, p2);
            ClienteModel c2 = new ClienteModel(2, "Lopez", "Maxi", d2, new DateTime(1980, 1, 1), "maxi.d.mza@gmail.com", p2, "Calle2", 221, 1, "B", l2, p3);
            ClienteModel c3 = new ClienteModel(3, "Vega", "Eric", d3, new DateTime(1970, 1, 1), "1.d.mza@gmail.com", p3, "Calle3", 331, 1, "C", l3, p4);
            ClienteModel c4 = new ClienteModel(4, "Perez", "Ana", d4, new DateTime(1966, 1, 1), "2.d.mza@gmail.com", p4, "Calle4",441, 1, "D", l1, p5);
            ClienteModel c5 = new ClienteModel(5, "Martinez", "Juan", d5, new DateTime(1955, 1, 1), "3.d.mza@gmail.com", p5, "Calle5", 551, 1, "E", l2, p1);
            ClienteModel c6 = new ClienteModel(6, "Pastorino", "Oscar", d6, new DateTime(1910, 1, 1), "4.d.mza@gmail.com", p1, "Calle6", 661, 1, "F", l3, p2);


            clientes.Add(c1);
            clientes.Add(c2);
            clientes.Add(c3);
            clientes.Add(c4);
            clientes.Add(c5);
            clientes.Add(c6);
 

            return clientes;
        }

        public ClienteModel getClienteById(UInt32 id)
        {
            List<ClienteModel> clientes = new List<ClienteModel>();

            PaisModel p1 = new PaisModel(1, "Argentina", "Argentino");
            PaisModel p2 = new PaisModel(2, "Chile", "Chileno");
            PaisModel p3 = new PaisModel(3, "Uruguay", "Uruguayo");
            PaisModel p4 = new PaisModel(4, "Paraguay", "Paraguayo");
            PaisModel p5 = new PaisModel(5, "Perú", "Peruano");
            LocalidadModel l1 = new LocalidadModel(1, "Haedo");
            LocalidadModel l2 = new LocalidadModel(2, "Moron");
            LocalidadModel l3 = new LocalidadModel(3, "Liniers");
            LocalidadModel l4 = new LocalidadModel(4, "Palermo");
            LocalidadModel l5 = new LocalidadModel(5, "Belgrano");

            DocumentoModel d1 = new DocumentoModel(1, "DNI", 34284433);
            DocumentoModel d2 = new DocumentoModel(1, "DNI", 34281111);
            DocumentoModel d3 = new DocumentoModel(2, "Pasaporte", 1231231236);
            DocumentoModel d4 = new DocumentoModel(3, "Pasaporte", 321312123);
            DocumentoModel d5 = new DocumentoModel(2, "Cedula", 34284433);
            DocumentoModel d6 = new DocumentoModel(3, "Cedula", 34284431);

            ClienteModel c1 = new ClienteModel(1, "Amaya", "Hector", d1, new DateTime(1995, 1, 1), "martin.d.mza@gmail.com", p1, "Calle1", 111, 1, "A", l1, p2);
            ClienteModel c2 = new ClienteModel(2, "Lopez", "Maxi", d2, new DateTime(1980, 1, 1), "maxi.d.mza@gmail.com", p2, "Calle2", 221, 1, "B", l2, p3);
            ClienteModel c3 = new ClienteModel(3, "Vega", "Eric", d3, new DateTime(1970, 1, 1), "1.d.mza@gmail.com", p3, "Calle3", 331, 1, "C", l3, p4);
            ClienteModel c4 = new ClienteModel(4, "Perez", "Ana", d4, new DateTime(1966, 1, 1), "2.d.mza@gmail.com", p4, "Calle4", 441, 1, "D", l1, p5);
            ClienteModel c5 = new ClienteModel(5, "Martinez", "Juan", d5, new DateTime(1955, 1, 1), "3.d.mza@gmail.com", p5, "Calle5", 551, 1, "E", l2, p1);
            ClienteModel c6 = new ClienteModel(6, "Pastorino", "Oscar", d6, new DateTime(1910, 1, 1), "4.d.mza@gmail.com", p1, "Calle6", 661, 1, "F", l3, p2);


            clientes.Add(c1);
            clientes.Add(c2);
            clientes.Add(c3);
            clientes.Add(c4);
            clientes.Add(c5);
            clientes.Add(c6);

            int value = (int)id;

            return clientes[value];
        }

        public List<ClienteModel> getClientsByFilters(ClienteFiltros filtros)
        {

            List<ClienteModel> clientes = new List<ClienteModel>();

            PaisModel p1 = new PaisModel(1, "Argentina", "Argentino");
            PaisModel p2 = new PaisModel(2, "Chile", "Chileno");
            PaisModel p3 = new PaisModel(3, "Uruguay", "Uruguayo");
            PaisModel p4 = new PaisModel(4, "Paraguay", "Paraguayo");
            PaisModel p5 = new PaisModel(5, "Perú", "Peruano");
            LocalidadModel l1 = new LocalidadModel(1, "Haedo");
            LocalidadModel l2 = new LocalidadModel(2, "Moron");
            LocalidadModel l3 = new LocalidadModel(3, "Liniers");
            LocalidadModel l4 = new LocalidadModel(4, "Palermo");
            LocalidadModel l5 = new LocalidadModel(5, "Belgrano");
            DocumentoModel d1 = new DocumentoModel(1, "DNI", 34284433);
            DocumentoModel d2 = new DocumentoModel(1, "DNI", 34281111);
            DocumentoModel d3 = new DocumentoModel(2, "Pasaporte", 1231231236);
            DocumentoModel d4 = new DocumentoModel(3, "Pasaporte", 321312123);
            DocumentoModel d5 = new DocumentoModel(2, "Cedula", 34284433);
            DocumentoModel d6 = new DocumentoModel(3, "Cedula", 34284431);

            ClienteModel c1 = new ClienteModel(1, "Amaya", "Hector", d1, new DateTime(1995, 1, 1), "martin.d.mza@gmail.com", p1, "Calle1", 111, 1, "A", l1, p2);
            ClienteModel c2 = new ClienteModel(2, "Lopez", "Maxi", d2, new DateTime(1980, 1, 1), "maxi.d.mza@gmail.com", p2, "Calle2", 221, 1, "B", l2, p3);
            ClienteModel c3 = new ClienteModel(3, "Vega", "Eric", d3, new DateTime(1970, 1, 1), "1.d.mza@gmail.com", p3, "Calle3", 331, 1, "C", l3, p4);
            ClienteModel c4 = new ClienteModel(4, "Perez", "Ana", d4, new DateTime(1966, 1, 1), "2.d.mza@gmail.com", p4, "Calle4", 441, 1, "D", l1, p5);
            ClienteModel c5 = new ClienteModel(5, "Martinez", "Juan", d5, new DateTime(1955, 1, 1), "3.d.mza@gmail.com", p5, "Calle5", 551, 1, "E", l2, p1);
            ClienteModel c6 = new ClienteModel(6, "Pastorino", "Oscar", d6, new DateTime(1910, 1, 1), "4.d.mza@gmail.com", p1, "Calle6", 661, 1, "F", l3, p2);


            clientes.Add(c1);
            //clientes.Add(c2);
            clientes.Add(c3);
            clientes.Add(c4);
            //clientes.Add(c5);
            //clientes.Add(c6);


            return clientes;
        }

        public ClienteModel addNewCliente(ClienteModel cliente)
        {
            cliente.id = 99;
            return cliente;
        }

        public ClienteModel updateCliente(ClienteModel cliente){
            //retorna un clienteModel por si al hacer update, algun trigger o SP hace algo sobre el cliente
            return cliente;
        }

        public ClienteModel unsubscribeCliente(ClienteModel cliente)
        {
            cliente.habilitado = false;
            return cliente;
        }
    }
}
