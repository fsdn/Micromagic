using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MicroUtils
{
    /// <summary>
    /// MD5的帮助类
    /// </summary>
    public class Md5Helper
    {
        /// <summary>
        /// MD5信息摘要，返回字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5String(string str)
        {
            MD5 md5 = MD5.Create();
            var bs = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bs)
            {
                sb.Append(b.ToString("X2"));
            }
            
            return sb.ToString();
        }

        /// <summary>
        /// MD5信息摘要，返回Base64的字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5Base64String(string str)
        {
            MD5 md5 = MD5.Create();
            var bs = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bs)
            {
                sb.Append(b.ToString("X2"));
            }
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(sb.ToString()));
        }

        /// <summary>
        /// MD5信息摘要，返回Hash,Base64字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5HashBase64String(string str)
        {
            HashAlgorithm MD5 = HashAlgorithm.Create("MD5");
            var bs = MD5.ComputeHash(Encoding.UTF8.GetBytes(str));
            return Convert.ToBase64String(bs);
        }
    }
}
