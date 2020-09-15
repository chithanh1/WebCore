using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VegeFood.Services.SQLService;

namespace VegeFood.Controllers
{
    public class UserController : Controller
    {
        private UserService userService;

        public UserController(IConfiguration configuration)
        {
            userService = new UserService(configuration);
        }


    }
}
