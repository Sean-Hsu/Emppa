using Emppa.Core.Wechat.Enum.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Core.Wechat.Domain.Response
{
    public class ResponseDomainVoice : ResponseDomainBasic
    {
        public ResponseDomainVoice() : base(ResponseMessageType.Voice) { }

        public string MediaId { get; set; }
    }
}
