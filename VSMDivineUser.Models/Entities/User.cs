using System.ComponentModel.DataAnnotations.Schema;

namespace VSMDivineUser.Models
{
    [Table("User")]
    public partial class User : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Gender { get; set; }
        public int MobileNumber { get; set; }
        public string EmailId { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public int? Pincode { get; set; }
    }
}