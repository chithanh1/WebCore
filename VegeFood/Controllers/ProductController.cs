using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using VegeFood.Models.SQLServer;
using VegeFood.Services;

namespace VegeFood.Controllers
{
    public class ProductController : Controller
    {
        private ProductService productService;
        private CategoryService categoryService;

        public ProductController(IConfiguration configuration)
        {
            productService = new ProductService(configuration);
            categoryService = new CategoryService(configuration);
        }

        [Route("/shop")]
        public IActionResult Index()
        {
            List<Product> productList = productService.GetListProducts();
            List<Category> categorieList = categoryService.GetListCategories();
            ViewBag.CategoryList = categorieList;
            if (productList.Count == 0) return BadRequest();
            return View(productList);
        }

        [Route("/shop/detail/{productId}")]
        public IActionResult Detail(int productId)
        {
            Product product = productService.GetProductById(productId);
            if (product == null) return BadRequest();
            return View(product);
        }
    }
}
