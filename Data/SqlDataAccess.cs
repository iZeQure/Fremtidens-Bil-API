using Fremtidens_Bil_API.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Fremtidens_Bil_API.Data
{
    /// <summary>
    /// Sql Data Access
    /// </summary>
    /// <seealso cref="Fremtidens_Bil_API.Interfaces.IDataBaseHandler" />
    public class SqlDataAccess : IDataBaseHandler
    {
        #region Attributes        
        /// <summary>
        /// The connection string
        /// </summary>
        private string connectionString;
        #endregion

        #region Properties        
        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <value>
        /// The connection string.
        /// </value>
        public string ConnectionString { get { return connectionString; } private set { connectionString = value; } }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlDataAccess"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public SqlDataAccess(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Closes the connection.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public void CloseConnection(IDbConnection connection)
        {
            SqlConnection sqlConnection = (SqlConnection)connection;

            sqlConnection.Close();
            sqlConnection.Dispose();
        }

        /// <summary>
        /// Creates the adapter.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public IDataAdapter CreateAdapter(IDbCommand command)
        {
            return new SqlDataAdapter((SqlCommand)command);
        }

        /// <summary>
        /// Creates the command.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="connection">The connection.</param>
        /// <returns></returns>
        public IDbCommand CreateCommand(string commandText, CommandType commandType, IDbConnection connection)
        {
            return new SqlCommand
            {
                CommandText = commandText,
                CommandType = commandType,
                Connection = (SqlConnection)connection
            };
        }

        /// <summary>
        /// Creates the connection.
        /// </summary>
        /// <returns></returns>
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        /// <summary>
        /// Creates the parameter.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public IDbDataParameter CreateParameter(IDbCommand command)
        {
            SqlCommand sqlCommand = (SqlCommand)command;
            return sqlCommand.CreateParameter();
        }
    }
}
