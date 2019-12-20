using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Fremtidens_Bil_API.Data
{
    public class Database
    {
        private static Database instance = null;
        private SqlConnection connection;
        private string connectionString;

        public SqlConnection Connection { get { return connection; } set { connection = value; } }

        private string ConnectionString { get { return connectionString; } set { connectionString = value; } }

        private Database()
        {
            try
            {
                ConnectionString = $"Data Source=10.108.226.9; Initial Catalog=CybertruckCentral; User Id=sa; Password=Passw0rd;";
                Connection = new SqlConnection(ConnectionString);
            }            
            catch (NullReferenceException ex)
            {
                Debug.WriteLine($"No Database string provided was valid. ~ {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unexpected Error. ~ {ex.Message}");
            }
        }

        public static Database Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Database();
                }
                return instance;
            }
        }
    }
}
