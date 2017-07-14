using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroUtils
{
    /// <summary>
    /// json帮助类
    /// </summary>
    public class JsonHelper
    {
        #region Json

        /// <summary>
        /// 判断是否Json，返回值 true、正确Json，false、错误Json
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static bool IsJsonStart(string json)
        {
            if (!string.IsNullOrEmpty(json))
            {
                json = json.Trim('\r', '\n', ' ');
                if (json.Length > 1)
                {
                    char s = json[0];
                    char e = json[json.Length - 1];
                    return (s == '{' && e == '}') || (s == '[' && e == ']');
                }
            }
            return false;
        }

        #endregion

        #region String To Json

        /// <summary>
        /// 序列化对象成JSON字符串，并且将属性字段都转为小写，并去除属性值的空格
        /// </summary>
        /// <param name="obj">要序列化的对象</param>
        /// <returns></returns>
        public static string SerializeObjectLower(object obj)
        {
            string rect = string.Empty;

            JsonSerializerSettings jsonSetting = new JsonSerializerSettings();
            jsonSetting.ContractResolver = new LowercaseContractResolver();
            rect = JsonConvert.SerializeObject(obj, Formatting.None, jsonSetting);

            return rect;
        }

        /// <summary>
        /// 将json的属性名小写
        /// </summary>
        private class LowercaseContractResolver : DefaultContractResolver
        {
            protected override string ResolvePropertyName(string propertyName)
            {
                return propertyName.ToLower();
            }
        }

        /// <summary>
        /// 序列化成JSON字符串，指定序列化时忽略的属性
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="props">忽略属性列表</param>
        /// <returns></returns>
        public static string SerializeObjectIgnorer(object obj, List<string> props)
        {
            string rect = string.Empty;
            JsonSerializerSettings jsonSetting = new JsonSerializerSettings();
            jsonSetting.ContractResolver = new IgnorePropsContractResolver(props.ToArray());
            rect = JsonConvert.SerializeObject(obj, Formatting.None, jsonSetting);
            return rect;
        }
        /// <summary>
        /// 指定忽略属性
        /// </summary>
        private class IgnorePropsContractResolver : DefaultContractResolver
        {
            string[] props = null;
            public IgnorePropsContractResolver(string[] props)
            {
                this.props = props;
            }

            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                IList<JsonProperty> list = base.CreateProperties(type, memberSerialization);
                return list.Where(p => !props.Contains(p.PropertyName, StringComparer.OrdinalIgnoreCase)).ToList();
            }
        }
        
        /// <summary>
        /// 序列化成JSON字符串，指定序列化的属性
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="props">属性列表</param>
        /// <returns></returns>
        public static string SerializeObjectLimiter(object obj, List<string> props)
        {
            string rect = string.Empty;
            JsonSerializerSettings jsonSetting = new JsonSerializerSettings();
            jsonSetting.ContractResolver = new LimitPropsContractResolver(props.ToArray());
            rect = JsonConvert.SerializeObject(obj, Formatting.None, jsonSetting);
            return rect;
        }

        /// <summary>
        /// 指定输出属性
        /// </summary>
        private class LimitPropsContractResolver : DefaultContractResolver
        {
            string[] props = null;
            public LimitPropsContractResolver(string[] props)
            {
                this.props = props;
            }

            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                IList<JsonProperty> list = base.CreateProperties(type, memberSerialization);
                return list.Where(p => props.Contains(p.PropertyName, StringComparer.OrdinalIgnoreCase)).ToList();
            }
        }

        /// <summary>
        /// 序列化成JSON字符串，指定序列化的属性，输出属性并且小写
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="props">属性列表</param>
        /// <returns></returns>
        public static string SerializeObjectLimitLower(object obj, List<string> props)
        {
            string rect = string.Empty;
            JsonSerializerSettings jsonSetting = new JsonSerializerSettings();
            jsonSetting.ContractResolver = new LimitLowerContractResolver(props.ToArray());
            rect = JsonConvert.SerializeObject(obj, Formatting.None, jsonSetting);
            return rect;
        }

        /// <summary>
        /// 指定输出属性
        /// </summary>
        private class LimitLowerContractResolver : DefaultContractResolver
        {
            string[] props = null;
            public LimitLowerContractResolver(string[] props)
            {
                this.props = props;
            }

            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                IList<JsonProperty> list = base.CreateProperties(type, memberSerialization);
                return list.Where(p => props.Contains(p.PropertyName, StringComparer.OrdinalIgnoreCase)).ToList();
            }
            protected override string ResolvePropertyName(string propertyName)
            {
                return propertyName.ToLower();
            }
        }

        /// <summary>
        /// 获得指定属性，区分大小写
        /// --> {'People':[{'Name':'Jeff','Roles':['Manager', 'Admin']}]}
        /// --> People[0].Roles
        /// </summary>
        /// <param name="str">Json字符串</param>
        /// <param name="path">指定路径下，指定属性</param>
        /// <returns></returns>
        public static string GetJsonParameterValue(string str, string path)
        {
            var jsObject = JObject.Parse(str);
            var sltValue = jsObject.SelectToken(path);
            string value = string.Empty;
            if (sltValue == null)
            {
                value = string.Empty;
            }
            else if (sltValue.Type.ToString().ToLower() == "object")
            {
                value = JsonConvert.SerializeObject(sltValue);
            }
            else
            {
                value = Convert.ToString(sltValue);
            }
            return value;
        }
        /// <summary>
        /// 获得指定属性，不区分大小写
        /// </summary>
        /// <param name="str">Json字符串</param>
        /// <param name="name">属性名称</param>
        /// <returns></returns>
        public static string GetJsonObjectValue(string str, string name)
        {
            var jsObject = JObject.Parse(str);
            var sltValue = jsObject.GetValue(name, StringComparison.InvariantCultureIgnoreCase);
            string value = string.Empty;
            if (sltValue == null)
            {
                value = string.Empty;
            }
            else if (sltValue.Type.ToString().ToLower() == "object")
            {
                value = JsonConvert.SerializeObject(sltValue);
            }
            else
            {
                value = Convert.ToString(sltValue);
            }
            return value;
        }

        /// <summary>
        /// 修改指定属性，现在只能对根节点的属性起作用
        /// </summary>
        /// <param name="str">Json字符串</param>
        /// <param name="path">指定路径下，指定属性</param>
        /// <param name="value">指定值</param>
        /// <returns></returns>
        public static string SetJsonParameterValue(string str, string path, string value)
        {
            var strJson = str;
            strJson = System.Text.RegularExpressions.Regex.Replace(str, "(?<=\"" + path + "\":\")[^\",]*", value);
            return strJson;
        }

        /// <summary>
        /// 序列化对象成JSON字符串，不改变原大小写
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeObject(object obj)
        {
            string rect = JsonConvert.SerializeObject(obj);
            return rect;
        }

        /// <summary>
        /// 序列化JSON字符串成T对象，不区分大小写
        /// </summary>
        /// <typeparam name="T">要序列化成的对象</typeparam>
        /// <param name="str">要序列化的字符串</param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string str)
        {
            T rect = JsonConvert.DeserializeObject<T>(str);
            return rect;
        }

        #endregion

        #region Datatable to Json

        /// <summary>
        /// 序列化DataTable对象成JSON字符串，不改变原大小写
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeDataTable(object obj)
        {
            string rect = JsonConvert.SerializeObject(obj, new DataTableConverter());
            return rect;
        }

        /// <summary>
        /// 序列化JSON字符串成T对象，不区分大小写
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static List<T> SerializeDataTable<T>(object obj)
        {
            string rect = SerializeDataTable(obj);
            return JsonConvert.DeserializeObject<List<T>>(rect);
        }

        #endregion

        #region Xml To Json

        /// <summary>
        /// 序列化Xml对象成JSON字符串，不改变原大小写
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeXml(object obj)
        {
            string str = Convert.ToString(obj);
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml(str);
            return JsonConvert.SerializeXmlNode(doc);
        }

        #endregion
    }
}
