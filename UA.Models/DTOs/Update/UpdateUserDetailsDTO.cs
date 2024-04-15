using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.Model.DTOs.Update
{
    public class UpdateUserDetailsDTO
    {
        public string ?Email { get; set; }
        public string ?NickName { get; set; }
        public int ?RoleId { get; set; }
    }
}
