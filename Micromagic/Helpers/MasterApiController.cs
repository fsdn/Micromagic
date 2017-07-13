using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Micromagic.Helpers
{
    public class MasterApiController : ApiController
    {
        public MasterApiController()
        {
        }

        /// <summary>
        /// 获得POST提交Host
        /// </summary>
        /// <returns></returns>
        private string GetPostHost()
        {
            string ret = Request.Headers.Host;
            return ret;
        }

        /// <summary>
        /// 获得POST提交数据
        /// </summary>
        /// <returns></returns>
        private string GetPostData()
        {
            string ret = Request.Content.ReadAsStringAsync().Result;
            return ret;
        }

        /// <summary>
        /// 获得POST提交数据，若非Json，则转换
        /// </summary>
        /// <returns></returns>
        protected string GetPostJson()
        {
            string ret = GetPostData();
            //ret = RequestHelper.ParametersToJson(ret); // 不进行Json转化
            return ret;
        }

        ///// <summary>
        ///// 判断结果，处理是否成功，返回值 true、成功，false、失败
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <returns></returns>
        //protected bool GetIsSuccess(object obj)
        //{
        //    string json = JsonHelper.SerializeObject(obj);
        //    string value = JsonHelper.GetJsonObjectValue(json, "RspCode");
        //    return string.Equals("0", value);
        //}
    }
}
