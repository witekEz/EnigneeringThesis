using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.DTOs.Read;
using UA.Model.Queries;

namespace UA.Services.Interfaces
{
    public interface IHomeService
    {
        PageResult<GenerationDTO> GetAll(GenerationQuery query);
        GenerationDTO GetById(int id);
    }
}
