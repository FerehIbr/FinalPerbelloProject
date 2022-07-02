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
        public async Task<IActionResult> AddToBasket(int? id, int? colorid, int? sizeid, int count = 1)
        {
            if (id == null) return BadRequest();

            Product product = await _context.Products.Include(p=>p.ProductColorSizes).FirstOrDefaultAsync(p => !p.IsDeleted && p.Id == id);

            if (product == null) return NotFound();

            if (colorid == null) return BadRequest();

            if (!await _context.Colors.AnyAsync(c => c.Id == colorid && !c.IsDeleted)) return NotFound();

            if (sizeid == null) return BadRequest();

            if(!await _context.Sizes.AnyAsync(s=>!s.IsDeleted && s.Id == sizeid)) return NotFound();

            if (product.ProductColorSizes == null || product.ProductColorSizes.Count <= 0) return BadRequest();

            if (!product.ProductColorSizes.Any(pc => pc.ColorId == colorid && pc.SizeId == sizeid)) return BadRequest();

            string coockie = HttpContext.Request.Cookies["basket"];

            List<BasketVM> basketVMs = null;

            if (!string.IsNullOrWhiteSpace(coockie))
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(coockie);

                if(basketVMs.Any(b=>b.ProductId == id && b.ColorId == colorid && b.SizeId == sizeid))
                {
                    basketVMs.FirstOrDefault(b => b.ProductId == id && b.ColorId == colorid && b.SizeId == sizeid).Count++;
                }
                else
                {
                    BasketVM basketVM = new BasketVM
                    {
                        ProductId = (int)id,
                        ColorId = (int)colorid,
                        SizeId = (int)sizeid,
                        Count = 1
                    };

                    basketVMs.Add(basketVM);
                }
            }
            else
            {
                basketVMs = new List<BasketVM>();

                BasketVM basketVM = new BasketVM
                {
                    ProductId = (int)id,
                    ColorId = (int)colorid,
                    SizeId = (int)sizeid,
                    Count = 1
                };

                basketVMs.Add(basketVM);
            }

            if (User.Identity.IsAuthenticated)
            {
                AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u=>u.UserName == User.Identity.Name && !u.IsAdmin);

                if (appUser != null)
                {
                    Basket basket = await _context.Baskets.FirstOrDefaultAsync(b => b.AppUserId == appUser.Id && !b.IsDeleted && b.ProductId == id && b.ColorId == colorid && b.SizeId == sizeid);

                    if (basket != null)
                    {
                        basket.Count += 1;
                    }
                    else
                    {
                        basket = new Basket
                        {
                            AppUserId = appUser.Id,
                            ProductId = id,
                            SizeId = sizeid,
                            ColorId = colorid,
                            Count = 1
                        };

                        await _context.Baskets.AddAsync(basket);
                    }

                    await _context.SaveChangesAsync();
                }
            }

            coockie = JsonConvert.SerializeObject(basketVMs);
            HttpContext.Response.Cookies.Append("basket", coockie);

            foreach (BasketVM basketVM in basketVMs)
            {
                Product dbProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == basketVM.ProductId);

                basketVM.Image = dbProduct.MainImage;
                basketVM.DiscountPrice = dbProduct.DiscountPrice;
                basketVM.ExTax = dbProduct.ExTax;
                basketVM.Name = dbProduct.Name;
                basketVM.Price = dbProduct.Price;
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
                return basketVMs.Count;
            }
            else
            {
                return 0;
            }

            
        }

    }
}

