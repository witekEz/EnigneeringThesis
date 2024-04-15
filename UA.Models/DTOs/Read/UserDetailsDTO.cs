using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.Model.DTOs.Read
{
    public class UserDetailsDTO
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string NickName { get; set; } = null!;
        public RoleDTO Role { get; set; }=null!;
        public int RoleId { get; set; }
    }
}
