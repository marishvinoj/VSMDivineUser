using VSMDivineUser.Models;
using VSMDivineUser.Models.Entities;
using VSMDivineUser.Repository.IRepositories;
using VSMDivineUser.Repository.Repositories;

namespace VSMDivineUser.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserDataContext _context;
        private IRepository<User> _userRepository;
        private IRepository<UserRole> _userRoleRepository;
        private IRepository<UserRoleMapping> _userRoleMappingRepository;

        public UnitOfWork(UserDataContext context)
        {
            _context = context;
        }

        public IRepository<UserRole> UserRoleRepository
        {
            get
            {
                _userRoleRepository ??= new GenericRepository<UserRole>(_context);
                return _userRoleRepository;
            }
        }

        public IRepository<User> UserRepository
        {
            get
            {
                _userRepository ??= new GenericRepository<User>(_context);
                return _userRepository;
            }
        }

        public IRepository<UserRoleMapping> UserRoleMappingRepository
        {
            get
            {
                _userRoleMappingRepository ??= new GenericRepository<UserRoleMapping>(_context);
                return _userRoleMappingRepository;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}