using Emppa.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Common.Domain.Table
{
    public class DtWechatAccessToken : BasicEntity
    {
        [ColumnAttribute(Name = "ACCESS_TOKEN")]
        public string AccessToken { get; set; }

        [ColumnAttribute(Name = "EXPIRES_IN")]
        public int? ExpiresIn { get; set; }

        [ColumnAttribute(Name = "FK_WECHAT_BASIC_DATA_PK_ID")]
        public int? BasicDataId { get; set; }
    }
}
