using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSMDivineUser.Models.Dtos;

namespace VSMDivineUser.Repository.IRepositories
{
    public interface ICustomRepo<T> where T : class
    {
        Task<IEnumerable<UserRoleMapListDto>> GetUserRoleMappingByUserId(int UserID);
        Task<IEnumerable<UserRoleMapUserListDto>> GetaAllUserRoleMapping(int pageIndex, int pageSize);
    }
}
