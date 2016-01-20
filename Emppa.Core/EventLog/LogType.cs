using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Core.EventLog
{
    public enum LogType
    {
        /// <summary>
        /// 默认
        /// </summary>
        Default,

        /// <summary>
        /// 信息
        /// </summary>
        Information,

        /// <summary>
        /// 警告
        /// </summary>
        Warning,

        /// <summary>
        /// 错误
        /// </summary>
        Error
    }
}
