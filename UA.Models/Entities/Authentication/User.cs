using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace UA.Model.Entities.Authentication
{
    public class User
    {
        //Primary Key
        public int Id { get; set; }
        //Properties
        public string Email { get; set; } = null!;
        public string NickName { get; set; } = null!;
        public string ?FirstName { get; set; }
        public string ?LastName { get; set; }
        public DateTime ?DateOfBirth { get; set; }
        public string PasswordHash { get; set; } = null!;
        //Navigation Property
        public virtual Role Role { get; set; } = null!;
        //Foreign Key
        public int RoleId { get; set; }
    }
}
