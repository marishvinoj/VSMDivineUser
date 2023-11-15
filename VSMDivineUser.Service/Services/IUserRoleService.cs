using VSMDivineUser.Models;

namespace VSMDivineUser.Service.Services
{
    public interface IUserRoleService
    {
        Task<IEnumerable<UserRole>> GetAllUserRoles();
        Task<IEnumerable<UserRole>> GetAllUserRoles(int pageIndex = 1, int pageSize = 10);
        Task<UserRole> GetUserRoleById(int id);
        Task AddUserRole(UserRole UserRole);
        Task UpdateUserRole(UserRole UserRole);
        Task DeleteUserRole(UserRole UserRole);
    }
}
