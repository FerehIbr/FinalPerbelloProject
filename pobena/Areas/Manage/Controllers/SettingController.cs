using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pobena.DAL;
using pobena.Extensions;
using pobena.Helpers;
using pobena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pobena.Areas.Manage.Controllers
{

    [Area("manage")]

    public class SettingController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public SettingController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Settings.FirstOrDefaultAsync());
        }
        public async Task<IActionResult> Detail()
        {
            return View(await _context.Settings.FirstOrDefaultAsync());
        }

        public async Task<IActionResult> Update()
        {
            return View(await _context.Settings.FirstOrDefaultAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Setting setting)
        {
            Setting dbSetting = await _context.Settings.FirstOrDefaultAsync();
            if (!ModelState.IsValid)
            {
                return View(dbSetting);
            }

            if (setting.LogoImage != null)
            {
                if (!setting.LogoImage.CheckFileContentType("image/png"))
                {
                    ModelState.AddModelError("LogoImage", "Secilen Seklin Novu Uygun");
                    return View(dbSetting);
                }

                if (!setting.LogoImage.CheckFileSize(30))
                {
                    ModelState.AddModelError("LogoImage", "Secilen Seklin Olcusu Maksimum 30 Kb Ola Biler");
                    return View(dbSetting);
                }


                Helper.DeleteFile(_env, dbSetting.Logo, "assets", "images");

                dbSetting.Logo = setting.LogoImage.CreateFile(_env, "assets", "images");
            }

       
            dbSetting.Phone = setting.Phone;
            dbSetting.Email = setting.Email;
            dbSetting.ContactEmail = setting.ContactEmail;
            dbSetting.Address = setting.Address;
            dbSetting.Fax = setting.Fax;
            dbSetting.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

    }
}
