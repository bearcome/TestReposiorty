using CXCVCapitalIntrant.BLL;
using CXCVCapitalIntrant.Common;
using CXCVCapitalIntrant.Model;
using CXCVCapitalIntrant.Web.App_Start;
using System;
using System.Web;
using System.Web.Mvc;

namespace CXCVCapitalIntrant.Web.Controllers
{
    public class UserInfoController : Controller
    {
        [HttpGet]
        public ActionResult Create() {
            return View();
        }


        [HttpPost]
        public ActionResult CreateSave() {

            t_userinfo_base userInfoBase = new t_userinfo_base();
            GenerateUserInfoFromRequest(userInfoBase, Request);
            UserInfoBaseBLL userInfoBaseBll = new UserInfoBaseBLL();
            bool res = userInfoBaseBll.AddEntity(userInfoBase);

            return Json("");
        }

        [HttpGet]
        public ActionResult Edit(int id) {
            var userInfo = new UserInfoBaseBLL().GetEntity(o => o.pkid == id);
            ViewBag.UserInfoBase = userInfo;
            return View();
        }


        [HttpPost]
        public ActionResult EditSave(int id)
        {
            
            UserInfoBaseBLL userInfoBaseBll = new UserInfoBaseBLL();
            t_userinfo_base userInfoBase = userInfoBaseBll.GetEntity(o=>o.pkid==id);
            GenerateUserInfoFromRequest(userInfoBase, Request);
            bool res = userInfoBaseBll.AddEntity(userInfoBase);
            return Json("");
        }


        private void GenerateUserInfoFromRequest(t_userinfo_base userInfoBase, HttpRequestBase request) {

            var userStatus = UserStatusManage.getUserStatus();

            userInfoBase.usercode = request["usercode"];
            userInfoBase.pycodefull = request["pycodefull"];
            userInfoBase.pycodeshort = request["pycodeshort"];
            userInfoBase.usernameen = request["usernameen"];
            userInfoBase.nickname = request["nickname"];
            userInfoBase.gender = request["gender"];
            userInfoBase.birthday = string.IsNullOrEmpty(request["birthday"])?default(DateTime?): DateTime.Parse(request["birthday"]);
            userInfoBase.birthcountry = string.IsNullOrEmpty(request["birthcountry"])?default(int?):int.Parse(request["birthcountry"]);
            userInfoBase.birthcity  = string.IsNullOrEmpty(request["birthcity"]) ? default(int?) : int.Parse(request["birthcity"]); 
            userInfoBase.nationalityid  = string.IsNullOrEmpty(request["nationalityid"]) ? default(int?) : int.Parse(request["nationalityid"]); 
            userInfoBase.lastrecord  = string.IsNullOrEmpty(request["lastrecord"]) ? default(int?) : int.Parse(request["lastrecord"]);
            userInfoBase.lastschool  = request["lastschool"];
            userInfoBase.lastspeciality  = request["lastspeciality"];
            userInfoBase.lastschooldate  = string.IsNullOrEmpty(request["lastschooldate"]) ? default(DateTime?) : DateTime.Parse(request["lastschooldate"]); 
            userInfoBase.checkindate  = string.IsNullOrEmpty(request["checkindate"]) ? default(DateTime?) : DateTime.Parse(request["checkindate"]);
            userInfoBase.checkoutdate  = string.IsNullOrEmpty(request["checkoutdate"]) ? default(DateTime?) : DateTime.Parse(request["checkoutdate"]);

            string tempfiletype = null;
            userInfoBase.userhrpic = StreamUtil.StreamToByte(request.Files, "userhrpic", ref tempfiletype);
            userInfoBase.userhrpictype = tempfiletype;
            userInfoBase.userselfpic = StreamUtil.StreamToByte(request.Files, "userselfpic", ref tempfiletype);
            userInfoBase.userselfpictype = tempfiletype;

            userInfoBase.lasttitle  = string.IsNullOrEmpty(request["lasttitle"]) ? default(int?) : int.Parse(request["lasttitle"]);
            userInfoBase.lastjobpost  = string.IsNullOrEmpty(request["lastjobpost"]) ? default(int?) : int.Parse(request["lastjobpost"]); 
            userInfoBase.lastlevel  = string.IsNullOrEmpty(request["lastlevel"]) ? default(int?) : int.Parse(request["lastlevel"]);
            userInfoBase.costcenterid  = string.IsNullOrEmpty(request["costcenterid"]) ? default(int?) : int.Parse(request["costcenterid"]); 
            userInfoBase.basecityid  = string.IsNullOrEmpty(request["basecityid"]) ? default(int?) : int.Parse(request["basecityid"]);
            userInfoBase.workcityid  = string.IsNullOrEmpty(request["workcityid"]) ? default(int?) : int.Parse(request["workcityid"]); 
            userInfoBase.towerid  = string.IsNullOrEmpty(request["towerid"]) ? default(int?) : int.Parse(request["towerid"]);
            userInfoBase.officenum  = request["officenum"];
            userInfoBase.groupid  = string.IsNullOrEmpty(request["groupid"]) ? default(int?) : int.Parse(request["groupid"]); 
            userInfoBase.subcomid  = string.IsNullOrEmpty(request["subcomid"]) ? default(int?) : int.Parse(request["subcomid"]);
            userInfoBase.departid  = string.IsNullOrEmpty(request["departid"]) ? default(int?) : int.Parse(request["departid"]);
            userInfoBase.areaid  = string.IsNullOrEmpty(request["areaid"]) ? default(int?) : int.Parse(request["areaid"]);
            userInfoBase.secuserid1  = string.IsNullOrEmpty(request["secuserid1"]) ? default(int?) : int.Parse(request["secuserid1"]);
            userInfoBase.secuserid2  = string.IsNullOrEmpty(request["secuserid2"]) ? default(int?) : int.Parse(request["secuserid2"]);
            userInfoBase.phonenums  = request["phonenums"];
            userInfoBase.callnums  = request["callnums"];
            userInfoBase.faxnums  = request["faxnums"];
            userInfoBase.emailcom  = request["emailcom"];
            userInfoBase.emailself  = request["emailself"];
            userInfoBase.politicalid  = string.IsNullOrEmpty(request["politicalid"]) ? default(int?) : int.Parse(request["politicalid"]); 
            userInfoBase.inpartydate = string.IsNullOrEmpty(request["inpartydate"]) ? default(DateTime?) : DateTime.Parse(request["inpartydate"]);
            //userInfoBase.lastlogdate = string.IsNullOrEmpty(request["inpartydate"]) ? default(DateTime?) : DateTime.Parse(request["inpartydate"]);
            //userInfoBase.statusid = request["statusid"];
            //userInfoBase.isdeleted = request["isdeleted"];
            userInfoBase.updatetime = DateTime.Now;
            userInfoBase.updateuserid = userStatus.UserID;

        }
      
    }
}
