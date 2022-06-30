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
    }
}
