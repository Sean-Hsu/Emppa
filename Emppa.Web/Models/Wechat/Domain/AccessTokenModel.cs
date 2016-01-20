using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Web.Models.Wechat.Domain
{
    public class AccessTokenModel : BasicModel
    {
        [JsonProperty("access_token")]
        public string AccessToken{get;set;}

        [JsonProperty("expires_in")]
        public int? ExpiresIn { get; set; }
    }
}
