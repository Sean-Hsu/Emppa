using Emppa.Core.Wechat.Enum.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Core.Wechat.Domain.Request
{
    public class RequestDomainEventSubscribe : RequestDomainEventBasic
    {
        public RequestDomainEventSubscribe() : base(RequestEventType.Subscribe) { }
    }
}
