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
    public interface IDrivetrainService
    {
        Task<List<DrivetrainDTO>> GetAll();
        Task<DrivetrainDTO> GetById(int id);
        Task<int> Create(CreateDrivetrainDTO dto);
        Task Update(int id, UpdateDrivetrainDTO dto);
        Task Delete(int id);
    }
}
