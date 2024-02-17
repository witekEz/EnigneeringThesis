using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.DTOs.Read;

namespace UA.Services.Interfaces
{
    public interface IBodyTypeService
    {
        List<BodyTypeDTO>GetAll();
    }
}
