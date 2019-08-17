using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ShareBooks.Repository.Utilities
{
    public class ConnectionFactory
    {
        public SqlConnection GetConnection( string _sqlConnection )
        {
            SqlConnection connection = new SqlConnection( _sqlConnection );

            connection.Open( );
            
            return connection;
        }
    }
}
