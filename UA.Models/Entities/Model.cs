using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.Model.Entities
{
    public class Model
    {
        //Primary Key
        public int Id { get; set; }
        //Navigation Properties
        public string Name { get; set; } = null!;
        public virtual Brand Brand { get; set; }= null!;
        public virtual List<Generation>? Generations { get; set; }
        //Foreign Keys
        public int BrandId { get; set; }

    }
}
