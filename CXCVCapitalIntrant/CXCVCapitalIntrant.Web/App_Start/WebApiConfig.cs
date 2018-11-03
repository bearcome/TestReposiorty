using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CXCVCapitalIntrant.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            //全局注册 登录验证   权限验证   异常处理
            //config.Filters.Add(new AuthFilterAttribute());
            //config.Filters.Add(new CXCVActionFilterAttribute());
            //config.Filters.Add(new ExceptionHandlerAttribute());

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
