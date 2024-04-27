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
         Task<List<UserDetailsDTO>> GetAll();
         Task<UserDetailsDTO> GetById(int id);
         Task Delete(int id);
         Task Update(int id, UpdateUserDetailsDTO userDTO);
    }
}
