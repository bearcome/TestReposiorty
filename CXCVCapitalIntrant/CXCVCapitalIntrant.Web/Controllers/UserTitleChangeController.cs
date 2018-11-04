using CXCVCapitalIntrant.BLL;
using CXCVCapitalIntrant.Model;
using CXCVCapitalIntrant.Model.AccountInfo;
using CXCVCapitalIntrant.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CXCVCapitalIntrant.Web.Controllers
{
    public class UserTitleChangeController : Controller
    {
        public ActionResult CreateSave()
        {
            var userStatus = UserStatusManage.getUserStatus();
            t_user_titlechange titleChange = new t_user_titlechange();
            UserTitleChangeBLL userTitleChangeBLL = new UserTitleChangeBLL();
            bool b = userTitleChangeBLL.AddUserTitleChange(titleChange, userStatus);
            return Json("");
        }

        public ActionResult EditSave(int id)
        {
            var userStatus = UserStatusManage.getUserStatus();
            UserTitleChangeBLL userTitleChangeBLL = new UserTitleChangeBLL();
            t_user_titlechange titleChange = userTitleChangeBLL.GetEntity(o=>o.pkid==id);
            bool b = userTitleChangeBLL.AddUserTitleChange(titleChange, userStatus);
            return Json("");
        }

        private void GenerateTitleChange(t_user_titlechange titleChange,UserStatus userStatus) {
            if (string.IsNullOrEmpty(Request["userid"])) {
                throw new ArgumentException("userid 参数为空");
            }

            titleChange.userid = int.Parse(Request["userid"]);
            titleChange.title = int.Parse(Request["userid"]);
            titleChange.startdate =  DateTime.Parse(Request["startdate"]);
            titleChange.isdelete = 0;
            titleChange.updateuserid = userStatus.UserID;
            titleChange.updatetime = DateTime.Now;
        }
    }
}