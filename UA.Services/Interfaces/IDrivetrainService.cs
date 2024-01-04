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
    public interface IDrivetrainService
    {
        List<DrivetrainDTO> GetAll();
        DrivetrainDTO GetById(int id);
        int Create(CreateDrivetrainDTO dto);
        void Update(int id, UpdateDrivetrainDTO dto);
        void Delete(int id);
    }
}
