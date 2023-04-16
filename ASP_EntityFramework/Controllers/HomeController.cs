using ASP_EntityFramework.Helpers;
using ASP_EntityFramework.Models;
using Microsoft.AspNetCore.Http;
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
            return View(this.blogDbContext.Posts.ToArray());
        }
        public IActionResult Remove(int id)
        {
            //Post post =this.blogDbContext.Posts.Where(x => x.Id == id).FirstOrDefault();//1
            //this.blogDbContext.Remove(post);
            this.blogDbContext.Remove(new Post {Id=id});//2
            this.blogDbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id)
        {
            Post post = this.blogDbContext.Posts.Where(x => x.Id == id).FirstOrDefault();//1
            
            return View(post);
        }
        [HttpPost]
        public IActionResult Edit(Post post)
        {

            this.blogDbContext.Update(post);
            this.blogDbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Post post, IFormFile image)
        {

            var path = await FileUploadHelper.UploadAsync(image);
            post.ImageUrl = path;

            //if (ModelState.IsValid)
            //{
            //    post.Date = DateTime.Now;
            //    await blogDbContext.AddAsync(post);
            //    await blogDbContext.SaveChangesAsync();
            //    return RedirectToAction("Index", "Home");
            //}
            //return View();
            post.Date = DateTime.Now;
            await blogDbContext.AddAsync(post);
            await blogDbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
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