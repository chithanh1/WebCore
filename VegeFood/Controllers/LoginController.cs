using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
using VegeFood.Models;
using VegeFood.Models.SQLModels;
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

        [AllowAnonymous]
        [Route("/login")]
        [HttpGet]
        public async Task<IActionResult> Index(string returnUrl)
        {
            LoginUserInfo loginUser = new LoginUserInfo()
            {
                ReturnUrl = "https://localhost:44300/home",
                ExternalLogin = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            return View(loginUser);
        }

        [Route("/admin/login")]
        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        [Route("/login/handle")]
        public async Task<IActionResult> LoginWithUsernameAndPassword(LoginUserInfo loginUser)
        {
            if (ModelState.IsValid)
            {
                Result result = await loginService.LoginWithUsernameAndPasswordAsync(loginUser);
                if (!result.status) ModelState.AddModelError("", result.data.ToString());
                else return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Login");
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("/login/external-handle")]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Login", new { ReturnUrl = returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            LoginUserInfo loginUserInfo = new LoginUserInfo()
            {
                ReturnUrl = returnUrl,
                ExternalLogin = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            if(remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"error from external provider: {remoteError}");
                return View("Login", loginUserInfo);
            }
            ExternalLoginInfo info = await _signInManager.GetExternalLoginInfoAsync();
            if(info == null)
            {
                ModelState.AddModelError(string.Empty, $"error from external provider: {remoteError}");
                return View("Login", loginUserInfo);
            }
            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (signInResult.Succeeded) return LocalRedirect(returnUrl);
            //else
            //{
            //    var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            //    if(email != null)
            //    {

            //    }
            //}
            return View("Login", loginUserInfo);
        }

        [HttpGet]
        [Route("/register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("/register/handle")]
        public IActionResult Register(InsertUserInfo insertUser)
        {
            return View();
        }

        [HttpPost]
        [Route("/forgot-password/handle")]
        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
