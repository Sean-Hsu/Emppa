using Emppa.Core.Wechat.Enum.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Core.Wechat.Domain.Request
{
    public class RequestDomainEventView : RequestDomainEventBasic
    {
        public RequestDomainEventView() : base(RequestEventType.View) { }

        /// <summary>
        /// 事件关键词
        /// </summary>
        public string EventKey { get; set; }
    }
}
