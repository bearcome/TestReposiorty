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
    public class UserLevelChangeController : Controller
    {
        public ActionResult CreateSave()
        {
            var userStatus = UserStatusManage.getUserStatus();
            t_user_levelchange levelChange = new t_user_levelchange();
            GenerateLevelChange(levelChange, userStatus);
            UserLevelChangeBLL userLevelChangeBLL = new UserLevelChangeBLL();
            bool b = userLevelChangeBLL.AddUserLevelChange(levelChange, userStatus);
            return Json("");
        }

        public ActionResult EditSave(int id)
        {
            var userStatus = UserStatusManage.getUserStatus();
            UserLevelChangeBLL userLevelChangeBLL = new UserLevelChangeBLL();
            t_user_levelchange levelChange = userLevelChangeBLL.GetEntity(o => o.pkid == id);
            GenerateLevelChange(levelChange, userStatus);
            bool b = userLevelChangeBLL.EditUserLevelChange(levelChange, userStatus);
            return Json("");
        }

        private void GenerateLevelChange(t_user_levelchange levelChange, UserStatus userStatus)
        {
            if (string.IsNullOrEmpty(Request["userid"]))
            {
                throw new ArgumentException("userid 参数为空");
            }

            levelChange.userid = int.Parse(Request["userid"]);
            levelChange.postlevel = int.Parse(Request["postlevel"]);
            levelChange.startdate = DateTime.Parse(Request["startdate"]);
            levelChange.isdelete = 0;
            levelChange.updateuserid = userStatus.UserID;
            levelChange.updatetime = DateTime.Now;
        }
    }
}