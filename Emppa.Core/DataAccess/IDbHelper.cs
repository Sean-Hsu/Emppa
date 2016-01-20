using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Core.DataAccess
{
    public interface IDbHelper
    {
        string ConnectionString { get; }

        DbProviderFactory Factory { get; }

        int ExecuteNonQuery(string commandText, object parameters = null, CommandType? commandType = null, IDbTransaction transaction = null);

        IEnumerable<T> ExecuteQuery<T>(string commandText, object parameters = null, CommandType? commandType = null, IDbTransaction transaction = null);
    }
}
