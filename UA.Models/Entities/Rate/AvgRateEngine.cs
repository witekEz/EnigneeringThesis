﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.Model.Entities.Rate
{
    public class AvgRateEngine
    {
        //Primary Key
        public int Id { get; set; }
        //Properties
        public double AverageRate { get; set; } = 0;
        public int NumberOfRates { get; set; }
        //Navigation Property
        public virtual Engine Engine { get; set; } = null!;
        //Foreign Key
        public int EngineId { get; set; }
    }
}
