using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Update;

namespace UA.Services.Interfaces
{
    public interface ICommentReplyService
    {
        int Create(CreateCommentReplyDTO dto, int commentId, int authorId);
        void Update(UpdateCommentReplyDTO dto, int commentId, int id, ClaimsPrincipal author);
        void Delete(int commentId, int id, ClaimsPrincipal author);
    }
}
