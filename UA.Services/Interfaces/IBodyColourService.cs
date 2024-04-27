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
    public interface IBodyColourService
    {
        Task<List<BodyColourDTO>> GetAll();
        Task<BodyColourDTO> GetById(int id);
        Task<int> Create(CreateBodyColourDTO dto);
        Task Update(int id, UpdateBodyColourDTO dto);
        Task Delete(int id);
    }
}
