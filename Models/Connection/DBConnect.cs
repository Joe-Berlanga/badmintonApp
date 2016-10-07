using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.Configuration;


namespace Models.Connection
{
    public class DBConnect: IDisposable
    {

        bool disposed;

        private MySqlConnection connection;

        public DBConnect(string connectionName)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ToString();
            connection = new MySqlConnection(connectionString);
        }

        public MySqlConnection GetConnection()
        {
            connection.Open();
            return connection;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    connection.Close();
                }
            }
            
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
