using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pobena.DAL;
using pobena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pobena.Areas.Manage.Controllers
{
    [Area("manage")]
    public class BrandController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public BrandController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index(bool? status, int page = 1)
        {
            ViewBag.Status = status;


            IQueryable<Brand> brands = _context.Brands
                .Include(t => t.Products)
                .OrderByDescending(t => t.CreatedAt);

            if (status != null)
                brands = brands.Where(c => c.IsDeleted == status);



            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)brands.Count() / 5);

            return View(await brands.Skip((page - 1) * 5).Take(5).ToListAsync());
        }


        public async Task<IActionResult> Create(bool? status, int page = 1)
        {
            ViewBag.MainBrand = await _context.Brands.Where(c => !c.IsDeleted).ToListAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Brand brand, bool? status, int page = 1)
        {
            ViewBag.MainBrand = await _context.Brands.Where(c => !c.IsDeleted).ToListAsync();

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (string.IsNullOrWhiteSpace(brand.Name))
            {
                ModelState.AddModelError("Name", "Bosluq Olmamalidir");
                return View();
            }

      

            if (await _context.Brands.AnyAsync(t => t.Name.ToLower() == brand.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View();
            }

            brand.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }

        public async Task<IActionResult> Update(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Brand brand = await _context.Brands.FirstOrDefaultAsync(c => c.Id == id);

            if (brand == null) return NotFound();

            ViewBag.MainBrand = await _context.Brands.Where(c => c.Id != id && !c.IsDeleted).ToListAsync();

            return View(brand);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Brand brand, bool? status, int page = 1)
        {
            ViewBag.MainBrand = await _context.Brands.Where(c => c.Id != id && !c.IsDeleted).ToListAsync();

            Brand dbBrand = await _context.Brands.FirstOrDefaultAsync(c => c.Id == id);

            if (dbBrand == null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(dbBrand);
            }

            if (id != brand.Id) return BadRequest();

            if (string.IsNullOrWhiteSpace(brand.Name))
            {
                ModelState.AddModelError("Name", "Bosluq Olmamalidir");
                return View(dbBrand);
            }




            if (await _context.Brands.AnyAsync(t => t.Id != id && t.Name.ToLower() == brand.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View(dbBrand);
            }

            dbBrand.Name = brand.Name;
            dbBrand.UpdatedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }

        public async Task<IActionResult> Delete(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Brand dbBrand = await _context.Brands.FirstOrDefaultAsync(t => t.Id == id);

            if (dbBrand == null) return NotFound();

            dbBrand.IsDeleted = true;
            dbBrand.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            ViewBag.Status = status;


            IEnumerable<Brand> brands = await _context.Brands
                .Include(t => t.Products)
                .Where(t => status != null ? t.IsDeleted == status : true)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)brands.Count() / 5);

            return PartialView("_BrandIndexPartial", brands.Skip((page - 1) * 5).Take(5));
        }
        public async Task<IActionResult> Restore(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Brand dbBrand = await _context.Brands.FirstOrDefaultAsync(t => t.Id == id);

            if (dbBrand == null) return NotFound();

            dbBrand.IsDeleted = false;

            await _context.SaveChangesAsync();

            ViewBag.Status = status;


            IEnumerable<Brand> brands = await _context.Brands
                .Include(t => t.Products)
                .Where(t => status != null ? t.IsDeleted == status : true)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)brands.Count() / 5);

            return PartialView("_BrandIndexPartial", brands.Skip((page - 1) * 5).Take(5));
        }
    }
}
