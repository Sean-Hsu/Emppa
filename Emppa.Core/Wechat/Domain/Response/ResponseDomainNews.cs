using Emppa.Core.Wechat.Enum.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Core.Wechat.Domain.Response
{
    public class ResponseDomainNews : ResponseDomainBasic
    {
        public ResponseDomainNews() : base(ResponseMessageType.News) { this.Articles = new List<Article>(); }

        public List<Article> Articles { get; set; }

        public class Article
        {
            /// <summary>
            /// 标题
            /// </summary>
            public string Title { get; set; }

            /// <summary>
            /// 描述
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// 图片链接
            /// </summary>
            public string PicUrl { get; set; }

            /// <summary>
            /// 链接
            /// </summary>
            public string Url { get; set; }

        }
    }
}
