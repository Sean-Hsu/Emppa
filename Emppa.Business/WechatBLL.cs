using Emppa.Common.Domain.Table;
using Emppa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Business
{
    public class WechatBLL
    {
        readonly WechatDAL dalWechat;

        public WechatBLL()
        {
            this.dalWechat = new WechatDAL();
        }

        public DtWechatBasicData GetBasicData(string appId)
        {
            var var_Result = this.dalWechat.SelectBasicData(appId);

            return var_Result.FirstOrDefault();
        }

        public DtWechatAccessToken GetAccessToken(string appId)
        {
            var var_Result = this.dalWechat.SelectAccessToken(appId);

            return var_Result.FirstOrDefault();
        }

        public int PostAccessToken(DtWechatAccessToken dtWechatAccessToken)
        {
            var var_Result = this.dalWechat.InsertAccessToken(dtWechatAccessToken);

            return var_Result;
        }

        public int PutAccessToken(DtWechatAccessToken dtWechatAccessToken)
        {
            var var_Result = this.dalWechat.UpdateAccessToken(dtWechatAccessToken);

            return var_Result;
        }

        public DtWechatJsapiTicket GetJsapiTicket(string appId)
        {
            var var_Result = this.dalWechat.SelectJsapiTicket(appId);

            return var_Result.FirstOrDefault();
        }

        public int PostJsapiTicket(DtWechatJsapiTicket dtWechatJsapiTicket)
        {
            var var_Result = this.dalWechat.InsertJsapiTicket(dtWechatJsapiTicket);

            return var_Result;
        }

        public int PutJsapiTicket(DtWechatJsapiTicket dtWechatJsapiTicket)
        {
            var var_Result = this.dalWechat.UpdateJsapiTicket(dtWechatJsapiTicket);

            return var_Result;
        }
    }
}
