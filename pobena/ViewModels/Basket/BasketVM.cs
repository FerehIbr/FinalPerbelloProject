using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pobena.ViewModels.Basket
{
    public class BasketVM
    {
        public int Count { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public int stockCount { get; set; }
        public int ProductId { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public double ExTax { get; set; }
    }
}
