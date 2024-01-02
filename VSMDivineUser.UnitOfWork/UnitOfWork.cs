using Microsoft.EntityFrameworkCore;
using VSMDivineUser.Models;
using VSMDivineUser.Models.Dtos;
using VSMDivineUser.Models.Entities;
using VSMDivineUser.Repository.IRepositories;
using VSMDivineUser.Repository.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VSMDivineUser.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserDataContext _context;
        private IRepository<User> _userRepository;
        private IRepository<UserRole> _userRoleRepository;
        private IRepository<UserRoleMapping> _userRoleMappingRepository;
        private ICustomRepo<UserRoleMapping> _customRepo;

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

        public ICustomRepo<UserRoleMapping> CustomRepo
        {
            get
            {
                _customRepo ??= new CustomRepo<UserRoleMapping>(_context);
                return _customRepo;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}