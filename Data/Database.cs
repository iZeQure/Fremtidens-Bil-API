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
        private string connectionString = $"Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=CybertruckCentral; Integrated Security=true;";

        public SqlConnection Connection { get { return connection; } set { connection = value; } }

        private string ConnectionString { get { return connectionString; } set { connectionString = value; } }


        public SqlConnection GetConn()
        {
            Connection = new SqlConnection(ConnectionString);
            return Connection;

        }

        private Database()
        {
            try
            {
                
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
