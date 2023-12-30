using System.ComponentModel.DataAnnotations.Schema;

namespace VSMDivineUser.Models
{
    [Table("User")]
    public partial class User : EntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Gender { get; set; }
        public long MobileNumber { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public int? Pincode { get; set; }
    }
}