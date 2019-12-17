using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Fremtidens_Bil_API.Managers
{
    /// <summary>
    /// Manager for data parameters.
    /// </summary>
    public class DataParameterManager
    {
        /// <summary>
        /// Creates the parameter.
        /// </summary>
        /// <param name="providerName">Name of the provider.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="dbType">Type of the database.</param>
        /// <param name="direction">The direction.</param>
        /// <returns></returns>
        public IDbDataParameter CreateParameter(string providerName, string name, object value, DbType dbType, ParameterDirection direction = ParameterDirection.Input)
        {
            IDbDataParameter parameter = null;

            switch (providerName.ToLower())
            {
                case "system.data.sqlclient":
                    return CreateSqlParameter(name, value, dbType, direction);
                default:
                    break;
            }
            return parameter;
        }

        /// <summary>
        /// Creates the parameter.
        /// </summary>
        /// <param name="providerName">Name of the provider.</param>
        /// <param name="name">The name.</param>
        /// <param name="size">The size.</param>
        /// <param name="value">The value.</param>
        /// <param name="dbType">Type of the database.</param>
        /// <param name="direction">The direction.</param>
        /// <returns></returns>
        public IDbDataParameter CreateParameter(string providerName, string name, int size, object value, DbType dbType, ParameterDirection direction = ParameterDirection.Input)
        {
            IDbDataParameter parameter = null;

            switch (providerName.ToLower())
            {
                case "system.data.sqlclient":
                    return CreateSqlParameter(name, size, value, dbType, direction);
                default:
                    break;
            }
            return parameter;
        }

        /// <summary>
        /// Creates the SQL parameter.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="dbType">Type of the database.</param>
        /// <param name="direction">The direction.</param>
        /// <returns></returns>
        private IDbDataParameter CreateSqlParameter(string name, object value, DbType dbType, ParameterDirection direction)
        {
            return new SqlParameter
            {
                DbType = dbType,
                ParameterName = name,
                Direction = direction,
                Value = value
            };
        }

        /// <summary>
        /// Creates the SQL parameter.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="size">The size.</param>
        /// <param name="value">The value.</param>
        /// <param name="dbType">Type of the database.</param>
        /// <param name="direction">The direction.</param>
        /// <returns></returns>
        private IDbDataParameter CreateSqlParameter(string name, int size, object value, DbType dbType, ParameterDirection direction)
        {
            return new SqlParameter
            {
                DbType = dbType,
                Size = size,
                ParameterName = name,
                Direction = direction,
                Value = value
            };
        }
    }
}
