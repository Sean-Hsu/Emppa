using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Web.Models.Wechat.Domain
{
    public class BasicModel
    {
        [JsonProperty("errcode")]
        public int? ErrCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }
    }
}
