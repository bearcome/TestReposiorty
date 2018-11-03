using CXCVCapitalIntrant.Model;
using CXCVCapitalIntrant.Model.AccountInfo;

namespace CXCVCapitalIntrant.IBLL
{
    public interface IUserResumeBLL:IBaseBLL<t_user_resume>
    {
        bool AddUserResume(t_user_resume resume, UserStatus userStatus);
        bool EditUserResume(t_user_resume resume, UserStatus userStatus);
        bool DeleteUserResume(t_user_resume resume, UserStatus userStatus);
    }
}
