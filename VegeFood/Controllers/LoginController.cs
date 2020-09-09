using Microsoft.AspNetCore.Mvc;
using VegeFood.Models.SQLModel;

namespace VegeFood.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        [Route("/login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserInfo loginUser)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(InsertUserInfo insertUser)
        {
            return View();
        }
    }
}
