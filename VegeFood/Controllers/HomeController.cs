using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VegeFood.Models;
using VegeFood.Models.SQLServer;
using VegeFood.Services;

namespace VegeFood.Controllers
{
    public class HomeController : Controller
    {
        private ProductService productService;

        public HomeController(IConfiguration configuration)
        {
            productService = new ProductService(configuration);
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

        [Route("/block")]
        public IActionResult Blog()
        {
            return View();
        }

        [Route("/contact")]
        public IActionResult Contact()
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
