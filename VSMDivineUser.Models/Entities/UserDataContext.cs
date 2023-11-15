using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace VSMDivineUser.Models.Entities
{
    public class UserDataContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        //[Table("UserRole")]
        public virtual DbSet<UserRole> UserRoles { get; set; }

        //[Table("UserRoleMapping")]
        public virtual DbSet<UserRoleMapping> UserRoleMappings { get; set; }

        public UserDataContext(DbContextOptions<UserDataContext> options) : base(options)
        {

        }

        public async Task<int> SaveChangesAsync()
        {
            // Perform any pre-save operations here

            int result = await base.SaveChangesAsync();

            // Perform any post-save operations here

            return result;
        }
    }
}
