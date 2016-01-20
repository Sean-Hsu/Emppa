using Emppa.Core.Wechat.Enum.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Core.Wechat.Domain.Request
{
    public class RequestDomainLocation : RequestDomainBasic
    {
        public RequestDomainLocation() : base(RequestMessageType.Location) { }

        /// <summary>
        /// 消息编号
        /// </summary>
        public string MsgId { get; set; }

        /// <summary>
        /// X坐标
        /// </summary>
        public string Location_X { get; set; }

        /// <summary>
        /// Y坐标
        /// </summary>
        public string Location_Y { get; set; }

        /// <summary>
        /// 缩放
        /// </summary>
        public string Scale { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public string Label { get; set; }
    }
}
