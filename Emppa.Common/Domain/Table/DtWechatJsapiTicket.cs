using Emppa.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Common.Domain.Table
{
    public class DtWechatJsapiTicket : BasicEntity
    {
        [ColumnAttribute(Name = "JSAPI_TICKET")]
        public string JsapiTicket { get; set; }

        [ColumnAttribute(Name = "EXPIRES_IN")]
        public int? ExpiresIn { get; set; }

        [ColumnAttribute(Name = "FK_WECHAT_ACCESS_TOKEN_PK_ID")]
        public int? AccessTokenId { get; set; }
    }
}
