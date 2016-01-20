using Emppa.Core.Wechat.Enum.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Core.Wechat.Domain.Request
{
    public class RequestDomainText : RequestDomainBasic
    {
        public RequestDomainText() : base(RequestMessageType.Text) { }

        /// <summary>
        /// 消息编号
        /// </summary>
        public string MsgId { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        public string Content { get; set; }
    }
}
