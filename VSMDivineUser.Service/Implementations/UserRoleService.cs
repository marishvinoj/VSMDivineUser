// UserService.cs
using VSMDivineUser.Models;
using VSMDivineUser.Service.Services;
using VSMDivineUser.UnitOfWork;

namespace Services.Implementations
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserRoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserRole>> GetAllUserRoles()
        {
            return await _unitOfWork.UserRoleRepository.GetAllAsync();
        }

        public async Task<IEnumerable<UserRole>> GetAllUserRoles(int pageIndex = 1, int pageSize = 10)
        {
            return await _unitOfWork.UserRoleRepository.GetAllAsync(pageIndex, pageSize);
        }

        public async Task<UserRole> GetUserRoleById(int id)
        {
            return await _unitOfWork.UserRoleRepository.GetByIdAsync(id);
        }

        public async Task AddUserRole(UserRole userRole)
        {
            await _unitOfWork.UserRoleRepository.AddAsync(userRole);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateUserRole(UserRole userRole)
        {
            await _unitOfWork.UserRoleRepository.UpdateAsync(userRole);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteUserRole(UserRole userRole)
        {
            await _unitOfWork.UserRoleRepository.DeleteAsync(userRole);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}