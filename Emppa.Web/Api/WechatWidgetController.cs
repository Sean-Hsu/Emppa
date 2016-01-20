using Emppa.Core.Wechat;
using Emppa.Web.Models.Wechat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Emppa.Web.Api
{
    public class WechatWidgetController : ApiController
    {
        readonly WechatWidget wechatWidget;

        public WechatWidgetController()
        {
            this.wechatWidget = new WechatWidget();
        }

        public string GetAccessToken(string appId)
        {
            var var_AccessToken = this.wechatWidget.GetAccessToken(appId);

            return var_AccessToken.AccessToken;
        }

        public string GetJsapiTicket(string appId)
        {
            var var_JsapiTicket = this.wechatWidget.GetJsapiTicket(appId);

            return var_JsapiTicket.JsapiTicket;
        }

        public HttpResponseMessage GetJsapiConfig(string appId, string url)
        {
            HttpResponseMessage Response = new HttpResponseMessage();

            string ticket = this.wechatWidget.GetJsapiTicket(appId).JsapiTicket;

            int timestamp = WechatUtility.GetTimestamp();
            string nonceStr = WechatUtility.GetNonceString();
            string signature = WechatManager.JsApiSignature(timestamp, nonceStr, ticket, url);

            string config = string.Format("wx.config({{debug: true,appId: '{0}', timestamp: {1}, nonceStr: '{2}', signature: '{3}', jsApiList: ['onMenuShareAppMessage','onMenuShareTimeline','previewImage']}});", appId, timestamp, nonceStr, signature);

            Response.Content = new StringContent(config);

            return Response;
        }
    }
}
