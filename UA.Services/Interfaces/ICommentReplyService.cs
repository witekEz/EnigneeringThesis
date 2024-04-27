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
        Task<int> Create(CreateCommentReplyDTO dto, int commentId, int authorId);
        Task Update(UpdateCommentReplyDTO dto, int commentId, int id, ClaimsPrincipal author);
        Task Delete(int commentId, int id, ClaimsPrincipal author);
    }
}
