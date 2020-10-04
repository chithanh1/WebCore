using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VegeFood.Models;
using VegeFood.Models.SQLModel;
using VegeFood.Services;

namespace VegeFood.Controllers
{
    public class LoginController : Controller
    {
        private LoginService loginService;

        public LoginController(IConfiguration configuration)
        {
            loginService = new LoginService(configuration);
        }

        [Route("/login")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/admin/login")]
        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }

        public IActionResult LoginWithUsernameAndPassword(LoginUserInfo loginUser)
        {
            if (ModelState.IsValid)
            {
                Result result = loginService.LoginWithUsernameAndPassword(loginUser);
                if (!result.status) ModelState.AddModelError("", result.data.ToString());
                else return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Login");
        }
    }
}
