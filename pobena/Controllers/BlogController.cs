using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pobena.DAL;
using pobena.Models;
using pobena.ViewModels.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pobena.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public BlogController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            ViewBag.Tags = _context.Tags.ToList();
            List<Blog> blogs = _context.Blogs
                .Include(p=>p.BlogTags).ThenInclude(t=>t.Tag)
                .Include(p=>p.Reviews)
                .Where(p => !p.IsDeleted).ToList();
            return View(blogs);
        }
        public async Task<IActionResult> Detail(int? bid)
        {
            ViewBag.Tags = await _context.Tags.ToListAsync();
            ViewBag.Categories = await _context.Categories.Where(p => !p.IsDeleted).ToListAsync();
            ViewBag.Blogs = await _context.Blogs.OrderByDescending(b => b.CreatedAt).Take(4).ToListAsync();

            if (bid == null) return BadRequest();
            Blog blog = await _context.Blogs
                .Include(b => b.Reviews)
                .FirstOrDefaultAsync(p => p.Id == (int)bid && !p.IsDeleted);
            if (blog == null) return NotFound();

            BlogVM blogVM = new BlogVM()
            {
                Blog = blog,
                Blogs = await _context.Blogs.Where(p => !p.IsDeleted).ToListAsync(),
                Reviews = await _context.Reviews.Where(p => p.BlogId == blog.Id && !p.IsDeleted).OrderByDescending(r => r.CreatedAt).ToListAsync()
            };

            return View(blogVM);
        }
        public async Task<IActionResult> AddReview(string Message, int? bid)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return PartialView("_LoginPartial");
            }
            if (bid == null) return View();
            Blog blog = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == bid && !b.IsDeleted);
            if (blog == null) return NotFound();
            Review review = new Review();
            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name && !u.IsAdmin);
            review.Email = appUser.Email;
            review.Name = appUser.UserName;
            BlogVM blogVM = new BlogVM()
            {
                Blog = blog,
                Blogs = await _context.Blogs.Where(p => !p.IsDeleted).ToListAsync(),
                Reviews = await _context.Reviews
               .Where(p => p.BlogId == blog.Id && !p.IsDeleted)
               .OrderByDescending(r => r.CreatedAt)
               .ToListAsync()
            };
            if (Message == null || Message == "" || Message.Trim() == null || Message.Trim() == "")
            {
                return PartialView("_AddReviewPartial", blogVM);
            }

            review.Message = Message.Trim();
            if (review.Star == null || review.Star < 0 || review.Star > 5)
            {
                review.Star = 1;
            }
            review.BlogId = (int)bid;
            review.CreatedAt = DateTime.UtcNow.AddHours(4);
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
            blogVM = new BlogVM()
            {
                Blog = blog,
                Blogs = await _context.Blogs.ToListAsync(),
                Reviews = await _context.Reviews
                .Where(p => p.BlogId == blog.Id && !p.IsDeleted)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync()
            };
            return PartialView("_AddReviewPartial", blogVM);
        }
        public async Task<IActionResult> Edit(string Message, int? id)
        {
            if (id == null) return BadRequest();
            Review dbReview = await _context.Reviews.FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);
            if (dbReview == null) return NotFound();

            if (Message != null && Message.Trim() != null && Message.Trim() != "")
            {
                dbReview.Message = Message.Trim();
            }
            dbReview.UpdatedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();

            BlogVM blogVM = new BlogVM()
            {
                Blog = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == dbReview.BlogId && !b.IsDeleted),
                Blogs = await _context.Blogs.ToListAsync(),
                Reviews = await _context.Reviews
                .Where(p => p.BlogId == dbReview.BlogId && !p.IsDeleted)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync()
            };
            return PartialView("_AddReviewPartial", blogVM);
        }
        public async Task<IActionResult> EditComment(int? id)
        {
            if (id == null) return BadRequest();
            Review dbReview = await _context.Reviews
                .Include(r => r.Blog)
                .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);
            if (dbReview == null) return NotFound();

            return PartialView("_ReviewEditPartial", dbReview);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();

            Review review = await _context.Reviews
                .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);
            if (review == null) return NotFound();
            review.IsDeleted = true;
            review.DeletedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();
            BlogVM blogVM = new BlogVM()
            {
                Blog = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == review.BlogId && !b.IsDeleted),
                Blogs = await _context.Blogs.ToListAsync(),
                Reviews = await _context.Reviews
                .Where(p => p.BlogId == review.BlogId && !p.IsDeleted)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync()
            };
            return PartialView("_AddReviewPartial", blogVM);
        }
        public async Task<IActionResult> CommentCount(int? id)
        {
            if (id == null) BadRequest();
            Blog blog = await _context.Blogs.FirstOrDefaultAsync(p => !p.IsDeleted && p.Id == id);
            if (blog == null) return NotFound();
            IEnumerable<Review> reviews = await _context.Reviews.Where(r => !r.IsDeleted && r.BlogId == blog.Id).ToListAsync();
            return Content($"{reviews.Count()}");
        }
        public async Task<IActionResult> toTag(int? tag, int page = 1)
        {
            if (tag == null) return BadRequest();
            Tag dbtag = await _context.Tags.FirstOrDefaultAsync(t => !t.IsDeleted && t.Id == tag);
            if (dbtag == null) return NotFound();
            ViewBag.PageIndex = page;
            ViewBag.WhichName = _context.Categories.FirstOrDefault(c => c.Id == dbtag.Id && !c.IsDeleted).Name;
            List<Blog> blogs = await _context.Blogs
                .Include(p => p.BlogTags)
                .ThenInclude(p => p.Tag)
                .Where(p => p.BlogTags.Any(p => p.TagId == dbtag.Id) && !p.IsDeleted)
                .ToListAsync();

            ViewBag.PageCount = Math.Ceiling((double)blogs.Count() / 6);

            return RedirectToAction("index", new { tag, page });
        }
    }
}
