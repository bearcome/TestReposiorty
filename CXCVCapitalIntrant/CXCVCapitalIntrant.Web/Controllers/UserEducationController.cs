using CXCVCapitalIntrant.BLL;
using CXCVCapitalIntrant.IBLL;
using CXCVCapitalIntrant.Model;
using CXCVCapitalIntrant.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CXCVCapitalIntrant.Web.Controllers
{
    public class UserEducationController : Controller
    {

        public ActionResult CreateSave() {
            var userStatus = UserStatusManage.getUserStatus();
            t_user_edu userEdu = new t_user_edu();
            GenerateUserEdu(userEdu);
            IUserEduBLL userEducationBLL = new UserEduBLL();
            userEducationBLL.AddEduRecord(userEdu, userStatus);
            return Json("");
        }

        public ActionResult EditSave(int id)
        {
            var userStatus = UserStatusManage.getUserStatus();
            IUserEduBLL userEducationBLL = new UserEduBLL();
            t_user_edu userEdu = userEducationBLL.GetEntity(o=>o.pkid==id);
            GenerateUserEdu(userEdu);
            userEducationBLL.AddEduRecord(userEdu, userStatus);
            return Json("");
        }

        public ActionResult Delete(int id)
        {
            var userStatus = UserStatusManage.getUserStatus();
            IUserEduBLL userEducationBLL = new UserEduBLL();
            t_user_edu userEdu = userEducationBLL.GetEntity(o => o.pkid == id);
            bool b = userEducationBLL.DeleteEduRecord(userEdu, userStatus);
            return Json("");
        }

        private void GenerateUserEdu(t_user_edu userEdu) {
            if(string.IsNullOrEmpty(Request["userid"])){
                throw new ArgumentException("userid 为空");
            }
            var userStatus = UserStatusManage.getUserStatus();

            userEdu.userid = int.Parse(Request["userid"]);
            userEdu.university = Request["university"];
            userEdu.city = string.IsNullOrEmpty(Request["city"]) ? default(int?) : int.Parse(Request["city"]);
            userEdu.startdate = string.IsNullOrEmpty(Request["startdate"]) ? default(DateTime?) : DateTime.Parse(Request["startdate"]);
            userEdu.enddate = string.IsNullOrEmpty(Request["enddate"]) ? default(DateTime?) : DateTime.Parse(Request["enddate"]);
            userEdu.education = string.IsNullOrEmpty(Request["education"]) ? default(int?) : int.Parse(Request["education"]);
            userEdu.major = Request["university"];
            userEdu.desc = Request["university"];
            userEdu.updatetime = DateTime.Now;
            userEdu.updateuserid = userStatus.UserID;
        }
    }
}