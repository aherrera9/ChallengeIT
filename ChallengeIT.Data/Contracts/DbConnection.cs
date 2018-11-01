using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeIT.Data.Contracts
{
    class DbConnection
    {
        public SqlConnection GetDbConnection()
        {            
            string connectionString;
            SqlConnection connection;

            connectionString = @"Data Source=W02879;Initial Catalog=ChallengeItDb;User ID=sa;Password=Passw0rd";
            connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
