using System.Data;

namespace Fremtidens_Bil_API.Interfaces
{
    /// <summary>
    /// Database base handler.
    /// </summary>
    public interface IDataBaseHandler
    {
        /// <summary>
        /// Creates the connection.
        /// </summary>
        /// <returns></returns>
        IDbConnection CreateConnection();

        /// <summary>
        /// Closes the connection.
        /// </summary>
        /// <param name="connection">The connection.</param>
        void CloseConnection(IDbConnection connection);

        /// <summary>
        /// Creates the command.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="connection">The connection.</param>
        /// <returns></returns>
        IDbCommand CreateCommand(string commandText, CommandType commandType, IDbConnection connection);

        /// <summary>
        /// Creates the adapter.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        IDataAdapter CreateAdapter(IDbCommand command);

        /// <summary>
        /// Creates the parameter.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        IDbDataParameter CreateParameter(IDbCommand command);
    }
}
