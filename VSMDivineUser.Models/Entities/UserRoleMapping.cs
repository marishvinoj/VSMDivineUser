using System.ComponentModel.DataAnnotations.Schema;

namespace VSMDivineUser.Models
{
    [Table("UserRoleMapping")]
    public partial class UserRoleMapping : EntityBase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
