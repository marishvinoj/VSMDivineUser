using VSMDivineUser.Models;

namespace VSMDivineUser.Service.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers(int pageIndex = 1, int pageSize = 10);
        Task<User> GetUserById(int id);
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(User user);
    }
}
