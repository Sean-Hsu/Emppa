using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Core.EventLog
{
    interface ILogger
    {
        void LogEvent(string eventSource, LogType logType, string logContent);
    }
}
