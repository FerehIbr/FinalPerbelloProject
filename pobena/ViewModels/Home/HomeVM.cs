using pobena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pobena.ViewModels.Home
{
    public class HomeVM
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<pobena.Models.Blog> Blogs { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
    }
}
