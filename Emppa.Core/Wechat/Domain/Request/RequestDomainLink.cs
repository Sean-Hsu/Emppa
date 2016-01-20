using Emppa.Core.Wechat.Enum.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Core.Wechat.Domain.Request
{
    public class RequestDomainLink : RequestDomainBasic
    {
        public RequestDomainLink() : base(RequestMessageType.Link) { }

        /// <summary>
        /// 消息编号
        /// </summary>
        public string MsgId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        public string Url { get; set; }
    }
}
