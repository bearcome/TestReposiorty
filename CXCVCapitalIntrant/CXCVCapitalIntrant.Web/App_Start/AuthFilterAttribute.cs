using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CXCVCapitalIntrant.Web
{
    public class AuthFilterAttribute: AuthorizationFilterAttribute
    {
        /// <summary>
        /// 登录状态验证
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
#warning AuthFilterAttribute 暂时没有实际内容
        }
    }
}