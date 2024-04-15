using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.DTOs.Read;
using UA.Model.DTOs.Update;

namespace UA.Services.Interfaces
{
    public interface IUserService
    {
         List<UserDetailsDTO> GetAll();
         UserDetailsDTO GetById(int id);
         void Delete(int id);
         void Update(int id, UpdateUserDetailsDTO userDTO);
    }
}
