using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSMDivineUser.Models.Dtos
{
    public class UserRoleMapUserListDto
    {
        public int Id { get; set; }
        //public int UserID { get; set; }
        public string UserName { get; set; }
        public string RoleNames { get; set; }
    }
}
