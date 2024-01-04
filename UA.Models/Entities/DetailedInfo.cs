using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Model.Entities.Enums;

namespace UA.Model.Entities
{
    public class DetailedInfo
    {
        //Primary Key
        public int Id { get; set; }
        //Properties
        public DateTime ProductionStartDate { get; set; }
        public DateTime ProductionEndDate { get; set; }
        //Navigation Properties
        public virtual List<BodyColour>? BodyColours { get; set; }
        public virtual List<Brake>? Brakes { get; set; }
        public virtual List<Suspension>? Suspensions { get; set; }
        public virtual Generation Generation { get; set; } = null!;
        //Foreign Key 
        public int GenerationId { get; set; }
    }
}
