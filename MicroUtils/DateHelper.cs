using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MicroUtils
{
    /// <summary>
    /// 时间的帮助类
    /// </summary>
    public class DateHelper
    {

        /// <summary>
        /// 时间戳转成时间格式
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime TimeStampToDateTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }

        /// <summary>
        /// 日期转换成时间戳，返回值 时间戳Long
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long DateTimeToTimestamp(DateTime dateTime)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, dateTime.Kind);
            return Convert.ToInt64((dateTime - start).TotalSeconds);
        }

        /// <summary>
        /// 日期转换成时间戳，返回值 时间戳 Long ，13位
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long DateTimeToTimestamp13(DateTime dateTime)
        {
            var start = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, 0));
            return (dateTime.Ticks - start.Ticks) / 10000;   //除10000调整为13位   
        }

        /// <summary>
        /// 日期格式的字符串yyyyMMddHHmmss，转成日期格式
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime DateTimeByString14(string str)
        {
            return DateTime.ParseExact(str, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// 日期格式的字符串yyyyMMdd，转成日期格式
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime DateTimeByString8(string str)
        {
            return DateTime.ParseExact(str, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// 获取标准北京时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetNetDateTime()
        {
            DateTime dt;

            //返回国际标准时间
            //只使用的dateServer的IP地址，未使用域名
            try
            {
                string[,] dateServer = new string[14, 2];
                int[] serachOrd = new int[] { 3, 2, 4, 8, 9, 6, 11, 5, 10, 0, 1, 7, 12 };
                dateServer[0, 0] = "time-a.nist.gov";
                dateServer[0, 1] = "129.6.15.28";
                dateServer[1, 0] = "time-b.nist.gov";
                dateServer[1, 1] = "129.6.15.29";
                dateServer[2, 0] = "time-a.timefreq.bldrdoc.gov";
                dateServer[2, 1] = "132.163.4.101";
                dateServer[3, 0] = "time-b.timefreq.bldrdoc.gov";
                dateServer[3, 1] = "132.163.4.102";
                dateServer[4, 0] = "time-c.timefreq.bldrdoc.gov";
                dateServer[4, 1] = "132.163.4.103";
                dateServer[5, 0] = "utcnist.colorado.edu";
                dateServer[5, 1] = "128.138.140.44";
                dateServer[6, 0] = "time.nist.gov";
                dateServer[6, 1] = "192.43.244.18";
                dateServer[7, 0] = "time-nw.nist.gov";
                dateServer[7, 1] = "131.107.1.10";
                dateServer[8, 0] = "nist1.symmetricom.com";
                dateServer[8, 1] = "69.25.96.13";
                dateServer[9, 0] = "nist1-dc.glassey.com";
                dateServer[9, 1] = "216.200.93.8";
                dateServer[10, 0] = "nist1-ny.glassey.com";
                dateServer[10, 1] = "208.184.49.9";
                dateServer[11, 0] = "nist1-sj.glassey.com";
                dateServer[11, 1] = "207.126.98.204";
                dateServer[12, 0] = "nist1.aol-ca.truetime.com";
                dateServer[12, 1] = "207.200.81.113";
                dateServer[13, 0] = "nist1.aol-va.truetime.com";
                dateServer[13, 1] = "64.236.96.53";
                int portNum = 13;
                string hostName;
                byte[] bytes = new byte[1024];
                int bytesRead = 0;
                System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient();
                for (int i = 0; i < 13; i++)
                {
                    hostName = dateServer[serachOrd[i], 1];
                    try
                    {
                        client.Connect(hostName, portNum);
                        System.Net.Sockets.NetworkStream ns = client.GetStream();
                        bytesRead = ns.Read(bytes, 0, bytes.Length);
                        client.Close();
                        break;
                    }
                    catch (Exception)
                    {
                    }
                }
                char[] sp = new char[1];
                sp[0] = ' ';
                dt = new DateTime();
                string str1;
                str1 = Encoding.ASCII.GetString(bytes, 0, bytesRead);

                string[] s;
                s = str1.Split(sp);
                if (s.Length >= 2)
                {
                    dt = DateTime.Parse(s[1] + " " + s[2]);//得到标准时间
                    dt = dt.AddHours(8);//得到北京时间*/
                }
                else
                {
                    dt = DateTime.Now; //DateTime.Parse("2011-1-1"); // --> 读取失败，采用服务器时间
                }
            }
            catch (Exception)
            {
                dt = DateTime.Parse("2011-1-1");
            }
            return dt;
        }

        /// <summary>
        /// 获取当前时间的时间戳字符串，返回值是13位
        /// </summary>
        /// <returns></returns>
        public static string GetNowTimeStamp()
        {
            string timespam = DateTimeToTimestamp(DateTime.Now).ToString();
            string timeStampUrl = "http://www.hko.gov.hk/cgi-bin/gts/time5a.pr?a=1";
            WebRequest wrt = null;
            WebResponse wrp = null;

            try
            {
                wrt = WebRequest.Create(timeStampUrl);
                wrp = wrt.GetResponse();

                string html = string.Empty;
                using (Stream stream = wrp.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(stream, Encoding.UTF8))
                    {
                        html = sr.ReadToEnd();
                    }
                }
                timespam = html.Split('=')[1]; //13位
            }
            catch (WebException)
            {
                return timespam;
            }
            catch (Exception)
            {
                return timespam;
            }
            finally
            {
                if (wrp != null)
                    wrp.Close();
                if (wrt != null)
                    wrt.Abort();
            }
            return timespam;
        }

        /// <summary>
        /// 获得标准时间戳，截取了前10位
        /// </summary>
        /// <returns></returns>
        public static string GetNetTimeStamp()
        {
            string timespam = DateTimeToTimestamp(DateTime.Now).ToString();
            string timeStampUrl = "http://www.hko.gov.hk/cgi-bin/gts/time5a.pr?a=1";
            WebRequest wrt = null;
            WebResponse wrp = null;

            try
            {
                wrt = WebRequest.Create(timeStampUrl);
                wrp = wrt.GetResponse();

                string html = string.Empty;
                using (Stream stream = wrp.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(stream, Encoding.UTF8))
                    {
                        html = sr.ReadToEnd();
                    }
                }
                timespam = html.Split('=')[1].Substring(0, 10);//保存10位
            }
            catch (WebException)
            {
                return timespam;
            }
            catch (Exception)
            {
                return timespam;
            }
            finally
            {
                if (wrp != null)
                    wrp.Close();
                if (wrt != null)
                    wrt.Abort();
            }
            return timespam;
        }

        /// <summary>
        /// 获得标准时间戳，时间戳截取（3-13）共10位，算出的是过去的时间
        /// </summary>
        /// <returns></returns>
        public static string GetOldTimeStamp()
        {
            string timespam = DateTimeToTimestamp13(DateTime.Now).ToString().Substring(3, 10);
            string timeStampUrl = "http://www.hko.gov.hk/cgi-bin/gts/time5a.pr?a=1";
            WebRequest wrt = null;
            WebResponse wrp = null;

            try
            {
                wrt = WebRequest.Create(timeStampUrl);
                wrp = wrt.GetResponse();

                string html = string.Empty;
                using (Stream stream = wrp.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(stream, Encoding.UTF8))
                    {
                        html = sr.ReadToEnd();
                    }
                }
                //timespam = html.Split('=')[1].Substring(0, 10);//保存10位
                timespam = html.Split('=')[1].Substring(3, 10); // APP端是从第三位截取，time:2017-03-21
            }
            catch (WebException)
            {
                return timespam;
            }
            catch (Exception)
            {
                return timespam;
            }
            finally
            {
                if (wrp != null)
                    wrp.Close();
                if (wrt != null)
                    wrt.Abort();
            }
            return timespam;
        }

    }
}
