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
    public class UserEduBLL:BaseBLL<t_user_edu>, IUserEduBLL
    {
        /// <summary>
        /// 给员工添加学历记录 
        /// 同时更新员工最高学历
        /// 按学历开始时间 取最后一个
        /// </summary>
        /// <param name="useredu"></param>
        /// <param name="userStatus"></param>
        /// <returns></returns>
        public bool AddEduRecord(t_user_edu useredu, UserStatus userStatus) {
            UserInfoBaseBLL userInfoBll = new UserInfoBaseBLL();
            var userInfo = userInfoBll.GetEntity(o => o.pkid == useredu.userid);
            if (userInfo == null) return false;

            bool b = AddEntity(useredu);
            var lastRecord = GetList(null)?.OrderByDescending(o => o.startdate).FirstOrDefault();
            b = b & UpdateUserInfo(userInfo, lastRecord, userStatus);
            return b;
        }

        /// <summary>
        /// 给员工添加学历记录 
        /// 同时更新员工最高学历
        /// 按学历开始时间 取最后一个
        /// </summary>
        /// <param name="useredu"></param>
        /// <param name="userStatus"></param>
        /// <returns></returns>
        public bool EditEduRecord(t_user_edu useredu, UserStatus userStatus)
        {
            UserInfoBaseBLL userInfoBll = new UserInfoBaseBLL();
            var userInfo = userInfoBll.GetEntity(o => o.pkid == useredu.userid);
            if (userInfo == null) return false;

            bool b = AddEntity(useredu);
            var lastRecord = GetList(null)?.OrderByDescending(o => o.startdate).FirstOrDefault();
            b = b & UpdateUserInfo(userInfo, lastRecord,userStatus);
            return b;
        }

        /// <summary>
        /// 删除学历 同时更新主表学历内容
        /// </summary>
        /// <param name="useredu"></param>
        /// <param name="userStatus"></param>
        /// <returns></returns>
        public bool DeleteEduRecord(t_user_edu useredu, UserStatus userStatus)
        {
            UserInfoBaseBLL userInfoBll = new UserInfoBaseBLL();
            var userInfo = userInfoBll.GetEntity(o => o.pkid == useredu.userid);
            if (userInfo == null) return false;
            bool b = DeleteEntity(useredu);
            var lastRecord = GetList(null)?.OrderByDescending(o => o.startdate).FirstOrDefault();
            b = b & UpdateUserInfo(userInfo, lastRecord, userStatus);
            return b;
        }


        /// <summary>
        /// 更新edu 相关的t_userinfo_base
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="lastRecord"></param>
        /// <param name="userStatus"></param>
        /// <returns></returns>
        private bool UpdateUserInfo(t_userinfo_base userInfo,t_user_edu lastRecord,UserStatus userStatus) {
            bool res = true;
            if (lastRecord != null && userInfo.lastrecord != lastRecord.education)
            {
                userInfo.lastrecord = lastRecord.education;
                userInfo.lastschool = lastRecord.university;
                userInfo.lastschooldate = lastRecord.enddate;
                userInfo.lastspeciality = lastRecord.major;
            }
            if (lastRecord == null) {
                userInfo.lastrecord = null;
                userInfo.lastschool = null;
                userInfo.lastschooldate = null;
                userInfo.lastspeciality = null;
            }
            userInfo.updatetime = DateTime.Now;
            userInfo.updateuserid = userStatus.UserID;
            res = new UserInfoBaseBLL().UpdateEntity(userInfo);

            return res;
        }
    }
}
