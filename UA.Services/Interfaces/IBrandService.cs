using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.DTOs;
using UA.Model.DTOs.Create;
using UA.Model.DTOs.Update;

namespace UA.Services.Interfaces
{
    public interface IBrandService
    {
        IEnumerable<BrandDTO> GetAll();
        BrandDTO GetById(int id);
        int Create(CreateBrandDTO brandDTO);
        void Delete(int id);
        void Update(int id,UpdateBrandDTO brandDTO);
    }
}
