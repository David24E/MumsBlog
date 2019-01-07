using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MumsBlog.Data;
using MumsBlog.Models;

namespace MumsBlog.Controllers
{
    public class BlogPostsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BlogPostsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(string userId = null)
        {
            if (userId == null)
            {
                //Only called when a customer logs in
                userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            var model = new PostAndUserViewModel
            {
                BlogPosts = _db.BlogPosts.Where(b => b.UserId == userId),
                UserObj = _db.Users.FirstOrDefault(u => u.Id == userId)
            };

            return View(model);
        }

        //Create GET
        public IActionResult Create(string userId)
        {
            BlogPost blogPostObj = new BlogPost
            {
                DateAdded = DateTime.Now.ToShortDateString(),
                UserId = userId
            };
            return View(blogPostObj);
        }


        //Create POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                _db.Add(blogPost);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { userId = blogPost.UserId });
            }

            return View(blogPost);
        }

        //Details GET
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogpost = await _db.BlogPosts
                .Include(b => b.ApplicationUser)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (blogpost == null)
            {
                NotFound();
            }

            return View(blogpost);
        }

        //EDIT GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogpost = await _db.BlogPosts
                .Include(b => b.ApplicationUser)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (blogpost == null)
            {
                NotFound();
            }

            return View(blogpost);
        }

        //EDIT POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BlogPost blogPost)
        {
            if (id != blogPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(blogPost);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { userId = blogPost.UserId });
            }

            return View(blogPost);
        }



        //Delete GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogpost = await _db.BlogPosts
                .Include(b => b.ApplicationUser)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (blogpost == null)
            {
                NotFound();
            }

            return View(blogpost);
        }


        //Delete POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogPost = await _db.BlogPosts.SingleOrDefaultAsync(b => b.Id == id);
            if (blogPost == null)
            {
                return NotFound();
            }
            _db.BlogPosts.Remove(blogPost);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { userId = blogPost.UserId });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }
    }
}