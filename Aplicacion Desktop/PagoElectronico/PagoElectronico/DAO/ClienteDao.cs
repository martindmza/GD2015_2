using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyExceptions;
using Models;

namespace DAO
{
    public class ClienteDao
    {

        public ClienteDao()
        {
            //this.connector = Conexion.getInstance();
        }

        public List<ClienteModel> getClients() {

            List<ClienteModel> clientes = new List<ClienteModel>();

            UserModel user = new UserModel(1,"admin","admin");

            ClienteModel c1 = new ClienteModel(1, "martin", "Amaya", 1, 34284433, 1,"Calle1",111,1,"A",DateTime.Today, "martin.d.mza@gmail.com","01110",1,1,user);
            ClienteModel c2 = new ClienteModel(2, "marcos", "Araya", 1, 34284434, 1,"Calle2", 222, 2, "A", DateTime.Today, "marcos.d.mza@gmail.com", "01111",1,1, user);
            ClienteModel c3 = new ClienteModel(3, "maxi", "Lopez", 1, 34284435,  1, "Calle3", 333, 3, "B", DateTime.Today, "maxi@gmail.com", "01112",1,1, user);
            ClienteModel c4 = new ClienteModel(4, "juan", "Gonzales", 1, 34284436, 1, "Calle4", 444, 4, "F", DateTime.Today, "juan@gmail.com", "01113",1,1, user);
            ClienteModel c5 = new ClienteModel(5, "franco", "Perez", 1, 34284437, 1, "Calle5", 455, 5, "C", DateTime.Today, "frnaco@gmail.com", "01114", 1, 1, user);
            ClienteModel c6 = new ClienteModel(6, "Ana", "Dominguez", 1, 34284438, 1, "Calle6", 345, 6, "A", DateTime.Today, "Ana@gmail.com", "01115", 1, 1, user);
            ClienteModel c7 = new ClienteModel(7, "Julia", "Martin", 1, 34284439, 1, "Calle7", 3453, 8, "H", DateTime.Today, "Julia@gmail.com", "01116", 1, 1, user);
            ClienteModel c8 = new ClienteModel(8, "Daniela", "Arjona", 1, 34284411, 1, "Calle8", 3654, 11, "A", DateTime.Today, "Daniela@gmail.com", "01117", 1, 1, user);
            ClienteModel c9 = new ClienteModel(9, "Andres", "Casetta", 1, 34244433, 1, "Calle9", 543, 33, "G", DateTime.Today, "andres@gmail.com", "01118", 1, 1, user);
            ClienteModel c10 = new ClienteModel(10, "Maximo", "Cajelli", 1, 33284433, 1, "Calle10", 378, 12, "C", DateTime.Today, "maximo@gmail.com", "01119", 1, 1, user);

            clientes.Add(c1);
            clientes.Add(c2);
            clientes.Add(c3);
            clientes.Add(c4);
            clientes.Add(c5);
            clientes.Add(c6);
            clientes.Add(c7);
            clientes.Add(c8);
            clientes.Add(c9);
            clientes.Add(c10);

            return clientes;
        }

