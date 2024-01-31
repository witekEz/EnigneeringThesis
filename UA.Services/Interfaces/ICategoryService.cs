using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Update;
using UA.Model.DTOs;

namespace UA.Services.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryDTO> GetAll();
        CategoryDTO GetById(int id);
        int Create(CreateCategoryDTO dto);
        void Update(int id, UpdateCategoryDTO dto);
        void Delete(int id);
    }
}
