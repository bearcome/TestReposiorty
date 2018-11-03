using CXCVCapitalIntrant.BLL;
using CXCVCapitalIntrant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CXCVCapitalIntrant.Web.Controllers
{
    public class UserRelationController : Controller
    {
        public ActionResult CreateSave() {
            t_user_relation userRel = new t_user_relation();
            GenerateUserRelFromRequest(userRel);
            bool b = new UserRelationBLL().AddEntity(userRel);
            return Json("");
        }

        public ActionResult EditSave(int id)
        {
            var userRelationBLL = new UserRelationBLL();
            t_user_relation userRel = userRelationBLL.GetEntity(o=>o.pkid==id);
            GenerateUserRelFromRequest(userRel);
            bool b = userRelationBLL.AddEntity(userRel);

            return Json("");
        }

        public ActionResult Delete(int id)
        {
            var userRelationBLL = new UserRelationBLL();
            t_user_relation userRel = userRelationBLL.GetEntity(o => o.pkid == id);
            bool b = userRelationBLL.DeleteEntity(userRel);
            return Json("");
        }

        private void GenerateUserRelFromRequest(t_user_relation userRel) {

            if (string.IsNullOrEmpty(Request["userid"]))
            {
                throw new ArgumentException("userid 参数为空");
            }
            if (string.IsNullOrEmpty(Request["relationship"]))
            {
                throw new ArgumentException("relationship 参数为空");
            }

            userRel.userid = int.Parse(Request["userid"]);
            userRel.name = Request["name"];
            userRel.gender = Request["gender"];
            userRel.nationalityid = string.IsNullOrEmpty(Request["nationalityid"])?default(int?):int.Parse(Request["nationalityid"]);
            userRel.nation = Request["nation"];
            userRel.relationship =  int.Parse(Request["relationship"]);
            userRel.location = string.IsNullOrEmpty(Request["location"]) ? default(int?) : int.Parse(Request["location"]);
            userRel.company = Request["company"];
            userRel.occupation = Request["occupation"];
            userRel.post = Request["post"];
            userRel.isparty = Request["isparty"];
            userRel.desc = Request["desc"];
        }
    }
}