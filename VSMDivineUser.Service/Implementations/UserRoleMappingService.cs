// UserService.cs
using System.Data;
using VSMDivineUser.Models;
using VSMDivineUser.Models.Dtos;
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

        public async Task Post(UserRoleMappingDto usrRoleMapDto)
        {
            await MultiDeleteByUserId(usrRoleMapDto);
            foreach (var item in usrRoleMapDto.Roles)
            {
                var userRoleMapping = new UserRoleMapping
                {
                    Id = 0,
                    RoleId = item.Id,
                    UserId = usrRoleMapDto.UserID,
                    IsActive = true,
                    CreatedDate = DateTime.UtcNow
                };
                await AddUserRoleMapping(userRoleMapping);
            }
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserRoleMapping>> GetaAllUserRoleMappingByUserId(int UserId)
        {
            return await _unitOfWork.CustomRepo.GetaAllUserRoleMappingByUserId(UserId);
        }

        public async Task MultiDeleteByUserId(UserRoleMappingDto Roles)
        {
            var users = await _unitOfWork.CustomRepo.GetaAllUserRoleMappingByUserId(Roles.UserID);
            foreach (var item in users)
            {
                await _unitOfWork.UserRoleMappingRepository.DeleteAsync(item);
            }

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserRoleMapUserListDto>> GetAllUserRoleMappings(int pageIndex = 1, int pageSize = 10)
        {
            var res = await _unitOfWork.CustomRepo.GetaAllUserRoleMapping(pageIndex, pageSize);
            return res;
        }

        public async Task<IEnumerable<UserRoleMapListDto>> GetUserRoleMappingByUserId(int UserID)
        {
            return await _unitOfWork.CustomRepo.GetUserRoleMappingByUserId(UserID);
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