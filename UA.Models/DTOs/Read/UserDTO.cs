﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.Model.DTOs.Read
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string NickName { get; set; } = null!;
    }
}
