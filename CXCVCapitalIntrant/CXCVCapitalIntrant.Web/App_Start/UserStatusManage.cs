using CXCVCapitalIntrant.Model.AccountInfo;
using CXCVCapitalIntrant.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CXCVCapitalIntrant.Web.App_Start
{
    public class UserStatusManage
    {
#warning 登录功能完成后 修改此方法
        /// <summary>
        /// 获取当前登录账号信息
        /// </summary>
        /// <returns></returns>
        public static UserStatus getUserStatus() {
            var user = HttpContext.Current.User as UserStatusPrincipal;
            if (user == null)
                return new UserStatus();
            return new UserStatus() {
                UserID = user.UserID,
                UserName = user.UserName,
                DeptID= user.DeptID,
                DeptName=user.DeptName
            };
        }
    }
}