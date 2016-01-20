using Emppa.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Common.Domain.Table
{
    public class DtWechatBasicData : BasicEntity
    {
        [ColumnAttribute(Name = "APP_ID")]
        public string AppId { get; set; }

        [ColumnAttribute(Name = "APP_SECRET")]
        public string AppSecret { get; set; }

        [ColumnAttribute(Name = "TOKEN")]
        public string Token { get; set; }

        [ColumnAttribute(Name = "ENCODING_AES_KEY")]
        public string EncodingAESKey { get; set; }

        [ColumnAttribute(Name = "ENCODING_TYPE")]
        public int? EncodingType { get; set; }
    }
}
