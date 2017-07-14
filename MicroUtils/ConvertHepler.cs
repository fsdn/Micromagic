using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroUtils
{
    public class ConvertHepler
    {
        /// <summary>
        /// 将指定字符串转换为词首字母大写（全部大写将被视为首字母缩写的词不包含在内）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string TextToTitleCase(string str)
        {
            string ret = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(str);
            return ret;
        }

        /// <summary>
        /// 将指定数字转成指定位数字符串；若不足位数，左侧补零；若已足位数，直接返回
        /// </summary>
        /// <param name="num"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string LeftZeroAtNumber(long num, int len)
        {
            string ret = string.Empty;
            string numStr = Convert.ToString(num);
            if (numStr.Length < len)
            {
                StringBuilder sb = new StringBuilder();
                int l = len - numStr.Length;
                for (int i = 0; i < l; i++)
                {
                    sb.Append("0");
                }
                sb.Append(numStr);
                ret = sb.ToString();
            }
            else
            {
                ret = numStr;
            }
            return ret;
        }

        /// <summary>
        /// 将指定数字转成指定位数字符串；若不足位数，右侧补零；若已足位数，直接返回
        /// </summary>
        /// <param name="num"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string RightZeroAtNumber(long num, int len)
        {
            string ret = string.Empty;
            string numStr = Convert.ToString(num);
            if (numStr.Length < len)
            {
                StringBuilder sb = new StringBuilder();
                int l = len - numStr.Length;
                sb.Append(numStr);
                for (int i = 0; i < l; i++)
                {
                    sb.Append("0");
                }
                ret = sb.ToString();
            }
            else
            {
                ret = numStr;
            }
            return ret;
        }

        /// <summary>
        /// 分钟转成时长字符串，几年几月几日几时几分
        /// </summary>
        /// <param name="min"></param>
        /// <returns></returns>
        public static string MinuteToDurationString(int min)
        {
            string ret = string.Empty;
            DateTime date1 = DateTime.Now;
            DateTime date2 = date1.AddMinutes(min);
            TimeSpan ts = date2.Subtract(date1);

            StringBuilder sb = new StringBuilder();
            if (ts.Days > 0)
            {
                sb.Append(string.Format("{0}天", ts.Days));
            }
            if (ts.Hours > 0)
            {
                sb.Append(string.Format("{0}时", ts.Hours));
            }
            if (ts.Minutes > 0)
            {
                sb.Append(string.Format("{0}分", ts.Minutes));
            }
            ret = sb.ToString();

            return ret;
        }

        /// <summary>
        /// 指定日期的下个月第一天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime DateToNextMonthFirstDay(DateTime date)
        {
            DateTime ret = new DateTime(date.Year, date.Month, 1);
            ret = ret.AddMonths(1);
            return ret;
        }
    }
}
