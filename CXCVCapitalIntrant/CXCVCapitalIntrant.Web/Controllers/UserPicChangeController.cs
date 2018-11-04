using CXCVCapitalIntrant.BLL;
using CXCVCapitalIntrant.Common;
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
    public class UserPicChangeController : Controller
    {
        public ActionResult CreateSave()
        {
            var userStatus = UserStatusManage.getUserStatus();
            t_user_picchange picChange = new t_user_picchange();
            GeneratePicChange(picChange, userStatus);
            UserPicChangeBLL userPicChangeBLL = new UserPicChangeBLL();
            bool b = userPicChangeBLL.AddUserPicChange(picChange, userStatus);
            return Json("");
        }

        public ActionResult EditSave(int id)
        {
            var userStatus = UserStatusManage.getUserStatus();
            UserPicChangeBLL userPicChangeBLL = new UserPicChangeBLL();
            t_user_picchange deptChange = userPicChangeBLL.GetEntity(o => o.pkid == id);
            GeneratePicChange(deptChange, userStatus);
            bool b = userPicChangeBLL.EditUserPicChange(deptChange, userStatus);
            return Json("");
        }

        private void GeneratePicChange(t_user_picchange picChange, UserStatus userStatus)
        {
            if (string.IsNullOrEmpty(Request["userid"]))
            {
                throw new ArgumentException("userid 参数为空");
            }

            picChange.userid = int.Parse(Request["userid"]);
            string filetype = null;
            picChange.pic = StreamUtil.StreamToByte(Request.Files, "pic", ref filetype);
            picChange.pictype = filetype;
            picChange.startdate = DateTime.Parse(Request["startdate"]);
            picChange.isdelete = 0;
            picChange.updateuserid = userStatus.UserID;
            picChange.updatetime = DateTime.Now;
        }
    }
}