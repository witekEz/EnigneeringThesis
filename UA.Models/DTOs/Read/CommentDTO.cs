using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.Model.DTOs.Read
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public bool IsModified { get; set; }
        public DateTime CreatedOn { get; set; }
        public UserDTO Author { get; set; } = null!;
        public List<CommentReplyDTO>? Replies { get; set; }
    }
}
