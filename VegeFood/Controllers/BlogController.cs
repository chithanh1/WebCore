using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using VegeFood.Models.SQLModel;
using VegeFood.Services.SQLService;

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
        public IActionResult Index()
        {
            List<Blog> blogList = blogService.GetListBlogs();
            if (blogList.Count == 0) return BadRequest();
            ViewBag.CategoryList = categoryService.GetListCategories();
            return View(blogList);
        }

        [Route("/blog/detail/{blogId}")]
        [HttpGet]
        public IActionResult Detail(int blogId)
        {
            Blog blog = blogService.GetBlogById(blogId);
            ViewBag.BlogList = blogService.GetListBlogs();
            ViewBag.CategoryList = categoryService.GetListCategories();
            if (blog == null) return BadRequest();
            return View(blog);
        }
    }
}
