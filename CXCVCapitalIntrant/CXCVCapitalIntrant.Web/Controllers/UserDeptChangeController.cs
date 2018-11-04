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
    public class UserDeptChangeController : Controller
    {
        public ActionResult CreateSave()
        {
            var userStatus = UserStatusManage.getUserStatus();
            t_user_deptchange deptChange = new t_user_deptchange();
            GenerateDeptChange(deptChange, userStatus);
            UserDeptChangeBLL userDeptChangeBLL = new UserDeptChangeBLL();
            bool b = userDeptChangeBLL.AddUserDeptChange(deptChange, userStatus);
            return Json("");
        }

        public ActionResult EditSave(int id)
        {
            var userStatus = UserStatusManage.getUserStatus();
            UserDeptChangeBLL userDeptChangeBLL = new UserDeptChangeBLL();
            t_user_deptchange deptChange = userDeptChangeBLL.GetEntity(o => o.pkid == id);
            GenerateDeptChange(deptChange, userStatus);
            bool b = userDeptChangeBLL.EditUserDeptChange(deptChange, userStatus);
            return Json("");
        }

        private void GenerateDeptChange(t_user_deptchange deptChange, UserStatus userStatus)
        {
            if (string.IsNullOrEmpty(Request["userid"]))
            {
                throw new ArgumentException("userid 参数为空");
            }

            deptChange.userid = int.Parse(Request["userid"]);
            deptChange.newdeptid = int.Parse(Request["newdeptid"]);
            deptChange.startdate = DateTime.Parse(Request["startdate"]);
            deptChange.isdelete = 0;
            deptChange.updateuserid = userStatus.UserID;
            deptChange.updatetime = DateTime.Now;
        }
    }
}