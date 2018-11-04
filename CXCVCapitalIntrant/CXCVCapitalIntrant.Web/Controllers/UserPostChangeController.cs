using CXCVCapitalIntrant.BLL;
using CXCVCapitalIntrant.Model;
using CXCVCapitalIntrant.Model.AccountInfo;
using CXCVCapitalIntrant.Web.App_Start;
using System;
using System.Web.Mvc;

namespace CXCVCapitalIntrant.Web.Controllers
{
    public class UserPostChangeController : Controller
    {
        public ActionResult CreateSave()
        {
            var userStatus = UserStatusManage.getUserStatus();
            t_user_postchange postChange = new t_user_postchange();
            GeneratePostChange(postChange, userStatus);
            UserPostChangeBLL userPostChangeBLL = new UserPostChangeBLL();
            bool b = userPostChangeBLL.AddUserPostChange(postChange, userStatus);
            return Json("");
        }

        public ActionResult EditSave(int id)
        {
            var userStatus = UserStatusManage.getUserStatus();
            UserPostChangeBLL userPostChangeBLL = new UserPostChangeBLL();
            t_user_postchange postChange = userPostChangeBLL.GetEntity(o => o.pkid == id);
            GeneratePostChange(postChange, userStatus);
            bool b = userPostChangeBLL.EditUserPostChange(postChange, userStatus);
            return Json("");
        }

        private void GeneratePostChange(t_user_postchange postChange, UserStatus userStatus)
        {
            if (string.IsNullOrEmpty(Request["userid"]))
            {
                throw new ArgumentException("userid 参数为空");
            }

            postChange.userid = int.Parse(Request["userid"]);
            postChange.post = int.Parse(Request["post"]);
            postChange.startdate = DateTime.Parse(Request["startdate"]);
            postChange.isdelete = 0;
            postChange.updateuserid = userStatus.UserID;
            postChange.updatetime = DateTime.Now;
        }
    }
}