using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using VegeFood.Models;
using VegeFood.Models.SQLModel;
using VegeFood.Services.SQLService;
using VegeFood.Support;

namespace VegeFood.Controllers
{
    public class HomeController : Controller
    {
        private ProductService productService;
        private ILogger<HomeController> logger;

        public HomeController(IConfiguration configuration, ILogger<HomeController> logger)
        {
            productService = new ProductService(configuration);
            this.logger = logger;
        }

        [Route("/home")]
        [ServiceFilter(typeof(AuthorizedAttribute))]
        public IActionResult Index()
        {
            List<Product> productList = productService.GetListProducts();
            logger.LogInformation(Request.HttpContext.Request.Headers["abc"]);
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
