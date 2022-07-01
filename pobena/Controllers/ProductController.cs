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
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Product> products = _context.Products.Where(p => !p.IsDeleted).ToList();
            return View(products);
        }


        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return RedirectToAction("Index", "Product");
            }
            List<Product> products = await _context.Products.Where(p => p.Name.ToLower().Contains(query.ToLower())).ToListAsync();
            if(products == null)
            {
                products = new List<Product>();
            }
            return View(products);
        }
        public async Task<IActionResult> SearchPartial(string query)
        {
            List<Product> products = await _context.Products.Where(p => p.Name.ToLower().Contains(query.ToLower())).ToListAsync();
            return PartialView("_ProductSearchPartial", products);
        }


        public async Task<IActionResult> Detail(int? id)
        {

            //Review review = await _context.Reviews.FirstOrDefaultAsync(r => r.BlogId == id);
          
            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.Tags = await _context.Tags.ToListAsync();
            ViewBag.Blogs = await _context.Blogs.ToListAsync();
            if (id == null) return BadRequest();
            Product product = await _context.Products
                .Include(b => b.ProductColorSizes)
                 .FirstOrDefaultAsync(u => u.Id == id);
            if (product == null) return NotFound();

            return View(product);
        }

        public async Task<IActionResult> AddBasket(int? id, int count = 1, int colorid=1, int sizeid=1)
        {
            if (id == null) return BadRequest();
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();

            List<Product> products = null;
            string cookiebasket = HttpContext.Request.Cookies["basket"];
            List<BasketVM> basketVMs = null;


            if (cookiebasket != null)
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(cookiebasket);
                if (basketVMs.Any(b => b.ProductId == id && (b.ColorId == colorid && b.SizeId == sizeid)))
                {
                    basketVMs.Find(b => b.ProductId == id).Count += count;
                }
                else
                {
                    basketVMs.Add(new BasketVM
                    {
                        ProductId = (int)id,
                        Count = count,
                        ColorId = colorid,
                        SizeId = sizeid

                    });
                }

            }
            else
            {
                basketVMs = new List<BasketVM>();
                basketVMs.Add(new BasketVM()
                {
                    ProductId = product.Id,
                    Count = count,
                    ColorId = colorid,
                    SizeId = sizeid

                });
            }
            cookiebasket = JsonConvert.SerializeObject(basketVMs);
            HttpContext.Response.Cookies.Append("basket", cookiebasket);
            foreach (BasketVM basketVM in basketVMs)
            {
                Product dbProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == basketVM.ProductId);
                basketVM.Image = dbProduct.MainImage;
                basketVM.Price = dbProduct.DiscountPrice > 0 ? dbProduct.DiscountPrice : dbProduct.Price;
                basketVM.Name = dbProduct.Name;


            }



            return PartialView("_BasketPartial", basketVMs);
        }
    }
}
