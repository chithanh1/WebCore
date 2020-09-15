using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
using VegeFood.Models;
using VegeFood.Models.SQLModel;
using VegeFood.Services;

namespace VegeFood.Controllers
{
    public class LoginController : Controller
    {
        private LoginService loginService;
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginController(SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _signInManager = signInManager;
            loginService = new LoginService(configuration);
        }

        [Route("/login")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index(string returnUrl)
        {
            LoginUserInfo loginUser = new LoginUserInfo()
            {
                ReturnUrl = returnUrl,
                ExternalLogin = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            return View(loginUser);
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

        public IActionResult LoginWithGoogle()
        {
            return View();
        }

        public IActionResult LoginWithFacebook()
        {
            return View();
        }

        public IActionResult ExternalLogin()
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
