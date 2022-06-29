using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pobena.DAL;
using System;
using System.Collections.Generic;
using pobena.Models;
using System.Linq;
using System.Threading.Tasks;
using pobena.Extensions;

namespace pobena.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SizeController : Controller
    {
        private readonly AppDbContext _context;
        public SizeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(bool? status, int page = 1)
        {
            ViewBag.Status = status;

            IEnumerable<Size> sizes = await _context.Sizes

                .Where(t => status != null ? t.IsDeleted == status : true)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)sizes.Count() / 5);

            return View(sizes.Skip((page - 1) * 5).Take(5));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Size size)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (string.IsNullOrWhiteSpace(size.Name))
            {
                ModelState.AddModelError("Name", "Bosluq Olmamalidir");
                return View();
            }

           

            if (size.Name.CheckString())
            {
                ModelState.AddModelError("Name", "Yalniz Herf Ola Biler");
                return View();
            }

            if (await _context.Sizes.AnyAsync(t => t.Name.ToLower() == size.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View();
            }

            size.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Sizes.AddAsync(size);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Size size = await _context.Sizes.FirstOrDefaultAsync(t => t.Id == id);

            if (size == null) return NotFound();

            return View(size);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Size size, bool? status, int page = 1)
        {
            if (!ModelState.IsValid) return View(size);

            if (id == null) return BadRequest();

            if (id != size.Id) return BadRequest();

            Size dbSize = await _context.Sizes.FirstOrDefaultAsync(t => t.Id == id);

            if (dbSize == null) return NotFound();

            if (string.IsNullOrWhiteSpace(size.Name))
            {
                ModelState.AddModelError("Name", "Bosluq Olmamalidir");
                return View(size);
            }

            if (size.Name.CheckString())
            {
                ModelState.AddModelError("Name", "Yalniz Herf Ola Biler");
                return View(size);
            }

            if (await _context.Sizes.AnyAsync(t => t.Id != size.Id && t.Name.ToLower() == size.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View(size);
            }


            dbSize.Name = size.Name;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }
        public async Task<IActionResult> Delete(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Size dbSize = await _context.Sizes.FirstOrDefaultAsync(t => t.Id == id);

            if (dbSize == null) return NotFound();

            dbSize.IsDeleted = true;
            dbSize.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            ViewBag.Status = status;

            IEnumerable<Size> sizes = await _context.Sizes

                .Where(t => status != null ? t.IsDeleted == status : true)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)sizes.Count() / 5);



            return PartialView("_BrandIndexPartial", sizes.Skip((page - 1) * 5).Take(5));
        }
        public async Task<IActionResult> Restore(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Size dbSize = await _context.Sizes.FirstOrDefaultAsync(t => t.Id == id);

            if (dbSize == null) return NotFound();

            dbSize.IsDeleted = false;

            await _context.SaveChangesAsync();

            ViewBag.Status = status;

            IEnumerable<Size> sizes = await _context.Sizes

                .Where(t => status != null ? t.IsDeleted == status : true)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)sizes.Count() / 5);



            return PartialView("_BrandIndexPartial", sizes.Skip((page - 1) * 5).Take(5));
        }
    }
}
