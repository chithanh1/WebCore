using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using VegeFood.Models.SQLModels;
using VegeFood.Services.SQLServices;

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
        public async Task<IActionResult> Index()
        {
            List<Product> productList = await productService.GetListProductsAsync();
            List<Category> categorieList = await categoryService.GetListCategoriesAsync();
            ViewBag.CategoryList = categorieList;
            if (productList.Count == 0) return BadRequest();
            return View(productList);
        }

        [Route("/shop/detail/{productId}")]
        [HttpGet]
        public async Task<IActionResult> Detail(int productId)
        {
            Product product = await productService.GetProductByIdAsync(productId);
            if (product == null) return BadRequest();
            List<Product> productList = await productService.GetListProductsAsync();
            ViewBag.ProductList = productList;
            return View(product);
        }

        [Route("/admin/product")]
        [HttpGet]
        public async Task<IActionResult> IndexAdmin()
        {
            List<Product> productList = await productService.GetListProductsAsync();
            if (productList.Count == 0) return BadRequest();
            ViewBag.Route = "/admin/product";
            ViewBag.NameRoute = "Products List";
            return View(productList);
        }

        [Route("/admin/product/detail/{productId}")]
        [HttpGet]
        public async Task<IActionResult> DetailAdmin(int productId)
        {
            Product product = await productService.GetProductByIdAsync(productId);
            if (product == null) return BadRequest();
            ViewBag.Route = $"/admin/product/detail/{productId}";
            ViewBag.NameRoute = "Products List";
            return View(product);
        }

        [Route("/admin/product/edit/{produtId}")]
        public async Task<IActionResult> EditAdmin(int productId)
        {
            Product product = await productService.GetProductByIdAsync(productId);
            if (product == null) return BadRequest();
            ViewBag.Route = $"/admin/product/edit/{productId}";
            ViewBag.NameRoute = "Edit Product";
            return View(product);
        }
    }
}
