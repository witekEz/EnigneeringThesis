using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Update;
using UA.Model.DTOs.Read;

namespace UA.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetAll();
        Task<CategoryDTO> GetById(int id);
        Task<int> Create(CreateCategoryDTO dto);
        Task Update(int id, UpdateCategoryDTO dto);
        Task Delete(int id);
    }
}
