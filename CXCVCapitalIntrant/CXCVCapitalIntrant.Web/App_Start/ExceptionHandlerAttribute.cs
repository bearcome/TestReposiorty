using CXCVCapitalIntrant.Common;
using System.Web.Http.Filters;

namespace CXCVCapitalIntrant.Web
{
    public class ExceptionHandlerAttribute: ExceptionFilterAttribute
    {
        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnException(actionExecutedContext);
            Log4netHelper.ErrorLog(actionExecutedContext.Exception);
        }
    }
}