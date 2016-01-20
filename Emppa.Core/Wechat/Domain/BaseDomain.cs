using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Core.Wechat.Domain
{
    public abstract class BaseDomain
    {
        /// <summary>
        /// 接受方用户名称
        /// </summary>
        public string ToUserName { get; set; }

        /// <summary>
        /// 发送方用户名称
        /// </summary>
        public string FromUserName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }
    }
}
