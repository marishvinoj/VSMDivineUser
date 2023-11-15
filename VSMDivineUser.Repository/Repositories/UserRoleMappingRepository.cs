using Microsoft.EntityFrameworkCore;
using VSMDivineUser.Models;
using VSMDivineUser.Models.Entities;
using VSMDivineUser.Repository.IRepositories;

namespace VSMDivineUser.Repository.Repositories
{
    public class UserRoleMappingRepository : IUserRoleMappingRepository
    {
        private readonly UserDataContext _context;

        public UserRoleMappingRepository(UserDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserRole>> GetAllUserRoles()
        {
            return await _context.UserRoles.ToListAsync();
        }

        public async Task<UserRole> GetUserRoleById(int id)
        {
            return await _context.UserRoles.FindAsync(id);
        }

        public async Task<UserRole> AddUserRole(UserRole UserRole)
        {
            _context.UserRoles.Add(UserRole);
            await _context.SaveChangesAsync();
            return UserRole;
        }

        public async Task<UserRole> UpdateUserRole(UserRole UserRole)
        {
            _context.Entry(UserRole).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return UserRole;
        }

        public async Task<bool> DeleteUserRole(int id)
        {
            var UserRole = await _context.UserRoles.FindAsync(id);
            if (UserRole == null)
                return false;

            _context.UserRoles.Remove(UserRole);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
