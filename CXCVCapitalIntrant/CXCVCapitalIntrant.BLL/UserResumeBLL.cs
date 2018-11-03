using CXCVCapitalIntrant.IBLL;
using CXCVCapitalIntrant.Model;
using CXCVCapitalIntrant.Model.AccountInfo;
using System;

namespace CXCVCapitalIntrant.BLL
{
    public class UserResumeBLL:BaseBLL<t_user_resume>,IUserResumeBLL
    {
        public bool AddUserResume(t_user_resume resume, UserStatus userStatus)
        {
            return AddEntity(resume)&& UpdateUserBase(resume, userStatus);
        }
        public bool EditUserResume(t_user_resume resume, UserStatus userStatus)
        {
            return UpdateEntity(resume) && UpdateUserBase(resume, userStatus);

        }
        public bool DeleteUserResume(t_user_resume resume, UserStatus userStatus)
        {
            return DeleteEntity(resume) && UpdateUserBase(resume, userStatus);
        }

        private bool UpdateUserBase(t_user_resume resume, UserStatus userStatus) {
            var userInfoBaseBll = new UserInfoBaseBLL();
            var userInfo = userInfoBaseBll.GetEntity(o => o.pkid == resume.userid);
            userInfo.updatetime = DateTime.Now;
            userInfo.updateuserid = userStatus.UserID;
            return userInfoBaseBll.UpdateEntity(userInfo);
        }
    }
}
