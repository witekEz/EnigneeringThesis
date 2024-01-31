﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.Model.DTOs.Create
{
    public class CreateBodyTypeDTO
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = null!;
    }
}
