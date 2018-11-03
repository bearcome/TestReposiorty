using CXCVCapitalIntrant.IBLL;
using CXCVCapitalIntrant.Model;
using CXCVCapitalIntrant.Model.AccountInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXCVCapitalIntrant.BLL
{
    public  class UserRelationBLL:BaseBLL<t_user_relation>, IUserRelationBLL
    {
        public bool AddUserRelation(t_user_relation userRel, UserStatus userStatus)
        {
            return  AddEntity(userRel) && UpdateUserInfo(userRel, userStatus);
        }
        public bool EditUserRelation(t_user_relation userRel, UserStatus userStatus)
        {
            return UpdateEntity(userRel) && UpdateUserInfo(userRel, userStatus);
        }
        public bool DeleteUserRelation(t_user_relation userRel, UserStatus userStatus)
        {
            return DeleteEntity(userRel) && UpdateUserInfo(userRel, userStatus);
        }

        private bool UpdateUserInfo(t_user_relation userRel, UserStatus userStatus) {
            var userInfoBaseBll = new UserInfoBaseBLL();
            var userInfo = userInfoBaseBll.GetEntity(o => o.pkid == userRel.userid);
            userInfo.updatetime = DateTime.Now;
            userInfo.updateuserid = userStatus.UserID;
            return userInfoBaseBll.UpdateEntity(userInfo);
        }
    }
}
