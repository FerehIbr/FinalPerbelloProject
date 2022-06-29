using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pobena.DAL;
using pobena.Extensions;
using System;
using System.Collections.Generic;
using pobena.Models;
using System.Linq;
using System.Threading.Tasks;
 

namespace pobena.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ColorController : Controller
    {
        private readonly AppDbContext _context;

        public ColorController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(bool? status, int page = 1)
        {
            ViewBag.Status = status;

            IEnumerable<Color> colors = (IEnumerable<Color>)await _context.Colors


                .Where(t => status != null ? t.IsDeleted == status : true)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)colors.Count() / 5);

            return View(colors.Skip((page - 1) * 5).Take(5));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Color color)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (string.IsNullOrWhiteSpace(color.Name))
            {
                ModelState.AddModelError("Name", "Bosluq Olmamalidir");
                return View();
            }

            //tag.Name = tag.Name.Trim();

            if (color.Name.CheckString())
            {
                ModelState.AddModelError("Name", "Yalniz Herf Ola Biler");
                return View();
            }

            if (await _context.Colors.AnyAsync(t => t.Name.ToLower() == color.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View();
            }

            color.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Colors.AddAsync(color);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Color color = await _context.Colors.FirstOrDefaultAsync(t => t.Id == id);

            if (color == null) return NotFound();

            return View(color);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Color color, bool? status, int page = 1)
        {
            if (!ModelState.IsValid) return View(color);

            if (id == null) return BadRequest();

            if (id != color.Id) return BadRequest();

            Color dbColor = await _context.Colors.FirstOrDefaultAsync(t => t.Id == id);

            if (dbColor == null) return NotFound();

            if (string.IsNullOrWhiteSpace(color.Name))
            {
                ModelState.AddModelError("Name", "Bosluq Olmamalidir");
                return View(color);
            }

            if (color.Name.CheckString())
            {
                ModelState.AddModelError("Name", "Yalniz Herf Ola Biler");
                return View(color);
            }

            if (await _context.Colors.AnyAsync(t => t.Id != color.Id && t.Name.ToLower() == color.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View(color);
            }


            dbColor.Name = color.Name;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }
        public async Task<IActionResult> Delete(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Color dbColor = await _context.Colors.FirstOrDefaultAsync(t => t.Id == id);

            if (dbColor == null) return NotFound();

            dbColor.IsDeleted = true;
            dbColor.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            ViewBag.Status = status;

            IEnumerable<Color> colors = await _context.Colors

                .Where(t => status != null ? t.IsDeleted == status : true)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)colors.Count() / 5);



            return PartialView("_BrandIndexPartial", colors.Skip((page - 1) * 5).Take(5));
        }
        public async Task<IActionResult> Restore(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Color dbColor = await _context.Colors.FirstOrDefaultAsync(t => t.Id == id);

            if (dbColor == null) return NotFound();

            dbColor.IsDeleted = false;

            await _context.SaveChangesAsync();

            ViewBag.Status = status;

            IEnumerable<Color> colors = await _context.Colors

                .Where(t => status != null ? t.IsDeleted == status : true)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)colors.Count() / 5);



            return PartialView("_BrandIndexPartial", colors.Skip((page - 1) * 5).Take(5));
        }
    }


}
