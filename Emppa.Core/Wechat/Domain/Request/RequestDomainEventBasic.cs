using Emppa.Core.Wechat.Enum.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Core.Wechat.Domain.Request
{
    public abstract class RequestDomainEventBasic : RequestDomainBasic
    {
        public RequestDomainEventBasic(RequestEventType eventType)
            : base(RequestMessageType.Event)
        {
            this.EventType = eventType;
        }

        /// <summary>
        /// 事件类型
        /// </summary>
        public RequestEventType EventType { get; private set; }
    }
}
