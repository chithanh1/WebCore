using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VegeFood.Models;
using VegeFood.Models.SQLModels;
using VegeFood.Services.SQLServices;

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
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Product> productList = await productService.GetListProductsAsync();
            return View(productList);
        }

        [Route("/about")]
        public async Task<IActionResult> About()
        {
            return View();
        }

        [Route("/contact")]
        public async Task<IActionResult> Contact()
        {
            return View();
        }

        [Route("/admin/home")]
        [HttpGet]
        public async Task<IActionResult> IndexAdmin()
        {
            ViewBag.ProductList = await productService.GetListProductsAsync();
            ViewBag.UserList = await userService.GetListUsersAsync();
            ViewBag.Route = "/admin/home";
            ViewBag.RouteName = "Home";
            return View();
        }

        [Route("/error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            ErrorViewModel errorView = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(errorView);
        }
    }
}
