using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pobena.DAL;
using pobena.ViewModels.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pobena.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ContactVM contactVM = new ContactVM
            {
                Settings = await _context.Settings.Where(c => !c.IsDeleted).ToListAsync()
            };
            return View();
        }
    }
}
