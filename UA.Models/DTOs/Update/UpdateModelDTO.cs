﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.Model.DTOs.Update
{
    public class UpdateModelDTO
    {
        [MaxLength(10)]
        public string Name { get; set; } = null!;
        public UpdateBrandDTO Brand { get; set; } = null!;
    }
}
