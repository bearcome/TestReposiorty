using CXCVCapitalIntrant.Model;
using CXCVCapitalIntrant.Model.AccountInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXCVCapitalIntrant.IBLL
{
    public interface IUserRelationBLL:IBaseBLL<t_user_relation>
    {
        bool AddUserRelation(t_user_relation userRel, UserStatus userStatus);
        bool EditUserRelation(t_user_relation userRel, UserStatus userStatus);
        bool DeleteUserRelation(t_user_relation userRel, UserStatus userStatus);
    }
}
