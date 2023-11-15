// UserService.cs
using VSMDivineUser.Models;
using VSMDivineUser.Service.Services;
using VSMDivineUser.UnitOfWork;

namespace Services.Implementations
{
    public class UserRoleMappingService : IUserRoleMappingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserRoleMappingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserRoleMapping>> GetAllUserRoleMappings(int pageIndex = 1, int pageSize = 10)
        {
            return await _unitOfWork.UserRoleMappingRepository.GetAllAsync(pageIndex, pageSize);
        }

        public async Task<UserRoleMapping> GetUserRoleMappingById(int id)
        {
            return await _unitOfWork.UserRoleMappingRepository.GetByIdAsync(id);
        }

        public async Task AddUserRoleMapping(UserRoleMapping userRoleMapping)
        {
            await _unitOfWork.UserRoleMappingRepository.AddAsync(userRoleMapping);
        }

        public async Task UpdateUserRoleMapping(UserRoleMapping userRoleMapping)
        {
            await _unitOfWork.UserRoleMappingRepository.UpdateAsync(userRoleMapping);
        }

        public async Task DeleteUserRoleMapping(UserRoleMapping userRoleMapping)
        {
            await _unitOfWork.UserRoleMappingRepository.DeleteAsync(userRoleMapping);
        }
    }
}