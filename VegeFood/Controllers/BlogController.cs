using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using VegeFood.Models.SQLModels;
using VegeFood.Services.SQLServices;

namespace VegeFood.Controllers
{
    public class BlogController : Controller
    {
        private BlogService blogService;
        private CategoryService categoryService;

        public BlogController(IConfiguration configuration)
        {
            blogService = new BlogService(configuration);
            categoryService = new CategoryService(configuration);
        }

        [Route("/blog")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Blog> blogList = await blogService.GetListBlogsAsync();
            if (blogList.Count == 0) return Redirect("/error");
            ViewBag.CategoryList = categoryService.GetListCategories();
            return View(blogList);
        }

        [Route("/blog/{blogId}")]
        [HttpGet]
        public async Task<IActionResult> Detail(int blogId)
        {
            Blog blog = await blogService.GetBlogByIdAsync(blogId);
            ViewBag.BlogList = blogService.GetListBlogs();
            ViewBag.CategoryList = categoryService.GetListCategories();
            if (blog == null) return Redirect("/error");
            return View(blog);
        }
    }
}
