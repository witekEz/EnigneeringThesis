using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.Model.Entities
{
    public class GenerationImage
    {
        //Primary Key
        public int Id { get; set; }
        //Property
        public Guid ImageGUID { get; set; }
        //Navigation Property
        public virtual Generation Generation { get; set; } = null!;
        //Foreign Key
        public int GenerationId { get; set; }
    }
}
