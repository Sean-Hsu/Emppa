using Emppa.Business;
using Emppa.Core.EventLog;
using Emppa.Core.Wechat;
using Emppa.Core.Wechat.Domain.Request;
using Emppa.Core.Wechat.Domain.Response;
using Emppa.Core.Wechat.Enum.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;

namespace Emppa.Web.Api
{
    public class WechatController : ApiController
    {
        readonly WechatBLL bllWechat;

        public WechatController()
        {
            this.bllWechat = new WechatBLL();
        }

        // GET: api/Wechat
        public HttpResponseMessage Get(string appid, string signature, string timestamp, string nonce, string echostr)
        {
            HttpResponseMessage Response = new HttpResponseMessage();

            try
            {
                var var_BasicData = this.bllWechat.GetBasicData(appid);

                if (var_BasicData == null)
                {
                    throw new Exception("未配置微信开发的基础数据");
                }

                string token = var_BasicData.Token;

                bool result = WechatManager.CheckSignature(signature, token, timestamp, nonce);

                if (!result)
                {
                    echostr = string.Empty;
                }

                Response.Content = new StringContent(echostr);
            }
            catch (Exception e)
            {
                // Log error type message.
                string currentKey = Request.Headers.LastOrDefault(x => x.Key == "Current-Key").Value.LastOrDefault();
                string internalEventSource = string.Format("[{0}][{1}][{2}]", "E", currentKey, Request.RequestUri.OriginalString);
                string errorMessage = e.Message;
                DefaultLogger.CurrentLogger.LogEvent(internalEventSource, LogType.Error, errorMessage);
            }

            return Response;
        }

