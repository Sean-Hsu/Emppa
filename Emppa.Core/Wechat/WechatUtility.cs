using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Core.Wechat
{
    public static class WechatUtility
    {
        public static int GetTimestamp()
        {
            int intResult = 0;

            DateTime dtBegin = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            DateTime dtEnd = DateTime.Now;

            intResult = Convert.ToInt32((dtEnd - dtBegin).TotalSeconds);

            return intResult;
        }

        public static string GetNonceString()
        {
            string strResult = string.Empty;

            int intLength = 16;
            string strOrigin = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

            Random random = new Random();
            for (int i = 0; i < intLength; i++)
            {
                strResult += strOrigin.Substring(random.Next(0, strOrigin.Length - 1), 1);
            }

            return strResult;
        }
    }
}
