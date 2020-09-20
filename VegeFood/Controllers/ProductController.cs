using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using VegeFood.Models.SQLModel;
using VegeFood.Services.SQLService;

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
        [HttpGet]
        public IActionResult Index()
        {
            List<Product> productList = productService.GetListProducts();
            List<Category> categorieList = categoryService.GetListCategories();
            ViewBag.CategoryList = categorieList;
            if (productList.Count == 0) return BadRequest();
            return View(productList);
        }

        [Route("/shop/detail/{productId}")]
        [HttpGet]
        public IActionResult Detail(int productId)
        {
            Product product = productService.GetProductById(productId);
            if (product == null) return BadRequest();
            List<Product> productList = productService.GetListProducts();
            ViewBag.ProductList = productList;
            return View(product);
        }

        [Route("/admin/product")]
        [HttpGet]
        public IActionResult IndexAdmin()
        {
            List<Product> productList = productService.GetListProducts();
            if (productList.Count == 0) return BadRequest();
            ViewBag.Route = "/admin/product";
            ViewBag.NameRoute = "Products List";
            return View(productList);
        }

        [Route("/admin/detail/{productId}")]
        [HttpGet]
        public IActionResult DetailAdmin(int productId)
        {
            Product product = productService.GetProductById(productId);
            if (product == null) return BadRequest();
            List<Product> productList = productService.GetListProducts();
            ViewBag.ProductList = productList;
            return View(product);
        }
    }
}
