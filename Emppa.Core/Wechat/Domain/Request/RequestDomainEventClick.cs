using Emppa.Core.Wechat.Enum.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Core.Wechat.Domain.Request
{
    public class RequestDomainEventClick : RequestDomainEventBasic
    {
        public RequestDomainEventClick() : base(RequestEventType.Click) { }

        /// <summary>
        /// 事件关键词
        /// </summary>
        public string EventKey { get; set; }
    }
}
