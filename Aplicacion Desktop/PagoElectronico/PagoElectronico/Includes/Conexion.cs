using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Collections;

namespace Includes
{
    class Conexion
    {
        private static Conexion dbInstance;
        private readonly SqlConnection conexion;
        private String conectionString;

        //get singleton
        public static Conexion getInstance()
        {
            if (dbInstance == null)
            {
                dbInstance = new Conexion();
            }

            return dbInstance;
        }

        //construct
        public Conexion()
        {

            string fileName = "credentials.json";
            string path = @"C:\Users\Administrador\Desktop\Backup\FACULTAD\Gestión de Datos\2015\TP\GD2015\Aplicacion Desktop\PagoElectronico\PagoElectronico\config\";
            conectionString = "";

            //obtengo los datos de conexión a la base de datos
            try
            {
                //recorro el file de configuración
                System.IO.StreamReader file = new System.IO.StreamReader(path + fileName);
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    conectionString += line + ";";
                }
                //quito el ultimo punto y coma
                conectionString = conectionString.Remove(conectionString.Length - 1);

            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("Config file not found" + e);
                return;
            }

            try
            {
                this.conexion = new SqlConnection(conectionString);
                conexion.Open();
                conexion.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("Database conection error :" + e);
            }

        }
        //--------------------------------------------------------------------

        //--------------------------------------------------------------------
        public void conect()
        {
            this.conexion.Open();
        }
        //--------------------------------------------------------------------

        //--------------------------------------------------------------------
        public void close()
        {
            this.conexion.Close();
        }
        //--------------------------------------------------------------------

        //--------------------------------------------------------------------
        //ejecuciones SQL sin retorno
        public Boolean execute(String query)
        {
            Boolean result = false;
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader resultado = comando.ExecuteReader();
                conexion.Close();
            }

            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }

            return result;
        }
        //--------------------------------------------------------------------

        //--------------------------------------------------------------------
        //ejecuciones SQL con retorno
        public DataTable query(String query)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(query, this.conexion);  //Ejecuta la consulta

            DataTable tabla = new DataTable();
            adapter.Fill(tabla);									//abre y cierra de forma implícita la conexión
            return tabla;
        }
        //--------------------------------------------------------------------
    }
}
