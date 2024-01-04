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
    public interface IBodyColourService
    {
        List<BodyColourDTO> GetAll();
        BodyColourDTO GetById(int id);
        int Create(CreateBodyColourDTO dto);
        void Update(int id, UpdateBodyColourDTO dto);
        void Delete(int id);
    }
}
