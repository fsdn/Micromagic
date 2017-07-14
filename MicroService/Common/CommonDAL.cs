using MicroUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MicroService.Common
{
    public class CommonDAL
    {
        #region DataConfig

        // Des3
        private static byte[] Keys = { 0xCD, 0xED, 0x39, 0x88, 0x90, 0x56, 0x10, 0x12 };
        // sql 数据库密码加密的Key
        private static string strSqlPwdKey = "DashInfo";
        // sql 数据库的连接字符串的Key
        private static string connNameSql = "connstring_sql";
        // sql 数据库的连接字符串的Value
        private static string connStrSQL = string.Empty;
        private static string connStrSql
        {
            get
            {
                if (string.IsNullOrEmpty(connStrSQL))
                {
                    connStrSQL = ConfigurationManager.AppSettings[connNameSql];
                    //////if (!string.IsNullOrEmpty(connStrSQL))
                    //////{
                    //////    string str1, str2, str3;
                    //////    int pos1, pos2, len = 2;
                    //////    pos1 = connStrSQL.IndexOf("[[");
                    //////    if (pos1 > 0)
                    //////    {
                    //////        // 已经加密
                    //////        pos2 = connStrSQL.IndexOf("]]");
                    //////        if (pos1 < pos2)
                    //////        {
                    //////            str1 = connStrSQL.Substring(0, pos1);
                    //////            str2 = connStrSQL.Substring(pos1 + len, pos2 - pos1 - len);
                    //////            str3 = connStrSQL.Substring(pos2 + len);
                    //////            str2 = DecryptDES(str2, strSqlPwdKey);
                    //////            connStrSQL = str1 + str2 + str3;
                    //////        }
                    //////    }
                    //////    else
                    //////    {
                    //////        // 未加密，则需要将其加密，并保存
                    //////        string strPwd, strConnEncrypt;
                    //////        len = "pwd=".Length;
                    //////        pos1 = connStrSQL.IndexOf("pwd=");
                    //////        pos2 = connStrSQL.IndexOf(";", pos1);
                    //////        str1 = connStrSQL.Substring(0, pos1);
                    //////        strPwd = connStrSQL.Substring(pos1 + len, pos2 - pos1 - len).Trim();
                    //////        str2 = EncryptDES(strPwd, strSqlPwdKey);
                    //////        str3 = connStrSQL.Substring(pos2);
                    //////        strConnEncrypt = str1 + "pwd=[[" + str2 + "]]" + str3;
                    //////        #region 覆盖config的连接字符串
                    //////        XmlDocument doc = new XmlDocument();
                    //////        doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/web.config"));
                    //////        XmlNode node;
                    //////        XmlElement element;
                    //////        node = doc.SelectSingleNode("//appSettings");
                    //////        element = (XmlElement)node.SelectSingleNode("//add[@key='" + connNameSql + "']");
                    //////        element.SetAttribute("value", strConnEncrypt);
                    //////        doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/web.config"));
                    //////        #endregion
                    //////    }
                    //////}
                }
                return connStrSQL;
            }
            set { }
        }
        private static SqlHelper dbHelper = new SqlHelper(connStrSql);

        #region 数据库密码加密

        //默认密钥向量
        //private static byte[] Keys = { 0xEF, 0xAB, 0x56, 0x78, 0x90, 0x34, 0xCD, 0x12 };
        //private static byte[] Keys = { 0xCD, 0xED, 0x39, 0x88, 0x90, 0x56, 0x10, 0x12 };  // --> 这个写成全局，放在顶部了

        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public static string EncryptDES(string encryptString, string encryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch (Exception ex)
            {
                return encryptString;
            }
        }

        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string DecryptDES(string decryptString, string decryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch (Exception ex)
            {
                return decryptString;
            }
        }

        #endregion

        #endregion

        #region SqlData

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        protected static bool SqlExecute(string sql)
        {
            return dbHelper.SqlExecute(sql);
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        protected static bool SqlExecute(string sql, SqlParameter[] sqlParameters)
        {
            return dbHelper.SqlExecute(sql, sqlParameters);
        }

        /// <summary>
        /// 执行多条SQL语句事物
        /// </summary>
        /// <param name="sqlList"></param>
        /// <param name="sqlParametersList"></param>
        /// <returns></returns>
        protected static bool SqlExecute(List<string> sqlList, List<SqlParameter[]> sqlParametersList)
        {
            return dbHelper.SqlExecute(sqlList, sqlParametersList);
        }

        /// <summary>
        /// 返回数据集的第一行第一列的值
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        protected static int SqlCount(string sql)
        {
            int ret = 0;
            ret = Convert.ToInt32(dbHelper.SqlScalar(sql));
            return ret;
        }

        /// <summary>
        /// 返回数据集的第一行第一列的值
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        protected static int SqlCount(string sql, SqlParameter[] sqlParameters)
        {
            int ret = 0;
            ret = Convert.ToInt32(dbHelper.SqlScalar(sql, sqlParameters));
            return ret;
        }

        /// <summary>
        /// 返回数据集的第一行第一列的值
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        protected static object SqlScalar(string sql)
        {
            return dbHelper.SqlScalar(sql);
        }

        /// <summary>
        /// 返回数据集的第一行第一列的值
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        protected static object SqlScalar(string sql, SqlParameter[] sqlParameters)
        {
            return dbHelper.SqlScalar(sql, sqlParameters);
        }

        /// <summary>
        /// 返回单条记录，数据转模型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        protected static T SqlSingle<T>(string sql)
        {
            return SqlQuery<T>(sql).FirstOrDefault();
        }

        /// <summary>
        /// 返回单条记录，数据转模型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        protected static T SqlSingle<T>(string sql, SqlParameter[] sqlParameters)
        {
            return SqlQuery<T>(sql, sqlParameters).FirstOrDefault();
        }

        /// <summary>
        /// 返回数据集，数据转模型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        protected static List<T> SqlQuery<T>(string sql)
        {
            DataTable dt = dbHelper.SqlTable(sql);
            return JsonHelper.SerializeDataTable<T>(dt);
        }

        /// <summary>
        /// 返回数据集，数据转模型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        protected static List<T> SqlQuery<T>(string sql, SqlParameter[] sqlParameters)
        {
            DataTable dt = dbHelper.SqlTable(sql, sqlParameters);
            return JsonHelper.SerializeDataTable<T>(dt);
        }

        /// <summary>
        /// 执行存储过程，返回第一个参数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        protected static object SqlProce(string sql)
        {
            SqlParameter[] parameters = { };
            return SqlProce(sql, parameters);
        }

        /// <summary>
        /// 执行存储过程，返回第一个参数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        protected static object SqlProce(string sql, SqlParameter[] sqlParameters)
        {
            DataTable dt = dbHelper.SqlTable(CommandType.StoredProcedure, sql, sqlParameters);
            if (dt == null)
            {
                return null;
            }
            else
            {
                return dt.Rows[0][0];
            }
        }

        /// <summary>
        /// 执行存储过程，返回单条记录，数据转模型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        protected static T SqlProce1<T>(string sql, SqlParameter[] sqlParameters)
        {
            return SqlProce<T>(sql, sqlParameters).FirstOrDefault();
        }

        /// <summary>
        /// 执行存储过程，返回数据集，数据转模型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        protected static List<T> SqlProce<T>(string sql, SqlParameter[] sqlParameters)
        {
            DataTable dt = dbHelper.SqlTable(CommandType.StoredProcedure, sql, sqlParameters);
            return JsonHelper.SerializeDataTable<T>(dt);
        }

        #endregion

        #region SqlParameter

        /// <summary>
        /// SQL传参数，字符串
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected static SqlParameter SqlParameterStringEmpty(string key, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return new SqlParameter(key, DBNull.Value);
            }
            else
            {
                return new SqlParameter(key, value);
            }
        }

        /// <summary>
        /// SQL传参数，数字
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected static SqlParameter SqlParameterNumberZero(string key, int value)
        {
            if (value == 0)
            {
                return new SqlParameter(key, DBNull.Value);
            }
            else
            {
                return new SqlParameter(key, value);
            }
        }

        #endregion
    }
}
