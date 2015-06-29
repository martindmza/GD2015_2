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
using System.Data.SqlClient;

namespace DAO
{
    public class UserDao: BasicaDAO<UserModel>
    {   
        public UserDao() {
        }

        //-----------------------------------------------------------------------------------------------------------------
        public UserModel loguin(String usuario, String password) {
            String passwordHash = hash(password);
            DataTable dt = new DataTable();
            SqlCommand command = InitializeConnection("Login");

            command.Parameters.Add("@Usuario", System.Data.SqlDbType.NVarChar, 50).Value = usuario;
            command.Parameters.Add("@Pass", System.Data.SqlDbType.NVarChar, 100).Value = passwordHash;
            var pOut = command.Parameters.Add("@Respuesta", SqlDbType.Decimal);
            var pOut2 = command.Parameters.Add("@RespuestaMensaje", SqlDbType.NVarChar, 255);
            pOut.Direction = ParameterDirection.Output;
            pOut2.Direction = ParameterDirection.Output;

            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            Decimal value = Convert.IsDBNull(pOut.Value) ? 0 : (Decimal)(pOut.Value);
            String mensaje = Convert.IsDBNull(pOut2.Value) ? null : (string)pOut2.Value;

            if (value > 0)
            {
                return new UserDao().dameTuModelo(value.ToString());
            }
            else {
                MessageBox.Show(value.ToString(), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return null;
            }
            
        }
        //-----------------------------------------------------------------------------------------------------------------

        //--------------------------------------------------------------------
        public static string hash(string input)
        {

            System.Security.Cryptography.SHA256 sha256 = new System.Security.Cryptography.SHA256Managed();
            byte[] sha256Bytes = System.Text.Encoding.Default.GetBytes(input);
            byte[] cryString = sha256.ComputeHash(sha256Bytes);
            string resultEncriptado = string.Empty;
            for (int i = 0; i < cryString.Length; i++)
            {
                resultEncriptado += cryString[i].ToString("X");
            }
            return resultEncriptado;
        }
        //--------------------------------------------------------------------

        public override UserModel getModeloBasico(DataRow fila)
        {
            return new UserModel(fila);
        }

        public override string getProcedureEncontrarPorId()
        {
            return "Buscar_User_ID";
        }

        public override string getProcedureListar()
        {
            return "Listar_User";
        }

        protected override string getProcedureCrearBasica()
        {
            return "Crear_User";
        }
    }
}
