using Emppa.Business;
using Emppa.Common.Domain.Table;
using Emppa.Web.Models.Wechat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Web.Models.Wechat
{
    public class WechatWidget
    {
        readonly WechatBLL bllWechat;

        const string urlAccessToken = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";
        const string urlJsapiTicket = "https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type=jsapi";

        public WechatWidget()
        {
            this.bllWechat = new WechatBLL();
        }

        public DtWechatAccessToken GetAccessToken(string appId)
        {
            DtWechatAccessToken dtWechatAccessToken = this.bllWechat.GetAccessToken(appId);

            if (dtWechatAccessToken == null)
            {
                dtWechatAccessToken = this.RenewAccessToken(appId);
                this.bllWechat.PostAccessToken(dtWechatAccessToken);
                dtWechatAccessToken = this.bllWechat.GetAccessToken(appId);
            }
            else
            {
                DateTime? dt_Refresh = dtWechatAccessToken.SystemUpdateDateTime ?? dtWechatAccessToken.SystemInsertDateTime;
                int? int_ExpiresIn = dtWechatAccessToken.ExpiresIn - 1200;

                if (!(dt_Refresh.HasValue && int_ExpiresIn.HasValue && dt_Refresh.Value.AddSeconds(int_ExpiresIn.Value) > DateTime.Now))
                {
                    int? intq_Id = dtWechatAccessToken.Id;
                    dtWechatAccessToken = this.RenewAccessToken(appId);
                    dtWechatAccessToken.Id = intq_Id;
                    this.bllWechat.PutAccessToken(dtWechatAccessToken);
                    dtWechatAccessToken = this.bllWechat.GetAccessToken(appId);
                }
            }

            return dtWechatAccessToken;
        }

        public DtWechatJsapiTicket GetJsapiTicket(string appId)
        {
            DtWechatJsapiTicket dtWechatJsapiTicket = this.bllWechat.GetJsapiTicket(appId);

            if (dtWechatJsapiTicket == null)
            {
                dtWechatJsapiTicket = this.RenewJsapiTicket(appId);
                this.bllWechat.PostJsapiTicket(dtWechatJsapiTicket);
                dtWechatJsapiTicket = this.bllWechat.GetJsapiTicket(appId);
            }
            else
            {
                DateTime? dt_Refresh = dtWechatJsapiTicket.SystemUpdateDateTime ?? dtWechatJsapiTicket.SystemInsertDateTime;
                int? int_ExpiresIn = dtWechatJsapiTicket.ExpiresIn - 1200;

                if (!(dt_Refresh.HasValue && int_ExpiresIn.HasValue && dt_Refresh.Value.AddSeconds(int_ExpiresIn.Value) > DateTime.Now))
                {
                    int? intq_Id = dtWechatJsapiTicket.Id;
                    dtWechatJsapiTicket = this.RenewJsapiTicket(appId);
                    dtWechatJsapiTicket.Id = intq_Id;
                    this.bllWechat.PutJsapiTicket(dtWechatJsapiTicket);
                    dtWechatJsapiTicket = this.bllWechat.GetJsapiTicket(appId);
                }
            }

            return dtWechatJsapiTicket;
        }

        private DtWechatAccessToken RenewAccessToken(string appId)
        {
            DtWechatAccessToken dtWechatAccessToken = null;

            var var_BasicData = this.bllWechat.GetBasicData(appId);

            if (var_BasicData == null)
            {
                throw new Exception("未配置微信开发的基础数据");
            }

            string requstUri = string.Format(urlAccessToken, var_BasicData.AppId, var_BasicData.AppSecret);

            HttpClient client = new HttpClient();
            AccessTokenModel model_AccessToken = client.GetAsync(requstUri).Result.Content.ReadAsAsync<AccessTokenModel>().Result;

            if (model_AccessToken != null && (model_AccessToken.ErrCode == null || model_AccessToken.ErrCode == 0))
            {
                dtWechatAccessToken = new DtWechatAccessToken();

                dtWechatAccessToken.AccessToken = model_AccessToken.AccessToken;
                dtWechatAccessToken.ExpiresIn = model_AccessToken.ExpiresIn;
                dtWechatAccessToken.BasicDataId = var_BasicData.Id;
            }

            return dtWechatAccessToken;
        }

        private DtWechatJsapiTicket RenewJsapiTicket(string appId)
        {
            DtWechatJsapiTicket dtWechatJsapiTicket = null;

            var var_AccessToken = this.GetAccessToken(appId);

            if (var_AccessToken == null)
            {
                throw new Exception("获取AccessToken失败");
            }

            string requstUri = string.Format(urlJsapiTicket, var_AccessToken.AccessToken);

            HttpClient client = new HttpClient();
            JsapiTicketModel model_JsapiTicket = client.GetAsync(requstUri).Result.Content.ReadAsAsync<JsapiTicketModel>().Result;

            if (model_JsapiTicket != null && (model_JsapiTicket.ErrCode == null || model_JsapiTicket.ErrCode == 0))
            {
                dtWechatJsapiTicket = new DtWechatJsapiTicket();

                dtWechatJsapiTicket.JsapiTicket = model_JsapiTicket.JsapiTicket;
                dtWechatJsapiTicket.ExpiresIn = model_JsapiTicket.ExpiresIn;
                dtWechatJsapiTicket.AccessTokenId = var_AccessToken.Id;
            }

            return dtWechatJsapiTicket;
        }
    }
}
