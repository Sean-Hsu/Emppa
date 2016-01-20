using Emppa.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Core.EventLog
{
    public class DefaultLogger : ILogger
    {
        public static DefaultLogger CurrentLogger = new DefaultLogger();

        private static readonly object s_locker = new object();

        readonly IDbHelper dbHelper;

        public DefaultLogger()
        {
            this.dbHelper = new DbHelper("Default");
        }

        public void LogEvent(string eventSource, LogType logType, string logContent)
        {
            try
            {
                lock (s_locker)
                {
                    string commandText = @"INSERT INTO [dbo].[SYSTEM_EVENT_LOG]
                        (
                            [SYSTEM_INSERT_DATETIME],
                            [SYSTEM_STATUS],
                            [EVENT_SOURCE],
                            [LOG_TYPE],
                            [LOG_CONTENT]
                        )
                        VALUES
                        (
                            GETDATE(),
                            0,
                            @EVENT_SOURCE,
                            @LOG_TYPE,
                            @LOG_CONTENT
                        )";

                    this.dbHelper.ExecuteNonQuery(commandText, new { EVENT_SOURCE = eventSource, LOG_TYPE = logType.ToString(), LOG_CONTENT = logContent });
                }
            }
            catch { }
        }
    }
}
