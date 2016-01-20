using Emppa.Core.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Core.Wechat
{
    public static class WechatManager
    {
        public static string Signature(string token, string timestamp, string nonce)
        {
            string[] tempArray = { token, timestamp, nonce };
            Array.Sort(tempArray);     //字典排序
            string tempString = string.Join("", tempArray);
            tempString = SHA1Hashing.HashString(tempString);
            tempString = tempString.ToLower();

            return tempString;
        }

        public static bool CheckSignature(string signature, string token, string timestamp, string nonce)
        {
            string tempString = Signature(token, timestamp, nonce);

            return tempString == signature;
        }

        public static string JsApiSignature(int timestamp, string nonceStr, string ticket, string url)
        {
            string[] tempArray = { "timestamp=" + timestamp, "noncestr=" + nonceStr, "jsapi_ticket=" + ticket, "url=" + url };
            Array.Sort(tempArray);  //字典排序
            string tempString = string.Join("&", tempArray);
            tempString = SHA1Hashing.HashString(tempString);
            tempString = tempString.ToLower();

            return tempString;
        }
    }
}
