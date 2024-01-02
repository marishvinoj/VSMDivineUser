using VSMDivineUser.Models;
using VSMDivineUser.Models.Dtos;

namespace VSMDivineUser.Service.Services
{
    public interface IUserRoleMappingService
    {
        Task Post(UserRoleMappingDto usrRoleMapDto);
        Task<IEnumerable<UserRoleMapUserListDto>> GetAllUserRoleMappings(int pageIndex = 1, int pageSize = 10);
        Task<IEnumerable<UserRoleMapListDto>> GetUserRoleMappingByUserId(int UserID);
        Task<UserRoleMapping> GetUserRoleMappingById(int id);
        Task AddUserRoleMapping(UserRoleMapping user);
        Task UpdateUserRoleMapping(UserRoleMapping user);
        Task DeleteUserRoleMapping(UserRoleMapping user);
    }
}
