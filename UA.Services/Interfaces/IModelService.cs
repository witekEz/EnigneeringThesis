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
        int Create(int brandId, CreateModelDTO dto);
        ModelDTO GetById(int brandId,int modelId);
        List<ModelDTO> GetAll(int brandId);
        void Delete(int brandId,int modelId);
        void Update(int id, UpdateModelDTO dto);
    }
}
