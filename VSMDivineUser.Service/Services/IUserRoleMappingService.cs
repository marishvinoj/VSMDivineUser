using VSMDivineUser.Models;

namespace VSMDivineUser.Service.Services
{
    public interface IUserRoleMappingService
    {
        Task<IEnumerable<UserRoleMapping>> GetAllUserRoleMappings(int pageIndex = 1, int pageSize = 10);
        Task<UserRoleMapping> GetUserRoleMappingById(int id);
        Task AddUserRoleMapping(UserRoleMapping user);
        Task UpdateUserRoleMapping(UserRoleMapping user);
        Task DeleteUserRoleMapping(UserRoleMapping user);
    }
}
