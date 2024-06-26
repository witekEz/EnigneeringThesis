﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.Entities.Enums;
using UA.Model.Entities.Rate;

namespace UA.Model.Entities
{
    public class Generation
    {
        //Primary Key
        public int Id { get; set; }
        //Properties
        public string Name { get; set; } = null!;
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
        //Navigation Properties
        public virtual List<RateGeneration> ?Rates { get; set; }
        public virtual Category Category { get; set; } = null!;
        public virtual List<GenerationImage> ?GenerationImages { get; set; }
        public virtual List<Body> Bodies { get; set; } = null!;
        public virtual List<Drivetrain> Drivetrains { get; set; }= null!;
        public virtual List<Engine> Engines { get; set; } = null!;
        public virtual List<Gearbox> Gearboxes { get; set; }=null!;
        public virtual DetailedInfo? DetailedInfo { get; set; }
        public virtual OptionalEquipment? OptionalEquipment { get; set; }
        public virtual Model Model { get; set; } = null!;
        public virtual AvgRateGeneration ?AvgRateGeneration { get; set; }
        public virtual List<Comment> ?Comments { get; set; }
        //Foreign Key
        public int CategoryId { get; set; }
        public int ModelId { get; set; }
    }
}
