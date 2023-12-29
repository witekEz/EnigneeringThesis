﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.Model.DTOs
{
    public class BrandDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<ModelDTO> ?Models { get; set; }
    }
}
