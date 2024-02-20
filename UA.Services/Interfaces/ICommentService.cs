using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Read;
using UA.Model.DTOs.Update;

namespace UA.Services.Interfaces
{
    public interface ICommentService
    {
        List<CommentDTO> GetAllComments(int generationId);
        int Create(CreateCommentDTO dto, int generationId, int authorId);
        void Update(UpdateCommentDTO dto, int generationId, int id, ClaimsPrincipal author);
        void Delete(int generationId, int id, ClaimsPrincipal author);
    }
}
