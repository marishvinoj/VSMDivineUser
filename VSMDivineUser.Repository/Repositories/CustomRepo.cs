using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using VSMDivineUser.Models;
using VSMDivineUser.Models.Dtos;
using VSMDivineUser.Models.Entities;
using VSMDivineUser.Repository.IRepositories;

namespace VSMDivineUser.Repository.Repositories
{
    public class CustomRepo<T> : ICustomRepo<T> where T : class
    {
        private readonly UserDataContext _context;
        private readonly DbSet<T> _dbSet;

        public CustomRepo(UserDataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<UserRoleMapListDto>> GetUserRoleMappingByUserId(int UserID)
        {
            List<UserRoleMapListDto> result = await GetUserRoleMappingList();

            var res = await _context.Users
                        .Join(_context.UserRoleMappings,
                            u => u.Id,
                            urm => urm.UserId,
                            (u, urm) => new { User = u, UserRoleMapping = urm })
                        .Join(_context.UserRoles,
                            ur => ur.UserRoleMapping.RoleId,
                            r => r.Id,
                            (ur, r) => new { ur.User, ur.UserRoleMapping, UserRole = r })
                        .Select(x => new UserRoleMapListDto
                        {
                            UserID = x.User.Id,
                            UserName = x.User.Name,
                            RoleName = x.UserRole.RoleName,
                            RoleID = x.UserRole.Id
                        }).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<UserRoleMapUserListDto>> GetaAllUserRoleMapping(int pageIndex, int pageSize)
        {
            try
            {
                var result = await (from u in _context.Users
                             join urm in _context.UserRoleMappings on u.Id equals urm.UserId into urmGroup
                             from urm in urmGroup.DefaultIfEmpty()
                             join ur in _context.UserRoles on urm.RoleId equals ur.Id into urGroup
                             from ur in urGroup.DefaultIfEmpty()
                             group new { u, ur } by new { u.Id, u.Name } into g
                             select new UserRoleMapUserListDto
                             {
                                 Id = g.Key.Id,
                                 UserName = g.Key.Name,
                                 RoleNames = string.Join(",", g.Select(x => x.ur.RoleName))
                             }).Where(x=> x.RoleNames != "").ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<UserRoleMapping>> GetaAllUserRoleMappingByUserId(int UserId)
        {
            var result = await (from urm in _context.UserRoleMappings
                                join u in _context.Users on urm.UserId equals u.Id into urmGroup
                                from u in urmGroup.DefaultIfEmpty()
                                where urm.UserId == urm.UserId
                                select urm
                                ).ToListAsync();
            return result;
        }

        private async Task<List<UserRoleMapListDto>> GetUserRoleMappingList()
        {
            var res = await _context.Users
                        .Join(_context.UserRoleMappings,
                            u => u.Id,
                            urm => urm.UserId,
                            (u, urm) => new { User = u, UserRoleMapping = urm })
                        .Join(_context.UserRoles,
                            ur => ur.UserRoleMapping.RoleId,
                            r => r.Id,
                            (ur, r) => new { ur.User, ur.UserRoleMapping, UserRole = r })
                        .Select(x => new UserRoleMapListDto
                        {
                            UserID = x.User.Id,
                            UserName = x.User.Name,
                            RoleName = x.UserRole.RoleName,
                            RoleID = x.UserRole.Id
                        }).ToListAsync();
            return res;
        }

    }
}
