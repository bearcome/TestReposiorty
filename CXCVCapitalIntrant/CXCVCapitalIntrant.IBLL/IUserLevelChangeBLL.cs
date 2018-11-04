using CXCVCapitalIntrant.Model;
using CXCVCapitalIntrant.Model.AccountInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXCVCapitalIntrant.IBLL
{
    public interface IUserLevelChangeBLL:IBaseBLL<t_user_levelchange>
    {
        bool AddUserLevelChange(t_user_levelchange levelChange, UserStatus userStatus);
        bool EditUserLevelChange(t_user_levelchange levelChange, UserStatus userStatus);
    }
    public interface IUserPostChangeBLL : IBaseBLL<t_user_postchange>
    {
        bool AddUserPostChange(t_user_postchange postChange, UserStatus userStatus);
        bool EditUserPostChange(t_user_postchange postChange, UserStatus userStatus);
    }
    public interface IUserTitleChangeBLL : IBaseBLL<t_user_titlechange>
    {
        bool AddUserTitleChange(t_user_titlechange titleChange, UserStatus userStatus);
        bool EditUserTitleChange(t_user_titlechange titleChange, UserStatus userStatus);
    }
    public interface IUserDeptChangeBLL : IBaseBLL<t_user_deptchange>
    {
        bool AddUserDeptChange(t_user_deptchange deptChange, UserStatus userStatus);
        bool EditUserDeptChange(t_user_deptchange deptChange, UserStatus userStatus);

    }
    public interface IUserPicChangeBLL : IBaseBLL<t_user_picchange>
    {
        bool AddUserPicChange(t_user_picchange picChange, UserStatus userStatus);
        bool EditUserPicChange(t_user_picchange picChange, UserStatus userStatus);
    }
}
