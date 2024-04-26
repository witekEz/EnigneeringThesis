using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.Entities.Authentication;

namespace UA.Model.Entities.Rate
{
    public class RateGearbox
    {
        //Primary Key
        public int Id { get; set; }
        //Properties
        public double Value { get; set; }
        //Navigaton Property
        public virtual Gearbox Gearbox { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        //Foreign Key
        public int GearboxId { get; set; }
        public int UserID { get; set; }
    }
}
