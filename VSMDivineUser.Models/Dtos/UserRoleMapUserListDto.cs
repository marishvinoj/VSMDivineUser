using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSMDivineUser.Models.Dtos
{
    public class UserRoleMappingDto
    {
        public UserRoleMappingDto()
        {
            Roles = new List<UserRole>();
        }
        public int UserID { get; set; }
        public List<UserRole> Roles { get; set; }
    }
}
