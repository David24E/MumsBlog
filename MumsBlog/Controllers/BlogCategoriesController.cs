using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MumsBlog.Data;
using MumsBlog.Models;

namespace MumsBlog.Controllers
{
    public class BlogCategoriesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BlogCategoriesController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET : ServiceTypes
        public IActionResult Index()
        {
            return View(_db.BlogCategories.ToList());
        }


        //GET: ServiceTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST : Services/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogCategory blogCategory)
        {
            if (ModelState.IsValid)
            {
                _db.Add(blogCategory);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blogCategory);
        }

        //Details : ServiceTypes/Details/1
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var blogCategory = await _db.BlogCategories.SingleOrDefaultAsync(m => m.Id == id);
            if (blogCategory == null)
            {
                return NotFound();
            }
            return View(blogCategory);
        }

        //Edit : ServiceTypes/Edit/1
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var blogCategory = await _db.BlogCategories.SingleOrDefaultAsync(m => m.Id == id);
            if (blogCategory == null)
            {
                return NotFound();
            }
            return View(blogCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BlogCategory blogCategory)
        {
            if (id != blogCategory.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Update(blogCategory);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(blogCategory);
        }


        //Delete : ServiceTypes/Delete/1
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var blogCategory = await _db.BlogCategories.SingleOrDefaultAsync(m => m.Id == id);
            if (blogCategory == null)
            {
                return NotFound();
            }
            return View(blogCategory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveBlogCategory(int id)
        {
            var blogCategory = await _db.BlogCategories.SingleOrDefaultAsync(m => m.Id == id);
            _db.BlogCategories.Remove(blogCategory);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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