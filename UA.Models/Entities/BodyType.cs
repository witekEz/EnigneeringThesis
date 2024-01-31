using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.Model.Entities
{
    public class BodyType
    {
        //Primary Key
        public int Id { get; set; }
        //Property
        public string Name { get; set; } = null!;
        //Navigation Property
        public virtual List<Body> ?Bodies { get; set; }
    }
}
