using CXCVCapitalIntrant.BLL;
using CXCVCapitalIntrant.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXCVCapitalIntrant.Web.Tests
{
    [TestClass]
    public class Test1
    {
        [TestMethod]
        public void TestAdd()
        {
            UserInfoBaseBLL userinfobll = new UserInfoBaseBLL();
            t_userinfo_base userinfo = new t_userinfo_base();
            userinfo.basecityid = 1;
            userinfo.birthcity = 1;
            userinfo.birthcountry = 1;
            userinfo.birthday = DateTime.Now.AddYears(20);
            userinfo.callnums = "13305331614";
            userinfo.checkindate = new DateTime(2018, 10, 10);
            userinfo.checkoutdate = null;
            userinfo.costcenterid = 1;
            userinfo.departid = 1;
            userinfo.emailcom = "123@qq.com";
            userinfo.emailself = "234@qq.com";
            userinfo.faxnums = "123245";
            userinfo.gender = "男";
            userinfo.groupid = 1;
            userinfo.inpartydate = DateTime.Now.AddYears(-3);
            userinfo.isdeleted = 0;
            userinfo.lastjobpost = 1;
            userinfo.lastlevel = 1;
            userinfo.lastlogdate = DateTime.Now;
            userinfo.lastschool = "beida";
            userinfo.lastschooldate = DateTime.Now.AddYears(-5);
            userinfo.lastspeciality = "computer";
            userinfo.lasttitle = 1;
            userinfo.nationalityid = 1;
            userinfo.nickname = "niickname";
            userinfo.officenum = "12345";
            userinfo.phonenums = "1233457";
            userinfo.politicalid = 2;
            userinfo.pycodefull = "zhangsan";
            userinfo.pycodeshort = "zs";
            userinfo.secuserid1 = 4;
            userinfo.secuserid2 = 5;
            userinfo.statusid = 0;
            userinfo.subcomid = 10;
            userinfo.towerid = 12;
            userinfo.updatetime = DateTime.Now;
            userinfo.updateuserid = 1;
            userinfo.usercode = "asd";
            userinfo.userhrpic = null;
            userinfo.userhrpictype = null;
            userinfo.usernameen = "张三";
            userinfo.userselfpic = null;
            userinfo.userselfpictype = null;
            userinfo.workcityid = 10;
            bool b = userinfobll.AddEntity(userinfo);
            Assert.AreEqual(true, b);
        }
        [TestMethod]
        public void TestGetEntity()
        {
            UserInfoBaseBLL userinfobll = new UserInfoBaseBLL();
            var model = userinfobll.GetEntity(o => o.pkid == 1);
            Assert.AreNotEqual(null, model);
        }
    }
}
