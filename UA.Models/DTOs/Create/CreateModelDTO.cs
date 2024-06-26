﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.Model.DTOs.Create
{
    public class CreateModelDTO
    {
        [Required]
        [MaxLength(10)]
        public string Name { get; set; } = null!;
        [Required]
        public int BrandId { get; set; }
    }
}
