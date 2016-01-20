//using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emppa.Core.Dapper;

namespace Emppa.Core.DataAccess
{
    public class DbHelper : IDbHelper
    {
        public DbHelper(string name)
        {
            ConnectionStringSettings cnnStringSettings = ConfigurationManager.ConnectionStrings[name];
            this._connectionString = cnnStringSettings.ConnectionString;
            this._factory = DbProviderFactories.GetFactory(cnnStringSettings.ProviderName);
        }

        string _connectionString;

        public string ConnectionString
        {
            get { return this._connectionString; }
        }

        DbProviderFactory _factory;

        public DbProviderFactory Factory
        {
            get { return this._factory; }
        }

        public int ExecuteNonQuery(string commandText, object parameters = null, CommandType? commandType = null, IDbTransaction transaction = null)
        {
            //Type type = typeof(T);
            //CustomPropertyTypeMap map = new CustomPropertyTypeMap(type, (systemType, columnName) => systemType.GetProperties().FirstOrDefault(pi => pi.GetCustomAttributes(false).OfType<ColumnAttribute>().Any(column => column.Name == columnName)));
            //SqlMapper.SetTypeMap(type, map);

            if (transaction == null)
            {
                using (IDbConnection connection = this.Factory.CreateConnection())
                {
                    connection.ConnectionString = this.ConnectionString;
                    return connection.Execute(commandText, param: parameters, commandType: commandType);
                }
            }
            else
            {
                return transaction.Connection.Execute(commandText, param: parameters, commandType: commandType, transaction: transaction);
            }
        }

        public IEnumerable<T> ExecuteQuery<T>(string commandText, object parameters = null, CommandType? commandType = null, IDbTransaction transaction = null)
        {
            //Type type = typeof(T);
            //CustomPropertyTypeMap map = new CustomPropertyTypeMap(type, (systemType, columnName) => systemType.GetProperties().FirstOrDefault(pi => (pi.GetCustomAttributes(false).OfType<ColumnAttribute>().Any(column => column.Name == columnName) || pi.Name == columnName)));
            //SqlMapper.SetTypeMap(type, map);

            if (transaction == null)
            {
                using (DbConnection connection = this.Factory.CreateConnection())
                {
                    connection.ConnectionString = this.ConnectionString;
                    return connection.Query<T>(commandText, param: parameters, commandType: commandType, transaction: transaction);
                }
            }
            else
            {
                return transaction.Connection.Query<T>(commandText, param: parameters, commandType: commandType, transaction: transaction);
            }
        }
    }
}
