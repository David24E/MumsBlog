using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MumsBlog.Data;
using MumsBlog.Models;

namespace MumsBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
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

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
