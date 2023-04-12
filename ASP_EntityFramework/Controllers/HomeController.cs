using ASP_EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP_EntityFramework.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlogDbContext blogDbContext;

        public HomeController(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }

        public IActionResult Index()
        {
            return View(blogDbContext.Posts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            //ModelState.AddModelError("Title", "Prosto tak");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Post post)
        {
            if (ModelState.IsValid)//
            {
                post.Date = DateTime.Now;
                await blogDbContext.AddAsync(post);
                await blogDbContext.SaveChangesAsync();
                TempData["Status"] = "New Post Added";
                return RedirectToAction("Index", "Home");
            }
            return View(post);
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