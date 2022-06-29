using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using pobena.DAL;
using pobena.Models;
using pobena.ViewModels.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pobena.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public BasketController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Colors = await _context.Colors.ToListAsync();
            ViewBag.Sizes = await _context.Sizes.ToListAsync();

            string cookie = HttpContext.Request.Cookies["basket"];

            List<BasketVM> basketVMs = null;

            if (cookie != null)
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(cookie);
            }
            else
            {
                basketVMs = new List<BasketVM>();
            }
            foreach (BasketVM basketVM in basketVMs)
            {
                Product dbProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == basketVM.ProductId);
                basketVM.Image = dbProduct.MainImage;
                //basketVM.Price = dbProduct.DiscountPrice > 0 ? dbProduct.DiscountPrice : dbProduct.Price;
                basketVM.Name = dbProduct.Name;
            }
            List<ProductColorSize> productColorSizes = await _context
               .ProductColorSizes
               .Include(p => p.Color)
               .Include(p => p.Size)
               .ToListAsync();

            foreach (ProductColorSize productColor in productColorSizes)
            {
                foreach (BasketVM basketVM in basketVMs)
                {
                    if (productColor.ProductId == basketVM.ProductId && productColor.ColorId == basketVM.ColorId && productColor.SizeId == basketVM.SizeId)
                    {
                        ViewBag.ProdCount = productColor.StockCount;
                    }
                }
            }
            return View(basketVMs);
        }

        public async Task<IActionResult> GetBasket()
        {
            string cookieBasket = HttpContext.Request.Cookies["basket"];

            List<BasketVM> basketVMs = null;

            if (cookieBasket != null)
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(cookieBasket);
            }
            else
            {
                basketVMs = new List<BasketVM>();
            }

            foreach (BasketVM basketVM in basketVMs)
            {
                Product dbProduct = await _context.Products
                    .Include(p => p.ProductColorSizes)
                    .FirstOrDefaultAsync(p => p.Id == basketVM.ProductId && !p.IsDeleted);
                if (dbProduct == null) return NotFound();
                basketVM.Image = dbProduct.MainImage;
                basketVM.Name = dbProduct.Name;
                if (dbProduct.ProductColorSizes.Any(p => p.ProductId == basketVM.ProductId && p.ColorId == basketVM.ColorId && p.SizeId == basketVM.SizeId))
                {
                    basketVM.stockCount = dbProduct.ProductColorSizes.Find(p => p.ColorId == basketVM.ColorId && p.SizeId == basketVM.SizeId).StockCount;
                }
                else
                {
                    basketVM.stockCount = 0;
                }
            }

            List<ProductColorSize> productColorSizes = await _context
              .ProductColorSizes
              .Include(p => p.Color)
              .Include(p => p.Size)
              .ToListAsync();

            foreach (ProductColorSize productColor in productColorSizes)
            {
                foreach (BasketVM basketVM in basketVMs)
                {
                    if (productColor.ProductId == basketVM.ProductId && productColor.ColorId == basketVM.ColorId && productColor.SizeId == basketVM.SizeId)
                    {
                        ViewBag.ProdCount = productColor.StockCount;
                    }
                }
            }
            return PartialView("_BasketPartial", basketVMs);
        }

        public async Task<IActionResult> Update(int? id, int? count, int color = 1, int size = 1)
        {
            ViewBag.ColorName = _context.Colors.FirstOrDefault(c => c.Id == color && !c.IsDeleted).Name;
            ViewBag.SizeName = _context.Sizes.FirstOrDefault(c => c.Id == size && !c.IsDeleted).Name;

            if (id == null) return BadRequest();

            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (product == null) return NotFound();

            string cookie = HttpContext.Request.Cookies["basket"];

            List<BasketVM> basketVMs = null;

            if (cookie != null)
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(cookie);

                if (!basketVMs.Any(b => b.ProductId == id && b.ColorId == (int)color && b.SizeId == (int)size))
                {
                    return NotFound();
                }

                basketVMs.Find(b => b.ProductId == id && b.ColorId == (int)color && b.SizeId == (int)size).Count = (int)count;
            }
            else
            {
                return BadRequest();
            }


            foreach (BasketVM basketVM in basketVMs)
            {
                Product dbProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == basketVM.ProductId);
                basketVM.Image = dbProduct.MainImage;
                basketVM.Name = dbProduct.Name;
                basketVM.ExTax = dbProduct.ExTax;
            }
            HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketVMs));


            List<ProductColorSize> productColorSizes = await _context
              .ProductColorSizes
              .Include(p => p.Color)
              .Include(p => p.Size)
              .ToListAsync();

            foreach (ProductColorSize productColor in productColorSizes)
            {
                foreach (BasketVM basketVM in basketVMs)
                {
                    if (productColor.ProductId == basketVM.ProductId && productColor.ColorId == basketVM.ColorId && productColor.SizeId == basketVM.SizeId)
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
                        await _context.SaveChangesAsync();
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

                if (baskets.Count > 0)
                {
                    await _context.Baskets.AddRangeAsync(baskets);
                }
                await _context.SaveChangesAsync();
            }

            return PartialView("_BasketIndexPartial", basketVMs);
        }

        public async Task<IActionResult> GetCard()
        {
            string cookieBasket = HttpContext.Request.Cookies["basket"];

            List<BasketVM> basketVMs = null;

            if (cookieBasket != null)
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
                //basketVM.Price = dbProduct.DiscountPrice > 0 ? dbProduct.DiscountPrice : dbProduct.Price;
                basketVM.Name = dbProduct.Name;
            }

            List<ProductColorSize> productColorSizes = await _context
              .ProductColorSizes
              .Include(p => p.Color)
              .Include(p => p.Size)
              .ToListAsync();

            foreach (ProductColorSize productColor in productColorSizes)
            {
                foreach (BasketVM basketVM in basketVMs)
                {
                    if (productColor.ProductId == basketVM.ProductId && productColor.ColorId == basketVM.ColorId && productColor.SizeId == basketVM.SizeId)
                    {
                        ViewBag.ProdCount = productColor.StockCount;
                    }
                }
            }
            return PartialView("_BasketIndexPartial", basketVMs);
        }

        public async Task<IActionResult> DeleteCard(int? id, int color = 1, int size = 1)
        {
            if (id == null) return BadRequest();

            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();

            string cookie = HttpContext.Request.Cookies["basket"];

            List<BasketVM> basketVMs = null;

            if (cookie != null)
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(cookie);

                BasketVM basketVM = basketVMs.FirstOrDefault(b => b.ProductId == id && b.ColorId == color && b.SizeId == size);

                if (basketVM == null)
                {
                    return NotFound();
                }

                basketVMs.Remove(basketVM);
            }
            else
            {
                return BadRequest();
            }

            HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketVMs));

            foreach (BasketVM basketVM in basketVMs)
            {
                Product dbProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == basketVM.ProductId);
                basketVM.Image = dbProduct.MainImage;
                //basketVM.Price = dbProduct.DiscountPrice > 0 ? dbProduct.DiscountPrice : dbProduct.Price;
                basketVM.Name = dbProduct.Name;
                basketVM.ExTax = dbProduct.ExTax;
            }


            List<ProductColorSize> productColorSizes = await _context
              .ProductColorSizes
              .Include(p => p.Color)
              .Include(p => p.Size)
              .ToListAsync();

            foreach (ProductColorSize productColor in productColorSizes)
            {
                foreach (BasketVM basketVM in basketVMs)
                {
                    if (productColor.ProductId == basketVM.ProductId && productColor.ColorId == basketVM.ColorId && productColor.SizeId == basketVM.SizeId)
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
                    Basket basket = new Basket
                    {
                        AppUserId = appUser.Id,
                        ProductId = basketVMs[i].ProductId,
                        Count = basketVMs[i].Count,
                        ColorId = basketVMs[i].ColorId,
                        SizeId = basketVMs[i].SizeId,
                        Price = basketVMs[i].Price,
                        DiscountPrice = basketVMs[i].DiscountPrice,
                        DeletedAt = DateTime.UtcNow.AddHours(4)
                    };
                    baskets.Add(basket);
                }
                _context.RemoveRange(existedBasket);
                await _context.Baskets.AddRangeAsync(baskets);
                await _context.SaveChangesAsync();
            }

            return PartialView("_BasketIndexPartial", basketVMs);
        }

        public async Task<IActionResult> DeleteBasket(int? id, int color = 1, int size = 1)
        {
            ViewBag.ColorName = _context.Colors.FirstOrDefault(c => c.Id == color).Name;
            ViewBag.SizeName = _context.Sizes.FirstOrDefault(c => c.Id == size).Name;

            if (id == null) return BadRequest();

            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();

            string cookie = HttpContext.Request.Cookies["basket"];

            List<BasketVM> basketVMs = null;

            if (cookie != null)
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(cookie);

                BasketVM basketVM = basketVMs.FirstOrDefault(b => b.ProductId == id && b.ColorId == color && b.SizeId == size);

                if (basketVM == null)
                {
                    return NotFound();
                }

                basketVMs.Remove(basketVM);
            }
            else
            {
                return BadRequest();
            }

            HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketVMs));

            foreach (BasketVM basketVM in basketVMs)
            {
                Product dbProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == basketVM.ProductId);
                basketVM.Image = dbProduct.MainImage;
                //basketVM.Price = dbProduct.DiscountPrice > 0 ? dbProduct.DiscountPrice : dbProduct.Price;
                basketVM.Name = dbProduct.Name;
            }

            List<ProductColorSize> productColorSizes = await _context
              .ProductColorSizes
              .Include(p => p.Color)
              .Include(p => p.Size)
              .ToListAsync();

            foreach (ProductColorSize productColor in productColorSizes)
            {
                foreach (BasketVM basketVM in basketVMs)
                {
                    if (productColor.ProductId == basketVM.ProductId && productColor.ColorId == basketVM.ColorId && productColor.SizeId == basketVM.SizeId)
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
                _context.RemoveRange(existedBasket);
                await _context.Baskets.AddRangeAsync(baskets);
                await _context.SaveChangesAsync();
            }

            return PartialView("_BasketPartial", basketVMs);
        }
    }
}
