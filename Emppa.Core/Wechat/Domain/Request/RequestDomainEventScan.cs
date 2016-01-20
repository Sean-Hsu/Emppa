using Emppa.Core.Wechat.Enum.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Core.Wechat.Domain.Request
{
    public class RequestDomainEventScan : RequestDomainEventBasic
    {
        public RequestDomainEventScan() : base(RequestEventType.Scan) { }

        /// <summary>
        /// 事件关键词
        /// </summary>
        public string EventKey { get; set; }

        /// <summary>
        /// 票据
        /// </summary>
        public string Ticket { get; set; }
    }
}
