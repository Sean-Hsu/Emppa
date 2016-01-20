using Emppa.Core.Wechat.Enum.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Core.Wechat.Domain.Response
{
    public abstract class ResponseDomainBasic : BaseDomain
    {
        public ResponseDomainBasic(ResponseMessageType msgType)
        {
            this.MsgType = msgType;
        }

        /// <summary>
        /// 消息类型
        /// </summary>
        public ResponseMessageType MsgType { get; private set; }
    }
}