        // POST: api/Wechat
        public HttpResponseMessage Post(string appid, string signature, string timestamp, string nonce, string encrypt_type, string msg_signature)
        {
            HttpResponseMessage Response = new HttpResponseMessage();

            ResponseDomainBasic responseDomainBasic = null;

            try
            {
                string requestData = Request.Content.ReadAsStringAsync().Result;
                RequestDomainBasic requestDomainBasic = WechatMessage.Deserialize(requestData);

                switch (requestDomainBasic.MsgType)
                {
                    case RequestMessageType.Text:
                        {
                            RequestDomainText requestDomainText = requestDomainBasic as RequestDomainText;

                            //if (requestDomainText.Content == "print")
                            {
                                string tempString = WechatManager.Signature("a4850954JfF0V3v", timestamp, nonce);

                                string url = string.Format("http://inleaderdev.weixinprint.com/weixin?publicUserId=79202&signature={0}&timestamp={1}&nonce={2}", tempString, timestamp, nonce);

                                var httpContent = new StringContent(requestData, Encoding.UTF8);
                                httpContent.Headers.ContentType = new MediaTypeHeaderValue("text/xml") { CharSet = "utf-8" };

                                HttpClient client = new HttpClient();
                                string s = client.PostAsync(url, httpContent).Result.Content.ReadAsStringAsync().Result;

                                Response.Content = new StringContent(s);
                                return Response;
                            }

                            ResponseDomainText responseDomainText = new ResponseDomainText();
                            responseDomainText.ToUserName = requestDomainText.FromUserName;
                            responseDomainText.FromUserName = requestDomainText.ToUserName;
                            responseDomainText.Content = requestDomainText.Content;

                            responseDomainBasic = responseDomainText;
                        }
                        break;
                    case RequestMessageType.Image:
                        {
                            string tempString = WechatManager.Signature("a4850954JfF0V3v", timestamp, nonce);

                            string url = string.Format("http://inleaderdev.weixinprint.com/weixin?publicUserId=79202&signature={0}&timestamp={1}&nonce={2}", tempString, timestamp, nonce);

                            var httpContent = new StringContent(requestData, Encoding.UTF8);
                            httpContent.Headers.ContentType = new MediaTypeHeaderValue("text/xml") { CharSet = "utf-8" };

                            HttpClient client = new HttpClient();
                            string s = client.PostAsync(url, httpContent).Result.Content.ReadAsStringAsync().Result;

                            Response.Content = new StringContent(s);
                            return Response;
                        }
                        break;
                    case RequestMessageType.Voice:
                        {
                            RequestDomainVoice requestDomainVoice = requestDomainBasic as RequestDomainVoice;

                            ResponseDomainVoice responseDomainVoice = new ResponseDomainVoice();
                            responseDomainVoice.ToUserName = requestDomainVoice.FromUserName;
                            responseDomainVoice.FromUserName = requestDomainVoice.ToUserName;
                            responseDomainVoice.MediaId = requestDomainVoice.MediaId;

                            responseDomainBasic = responseDomainVoice;
                        }
                        break;
                    case RequestMessageType.Event:
                        {
                            RequestDomainEventBasic requestDomainEventBasic = requestDomainBasic as RequestDomainEventBasic;

                            switch (requestDomainEventBasic.EventType)
                            {
                                case RequestEventType.Subscribe:
                                    {
                                        string tempString = WechatManager.Signature("a4850954JfF0V3v", timestamp, nonce);

                                        string url = string.Format("http://inleaderdev.weixinprint.com/weixin?publicUserId=79202&signature={0}&timestamp={1}&nonce={2}", tempString, timestamp, nonce);

                                        var httpContent = new StringContent(requestData, Encoding.UTF8);
                                        httpContent.Headers.ContentType = new MediaTypeHeaderValue("text/xml") { CharSet = "utf-8" };

                                        HttpClient client = new HttpClient();
                                        string s = client.PostAsync(url, httpContent).Result.Content.ReadAsStringAsync().Result;

                                        Response.Content = new StringContent(s);
                                        return Response;
                                    }
                                    break;
                                case RequestEventType.Unsubscribe:
                                    break;
                                case RequestEventType.Scan:
                                    {
                                        string tempString = WechatManager.Signature("a4850954JfF0V3v", timestamp, nonce);

                                        string url = string.Format("http://inleaderdev.weixinprint.com/weixin?publicUserId=79202&signature={0}&timestamp={1}&nonce={2}", tempString, timestamp, nonce);

                                        var httpContent = new StringContent(requestData, Encoding.UTF8);
                                        httpContent.Headers.ContentType = new MediaTypeHeaderValue("text/xml") { CharSet = "utf-8" };

                                        HttpClient client = new HttpClient();
                                        string s = client.PostAsync(url, httpContent).Result.Content.ReadAsStringAsync().Result;

                                        Response.Content = new StringContent(s);
                                        return Response;
                                    }
                                    break;
                            }
                        }
                        break;
                }

                //ResponseDomainText responseDomainText = new ResponseDomainText();
                //responseDomainText.ToUserName = requestDomainBasic.FromUserName;
                //responseDomainText.FromUserName = requestDomainBasic.ToUserName;
                //responseDomainText.Content = "许安博，你好！";

                //if (requestDomainBasic.MsgType == Core.Wechat.Enum.Request.RequestMessageType.Text)
                //{
                //    RequestDomainText requestDomainText = requestDomainBasic as RequestDomainText;

                //    if (!string.IsNullOrWhiteSpace(requestDomainText.Content))
                //    {
                //        if (requestDomainText.Content == "news")
                //        {
                //            ResponseDomainNews.Article article = new ResponseDomainNews.Article();
                //            article.Title = "Bill Gross：创业成功最关键因素";
                //            article.PicUrl = "http://e.hiphotos.baidu.com/news/q%3D100/sign=028f2e589552982203333dc3e7cb7b3b/ac345982b2b7d0a248581602ceef76094a369a9f.jpg";
                //            article.Description = "Bill Gross 前天在 TED 的演讲，Youtube 上已有几百万点击量。这家伙实在太有名了，不仅曾发明造就谷歌今日成功的商业模式；他还有个闻名硅谷的 IdeaLab，基本可把后者看成是“创新工场”原型。Bill 一个人能量，共已折腾出 100 多家公司，这样重量级人物出场，还是非常值得一看。以下是我们对 Bill Gross 前天演讲的一个整理，Enjoy。";
                //            article.Url = "http://180.166.144.198/emppa/default/index";

                //            ResponseDomainNews responseDomainNews = new ResponseDomainNews();
                //            responseDomainNews.Articles = new List<ResponseDomainNews.Article>();
                //            responseDomainNews.Articles.Add(article);
                //            responseDomainNews.ToUserName = requestDomainBasic.FromUserName;
                //            responseDomainNews.FromUserName = requestDomainBasic.ToUserName;

                //            responseData = WechatMessage.Serialize(responseDomainNews);
                //        }
                //        else if (requestDomainText.Content == "test")
                //        {
                //            ResponseDomainNews.Article article = new ResponseDomainNews.Article();
                //            article.Title = "Bill Gross：创业成功最关键因素";
                //            article.PicUrl = "http://e.hiphotos.baidu.com/news/q%3D100/sign=028f2e589552982203333dc3e7cb7b3b/ac345982b2b7d0a248581602ceef76094a369a9f.jpg";
                //            article.Description = "Bill Gross 前天在 TED 的演讲，Youtube 上已有几百万点击量。这家伙实在太有名了，不仅曾发明造就谷歌今日成功的商业模式；他还有个闻名硅谷的 IdeaLab，基本可把后者看成是“创新工场”原型。Bill 一个人能量，共已折腾出 100 多家公司，这样重量级人物出场，还是非常值得一看。以下是我们对 Bill Gross 前天演讲的一个整理，Enjoy。";
                //            article.Url = "http://180.166.144.198/emppa/pages/test.html";

                //            ResponseDomainNews responseDomainNews = new ResponseDomainNews();
                //            responseDomainNews.Articles = new List<ResponseDomainNews.Article>();
                //            responseDomainNews.Articles.Add(article);
                //            responseDomainNews.ToUserName = requestDomainBasic.FromUserName;
                //            responseDomainNews.FromUserName = requestDomainBasic.ToUserName;

                //            responseData = WechatMessage.Serialize(responseDomainNews);
                //        }
                //        else
                //        {
                //            responseDomainText.Content = requestDomainText.Content;

                //            responseData = WechatMessage.Serialize(responseDomainText);
                //        }
                //    }
                //}

                string responseData = WechatMessage.Serialize(responseDomainBasic);

                Response.Content = new StringContent(responseData);
            }
            catch (Exception e)
            {
                // Log error type message.
                string currentKey = Request.Headers.LastOrDefault(x => x.Key == "Current-Key").Value.LastOrDefault();
                string internalEventSource = string.Format("[{0}][{1}][{2}]", "E", currentKey, Request.RequestUri.OriginalString);
                string errorMessage = e.Message;
                DefaultLogger.CurrentLogger.LogEvent(internalEventSource, LogType.Error, errorMessage);
            }

            return Response;

            //ResponseDomainNews.Article article = new ResponseDomainNews.Article();
            //article.Title = "Bill Gross：创业成功最关键因素";
            //article.PicUrl = "http://e.hiphotos.baidu.com/news/q%3D100/sign=028f2e589552982203333dc3e7cb7b3b/ac345982b2b7d0a248581602ceef76094a369a9f.jpg";
            //article.Description = "Bill Gross 前天在 TED 的演讲，Youtube 上已有几百万点击量。这家伙实在太有名了，不仅曾发明造就谷歌今日成功的商业模式；他还有个闻名硅谷的 IdeaLab，基本可把后者看成是“创新工场”原型。Bill 一个人能量，共已折腾出 100 多家公司，这样重量级人物出场，还是非常值得一看。以下是我们对 Bill Gross 前天演讲的一个整理，Enjoy。";
            //article.Url = "http://yanglinhua.baijia.baidu.com/article/74102";

            //ResponseDomainNews responseDomainNews = new ResponseDomainNews();
            //responseDomainNews.Articles = new List<ResponseDomainNews.Article>();
            //responseDomainNews.Articles.Add(article);
            //responseDomainNews.ToUserName = requestDomainBasic.FromUserName;
            //responseDomainNews.FromUserName = requestDomainBasic.ToUserName;
        }

        public HttpResponseMessage Post(string appid, string signature, string timestamp, string nonce)
        {
            return Post(appid, signature, timestamp, nonce, null, null);
        }
    }
}
