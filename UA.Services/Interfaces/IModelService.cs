using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Read;
using UA.Model.DTOs.Update;
using UA.Model.Entities;

namespace UA.Services.Interfaces
{
    public interface IModelService
    {
        Task<int> Create(int brandId, CreateModelDTO dto);
        Task<ModelDTO> GetById(int brandId,int modelId);
        Task<List<ModelDTO>> GetAll(int brandId);
        Task Delete(int brandId,int modelId);
        Task Update(int id, UpdateModelDTO dto);
    }
}
