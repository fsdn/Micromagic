using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace MicroUtils
{
    public class RequestHelper
    {
        #region Url转码/解码

        /// <summary>
        /// 字符串传值Url之Path转码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string HttpPathEncode(string str)
        {
            return HttpUtility.UrlPathEncode(str);
        }

        /// <summary>
        /// 字符串传值Url转码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string HttpUrlEncode(string str)
        {
            return HttpUtility.UrlEncode(str).Replace("+", "%2B");
        }

        /// <summary>
        /// 字符串传值Url解码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string HttpUrlDecode(string str)
        {
            return HttpUtility.UrlDecode(str);
        }

        /// <summary>
        /// 字符串传值Html转码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string HttpHtmlEncode(string str)
        {
            return HttpUtility.HtmlEncode(str);
        }

        /// <summary>
        /// 字符串传值Html解码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string HttpHtmlDecode(string str)
        {
            return HttpUtility.HtmlDecode(str);
        }

        #endregion

        /// <summary>
        /// 将Request的普通传参序列化成Model
        /// -- 如：?id=0000-0000-000000&key=123456&sec=jksdjasdna#one
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T ParametersToObject<T>(string str)
        {
            string strJson = ParametersToJson(str);
            T ret = JsonHelper.DeserializeObject<T>(strJson);
            return ret;
        }

        /// <summary>
        /// 将Request的普通传参序列化成json字符串
        /// -- 如：?id=0000-0000-000000&key=123456&sec=jksdjasdna#one 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ParametersToJson(string str)
        {
            if (string.IsNullOrEmpty(str)) { return "{}"; }
            if (str.StartsWith("{") || str.StartsWith("[")) { return str; }
            StringBuilder sb = new StringBuilder();
            int questIndex = str.IndexOf("?");
            int wellIndex = str.IndexOf("#");
            int startIndex = (questIndex > 0 ? questIndex : 1);
            int endIndex = (wellIndex > 0 ? wellIndex : str.Length);
            str = str.Substring(startIndex, endIndex - startIndex);
            string[] paramList = str.Split('&');
            sb.Append("{");
            foreach (var item in paramList)
            {
                if (paramList[0] != item) { sb.Append(","); }
                string[] paramItem = item.Split('=');
                if (paramItem.Length > 1)
                {
                    sb.Append(string.Format("\"{0}\":\"{1}\"", paramItem[0], paramItem[1]));
                }
            }
            sb.Append("}");
            return sb.ToString();
        }

        /// <summary>
        /// 创建HttpClient Get请求
        /// </summary>
        /// <param name="url">请求URL（包含完整参数）</param>
        /// <returns></returns>
        public static string GetHttpClientData(string url)
        {
            string retString = string.Empty;
            HttpClient httpClient = new HttpClient();
            retString = httpClient.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
            return retString;
        }

        /// <summary>
        /// 创建HttpClient Post请求
        /// </summary>
        /// <param name="url">请求URL（不需要包含？）</param>
        /// <param name="IData">请求参数</param>
        /// <returns></returns>
        public static string PostHttpClientData(string url, IDictionary<string, string> IData)
        {
            string retString = string.Empty;
            HttpClient httpClient = new HttpClient();
            retString = httpClient.PostAsync(url, new FormUrlEncodedContent(IData)).Result.Content.ReadAsStringAsync().Result;
            return retString;
        }

        /// <summary>
        /// 创建Http Get请求
        /// </summary>
        /// <param name="url">请求URL（包含完整参数）</param>
        /// <returns>请求结果</returns>
        public static string GetRequestData(string url)
        {
            String retString = string.Empty;
            StreamReader reader = null;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "GET";
            webRequest.KeepAlive = true;
            webRequest.Timeout = 30000;
            webRequest.ReadWriteTimeout = 30000;
            try
            {
                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
                if (webResponse.StatusCode == HttpStatusCode.OK)
                {
                    Stream stream = webResponse.GetResponseStream();
                    stream.ReadTimeout = 30000;
                    if (webResponse.ContentEncoding == "gzip")
                    {
                        reader = new StreamReader(new GZipStream(stream, CompressionMode.Decompress), Encoding.UTF8);
                    }
                    else
                    {
                        reader = new StreamReader(stream, Encoding.UTF8);
                    }
                    retString = reader.ReadToEnd();
                    stream.Close();
                    reader.Close();
                }
                webRequest.Abort();
                webResponse.Close();
            }
            catch (Exception ex)
            {
                //throw new WxException("Http Get请求错误！", e);
                LogHelper.LogError(ex);
            }
            return retString;
        }

        /// <summary>
        /// 创建Http Post请求
        /// </summary>
        /// <param name="url">请求URL（不需要包含？）</param>
        /// <param name="IData">请求参数</param>
        /// <returns>请求结果</returns>
        public static string PostRequestData(string url, IDictionary<string, string> IData)
        {
            string retString = string.Empty;
            try
            {
                string param = string.Empty;
                foreach (var item in IData)
                {
                    param += string.Format("&{0}={1}", item.Key, item.Value);
                }
                if (!string.IsNullOrEmpty(param))
                {
                    param = param.Substring(1);
                }
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                //Header设定
                request.ContentType = "application/x-www-form-urlencoded";
                request.Method = "POST";
                request.Timeout = 200000;
                //返回类型编码
                Encoding encoding = Encoding.UTF8;
                //参数数据
                byte[] postData = encoding.GetBytes(param);
                request.ContentLength = postData.Length;
                Stream requestStream = request.GetRequestStream();
                //写入post请求参数
                requestStream.Write(postData, 0, postData.Length);
                //获取服务器返回Response对象
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                //获取服务器返回结果
                StreamReader streamReader = new StreamReader(responseStream, encoding);
                retString = streamReader.ReadToEnd();

                streamReader.Close();
                request.Abort();
                response.Close();
            }
            catch (Exception ex)
            {
                //throw new WxException("Http Post请求错误！", e);
                LogHelper.LogError(ex);
            }
            return retString;
        }
        /// <summary>
        /// 创建Http Post请求，POST提交JSON数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string PostRequestJson(string url, string json)
        {
            string retString = string.Empty;
            try
            {
                string param = json;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                //Header设定
                request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8,en-US;q=0.5,en;q=0.3");
                request.Headers.Add("Accept-Encoding", "gzip, deflate");
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:54.0) Gecko/20100101 Firefox/54.0";
                request.Accept = "*/*";
                request.ContentType = "application/json";
                request.Method = "POST";
                request.Timeout = 200000;
                request.KeepAlive = true;
                //返回类型编码
                Encoding encoding = Encoding.UTF8;
                //参数数据
                byte[] postData = encoding.GetBytes(param);
                request.ContentLength = postData.Length;
                Stream requestStream = request.GetRequestStream();
                //写入post请求参数
                requestStream.Write(postData, 0, postData.Length);
                //获取服务器返回Response对象
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                //获取服务器返回结果
                StreamReader streamReader = new StreamReader(responseStream, encoding);
                retString = streamReader.ReadToEnd();

                streamReader.Close();
                request.Abort();
                response.Close();
            }
            catch (Exception ex)
            {
                //throw new WxException("Http Post请求错误！", e);
                LogHelper.LogError(ex);
            }
            return retString;
        }
        /// <summary>
        /// 创建Client Post请求，POST提交JSON数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string PostClientJson(string url, string json)
        {
            string retString = string.Empty;
            try
            {
                string param = json;
                WebClient wc = new WebClient();
                wc.Credentials = CredentialCache.DefaultCredentials;
                wc.Encoding = Encoding.UTF8;
                retString = wc.UploadString(url, json);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex);
                if (ex.GetType().Name == "WebException")
                {
                    var e = (WebException)ex;
                    if (e.Status == WebExceptionStatus.ProtocolError)
                    {
                        HttpStatusCode errorCode = ((HttpWebResponse)e.Response).StatusCode;
                        string statusDescription = ((HttpWebResponse)e.Response).StatusDescription;
                        using (StreamReader sr = new StreamReader(((HttpWebResponse)e.Response).GetResponseStream(), Encoding.UTF8))
                        {
                            string rstResponseContent = sr.ReadToEnd();
                            retString = rstResponseContent;
                        }
                        string rstExceptionString = e.Message;
                    }
                }
            }
            return retString;
        }

        /// <summary>
        /// 创建Http 网页提交
        /// </summary>
        /// <param name="url">请求URL（不需要包含？）</param>
        /// <param name="token">token</param>
        /// <param name="data">请求参数</param>
        /// <returns></returns>
        public static string PostRequestPage(string url, string token, string data)
        {
            string retString = string.Empty;
            try
            {
                HttpClient client = new HttpClient();
                client.MaxResponseContentBufferSize = 256000;
                client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2403.157 Safari/537.36");
                client.DefaultRequestHeaders.Add("X-Token", token);
                HttpContent content = new StringContent(data);
                HttpResponseMessage response = client.PostAsync(new Uri(url), content).Result;
                retString = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex);
            }
            return retString;
        }

        /// <summary>
        /// 测试Http Url是否有效访问链接，返回值 true、测试通过，false、测试不通过，连接远程服务器失败
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool TestRequestUrl(string url)
        {
            bool ret = false;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "HEAD"; // 请求方式，必须有HttpHead访问权限，否则访问失败
                request.Timeout = 100; // 请求超时时间，单位：毫秒
                request.AllowAutoRedirect = false; // 是否允许自动重定向
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                ret = (response.StatusCode == HttpStatusCode.OK);
                request.Abort();
                response.Close();
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex);
            }
            return ret;
        }

        /// <summary>
        /// 获取请求的IP地址，包括本地、远程客户端
        /// -- 127.0.0.1，表示本地调试
        /// -- 120.25.2.44， 表示标准的IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetRequestIP()
        {
            string clientIP = string.Empty;
            if (HttpContext.Current != null)
            {
                clientIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(clientIP) || (clientIP.ToLower() == "unknown"))
                {
                    clientIP = HttpContext.Current.Request.ServerVariables["HTTP_X_REAL_IP"];
                    if (string.IsNullOrEmpty(clientIP))
                    {
                        clientIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    }
                }
                else
                {
                    clientIP = clientIP.Split(',')[0];
                }
            }
            if (clientIP.Length < 7)
            {
                clientIP = "127.0.0.1";
            }
            return clientIP;
        }

        /// <summary>
        /// 获得本地的Mac地址，必须首先获得正确IP
        /// </summary>
        /// <param name="IP">公网IP，不可以是127.0.0.1、::1等</param>
        /// <returns></returns>
        public string GetLocalMacByIP(string IP)
        {
            string dirResults = string.Empty;
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            psi.FileName = "nbtstat";
            psi.RedirectStandardInput = false;
            psi.RedirectStandardOutput = true;
            psi.Arguments = "-A " + IP;
            psi.UseShellExecute = false;
            proc = System.Diagnostics.Process.Start(psi);
            dirResults = proc.StandardOutput.ReadToEnd();
            proc.WaitForExit();
            dirResults = dirResults.Replace("\r", "").Replace("\n", "").Replace("\t", "");

            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("Mac[ ]{0,}Address[ ]{0,}=[ ]{0,}(?<key>((.)*?))__MAC", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Compiled);
            System.Text.RegularExpressions.Match mc = reg.Match(dirResults + "__MAC");

            if (mc.Success)
            {
                return mc.Groups["key"].Value;
            }
            else
            {
                reg = new System.Text.RegularExpressions.Regex("Host not found", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Compiled);
                mc = reg.Match(dirResults);
                if (mc.Success)
                {
                    return "Host not found!";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        #region WebService调用

        #region Soap1.1 Soap1.2 调用

        /// <summary>
        /// Soap1.1 Post 调用
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="name">方法名</param>
        /// <param name="ht">参数</param>
        /// <param name="xmlNs">默认值：http://tempuri.org/ </param>
        /// <returns></returns>
        public static string QuerySoapWebService1_1(string url, string name, Hashtable ht, string xmlNs)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "text/xml; charset=utf-8";
            request.Headers.Add("SOAPAction", string.Format("\"{0}{1}\"", (xmlNs + (xmlNs.EndsWith("/") ? "" : "/")), name));
            request.Credentials = CredentialCache.DefaultCredentials;// 凭证
            request.Timeout = 10000; //超时时间
            #region HashtableToSoap
            XmlDocument docXml = new XmlDocument();
            docXml.LoadXml("<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"></soap:Envelope>");
            XmlDeclaration decl = docXml.CreateXmlDeclaration("1.0", "utf-8", null);
            docXml.InsertBefore(decl, docXml.DocumentElement);
            XmlElement soapBody = docXml.CreateElement("soap", "Body", "http://schemas.xmlsoap.org/soap/envelope/");
            XmlElement soapMethod = docXml.CreateElement(name);
            soapMethod.SetAttribute("xmlns", xmlNs);
            foreach (string k in ht.Keys)
            {

                XmlElement soapPar = docXml.CreateElement(k);
                soapPar.InnerXml = ObjectToSoapXml(ht[k]);
                soapMethod.AppendChild(soapPar);
            }
            soapBody.AppendChild(soapMethod);
            docXml.DocumentElement.AppendChild(soapBody);
            byte[] data = Encoding.UTF8.GetBytes(docXml.OuterXml);
            #endregion
            request.ContentLength = data.Length;
            Stream writer = request.GetRequestStream();
            writer.Write(data, 0, data.Length);
            writer.Close();
            var response = request.GetResponse();
            XmlDocument doc = new XmlDocument();
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string retXml = sr.ReadToEnd();
            sr.Close();
            doc.LoadXml(retXml);
            XmlNamespaceManager mgr = new XmlNamespaceManager(doc.NameTable);
            mgr.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
            string bodyStr = doc.SelectSingleNode("//soap:Body/*", mgr).InnerXml;
            string tagName = string.Format("{0}Result", name);
            string retStr = RegexHelper.RegexHtmlText(bodyStr, tagName); // RegexHelper.RegexHtmlText(doc.OuterXml, tagName); 
            return retStr;
        }

        /// <summary>
        /// Soap1.2 Post 调用
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="name">方法名</param>
        /// <param name="ht">参数</param>
        /// <param name="xmlNs">默认值：http://tempuri.org/ </param>
        /// <returns></returns>
        public static string QuerySoapWebService1_2(string url, string name, Hashtable ht, string xmlNs)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/soap+xml; charset=utf-8";
            request.Credentials = CredentialCache.DefaultCredentials;// 凭证
            request.Timeout = 10000; //超时时间
            #region HashtableToSoap
            XmlDocument docXml = new XmlDocument();
            docXml.LoadXml("<soap12:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap12=\"http://www.w3.org/2003/05/soap-envelope\"></soap12:Envelope>");
            XmlDeclaration decl = docXml.CreateXmlDeclaration("1.0", "utf-8", null);
            docXml.InsertBefore(decl, docXml.DocumentElement);
            XmlElement soapBody = docXml.CreateElement("soap12", "Body", "http://www.w3.org/2003/05/soap-envelope");
            XmlElement soapMethod = docXml.CreateElement(name);
            soapMethod.SetAttribute("xmlns", xmlNs);
            foreach (string k in ht.Keys)
            {
                XmlElement soapPar = docXml.CreateElement(k);
                soapPar.InnerXml = ObjectToSoapXml(ht[k]);
                soapMethod.AppendChild(soapPar);
            }
            soapBody.AppendChild(soapMethod);
            docXml.DocumentElement.AppendChild(soapBody);
            byte[] data = Encoding.UTF8.GetBytes(docXml.OuterXml);

            #endregion
            request.ContentLength = data.Length;
            Stream writer = request.GetRequestStream();
            writer.Write(data, 0, data.Length);
            writer.Close();
            var response = request.GetResponse();
            XmlDocument doc = new XmlDocument();
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            String retXml = sr.ReadToEnd();
            sr.Close();
            doc.LoadXml(retXml);
            XmlNamespaceManager mgr = new XmlNamespaceManager(doc.NameTable);
            mgr.AddNamespace("soap12", "http://www.w3.org/2003/05/soap-envelope");
            string bodyStr = doc.SelectSingleNode("//soap12:Body/*", mgr).InnerXml;
            string tagName = string.Format("{0}Result", name);
            string retStr = RegexHelper.RegexHtmlText(bodyStr, tagName); // RegexHelper.RegexHtmlText(doc.OuterXml, tagName);

            return retStr;
        }

        #endregion

        #region Get Post Soap 调用


        //调用示例：
        //Hashtable ht = new Hashtable();
        //ht.Add("str", "test");
        //ht.Add("b", "true");
        //XmlDocument xx = WebSvcCaller.QuerySoapWebService("http://localhost:81/service.asmx", "HelloWorld", ht);
        //MessageBox.Show(xx.OuterXml);
        

        /// <summary>
        /// 需要WebService支持Post调用
        /// </summary>
        public static XmlDocument QueryPostWebService(string url, string methodName, Hashtable ht)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url + "/" + methodName);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            SetWebRequest(request);
            byte[] data = EncodePars(ht);
            WriteRequestData(request, data);

            return ReadXmlResponse(request.GetResponse());
        }

        /// <summary>
        /// 需要WebService支持Get调用
        /// </summary>
        public static XmlDocument QueryGetWebService(string url, string methodName, Hashtable ht)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url + "/" + methodName + "?" + ParsToString(ht));
            request.Method = "GET";
            request.ContentType = "text/xml; charset=utf-8";// "application/x-www-form-urlencoded";
            SetWebRequest(request);
            return ReadXmlResponse(request.GetResponse());
        }


        private static Hashtable _xmlNamespaces = new Hashtable();//缓存xmlNamespace，避免重复调用GetNamespace
        /// <summary>
        /// 通用WebService调用(Soap),参数Pars为String类型的参数名、参数值
        /// </summary>
        public static XmlDocument QuerySoapWebService(string url, string methodName, Hashtable ht)
        {
            if (_xmlNamespaces.ContainsKey(url))
            {
                return QuerySoapWebService(url, methodName, ht, _xmlNamespaces[url].ToString());
            }
            else
            {
                return QuerySoapWebService(url, methodName, ht, GetNamespace(url));
            }
        }

        private static XmlDocument QuerySoapWebService(string url, string methodName, Hashtable ht, string xmlNs)
        {
            _xmlNamespaces[url] = xmlNs;//加入缓存，提高效率
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "text/xml; charset=utf-8";
            request.Headers.Add("SOAPAction", "\"" + xmlNs + (xmlNs.EndsWith("/") ? "" : "/") + methodName + "\"");
            SetWebRequest(request);
            byte[] data = EncodeParsToSoap(ht, xmlNs, methodName);
            WriteRequestData(request, data);
            XmlDocument doc = new XmlDocument(), doc2 = new XmlDocument();
            doc = ReadXmlResponse(request.GetResponse());

            XmlNamespaceManager mgr = new XmlNamespaceManager(doc.NameTable);
            mgr.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
            String RetXml = doc.SelectSingleNode("//soap:Body/*", mgr).InnerXml;
            doc2.LoadXml("<root>" + RetXml + "</root>");
            AddDelaration(doc2);
            return doc2;
        }
        private static string GetNamespace(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "?WSDL");
            SetWebRequest(request);
            WebResponse response = request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(sr.ReadToEnd());
            sr.Close();
            return doc.SelectSingleNode("//@targetNamespace").Value;
        }
        private static byte[] EncodeParsToSoap(Hashtable ht, string xmlNs, string methodName)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"></soap:Envelope>");
            AddDelaration(doc);
            XmlElement soapBody = doc.CreateElement("soap", "Body", "http://schemas.xmlsoap.org/soap/envelope/");
            XmlElement soapMethod = doc.CreateElement(methodName);
            soapMethod.SetAttribute("xmlns", xmlNs);
            foreach (string k in ht.Keys)
            {
                XmlElement soapPar = doc.CreateElement(k);
                soapPar.InnerXml = ObjectToSoapXml(ht[k]);
                soapMethod.AppendChild(soapPar);
            }
            soapBody.AppendChild(soapMethod);
            doc.DocumentElement.AppendChild(soapBody);
            return Encoding.UTF8.GetBytes(doc.OuterXml);
        }
        private static void SetWebRequest(HttpWebRequest request)
        {
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Timeout = 10000;
        }

        private static void WriteRequestData(HttpWebRequest request, byte[] data)
        {
            request.ContentLength = data.Length;
            Stream writer = request.GetRequestStream();
            writer.Write(data, 0, data.Length);
            writer.Close();
        }

        private static byte[] EncodePars(Hashtable ht)
        {
            return Encoding.UTF8.GetBytes(ParsToString(ht));
        }

        private static string ParsToString(Hashtable ht)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string k in ht.Keys)
            {
                if (sb.Length > 0)
                {
                    sb.Append("&");
                }
                sb.Append(HttpUtility.UrlEncode(k) + "=" + HttpUtility.UrlEncode(ht[k].ToString()));
            }
            return sb.ToString();
        }

        private static XmlDocument ReadXmlResponse(WebResponse response)
        {
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            String retXml = sr.ReadToEnd();
            sr.Close();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(retXml);
            return doc;
        }

        private static void AddDelaration(XmlDocument doc)
        {
            XmlDeclaration decl = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.InsertBefore(decl, doc.DocumentElement);
        }

        #endregion

        #region 公用方法

        /// <summary>
        /// 需要WebService支持Get调用
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetWebServiceByHttp(string url)
        {
            //与指定URL创建HTTP请求
            WebRequest wrt = WebRequest.Create(url);
            //获取对应HTTP请求的响应
            WebResponse wrse = wrt.GetResponse();
            //获取响应流
            Stream strM = wrse.GetResponseStream();
            //对接响应流(以"GBK"字符集)
            StreamReader SR = new StreamReader(strM, Encoding.GetEncoding("UTF-8"));
            //获取响应流的全部字符串
            string strallstrm = SR.ReadToEnd();
            //关闭读取流
            SR.Close();
            //返回网页html代码
            return strallstrm;
        }

        /// <summary>
        /// 需要WebService支持Post调用
        /// </summary>
        /// <param name="url"></param>
        /// <param name="name"></param>
        /// <param name="ht"></param>
        /// <returns></returns>
        public static string PostWebServiceByHttp(string url, string name, Hashtable ht)
        {
            string param = string.Empty;
            foreach (var key in ht.Keys)
            {
                var value = ht[key];
                param += string.Format("&{0}={1}", Convert.ToString(key), Convert.ToString(value));
            }
            if (!string.IsNullOrEmpty(param))
            {
                param = param.Substring(1);
            }

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url + "/" + name);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Timeout = 10000;
            byte[] data = Encoding.UTF8.GetBytes(param);
            request.ContentLength = data.Length;
            Stream writer = request.GetRequestStream();
            writer.Write(data, 0, data.Length);
            writer.Close();

            StreamReader sr = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.UTF8);
            String retXml = sr.ReadToEnd();
            sr.Close();
            return retXml;
        }


        private static string ObjectToSoapXml(object o)
        {
            XmlSerializer mySerializer = new XmlSerializer(o.GetType());
            MemoryStream ms = new MemoryStream();
            mySerializer.Serialize(ms, o);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Encoding.UTF8.GetString(ms.ToArray()));
            if (doc.DocumentElement != null)
            {
                return doc.DocumentElement.InnerXml;
            }
            else
            {
                return o.ToString();
            }
        }

        #endregion

        #endregion
    }
}
