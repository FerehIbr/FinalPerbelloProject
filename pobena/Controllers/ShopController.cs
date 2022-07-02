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
            ViewBag.Categories = await _context.Categories.Where(p =>!p.IsDeleted).ToListAsync();
            ViewBag.Brands = await _context.Brands.Where(p =>!p.IsDeleted).ToListAsync();
            ViewBag.Colors = await _context.Colors.Where(p =>!p.IsDeleted).ToListAsync();
            ShopVM shopVM = new ShopVM
            {
                Products = await _context.Products
               .Include(p => p.ProductColorSizes).ThenInclude(p => p.Color)
                .Include(p => p.ProductColorSizes).ThenInclude(p => p.Size)
               .Where(p => !p.IsDeleted).ToListAsync(),
               

            };

            return View(shopVM);

        }

        public async Task<IActionResult> Filter1(string sizes, string colors, string brands,
           string price, int sortby, string category
            )
        {
            IQueryable<Product> products = _context.Products
                .Include(p => p.ProductColorSizes)
                .Include(p => p.Category)
                .Include(p => p.Brand)
                ;

            if (string.IsNullOrEmpty(sizes)
                && string.IsNullOrEmpty(colors)
                && string.IsNullOrEmpty(brands)
                && string.IsNullOrEmpty(sortby.ToString())
                && string.IsNullOrEmpty(category)
                && string.IsNullOrEmpty(price)
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
            if (!string.IsNullOrEmpty(brands))
            {
                string[] colrs = brands.Split(",");

            }
            if (!string.IsNullOrEmpty(brands))
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
            if (!string.IsNullOrEmpty(sortby.ToString()))
            {
                switch (sortby)
                {

                    case 1:
                        products = products.OrderBy(p => p.CreatedAt);
                        break;
                    case 2:
                        products = products.OrderBy(p => p.Name);
                        break;
                    case 3:
                        products = products.OrderByDescending(p => p.Name);
                        break;
                    case 4:
                        products = products.OrderBy(p => p.Price);
                        break;
                    case 5:
                        products = products.OrderByDescending(p => p.Price);
                        break;
                    case 6:
                        products = products.OrderByDescending(p => p.Brand.Name);
                        break;
                    case 7:
                        products = products.OrderBy(p => p.Brand.Name);
                        break;
                    default:
                        break;
                }
            }
            if (!string.IsNullOrEmpty(price))
            {
                switch (price)
                {

                    case "1":
                        products = products.Where(p => p.Price >= 43 && p.Price <= 45);
                        break;
                    case "2":
                        products = products.Where(p => p.Price >= 54 && p.Price <= 58);
                        break;
                    case "3":
                        products = products.Where(p => p.Price >= 62 && p.Price <= 70);
                        break;
                    case "4":
                        products = products.Where(p => p.Price >= 78 && p.Price <= 83);
                        break;
                    case "5":
                        products = products.Where(p => p.Price >= 85 && p.Price <= 89);
                        break;
                    default:
                        break;
                }
            }
            return PartialView("_ShopProductListPartial", products.Where(p => !p.IsDeleted).ToList());
        }
        public async Task<IActionResult> Filter2(string sizes, string colors, string brands,
           string price, int sortby, string category
            )
        {
            IQueryable<Product> products = _context.Products
                .Include(p => p.ProductColorSizes)
                .Include(p => p.Category)
                .Include(p => p.Brand)
                ;

            if (string.IsNullOrEmpty(sizes)
                && string.IsNullOrEmpty(colors)
                && string.IsNullOrEmpty(brands)
                && string.IsNullOrEmpty(sortby.ToString())
                && string.IsNullOrEmpty(category)
                && string.IsNullOrEmpty(price)
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
            if (!string.IsNullOrEmpty(brands))
            {
                string[] colrs = brands.Split(",");

            }
            if (!string.IsNullOrEmpty(brands))
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
            if (!string.IsNullOrEmpty(sortby.ToString()))
            {
                switch (sortby)
                {

                    case 1:
                        products = products.OrderBy(p => p.CreatedAt);
                        break;
                    case 2:
                        products = products.OrderBy(p => p.Name);
                        break;
                    case 3:
                        products = products.OrderByDescending(p => p.Name);
                        break;
                    case 4:
                        products = products.OrderBy(p => p.Price);
                        break;
                    case 5:
                        products = products.OrderByDescending(p => p.Price);
                        break;
                    case 6:
                        products = products.OrderByDescending(p => p.Brand.Name);
                        break;
                    case 7:
                        products = products.OrderBy(p => p.Brand.Name);
                        break;
                    default:
                        break;
                }
            }
            if (!string.IsNullOrEmpty(price))
            {
                switch (price)
                {

                    case "1":
                        products = products.Where(p => p.Price >= 43 && p.Price <= 45);
                        break;
                    case "2":
                        products = products.Where(p => p.Price >= 54 && p.Price <= 58);
                        break;
                    case "3":
                        products = products.Where(p => p.Price >= 62 && p.Price <= 70);
                        break;
                    case "4":
                        products = products.Where(p => p.Price >= 78 && p.Price <= 83);
                        break;
                    case "5":
                        products = products.Where(p => p.Price >= 85 && p.Price <= 89);
                        break;
                    default:
                        break;
                }
            }
            return PartialView("_ShopProductListPartial2", products.Where(p => !p.IsDeleted).ToList());
        }
    }
}
