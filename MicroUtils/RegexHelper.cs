using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MicroUtils
{
    /// <summary>
    /// 正则表达式帮助类
    /// </summary>
    public class RegexHelper
    {
        #region 正则表达式

        /// <summary>
        /// 验证手机号码，简单的验证；
        /// 若是11位手机号码则true，否则false
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static bool RegexPhoneNumber(string phone)
        {
            Regex regex = new Regex("^[1]+\\d{10}$");
            return regex.IsMatch(phone);
        }

        /// <summary>
        /// 验证是否11位的纯数字，返回值 true、是，false、否
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool RegexElevenNumber(string str)
        {
            Regex regex = new Regex("\\d{11}$");
            return regex.IsMatch(str);
        }

        /// <summary>
        /// 验证是否6位的纯数字，返回值 true、是，false、否
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool RegSixNumber(string str)
        {
            Regex regex = new Regex("\\d{6}$");
            return regex.IsMatch(str);
        }

        /// <summary>
        /// 验证密码，简单的验证；
        /// 若是密码为6-16位的字母或数字则true，否者false
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static bool RegexPassWord(string pwd)
        {
            Regex regex = new Regex("^[0-9a-zA-Z]{6,16}$");
            return regex.IsMatch(pwd);
        }

        /// <summary>
        /// 验证url是不是网络路径；
        /// 若是网络路径则true，否者false
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool RegexHttpUrl(string url)
        {
            Regex regex = new Regex("^[A-Za-z]+://[A-Za-z0-9-_]+\\.[A-Za-z0-9\u4e00-\u9fa5-_~!%&#\\?\\/.=@]+$");
            return regex.IsMatch(url);
        }

        /// <summary>
        /// 验证IP地址，返回值 true、正确IP，false、错误IP
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool RegexIP(string ip)
        {
            Regex regex = new Regex("^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])$");
            return regex.IsMatch(ip);
        }

        /// <summary>
        /// 验证域名，返回值 true、正确域名，false、错误域名
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool RegexDomain(string str)
        {
            Regex regex = new Regex("^[a-zA-Z0-9]+([a-zA-Z0-9\\-\\.]+)?\\.");
            return regex.IsMatch(str);
        }

        /// <summary>
        /// 验证是否护照，返回值 true、是，false、否；验证P+7个数字和G+8个数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool RegexPassPort(string str)
        {
            Regex regex = new Regex("(P\\d{7})|G\\d{8})");
            return regex.IsMatch(str);
        }

        /// <summary>
        /// 验证是否信用卡，返回值 true、是，false、否；例如：验证VISA卡，万事达卡，Discover卡，美国运通卡
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool RegexCredit(string str)
        {
            Regex regex = new Regex("^((?:4\\d{3})|(?:5[1-5]\\d{2})|(?:6011)|(?:3[68]\\d{2})|(?:30[012345]\\d))[ -]?(\\d{4})[ -]?(\\d{4})[ -]?(\\d{4}|3[4,7]\\d{13})$");
            return regex.IsMatch(str);
        }

        /// <summary>
        /// 验证是否车牌号，返回值 true、是，false、否
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool RegexCarNo(string str)
        {
            Regex regex = new Regex("^[京津沪渝冀豫云辽黑湘皖鲁新苏浙赣鄂桂甘晋蒙陕吉闽贵粤青藏川宁琼使领A-Z]{1}[A-Z]{1}[A-Z0-9]{4,5}[A-Z0-9挂学警港澳]{1}$");
            return regex.IsMatch(str);
        }

        /// <summary>
        /// 验证是否Guid，返回值 true、是，false、否
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool RegexGuid(string str)
        {
            Regex regex = new Regex("^[A-Z0-9]{8}-[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{12}$");
            return regex.IsMatch(str);
        }

        /// <summary>
        /// 正则表达式替换字符串
        /// 示例：string s = Regex.Replace(" abra ", @"^\s*(.*?)\s*$", "$1"); 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="rule"></param>
        /// <param name="ss"></param>
        /// <returns></returns>
        public static string RegexReplace(string str, string rule, string ss)
        {
            string ret = string.Empty;
            ret = Regex.Replace(str, rule, ss);
            return ret;
        }

        /// <summary>
        /// 获得HTML中的指定标签名称的Text
        /// </summary>
        /// <param name="htmlText"></param>
        /// <param name="htmlTag"></param>
        /// <returns></returns>
        public static string RegexHtmlText(string htmlText, string htmlTag)
        {
            string retString = string.Empty;
            string reg = "(?<=<HtmlTag.*?>)(.*?)(?=</HtmlTag>)".Replace("HtmlTag", htmlTag); // <a[^>]*?>(?<Text>[^<]*)<\\/a> // "<a[^<]*>(.*?)</a>";
            //MatchCollection matchs = Regex.Matches(htmlText, reg, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline);
            Match match = Regex.Match(htmlText, reg, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.Singleline);
            retString = match.Groups[1].Value;
            return retString;
        }

        /// <summary>
        /// 替换Html中的img标签的src路径，若是相对路径就转为Http网络路径
        /// </summary>
        /// <param name="htmlText"></param>
        /// <param name="prefixUrl"></param>
        /// <returns></returns>
        public static string RegexHtmlImgUrl(string htmlText, string prefixUrl)
        {
            string retString = string.Empty;
            string reg = "(?is)<img\\s+((?<key>[^=]+)=([\"']?)(?<value>[^'\"]+)\\2\\s*)+?\\s*/?>([^<>]*?</img>)?";
            if (string.IsNullOrEmpty(prefixUrl))
            {
                retString = htmlText;
            }
            else if (string.IsNullOrEmpty(htmlText))
            {
                retString = htmlText;
            }
            else
            {
                retString = htmlText;
                MatchCollection matchs = Regex.Matches(retString, reg, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline);
                foreach (Match match in matchs)
                {
                    CaptureCollection keys = match.Groups["key"].Captures;
                    CaptureCollection values = match.Groups["value"].Captures;
                    for (int i = 0; i < keys.Count; i++)
                    {
                        Capture key = keys[i];
                        Capture value = values[i];
                        if (key.Value == "src")
                        {
                            string src = value.Value;
                            if (!RegexHttpUrl(src))
                            {
                                string httpSrc = src;
                                if (httpSrc.StartsWith("/ueditor/net/"))
                                {
                                    httpSrc = string.Format("{0}{1}", prefixUrl, httpSrc.Replace("/ueditor/net/", "/download/ueditor/"));
                                }
                                else
                                {
                                    httpSrc = string.Format("{0}{1}", prefixUrl, httpSrc);
                                }
                                string oldHtml = match.Value;
                                string newHtml = oldHtml.Replace(src, httpSrc);
                                retString = retString.Replace(oldHtml, newHtml);
                            }
                            else if (src.LastIndexOf("?") > 0)
                            {
                                // 过滤页面给图片的传参
                                string httpSrc = src;
                                httpSrc = httpSrc.Substring(0, httpSrc.LastIndexOf("?"));
                                string oldHtml = match.Value;
                                string newHtml = oldHtml.Replace(src, httpSrc);
                                retString = retString.Replace(oldHtml, newHtml);
                            }
                            break; // 跳出本次循环
                        }
                    }
                }
            }
            return retString;
        }

        #endregion
    }
}
