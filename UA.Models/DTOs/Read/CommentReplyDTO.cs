using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.Entities.Authentication;

namespace UA.Model.DTOs.Read
{
    public class CommentReplyDTO
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public bool IsModified { get; set; } = false;
        public virtual UserDTO Author { get; set; } = null!;
    }
}
