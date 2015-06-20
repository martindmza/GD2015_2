using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using PagoElectronico.Herramientas;

namespace DAO
{
    public abstract class AbstractDAO
    {
        
        private SqlConnection _connection = null;
		private SqlTransaction _transaction = null;
		private bool _conTransaccion = false;

		protected AbstractDAO()
		{
		}

        protected AbstractDAO(bool conTransaccion)
		{
			_conTransaccion = conTransaccion;
		}

		public SqlTransaction Transaction
		{
			get { return _transaction; }
			set { _transaction = value; }
		}

		public SqlConnection Connection
		{
			get { return _connection; }
		}
		public SqlCommand InitializeConnection(string sp)
        {
			if (Transaction != null)
				_connection = Transaction.Connection;
			else
			{
				_connection = new SqlConnection(Config.Base.ConnectionString);
				_connection.Open();
			}

			SqlCommand command = _connection.CreateCommand();

			
			if (_conTransaccion && _transaction == null)
			{
				//Si la transaccion ya esta abierta que tome la q esta abierta
				_transaction = _connection.BeginTransaction();
			}

			command.Connection = _connection;
			command.Transaction = _transaction;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "REZAGADOS." + sp;
          
            return command;
        }

		public void RollBack()
		{
			if (_conTransaccion)
				_transaction.Rollback();
		}

		public void Commit()
		{
			if (_conTransaccion)
				Transaction.Commit();
		}
        public virtual void CerrarConexion()
        {
            _connection.Close();
        }


    }
}
