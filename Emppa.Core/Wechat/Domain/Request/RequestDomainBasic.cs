using Emppa.Core.Wechat.Enum.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Core.Wechat.Domain.Request
{
    public abstract class RequestDomainBasic : BaseDomain
    {
        public RequestDomainBasic(RequestMessageType msgType)
        {
            this.MsgType = msgType;
        }

        /// <summary>
        /// 消息类型
        /// </summary>
        public RequestMessageType MsgType { get; private set; }
    }
}
