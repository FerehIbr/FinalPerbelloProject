using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pobena.Models
{
    public class Basket : BaseEntity
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
        public int? ColorId { get; set; }
        public Color Color { get; set; }
        public int? SizeId { get; set; }
        public Size Size { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public int Count { get; set; }
    }
}
