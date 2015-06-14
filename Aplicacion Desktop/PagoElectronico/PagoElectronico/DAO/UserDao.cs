using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Includes;
using System.Data;
using Models;
using System.Windows.Forms;
using System.Security.Cryptography;
using MyExceptions;

namespace DAO
{
    public class UserDao
    {
        private Conexion connector;

        public UserDao() {
            //this.connector = Conexion.getInstance();
        }

        //-----------------------------------------------------------------------------------------------------------------
        public UserModel loguin(String usuario, String password) {

            PaisModel p1 = new PaisModel(1, "Argentina", "Argentino");
            LocalidadModel l1 = new LocalidadModel(1, "Haedo");
            DocumentoModel d1 = new DocumentoModel(1, "DNI", 34284430);
            ClienteModel c1 = new ClienteModel(1, "Amaya", "Hector", d1, new DateTime(1995, 1, 1), "martin.d.mza@gmail.com", p1, "Calle1", 111, 1, "A", l1, p1);

            UserModel user = new UserModel(1,"admin","admin",true,1,c1);

            /*
            UserModel user = null;
            String passwordHash = hash(password);

            String query = "SELECT TOP 1 Id_Usuario,                             " +
                           "             Nombre,                                 " +
                           "             Contrasenia,                            " +
                           "             Habilitada,                             " +
                           "             Cantidad_Intentos_Fallidos              " +
                           "  FROM       REZAGADOS.Usuario                       " +
                           " WHERE       Nombre ='" + usuario + "'               " +
                           "   AND       Contrasenia ='" + password + "' ;       ";

            DataTable result = connector.query(query);

            //si encontró el usuario
            if (result.Rows.Count != 0)
            {
                user = new UserModel(usuario, password);
                try
                {
                    user.id = Convert.ToDecimal(result.Rows[0]["Id_Usuario"].ToString());
                    user.habilitado = Convert.ToBoolean(result.Rows[0]["Habilitada"].ToString());
                    user.intentosFallidos = Convert.ToDecimal(result.Rows[0]["Cantidad_Intentos_Fallidos"].ToString());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Error:" + e);
                }
            }
            else
            {
                throw new UserNotFoundException(user.nombre);
            }
            */
            
            return user;
        }
        //-----------------------------------------------------------------------------------------------------------------

        //--------------------------------------------------------------------
        public static string hash(string input)
        {
            SHA256 hash = SHA256.Create();

            // Convertir la cadena en un array de bytes y calcular hash
            byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Copiar cada elemento del array a un
            // StringBuilder en formato hexadecimal
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
        //--------------------------------------------------------------------
    }
}
