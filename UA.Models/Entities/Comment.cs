using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.Entities.Authentication;

namespace UA.Model.Entities
{
    public class Comment
    {
        //Primary Key
        public int Id { get; set; }
        //Properties
        public string Content { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public bool IsModified { get; set; } = false; 
        //Navigiation Property
        public virtual User Author { get; set; } = null!;
        public virtual List<CommentReply> ?Replies { get; set; }
        public virtual Generation Generation { get; set; }=null!;
        //Foregin Key
        public int AuthorId { get; set; }
        public int GenerationId { get; set; }
    }
}
