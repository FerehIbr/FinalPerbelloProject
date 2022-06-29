using pobena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pobena.ViewModels.Blog
{
    public class BlogVM
    {
        public List<Review> Reviews { get; set; }
        public pobena.Models.Blog Blog { get; set; }
        public List<pobena.Models.Blog> Blogs { get; set; }
    }
}
