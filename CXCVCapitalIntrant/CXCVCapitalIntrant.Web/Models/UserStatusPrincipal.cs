using CXCVCapitalIntrant.Model.AccountInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace CXCVCapitalIntrant.Web.Models
{
    public class UserStatusPrincipal : UserStatus, IPrincipal
    {
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role) { return false; }

        public UserStatusPrincipal(FormsIdentity formsIdentity)
        {
            this.Identity = formsIdentity;
        }
    }
}