using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using pobena.DAL;
using pobena.Models;
using pobena.ViewModels.Basket;
using pobena.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pobena.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public HomeController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Products = await _context.Products
               .Include(p => p.ProductColorSizes).ThenInclude(p => p.Color)
                .Include(p => p.ProductColorSizes).ThenInclude(p => p.Size)
               .Where(p => !p.IsDeleted).ToListAsync(),
                Blogs = await _context.Blogs.Where(p => !p.IsDeleted).ToListAsync(),
                Brands = await _context.Brands.Where(p => !p.IsDeleted).ToListAsync()

            };

            return View(homeVM);

        }
        public async Task<IActionResult> AddToBasket(int? id, int colorid = 1, int sizeid = 1, int count = 1)
        {
            ViewBag.ColorName = await _context.Colors.Where(p => !p.IsDeleted).ToListAsync();
            ViewBag.SizeName = await _context.Sizes.Where(p => !p.IsDeleted).ToListAsync();
            if (colorid == null || sizeid == null) return BadRequest();
            Color color = await _context.Colors.FirstOrDefaultAsync(p => p.Id == colorid && !p.IsDeleted);
            Size size = await _context.Sizes.FirstOrDefaultAsync(p => p.Id == sizeid && !p.IsDeleted);
            if (color == null || size == null) return NotFound();

            if (id == null) return BadRequest();
            Product dBproduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
            if (dBproduct == null) return NotFound();

            ProductColorSize productColorSize = _context.ProductColorSizes
                .Include(p => p.Color)
                .Include(p => p.Size)
                .FirstOrDefault(p => p.ProductId == dBproduct.Id && p.ColorId == color.Id && p.SizeId == size.Id);
            if (productColorSize == null) return NotFound();
            //List<Product> products = null;
            List<BasketVM> basketVMs = null;

            string cookie = HttpContext.Request.Cookies["basket"];

            if (cookie != "" && cookie != null)
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(cookie);
                if (basketVMs.Any(b => b.ProductId == dBproduct.Id && b.ColorId == color.Id && b.SizeId == size.Id))
                {
                    basketVMs.Find(b => b.ProductId == dBproduct.Id && b.ColorId == color.Id && b.SizeId == size.Id).Count = count;
                }
                else
                {
                    basketVMs.Add(new BasketVM
                    {
                        ProductId = dBproduct.Id,
                        Name = dBproduct.Name,
                        Count = count,
                        ColorId = productColorSize.Color.Id,
                        ColorName = productColorSize.Color.Name,
                        SizeId = productColorSize.Size.Id,
                        SizeName = productColorSize.Size.Name,
                        Price = productColorSize.Price,
                        DiscountPrice = productColorSize.DiscountPrice,
                        stockCount = productColorSize.StockCount
                    });
                }
            }
            else
            {
                basketVMs = new List<BasketVM>();

                basketVMs.Add(new BasketVM()
                {
                    ProductId = dBproduct.Id,
                    Name = dBproduct.Name,
                    Count = count,
                    ColorId = productColorSize.Color.Id,
                    ColorName = productColorSize.Color.Name,
                    SizeId = productColorSize.Size.Id,
                    SizeName = productColorSize.Size.Name,
                    Price = productColorSize.Price,
                    DiscountPrice = productColorSize.DiscountPrice,
                    stockCount = productColorSize.StockCount
                });
            }



            foreach (BasketVM basketVM in basketVMs)
            {
                Product dbProduct = await _context.Products
                    .Include(p => p.ProductColorSizes)
                    .FirstOrDefaultAsync(p => p.Id == basketVM.ProductId);
                basketVM.Image = dbProduct.MainImage;
                basketVM.Name = dbProduct.Name;
                basketVM.ExTax = dbProduct.ExTax;
                if (dbProduct.ProductColorSizes.Any(p => p.ProductId == basketVM.ProductId && p.ColorId == basketVM.ColorId && p.SizeId == basketVM.SizeId))
                {
                    basketVM.stockCount = dbProduct.ProductColorSizes.Find(p => p.ColorId == basketVM.ColorId && p.SizeId == basketVM.SizeId).StockCount;
                }
            }

            HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketVMs));
            List<ProductColorSize> productColorSizes = await _context
              .ProductColorSizes
              .Include(p => p.Product)
              .Include(p => p.Color)
              .Include(p => p.Size)
              .ToListAsync();

            foreach (ProductColorSize productColor in productColorSizes)
            {
                foreach (BasketVM basketVM in basketVMs)
                {
                    if (productColor.Product.Id == basketVM.ProductId && productColor.Color.Id == basketVM.ColorId && productColor.Size.Id == basketVM.SizeId)
                    {
                        ViewBag.ProdCount = productColor.StockCount;
                    }
                }
            }

            cookie = JsonConvert.SerializeObject(basketVMs);


            if (User.Identity.IsAuthenticated && !string.IsNullOrWhiteSpace(cookie))
            {
                AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name.ToUpper() && !u.IsAdmin);
                List<BasketVM> BasketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(cookie);
                List<Basket> baskets = new List<Basket>();
                List<Basket> existedBasket = await _context.Baskets.Where(b => b.AppUserId == appUser.Id).ToListAsync();
                for (int i = 0; i < BasketVMs.Count(); i++)
                {
                    if (existedBasket.Any(b => b.ProductId == basketVMs[i].ProductId && b.SizeId == basketVMs[i].SizeId && b.ColorId == basketVMs[i].ColorId))
                    {
                        existedBasket.Find(b => b.ProductId == basketVMs[i].ProductId && b.SizeId == basketVMs[i].SizeId && b.ColorId == basketVMs[i].ColorId).Count = basketVMs[i].Count;
                    }
                    else
                    {
                        Basket basket = new Basket
                        {
                            AppUserId = appUser.Id,
                            ProductId = basketVMs[i].ProductId,
                            Count = basketVMs[i].Count,
                            ColorId = basketVMs[i].ColorId,
                            SizeId = basketVMs[i].SizeId,
                            Price = basketVMs[i].Price,
                            DiscountPrice = basketVMs[i].DiscountPrice,
                            CreatedAt = DateTime.UtcNow.AddHours(4)
                        };

                        baskets.Add(basket);
                    }

                }

                await _context.Baskets.AddRangeAsync(baskets);
                await _context.SaveChangesAsync();
            }



            return PartialView("_BasketPartial", basketVMs);
        }
        public async Task<int> Count()
        {
            string cookieBasket = HttpContext.Request.Cookies["basket"];

            List<BasketVM> basketVMs = null;

            if (!string.IsNullOrWhiteSpace(cookieBasket))
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(cookieBasket);
            }
            else
            {
                basketVMs = new List<BasketVM>();
            }

            foreach (BasketVM basketVM in basketVMs)
            {
                Product dbProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == basketVM.ProductId);
                basketVM.Image = dbProduct.MainImage;
                basketVM.Name = dbProduct.Name;
                basketVM.ExTax = dbProduct.ExTax;
            }

            return basketVMs.Count();
        }

    }
}

