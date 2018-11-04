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
    public class UserLevelChangeBLL:BaseBLL<t_user_levelchange>, IUserLevelChangeBLL
    {
        public bool AddUserLevelChange(t_user_levelchange levelChange, UserStatus userStatus)
        {
            return AddEntity(levelChange) && UpdateUserInfo(levelChange, userStatus);
        }
        public bool EditUserLevelChange(t_user_levelchange levelChange, UserStatus userStatus)
        {
            return UpdateEntity(levelChange) && UpdateUserInfo(levelChange, userStatus);
        }

        private bool UpdateUserInfo(t_user_levelchange levelChange, UserStatus userStatus)
        {
            var userInfoBaseBLL = new UserInfoBaseBLL();
            var userInfo = userInfoBaseBLL.GetEntity(o => o.pkid == levelChange.userid);
            userInfo.lastlevel = levelChange.postlevel;
            userInfo.updatetime = DateTime.Now;
            userInfo.updateuserid = userStatus.UserID;
            return userInfoBaseBLL.UpdateEntity(userInfo);
        }
    }
    public class UserPostChangeBLL : BaseBLL<t_user_postchange>, IUserPostChangeBLL
    {
        public bool AddUserPostChange(t_user_postchange postChange, UserStatus userStatus)
        {
            return AddEntity(postChange) && UpdateUserInfo(postChange, userStatus);
        }
        public bool EditUserPostChange(t_user_postchange postChange, UserStatus userStatus)
        {
            return UpdateEntity(postChange) && UpdateUserInfo(postChange, userStatus);
        }

        private bool UpdateUserInfo(t_user_postchange postChange, UserStatus userStatus)
        {
            var userInfoBaseBLL = new UserInfoBaseBLL();
            var userInfo = userInfoBaseBLL.GetEntity(o => o.pkid == postChange.userid);
            userInfo.lastjobpost = postChange.post;
            userInfo.updatetime = DateTime.Now;
            userInfo.updateuserid = userStatus.UserID;
            return userInfoBaseBLL.UpdateEntity(userInfo);
        }
    }
    public class UserTitleChangeBLL : BaseBLL<t_user_titlechange>, IUserTitleChangeBLL
    {
        public bool AddUserTitleChange(t_user_titlechange titleChange, UserStatus userStatus)
        {
            return AddEntity(titleChange) && UpdateUserInfo(titleChange, userStatus);
        }
        public bool EditUserTitleChange(t_user_titlechange titleChange, UserStatus userStatus)
        {
            return UpdateEntity(titleChange) && UpdateUserInfo(titleChange, userStatus);
        }

        private bool UpdateUserInfo(t_user_titlechange titleChange, UserStatus userStatus)
        {
            var userInfoBaseBLL = new UserInfoBaseBLL();
            var userInfo = userInfoBaseBLL.GetEntity(o => o.pkid == titleChange.userid);
            userInfo.lasttitle = titleChange.title;
            userInfo.updatetime = DateTime.Now;
            userInfo.updateuserid = userStatus.UserID;
            return userInfoBaseBLL.UpdateEntity(userInfo);
        }
    }
    public class UserDeptChangeBLL :BaseBLL<t_user_deptchange>, IUserDeptChangeBLL
    {
        public bool AddUserDeptChange(t_user_deptchange deptChange, UserStatus userStatus)
        {
            return AddEntity(deptChange) && UpdateUserInfo(deptChange, userStatus);
        }
        public bool EditUserDeptChange(t_user_deptchange deptChange, UserStatus userStatus)
        {
            return UpdateEntity(deptChange) && UpdateUserInfo(deptChange, userStatus);
        }

        private bool UpdateUserInfo(t_user_deptchange deptChange, UserStatus userStatus)
        {
            var userInfoBaseBLL = new UserInfoBaseBLL();
            var userInfo = userInfoBaseBLL.GetEntity(o => o.pkid == deptChange.userid);
            userInfo.departid = deptChange.newdeptid;
            userInfo.updatetime = DateTime.Now;
            userInfo.updateuserid = userStatus.UserID;
            return userInfoBaseBLL.UpdateEntity(userInfo);
        }
    }
    public class UserPicChangeBLL : BaseBLL<t_user_picchange>, IUserPicChangeBLL
    {
        public bool AddUserPicChange(t_user_picchange picChange, UserStatus userStatus)
        {
            return AddEntity(picChange) && UpdateUserInfo(picChange, userStatus);
        }
        public bool EditUserPicChange(t_user_picchange picChange, UserStatus userStatus)
        {
            return UpdateEntity(picChange) && UpdateUserInfo(picChange, userStatus);
        }

        private bool UpdateUserInfo(t_user_picchange picChange, UserStatus userStatus)
        {
            var userInfoBaseBLL = new UserInfoBaseBLL();
            var userInfo = userInfoBaseBLL.GetEntity(o => o.pkid == picChange.userid);
            userInfo.userselfpic = picChange.pic;
            userInfo.userselfpictype = picChange.pictype;
            userInfo.updatetime = DateTime.Now;
            userInfo.updateuserid = userStatus.UserID;
            return userInfoBaseBLL.UpdateEntity(userInfo);
        }
    }
}
