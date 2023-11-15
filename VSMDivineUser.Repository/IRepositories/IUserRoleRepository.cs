using VSMDivineUser.Models;

namespace VSMDivineUser.Repository.IRepositories
{
    public interface IUserRoleRepository
    {
        Task<IEnumerable<UserRole>> GetAllUserRoles();
        Task<UserRole> GetUserRoleById(int id);
        Task<UserRole> AddUserRole(UserRole UserRole);
        Task<UserRole> UpdateUserRole(UserRole UserRole);
        Task<bool> DeleteUserRole(int id);
    }
}
