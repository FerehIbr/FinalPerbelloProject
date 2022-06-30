using pobena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pobena.ViewModels.Shop
{
    public class ShopVM
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
