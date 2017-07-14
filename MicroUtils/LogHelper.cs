using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MicroUtils
{
    /// <summary>
    /// 日志帮助类，默认使用Log4net需要配置
    /// </summary>
    public class LogHelper
    {
        #region log4net

        private static log4net.ILog _logInfo = log4net.LogManager.GetLogger("loginfo");
        private static log4net.ILog _logDebug = log4net.LogManager.GetLogger("logdebug");
        private static log4net.ILog _logError = log4net.LogManager.GetLogger("logerror");
        /// <summary>
        /// 设置config配置
        /// </summary>
        public static void SetConfig()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
        public static void SetConfig(FileInfo configFile)
        {
            log4net.Config.XmlConfigurator.Configure(configFile);
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        public static void LogError(Exception ex)
        {
            LogError(ex, null);
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        public static void LogError(Exception ex, object obj)
        {
            _logError.Error(obj, ex);
        }

        /// <summary>
        /// 调试日志
        /// </summary>
        public static void LogDebug(Exception ex)
        {
            LogDebug(ex, null);
        }

        /// <summary>
        /// 调试日志
        /// </summary>
        public static void LogDebug(Exception ex, object obj)
        {
            _logDebug.Debug(obj, ex);
        }

        /// <summary>
        /// 信息日志
        /// </summary>
        public static void LogInfo(Exception ex)
        {
            LogInfo(ex, null);
        }

        /// <summary>
        /// 信息日志
        /// </summary>
        /// <param name="obj">信息对象</param>
        /// <param name="msg">信息对象内容</param>
        public static void LogInfo(Exception ex, object obj)
        {
            _logInfo.Info(obj, ex);
        }

        #endregion

        #region WriteLog

        // 日志记录，自定义日志
        #region Model
        internal class DataEntity
        {
            internal string logTime { get; set; }
            internal string logClass { get; set; }
            internal string logNamespace { get; set; }
            internal string logInfo { get; set; }
            internal string logErrorInfo { get; set; }
            internal string logLocation { get; set; }
        }
        #endregion

        #region Class

        private static object obj = new object();

        /// <summary>
        /// 记录日志信息
        /// </summary>
        /// <param name="t">信息记录类</param>
        /// <param name="e">错误信息</param>
        public static void WriteLog(Type t, Exception e)
        {
            DataEntity _dataEntity = GetLogInfo(t, e);
            WriteLogToFile(_dataEntity);
        }

        /// <summary>
        /// 记录日志信息
        /// </summary>
        /// <param name="t">信息记录类</param>
        /// <param name="debugInfo">调试信息</param>
        /// <param name="openWriteConfig">Debug配置</param>
        public static void WriteLog(Type t, string debugInfo, string openWriteConfig = "openDebug")
        {
            string debugConfig = ConfigurationManager.AppSettings[openWriteConfig];
            if (!string.IsNullOrEmpty(debugConfig))
            {
                Boolean debug = Convert.ToBoolean(debugConfig);
                if (debug)
                {
                    DataEntity _dataEntity = GetLogInfo(t, debugInfo);
                    WriteLogToFile(_dataEntity);
                }
            }
            else
            {
                DataEntity _dataEntity = GetLogInfo(t, debugInfo);
                WriteLogToFile(_dataEntity);
            }
        }

        /// <summary>
        /// 解析系统信息
        /// </summary>
        /// <param name="t">信息记录类</param>
        /// <param name="e">错误信息</param>
        /// <returns>日志对象</returns>
        private static DataEntity GetLogInfo(Type t, Exception e)
        {
            DataEntity _dataEntity = new DataEntity()
            {
                logTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,fff"),
                logClass = t.Name.Trim(),
                logNamespace = t.FullName.Trim(),
                logInfo = e.Message.Trim(),
                logErrorInfo = e.InnerException != null ? e.InnerException.Message : "无",
                logLocation = e.StackTrace.Trim()
            };
            return _dataEntity;
        }

        /// <summary>
        /// 解析系统信息
        /// </summary>
        /// <param name="t">信息记录类</param>
        /// <param name="debugInfo">调试信息</param>
        /// <returns>日志对象</returns>
        private static DataEntity GetLogInfo(Type t, string debugInfo)
        {
            PropertyInfo[] info = t.GetProperties();
            DataEntity _dataEntity = new DataEntity()
            {
                logTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,fff"),
                logClass = t.Name.Trim(),
                logNamespace = t.FullName.Trim(),
                logInfo = debugInfo,
                logErrorInfo = "无",
                logLocation = null
            };
            return _dataEntity;
        }

        /// <summary>
        /// 写入日志到本地文件
        /// </summary>
        /// <param name="de">日志对象</param>
        private static void WriteLogToFile(DataEntity de)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("记录时间：{0}\r\n", de.logTime);
            sb.AppendFormat("记录类：{0}\r\n", de.logClass);
            sb.AppendFormat("命名空间：{0}\r\n", de.logNamespace);
            sb.AppendFormat("方法位置：{0}\r\n", de.logLocation);
            sb.AppendFormat("记录信息：{0}\r\n", de.logInfo);
            sb.AppendFormat("错误信息：{0}\r\n", de.logErrorInfo);
            sb.AppendFormat("-------------------------------------优美的分割线 ------------------------------------\r\n");

            lock (obj)
            {
                byte[] bte = ASCIIEncoding.UTF8.GetBytes(sb.ToString());
                FileStream fs = new FileStream(CreateFile(), FileMode.Append, FileAccess.Write);
                fs.Write(bte, 0, bte.Length);
                fs.Close();
            }
        }

        /// <summary>
        /// 创建日志保存目录
        /// </summary>
        /// <returns>保存路径</returns>
        private static string CreateFile()
        {
            string fileName = string.Format("c:\\WebRunningLog\\{0}\\{1}\\{2}{3}"
                          , DateTime.Now.ToString("yyyy-MM")
                          , DateTime.Now.ToString("dd")
                          , DateTime.Now.ToString("HH")
                          , ".txt");
            string cataLog = string.Format("c:\\WebRunningLog\\{0}\\{1}"
                , DateTime.Now.ToString("yyyy-MM")
                , DateTime.Now.ToString("dd"));

            if (!Directory.Exists(cataLog))
            {
                Directory.CreateDirectory(cataLog);
            }
            return fileName;
        }

        #endregion

        #endregion

        #region logJson

        private static object json = new object();

        /// <summary>
        /// 记录Json对象
        /// </summary>
        /// <param name="obj"></param>
        public static void LogJsonWrite(object obj)
        {
            LogJsonWrite(string.Empty, obj);
        }
        /// <summary>
        /// 记录Json对象
        /// </summary>
        /// <param name="name"></param>
        /// <param name="obj"></param>
        public static void LogJsonWrite(string name, object obj)
        {
            LogJsonEntity data = new LogJsonEntity()
            {
                Time = DateTime.Now,
                Data = obj
            };
            string day = DateTime.Now.ToString("yyyy-MM-dd");
            string json = JsonHelper.SerializeObject(data);
            if (string.IsNullOrEmpty(name))
            {
                name = day;
            }
            else
            {
                name = string.Format("{0} {1}", day, name);
            }
            string path = GetLogJsonFilePath(name);
            string txt = LogJsonReadFile(path);
            if (string.IsNullOrEmpty(txt))
            {
                txt = "[]";
            }
            var list = JsonHelper.DeserializeObject<List<LogJsonEntity>>(txt);
            list.Add(data);
            string str = JsonHelper.SerializeObject(list);
            LogJsonClearFile(path, str);
        }
        /// <summary>
        /// 读取Json对象
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string LogJsonRead(string name)
        {
            string ret = string.Empty;
            string path = GetLogJsonFilePath(name);
            string txt = LogJsonReadFile(path);
            if (string.IsNullOrEmpty(txt))
            {
                txt = "[]";
            }
            var list = JsonHelper.DeserializeObject<List<LogJsonEntity>>(txt);
            var obj = list.LastOrDefault();
            if (obj != null)
            {
                ret = JsonHelper.SerializeObject(obj.Data);
            }
            return ret;
        }
        private static bool LogJsonClearFile(string path, string str)
        {
            bool ret = false;
            using (FileStream fs = new FileStream(path, FileMode.Truncate, FileAccess.Write, FileShare.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
                {
                    byte[] byteArray = Encoding.Default.GetBytes(str);
                    str = Encoding.Default.GetString(byteArray);
                    sw.WriteLine(str);
                }
            }
            ret = true;
            return ret;
        }
        private static bool LogJsonWriteFile(string path, string str)
        {
            bool ret = false;
            using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
                {
                    byte[] byteArray = Encoding.Default.GetBytes(str);
                    str = Encoding.Default.GetString(byteArray);
                    sw.WriteLine(str);
                }
            }
            ret = true;
            return ret;
        }
        private static string LogJsonReadFile(string path)
        {
            string ret = string.Empty;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.Default))
                {
                    ret = sr.ReadToEnd();
                }
            }
            return ret;
        }
        private static string GetLogJsonFilePath(string name)
        {
            string folder = ConfigurationManager.AppSettings["logJson"];
            if (string.IsNullOrEmpty(folder))
            {
                folder = "C:\\logJson\\Json\\";
            }
            string path = string.Format("{0}{1}.txt", folder, name);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
            return path;
        }
        private class LogJsonEntity
        {
            public DateTime Time { get; set; }
            public object Data { get; set; }
        }

        #endregion
    }
}
