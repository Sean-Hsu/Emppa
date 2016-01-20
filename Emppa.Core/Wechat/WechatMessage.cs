using Emppa.Core.Wechat.Domain.Request;
using Emppa.Core.Wechat.Domain.Response;
using Emppa.Core.Wechat.Enum.Response;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Emppa.Core.Wechat
{
    public static class WechatMessage
    {
        public static string Serialize(ResponseDomainBasic obj)
        {
            string val = string.Empty;

            if (obj != null)
            {
                switch (obj.MsgType)
                {
                    case ResponseMessageType.Text:
                        {
                            ResponseDomainText responseDomainText = obj as ResponseDomainText;

                            StringBuilder sb = new StringBuilder();
                            sb.Append("<xml>");
                            sb.AppendFormat("<ToUserName><![CDATA[{0}]]></ToUserName>", responseDomainText.ToUserName);
                            sb.AppendFormat("<FromUserName><![CDATA[{0}]]></FromUserName>", responseDomainText.FromUserName);
                            sb.AppendFormat("<CreateTime>{0}</CreateTime>", DateTime.Now.Ticks);
                            sb.AppendFormat("<MsgType><![CDATA[{0}]]></MsgType>", responseDomainText.MsgType);
                            sb.AppendFormat("<Content><![CDATA[{0}]]></Content>", string.IsNullOrWhiteSpace(responseDomainText.Content) ? "看不懂" : responseDomainText.Content);
                            sb.Append("</xml>");

                            val = sb.ToString();
                        }
                        break;
                    case ResponseMessageType.Voice:
                        {
                            ResponseDomainVoice responseDomainVoice = obj as ResponseDomainVoice;

                            StringBuilder sb = new StringBuilder();
                            sb.Append("<xml>");
                            sb.AppendFormat("<ToUserName><![CDATA[{0}]]></ToUserName>", responseDomainVoice.ToUserName);
                            sb.AppendFormat("<FromUserName><![CDATA[{0}]]></FromUserName>", responseDomainVoice.FromUserName);
                            sb.AppendFormat("<CreateTime>{0}</CreateTime>", DateTime.Now.Ticks);
                            sb.AppendFormat("<MsgType><![CDATA[{0}]]></MsgType>", responseDomainVoice.MsgType);
                            sb.Append("<Voice>");
                            sb.AppendFormat("<MediaId><![CDATA[{0}]]></MediaId>", responseDomainVoice.MediaId);
                            sb.Append("</Voice>");
                            sb.Append("</xml>");

                            val = sb.ToString();
                        }
                        break;
                    case ResponseMessageType.News:
                        {
                            ResponseDomainNews responseDomainNews = obj as ResponseDomainNews;

                            StringBuilder sb = new StringBuilder();
                            sb.Append("<xml>");
                            sb.AppendFormat("<ToUserName><![CDATA[{0}]]></ToUserName>", responseDomainNews.ToUserName);
                            sb.AppendFormat("<FromUserName><![CDATA[{0}]]></FromUserName>", responseDomainNews.FromUserName);
                            sb.AppendFormat("<CreateTime>{0}</CreateTime>", DateTime.Now.Ticks);
                            sb.AppendFormat("<MsgType><![CDATA[{0}]]></MsgType>", responseDomainNews.MsgType);
                            sb.AppendFormat("<ArticleCount>{0}</ArticleCount>", responseDomainNews.Articles.Count);
                            sb.Append("<Articles>");
                            foreach (ResponseDomainNews.Article article in responseDomainNews.Articles)
                            {
                                sb.Append("<item>");
                                sb.AppendFormat("<Title><![CDATA[{0}]]></Title>", article.Title);
                                sb.AppendFormat("<Description><![CDATA[{0}]]></Description>", article.Description);
                                sb.AppendFormat("<PicUrl><![CDATA[{0}]]></PicUrl>", article.PicUrl);
                                sb.AppendFormat("<Url><![CDATA[{0}]]></Url>", article.Url);
                                sb.Append("</item>");
                            }
                            sb.Append("</Articles>");
                            sb.Append("</xml>");

                            val = sb.ToString();
                        }
                        break;
                    default:
                        break;
                }
            }

            return val;
        }

        public static RequestDomainBasic Deserialize(string val)
        {
            RequestDomainBasic requestDomainBasic = null;

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(val);
                XmlNode bodyNode = xmlDocument.ChildNodes[0];
                Hashtable hashtable = new Hashtable();

                if (bodyNode.ChildNodes.Count > 0)
                {
                    foreach (XmlNode xn in bodyNode.ChildNodes)
                    {
                        hashtable.Add(xn.Name, xn.InnerText);
                    }
                }

                string toUserName = (string)hashtable["ToUserName"];
                string fromUserName = (string)hashtable["FromUserName"];
                string createTime = (string)hashtable["CreateTime"];
                string msgType = (string)hashtable["MsgType"];

                switch (msgType.ToLower())
                {
                    case "text":
                        {
                            #region text

                            string msgId = (string)hashtable["MsgId"];
                            string content = (string)hashtable["Content"];
                            //
                            requestDomainBasic = new RequestDomainText()
                            {
                                ToUserName = toUserName,
                                FromUserName = fromUserName,
                                CreateTime = createTime,
                                MsgId = msgId,
                                Content = content
                            };

                            #endregion
                        }
                        break;
                    case "image":
                        {
                            #region image

                            string msgId = (string)hashtable["MsgId"];
                            string picUrl = (string)hashtable["PicUrl"];
                            string mediaId = (string)hashtable["MediaId"];
                            //
                            requestDomainBasic = new RequestDomainImage()
                            {
                                ToUserName = toUserName,
                                FromUserName = fromUserName,
                                CreateTime = createTime,
                                MsgId = msgId,
                                PicUrl = picUrl,
                                MediaId = mediaId
                            };

                            #endregion
                        }
                        break;
                    case "voice":
                        {
                            #region voice

                            string msgId = (string)hashtable["MsgId"];
                            string mediaId = (string)hashtable["MediaId"];
                            string format = (string)hashtable["Format"];
                            //
                            requestDomainBasic = new RequestDomainVoice()
                            {
                                ToUserName = toUserName,
                                FromUserName = fromUserName,
                                CreateTime = createTime,
                                MsgId = msgId,
                                MediaId = mediaId,
                                Format = format
                            };

                            #endregion
                        }
                        break;
                    case "video":
                        {
                            #region video

                            string msgId = (string)hashtable["MsgId"];
                            string mediaId = (string)hashtable["MediaId"];
                            string thumbMediaId = (string)hashtable["ThumbMediaId"];
                            //
                            requestDomainBasic = new RequestDomainVideo()
                            {
                                ToUserName = toUserName,
                                FromUserName = fromUserName,
                                CreateTime = createTime,
                                MsgId = msgId,
                                MediaId = mediaId,
                                ThumbMediaId = thumbMediaId
                            };

                            #endregion
                        }
                        break;
                    case "location":
                        {
                            #region location

                            string msgId = (string)hashtable["MsgId"];
                            string location_X = (string)hashtable["Location_X"];
                            string location_Y = (string)hashtable["Location_Y"];
                            string scale = (string)hashtable["Scale"];
                            string label = (string)hashtable["Label"];
                            //
                            requestDomainBasic = new RequestDomainLocation()
                            {
                                ToUserName = toUserName,
                                FromUserName = fromUserName,
                                CreateTime = createTime,
                                MsgId = msgId,
                                Location_X = location_X,
                                Location_Y = location_Y,
                                Scale = scale,
                                Label = label
                            };

                            #endregion
                        }
                        break;
                    case "link":
                        {
                            #region link

                            string msgId = (string)hashtable["MsgId"];
                            string title = (string)hashtable["Title"];
                            string description = (string)hashtable["Description"];
                            string url = (string)hashtable["Url"];
                            //
                            requestDomainBasic = new RequestDomainLink()
                            {
                                ToUserName = toUserName,
                                FromUserName = fromUserName,
                                CreateTime = createTime,
                                MsgId = msgId,
                                Title = title,
                                Description = description,
                                Url = url
                            };

                            #endregion
                        }
                        break;
                    case "event":
                        {
                            #region event

                            string eventType = (string)hashtable["Event"];

                            switch (eventType.ToLower())
                            {
                                case "subscribe":
                                    {
                                        #region subscribe or (scan + subscribe)

                                        string eventKey = (string)hashtable["EventKey"];

                                        if (string.IsNullOrWhiteSpace(eventKey))
                                        {
                                            requestDomainBasic = new RequestDomainEventSubscribe()
                                            {
                                                ToUserName = toUserName,
                                                FromUserName = fromUserName,
                                                CreateTime = createTime,
                                            };
                                        }
                                        else
                                        {
                                            string ticket = (string)hashtable["Ticket"];

                                            requestDomainBasic = new RequestDomainEventScanAndSubscribe()
                                            {
                                                ToUserName = toUserName,
                                                FromUserName = fromUserName,
                                                CreateTime = createTime,
                                                EventKey = eventKey,
                                                Ticket = ticket
                                            };
                                        }

                                        #endregion
                                    }
                                    break;
                                case "unsubscribe":
                                    {
                                        #region unsubscribe

                                        string eventKey = (string)hashtable["EventKey"];
                                        string ticket = (string)hashtable["Ticket"];

                                        requestDomainBasic = new RequestDomainEventUnsubscribe()
                                        {
                                            ToUserName = toUserName,
                                            FromUserName = fromUserName,
                                            CreateTime = createTime,
                                        };

                                        #endregion
                                    }
                                    break;
                                case "scan":
                                    {
                                        #region scan

                                        string eventKey = (string)hashtable["EventKey"];
                                        string ticket = (string)hashtable["Ticket"];

                                        requestDomainBasic = new RequestDomainEventScan()
                                        {
                                            ToUserName = toUserName,
                                            FromUserName = fromUserName,
                                            CreateTime = createTime,
                                            EventKey = eventKey,
                                            Ticket = ticket
                                        };

                                        #endregion
                                    }
                                    break;
                                case "location":
                                    {
                                        #region location

                                        string latitude = (string)hashtable["Latitude"];
                                        string longitude = (string)hashtable["Longitude"];
                                        string precision = (string)hashtable["Precision"];

                                        requestDomainBasic = new RequestDomainEventLocation()
                                        {
                                            ToUserName = toUserName,
                                            FromUserName = fromUserName,
                                            CreateTime = createTime,
                                            Latitude = latitude,
                                            Longitude = longitude,
                                            Precision = precision
                                        };

                                        #endregion
                                    }
                                    break;
                                case "click":
                                    {
                                        #region click

                                        string eventKey = (string)hashtable["EventKey"];

                                        requestDomainBasic = new RequestDomainEventClick()
                                        {
                                            ToUserName = toUserName,
                                            FromUserName = fromUserName,
                                            CreateTime = createTime,
                                            EventKey = eventKey
                                        };

                                        #endregion
                                    }
                                    break;
                                case "view":
                                    {
                                        #region view

                                        string eventKey = (string)hashtable["EventKey"];

                                        requestDomainBasic = new RequestDomainEventView()
                                        {
                                            ToUserName = toUserName,
                                            FromUserName = fromUserName,
                                            CreateTime = createTime,
                                            EventKey = eventKey
                                        };

                                        #endregion
                                    }
                                    break;
                            }

                            #endregion
                        }
                        break;
                    default:
                        throw new Exception("未知的消息类型");
                }
            }
            catch (Exception ex)
            {

            }

            return requestDomainBasic;
        }
    }
}
