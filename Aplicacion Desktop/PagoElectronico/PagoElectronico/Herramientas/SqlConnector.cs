using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace PagoElectronico.Herramientas

{
    public class SqlConnector
    {
        static SqlConnector instance = null;

        private SqlConnection conn;
        private SqlConnection Conn
        {
            get { return this.conn; }
            set { this.conn = value; }
        }

        private string error;
        public string Error
        {
            get { return this.error; }
            set { this.error = value; }
        }

        private SqlConnector()
        {
            string configvalue1 = ConfigurationSettings.AppSettings["url"];
            this.Conn = new SqlConnection(configvalue1);
            this.Conn.ConnectionString = configvalue1;
            this.Conn.Open();
            Console.WriteLine("ServerVersion: {0}", this.Conn.ServerVersion);
            Console.WriteLine("State: {0}", this.Conn.State);
        }

        public static SqlConnector Instance
        {
            get
            {
                if (instance == null)
                    instance = new SqlConnector();
                return instance;
            }
        }

        public DataTable executeQuery(string query)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandTimeout = 65000;

            sqlCommand.Connection = this.Conn;
            sqlCommand.CommandText = query;

            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, this.Conn);

            DataTable dataTable = new DataTable();
            dataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;

            dataAdapter.Fill(dataTable);

            return dataTable;
        }

        public void executeQueryOnly(string query)
        {
            SqlCommand com = new SqlCommand();
            com.CommandTimeout = 0;

            com.Connection = this.Conn;
            com.CommandText = query;
            com.ExecuteNonQuery();
            com.Dispose();
            com = null;
        }
        public SqlCommand getCommand()
        {
            return this.Conn.CreateCommand();
        }

        public SqlConnection getConnection()
        {
            return this.Conn;
        }

        public SqlTransaction getBeginTransaction()
        {
            return this.getConnection().BeginTransaction();
        }
        public void CerrarConexion()
        {
            this.conn.Close();
        }
    }
}
