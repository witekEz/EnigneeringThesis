using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.Model.Entities.Authentication
{
    public class Role
    {
        //Primary Key
        public int Id { get; set; }
        //Property
        public string Name { get; set; } = null!;
    }
}
