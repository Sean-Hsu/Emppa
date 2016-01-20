using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Web.Models.Wechat.Domain
{
    public class JsapiTicketModel : BasicModel
    {
        [JsonProperty("ticket")]
        public string JsapiTicket { get; set; }

        [JsonProperty("expires_in")]
        public int? ExpiresIn { get; set; }
    }
}
