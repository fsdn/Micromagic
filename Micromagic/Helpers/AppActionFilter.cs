using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Micromagic.Helpers
{
    public class AppActionFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);

            bool hasErr = false;
            //RspModel obj = new RspModel();
            //try
            //{
            //    var json = actionContext.Request.Content.ReadAsStringAsync().Result;
            //    var host = actionContext.Request.Headers.Host;
            //    Services.BLL.Common.CommonBLL bll = new Services.BLL.Common.CommonBLL();
            //    // 验证域名
            //    bool isHost = bll.ValidHost(json, host, ref obj);
            //    hasErr = !isHost;
            //    if (!hasErr)
            //    {
            //        // 验证参数
            //        bool isValid = bll.ValidModel(json, ref obj);
            //        hasErr = !isValid;
            //    }
            //    if (!hasErr)
            //    {
            //        // 验证权限
            //        bool isPass = bll.ValidPayPass(json, ref obj);
            //        hasErr = !isPass;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    LogHelper.LogError(ex, this);
            //}
            //if (hasErr)
            //{
            //    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK, obj);
            //}
        }
    }
}