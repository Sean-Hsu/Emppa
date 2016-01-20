using Emppa.Business;
using Emppa.Core.Wechat;
using Emppa.Web.Models.Wechat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emppa.Web.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            string appId = "wxb40586eea1460e5a";

            WechatWidget wechatWidget = new WechatWidget();

            string ticket = wechatWidget.GetJsapiTicket(appId).JsapiTicket;


            int timestamp = WechatUtility.GetTimestamp();
            string nonceStr = WechatUtility.GetNonceString();
            string signature = WechatManager.JsApiSignature(timestamp, nonceStr, ticket, Request.Url.AbsoluteUri);

            string config = string.Format("<script>wx.config({{debug: false,appId: '{0}', timestamp: {1}, nonceStr: '{2}', signature: '{3}', jsApiList: ['onMenuShareAppMessage','onMenuShareTimeline','previewImage']}});</script>", appId, timestamp, nonceStr, signature);

            ViewBag.Script = config;

            return View();
        }

        public ActionResult Test()
        {
            new TestBLL().Select();

            return View();
        }
    }
}