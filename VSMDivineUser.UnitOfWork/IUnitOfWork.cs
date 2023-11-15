using VSMDivineUser.Models;
using VSMDivineUser.Repository.IRepositories;

namespace VSMDivineUser.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<User> UserRepository { get; }
        IRepository<UserRole> UserRoleRepository { get; }
        IRepository<UserRoleMapping> UserRoleMappingRepository { get; }
        Task<int> SaveChangesAsync();
    }
}