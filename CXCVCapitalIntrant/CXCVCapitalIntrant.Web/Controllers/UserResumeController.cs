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
    public class UserResumeController : Controller
    {
        public ActionResult CreateSave()
        {
            var userStatus = UserStatusManage.getUserStatus();
            var resume = new t_user_resume();
            GenerateResumeFromRequest(resume, userStatus);
            bool b = new UserResumeBLL().AddUserResume(resume, userStatus);
            return Json("");
        }


        private void GenerateResumeFromRequest(t_user_resume resume , UserStatus userStatus)
        {
            if (string.IsNullOrEmpty(Request["userid"])) {
                throw new ArgumentException("userid 参数为空");
            }

            resume.userid = int.Parse(Request["userid"]);
            resume.belcompany = Request["userid"];
            resume.startdate = DateTime.Parse(Request["startdate"]);
            resume.enddate = string.IsNullOrEmpty(Request["enddate"]) ? default(DateTime?) : DateTime.Parse(Request["enddate"]);
            resume.lasttitle = Request["lasttitle"];
            resume.lastjobpost = Request["lastjobpost"];
            resume.lastlevel = Request["lastlevel"];
            resume.salary = string.IsNullOrEmpty(Request["salary"]) ? default(int?) : int.Parse(Request["salary"]); ;
            resume.reporttoleader = Request["reporttoleader"];
            resume.leadertitle = Request["leadertitle"];
            resume.leaderlevel = Request["leaderlevel"];
            resume.dutydesc = Request["dutydesc"];
            resume.updatetime = DateTime.Now;
            resume.updateuserid = userStatus.UserID;
        }
    }
}