        public ClienteModel getClientsById(Decimal id)
        {

            List<ClienteModel> clientes = new List<ClienteModel>();

            UserModel user = new UserModel(1, "admin", "admin");

            ClienteModel c1 = new ClienteModel(1, "martin", "Amaya", 1, 34284433, 1, "Calle1", 111, 1, "A", DateTime.Today, "martin.d.mza@gmail.com", "01110", 1, 1, user);
            ClienteModel c2 = new ClienteModel(2, "marcos", "Araya", 1, 34284434, 1, "Calle2", 222, 2, "A", DateTime.Today, "marcos.d.mza@gmail.com", "01111", 1, 1, user);
            ClienteModel c3 = new ClienteModel(3, "maxi", "Lopez", 1, 34284435, 1, "Calle3", 333, 3, "B", DateTime.Today, "maxi@gmail.com", "01112", 1, 1, user);
            ClienteModel c4 = new ClienteModel(4, "juan", "Gonzales", 1, 34284436, 1, "Calle4", 444, 4, "F", DateTime.Today, "juan@gmail.com", "01113", 1, 1, user);
            ClienteModel c5 = new ClienteModel(5, "franco", "Perez", 1, 34284437, 1, "Calle5", 455, 5, "C", DateTime.Today, "frnaco@gmail.com", "01114", 1, 1, user);
            ClienteModel c6 = new ClienteModel(6, "Ana", "Dominguez", 1, 34284438, 1, "Calle6", 345, 6, "A", DateTime.Today, "Ana@gmail.com", "01115", 1, 1, user);
            ClienteModel c7 = new ClienteModel(7, "Julia", "Martin", 1, 34284439, 1, "Calle7", 3453, 8, "H", DateTime.Today, "Julia@gmail.com", "01116", 1, 1, user);
            ClienteModel c8 = new ClienteModel(8, "Daniela", "Arjona", 1, 34284411, 1, "Calle8", 3654, 11, "A", DateTime.Today, "Daniela@gmail.com", "01117", 1, 1, user);
            ClienteModel c9 = new ClienteModel(9, "Andres", "Casetta", 1, 34244433, 1, "Calle9", 543, 33, "G", DateTime.Today, "andres@gmail.com", "01118", 1, 1, user);
            ClienteModel c10 = new ClienteModel(10, "Maximo", "Cajelli", 1, 33284433, 1, "Calle10", 378, 12, "C", DateTime.Today, "maximo@gmail.com", "01119", 1, 1, user);

            clientes.Add(c1);
            clientes.Add(c2);
            clientes.Add(c3);
            clientes.Add(c4);
            clientes.Add(c5);
            clientes.Add(c6);
            clientes.Add(c7);
            clientes.Add(c8);
            clientes.Add(c9);
            clientes.Add(c10);

            foreach (ClienteModel cliente in clientes)
            {
                if (cliente.id == id) {
                    return cliente;
                }
            }
            return null;
        }

        public List<ClienteModel> getClientsByName(String nombre)
        {

            List<ClienteModel> clientes = new List<ClienteModel>();

            UserModel user = new UserModel(1, "admin", "admin");

            ClienteModel c1 = new ClienteModel(1, "martin", "Amaya", 1, 34284433, 1, "Calle1", 111, 1, "A", DateTime.Today, "martin.d.mza@gmail.com", "01110", 1, 1, user);
            ClienteModel c2 = new ClienteModel(2, "marcos", "Araya", 1, 34284434, 1, "Calle2", 222, 2, "A", DateTime.Today, "marcos.d.mza@gmail.com", "01111", 1, 1, user);
            ClienteModel c3 = new ClienteModel(3, "maxi", "Lopez", 1, 34284435, 1, "Calle3", 333, 3, "B", DateTime.Today, "maxi@gmail.com", "01112", 1, 1, user);
            ClienteModel c4 = new ClienteModel(4, "juan", "Gonzales", 1, 34284436, 1, "Calle4", 444, 4, "F", DateTime.Today, "juan@gmail.com", "01113", 1, 1, user);
            ClienteModel c5 = new ClienteModel(5, "franco", "Perez", 1, 34284437, 1, "Calle5", 455, 5, "C", DateTime.Today, "frnaco@gmail.com", "01114", 1, 1, user);
            ClienteModel c6 = new ClienteModel(6, "Ana", "Dominguez", 1, 34284438, 1, "Calle6", 345, 6, "A", DateTime.Today, "Ana@gmail.com", "01115", 1, 1, user);
            ClienteModel c7 = new ClienteModel(7, "Julia", "Martin", 1, 34284439, 1, "Calle7", 3453, 8, "H", DateTime.Today, "Julia@gmail.com", "01116", 1, 1, user);
            ClienteModel c8 = new ClienteModel(8, "Daniela", "Arjona", 1, 34284411, 1, "Calle8", 3654, 11, "A", DateTime.Today, "Daniela@gmail.com", "01117", 1, 1, user);
            ClienteModel c9 = new ClienteModel(9, "Andres", "Casetta", 1, 34244433, 1, "Calle9", 543, 33, "G", DateTime.Today, "andres@gmail.com", "01118", 1, 1, user);
            ClienteModel c10 = new ClienteModel(10, "Maximo", "Cajelli", 1, 33284433, 1, "Calle10", 378, 12, "C", DateTime.Today, "maximo@gmail.com", "01119", 1, 1, user);

            clientes.Add(c1);
            clientes.Add(c2);
            clientes.Add(c3);
            clientes.Add(c4);
            clientes.Add(c5);
            clientes.Add(c6);
            clientes.Add(c7);
            clientes.Add(c8);
            clientes.Add(c9);
            clientes.Add(c10);

            foreach (ClienteModel cliente in clientes)
            {
                if ( ! cliente.nombre.Equals(nombre))
                {
                    clientes.Remove(cliente);
                }
            }
            return clientes;
        }

    }
}
