using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.Entities.Authentication;

namespace UA.Model.Entities.Rate
{
    public class RateGeneration
    {
        //Primary Key
        public int Id { get; set; }
        //Properties
        public double Value { get; set; }
        //Navigaton Property
        public Generation Generation { get; set; } = null!;
        public User User { get; set; } = null!;
        //Foreign Key
        public int GenerationId { get; set; }
        public int UserID { get; set; }
    }
}
