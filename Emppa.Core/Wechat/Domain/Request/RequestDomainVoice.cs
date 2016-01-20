using Emppa.Core.Wechat.Enum.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Core.Wechat.Domain.Request
{
    public class RequestDomainVoice : RequestDomainBasic
    {
        public RequestDomainVoice() : base(RequestMessageType.Voice) { }

        /// <summary>
        /// 消息编号
        /// </summary>
        public string MsgId { get; set; }

        /// <summary>
        /// 媒体编号
        /// </summary>
        public string MediaId { get; set; }

        /// <summary>
        /// 格式
        /// </summary>
        public string Format { get; set; }
    }
}
