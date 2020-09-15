using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VegeFood.Models;
using VegeFood.Models.SQLModel;
using VegeFood.Services.SQLService;

namespace VegeFood.Controllers
{
    public class HomeController : Controller
    {
        private ProductService productService;
        private UserService userService;

        public HomeController(IConfiguration configuration)
        {
            productService = new ProductService(configuration);
            userService = new UserService(configuration);
        }

        [Route("/home")]
        public IActionResult Index()
        {
            List<Product> productList = productService.GetListProducts();
            return View(productList);
        }

        [Route("/about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("/contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("/admin/home")]
        public IActionResult IndexAdmin()
        {
            ViewBag.ProductList = productService.GetListProducts();
            ViewBag.UserList = userService.GetListUsers();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
