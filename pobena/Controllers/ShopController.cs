using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pobena.DAL;
using pobena.Models;
using pobena.ViewModels.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pobena.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public ShopController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            ShopVM shopVM = new ShopVM
            {
                Products = await _context.Products
               .Include(p => p.ProductColorSizes).ThenInclude(p => p.Color)
                .Include(p => p.ProductColorSizes).ThenInclude(p => p.Size)
               .Where(p => !p.IsDeleted).ToListAsync(),
               

            };

            return View(shopVM);

        }

        public async Task<IActionResult> Filter(string sizes, string colors, string specs
           , string vendors, int countby, int sortby
           , string category, int minPrice, int maxPrice)
        {
            IQueryable<Product> products = _context.Products
                .Include(p => p.ProductColorSizes)
                .Include(p => p.Category)           
                ;

            if (string.IsNullOrEmpty(sizes)
                && string.IsNullOrEmpty(colors)
                && string.IsNullOrEmpty(specs)
                && string.IsNullOrEmpty(vendors)
                && string.IsNullOrEmpty(countby.ToString())
                && string.IsNullOrEmpty(sortby.ToString())
                && string.IsNullOrEmpty(category)
                && string.IsNullOrEmpty(minPrice.ToString())
                && string.IsNullOrEmpty(maxPrice.ToString())
                )
            {
                return PartialView("_ShopProductsPartial", _context.Products
                    .Include(p => p.ProductColorSizes)
                    .Where(p => !p.IsDeleted).ToList());
            }
            if (!string.IsNullOrEmpty(sizes))
            {
                string[] sizs = sizes.Split(",");
                foreach (var s in sizs)
                {
                    products = products
                        .Where(p => p.ProductColorSizes.Any(p => p.SizeId.ToString() == s.ToString()));

                }
            }
            if (!string.IsNullOrEmpty(colors))
            {
                string[] colrs = colors.Split(",");
                foreach (var c in colrs)
                {
                    products = products
                        .Where(p => p.ProductColorSizes.Any(p => p.ColorId.ToString() == c.ToString()));

                }
            }
            if (!string.IsNullOrEmpty(specs))
            {
                string[] colrs = specs.Split(",");
              
            }
            if (!string.IsNullOrEmpty(vendors))
            {
              
            }
            if (!string.IsNullOrEmpty(category))
            {
                string[] colrs = category.Split(",");
                foreach (var c in colrs)
                {
                    products = products
                        .Where(p => p.Category.Id.ToString() == c.ToString());

                }
            }
            if (!string.IsNullOrEmpty(countby.ToString()))
            {
                ViewBag.CountBy = countby;
                products = products.Take(countby);
            }
            if (!string.IsNullOrEmpty(sortby.ToString()))
            {
                switch (sortby)
                {
               
                    case 1:
                        products = products.OrderBy(p => p.Name);
                        break;
                    case 2:
                        products = products.OrderByDescending(p => p.Name);
                        break;
                    case 3:
                        products = from p in products
                                   let produccs = p.ProductColorSizes.FirstOrDefault()
                                   orderby produccs.Price
                                   select p;
                        break;
                    case 4:
                        products = from p in products
                                   let produccs = p.ProductColorSizes.FirstOrDefault()
                                   orderby produccs.Price descending
                                   select p;
                        break;
                    case 5:
                        products = products.OrderBy(p => p.CreatedAt);
                        break;
                    case 6:
                        products = products.OrderByDescending(p => p.CreatedAt);
                        break;
                    default:
                        break;
                }
            }
            if (!string.IsNullOrEmpty(minPrice.ToString()))
            {
                products = from p in products
                           let produccs = p.ProductColorSizes.FirstOrDefault()
                           where produccs.Price >= minPrice
                           select p;
            }
            if (!string.IsNullOrEmpty(maxPrice.ToString()))
            {
                products = from p in products
                           let produccs = p.ProductColorSizes.FirstOrDefault()
                           where produccs.Price <= maxPrice
                           select p;
            }
            return PartialView("_ShopProductsPartial", products.Where(p => !p.IsDeleted).ToList());
        }
    }
}
