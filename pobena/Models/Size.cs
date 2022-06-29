using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pobena.Models
{
    public class Size : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<ProductColorSize> ProductColorSizes { get; set; }
    }
}
