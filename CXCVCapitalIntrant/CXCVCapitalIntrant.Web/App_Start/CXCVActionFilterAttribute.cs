using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CXCVCapitalIntrant.Web
{
    public class CXCVActionFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Controller Action  访问权限
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext) {
            base.OnActionExecuting(actionContext);
#warning PlatformActionFilterAttribute 暂时没有实际内容
        }
    }
}