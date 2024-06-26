﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.Model.Entities
{
    public class Brake
    {
        //Primary Key
        public int Id { get; set; }
        //Properties
        public string Type { get; set; } = null!;
        //Navigation Properties
        public virtual List<DetailedInfo> ?DetailedInfos { get; set; }
    }
}
