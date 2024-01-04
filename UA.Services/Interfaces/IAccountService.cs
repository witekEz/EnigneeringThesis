using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.DTOs;

namespace UA.Services.Interfaces
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDTO dto);
        string GenerateJwt(LoginDTO dto);
    }
}
