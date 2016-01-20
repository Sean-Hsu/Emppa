using Emppa.Core.Wechat.Enum.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Core.Wechat.Domain.Request
{
    public class RequestDomainImage : RequestDomainBasic
    {
        public RequestDomainImage() : base(RequestMessageType.Image) { }

        /// <summary>
        /// 消息编号
        /// </summary>
        public string MsgId { get; set; }

        /// <summary>
        /// 图片链接
        /// </summary>
        public string PicUrl { get; set; }

        /// <summary>
        /// 媒体编号
        /// </summary>
        public string MediaId { get; set; }
    }
}
