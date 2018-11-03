using CXCVCapitalIntrant.Model.AccountInfo;
using CXCVCapitalIntrant.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace CXCVCapitalIntrant.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            if (!HttpContext.Current.Request.IsAuthenticated) return;
            var identity = (FormsIdentity)HttpContext.Current.User.Identity;

            var user = JsonConvert.DeserializeObject<UserStatus>(identity.Ticket.UserData);

            var newUser = new UserStatusPrincipal(identity)
            {
                UserID = user.UserID,
                DeptID = user.DeptID,
                UserName = user.UserName,
                DeptName = user.DeptName
            };
            HttpContext.Current.User = newUser;
        }
    }
}
