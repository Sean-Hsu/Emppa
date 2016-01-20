using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Emppa.Core.Encryption
{
    public sealed class MD5Hashing
    {
        static MD5 md5 = new MD5CryptoServiceProvider();

        //私有化构造函数 
        private MD5Hashing()
        {
        }

        /// <summary> 
        /// 使用utf8编码将字符串散列 
        /// </summary> 
        /// <param name="sourceString">要散列的字符串</param> 
        /// <returns>散列后的字符串</returns> 
        public static string HashString(string sourceString)
        {
            return HashString(Encoding.UTF8, sourceString);
        }

        /// <summary> 
        /// 使用指定的编码将字符串散列 
        /// </summary> 
        /// <param name="encode">编码</param> 
        /// <param name="sourceString">要散列的字符串</param> 
        /// <returns>散列后的字符串</returns> 
        public static string HashString(Encoding encode, string sourceString)
        {
            return BitConverter.ToString(md5.ComputeHash(encode.GetBytes(sourceString))).Replace("-", "");
        }
    }
}
