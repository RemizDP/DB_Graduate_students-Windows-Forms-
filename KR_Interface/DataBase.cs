using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace KR_Interface
{
    public class DataBase
    {
        SqlConnection connectionString = new SqlConnection(@"Data Source=DMITRLAPTOP;Initial Catalog=KR_DB;Integrated Security=True");

        public void OpenConnection()
        {
            if(connectionString.State == System.Data.ConnectionState.Closed) {
                connectionString.Open();
            }
        }

        public void CloseConnection()
        {
            if (connectionString.State == System.Data.ConnectionState.Open)
            {
                connectionString.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            return connectionString;
        }
    }
}
