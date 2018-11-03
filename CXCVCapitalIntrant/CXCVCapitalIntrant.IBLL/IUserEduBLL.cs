using CXCVCapitalIntrant.Model;
using CXCVCapitalIntrant.Model.AccountInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXCVCapitalIntrant.IBLL
{
    public interface IUserEduBLL:IBaseBLL<t_user_edu>
    {

        bool AddEduRecord(t_user_edu useredu, UserStatus userStatus);
        bool EditEduRecord(t_user_edu useredu, UserStatus userStatus);

        bool DeleteEduRecord(t_user_edu useredu, UserStatus userStatus);
    }
}
