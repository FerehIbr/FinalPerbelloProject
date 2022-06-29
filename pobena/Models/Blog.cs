using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pobena.Models
{
    public class Blog : BaseEntity
    {
        [StringLength(1000)]
        public string Image { get; set; }
        [StringLength(1000)]
        public string Title { get; set; }
        [StringLength(2000)]
        public string Description { get; set; }
        public string PublisherName { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public IEnumerable<BlogTag> BlogTags { get; set; }


        [NotMapped]
        public List<int> TagIds { get; set; } = new List<int>();
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
