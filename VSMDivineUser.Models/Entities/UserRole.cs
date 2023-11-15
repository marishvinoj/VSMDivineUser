using System.ComponentModel.DataAnnotations.Schema;

namespace VSMDivineUser.Models
{
    [Table("UserRole")]
    public partial class UserRole : EntityBase
    {
        //public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
