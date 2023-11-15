using VSMDivineUser.Models;

namespace VSMDivineUser.Repository.IRepositories
{
    public interface IUserRoleMappingRepository
    {
        Task<IEnumerable<UserRoleMapping>> GetAllUserRoleMappings();
        Task<UserRoleMapping> GetUserRoleMappingById(int id);
        Task<UserRoleMapping> AddUserRoleMapping(UserRoleMapping UserRoleMapping);
        Task<UserRoleMapping> UpdateUserRoleMapping(UserRoleMapping UserRoleMapping);
        Task<bool> DeleteUserRoleMapping(int id);
    }
}
