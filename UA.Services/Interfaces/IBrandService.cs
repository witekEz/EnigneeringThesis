using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Read;
using UA.Model.DTOs.Update;

namespace UA.Services.Interfaces
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandDTO>> GetAll();
        Task<BrandDTO> GetById(int id);
        Task<int> Create(CreateBrandDTO brandDTO);
        Task Delete(int id);
        Task Update(int id,UpdateBrandDTO brandDTO);
    }
}
