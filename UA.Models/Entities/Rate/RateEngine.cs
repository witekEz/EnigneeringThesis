using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.Entities.Authentication;

namespace UA.Model.Entities.Rate
{
    public class RateEngine
    {
        //Primary Key
        public int Id { get; set; }
        //Properties
        public double Value { get; set; }
        //Navigaton Property
        public virtual Engine Engine { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        //Foreign Key
        public int EngineId { get; set; }
        public int UserID { get; set; }
    }
}
