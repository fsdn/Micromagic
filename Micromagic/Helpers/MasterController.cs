using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Micromagic.Helpers
{
    public class MasterController : Controller
    {
        public MasterController()
        {
        }

        #region Mvc

        ///// <summary>
        ///// 获得POST提交数据
        ///// </summary>
        ///// <returns></returns>
        //private string GetPostData()
        //{
        //    string ret = Request.Form.ToString();// Request.Content.ReadAsStringAsync().Result;
        //    ret = RequestHelper.HttpUrlDecode(ret);
        //    return ret;
        //}

        ///// <summary>
        ///// 获得POST提交数据，若非Json，则转换
        ///// </summary>
        ///// <returns></returns>
        //protected string GetPostJson()
        //{
        //    string ret = GetPostData();
        //    //ret = RequestHelper.ParametersToJson(ret); // 不进行Json转化
        //    return ret;
        //}

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

        #endregion

        #region Common

        protected string GetActionID()
        {
            var objID = ControllerContext.RouteData.Values["ID"];
            string strID = (objID == null ? string.Empty : Convert.ToString(objID));
            return strID;
        }

        protected string GetParamForm(string name)
        {
            string ret = Request.Form[name];
            return ret;
        }

        protected string GetParamQuery(string name)
        {
            string ret = Request.QueryString[name];
            return ret;
        }

        //protected string GetParamEncrypt(string str)
        //{
        //    string key = GetDesKey();
        //    string ret = Des3Helper.Des3EncodeCBCStr1(key, str);
        //    return ret;
        //}

        //protected string GetParamDecrypt(string str)
        //{
        //    string key = GetDesKey();
        //    string ret = Des3Helper.Des3DecodeCBCStr1(key, str);
        //    return ret;
        //}

        private string GetDesKey()
        {
            string ret = "ABCDEFGHIGKLMNOPQRSTUVWXYZ";// "ABCDEFGHIJKLMNOPQRSTUVWX";
            string pos1 = ret.Substring(3, 8);
            string pos2 = ret.Substring(7, 8);
            string pos3 = ret.Substring(11, 8);
            ret = string.Format("{0}{1}{2}", pos3, pos2, pos1);
            return ret;
        }

        protected string GetCookieValue(string name)
        {
            string ret = string.Empty;
            HttpCookie cookie = Request.Cookies[name];
            if (cookie != null)
            {
                ret = cookie.Value;
            }
            return ret;
        }

        protected bool SetCookieValue(string name, string str)
        {
            return SetCookieValue(name, str, true);
        }
        public bool SetCookieValue(string name, string str, bool httpOnly)
        {
            bool ret = false;
            bool del = DeleteCookie(name); // 先删除之前的cookie
            HttpCookie cookie = new HttpCookie(name);
            cookie.Expires = DateTime.Now.AddHours(2);
            cookie.HttpOnly = true;
            cookie.Value = str;
            Response.Cookies.Add(cookie);
            ret = true;
            return ret;
        }

        protected bool DeleteCookie(string name)
        {
            bool ret = false;
            foreach (string cookieName in Request.Cookies.AllKeys)
            {
                HttpCookie cookies = Request.Cookies[cookieName];
                if (cookies != null && cookieName == name)
                {
                    cookies.Expires = DateTime.Today.AddDays(-1);
                    Response.Cookies.Add(cookies);
                    Request.Cookies.Remove(cookieName);

                    ret = true;
                }
            }
            return ret;
        }

        #endregion
    }
}