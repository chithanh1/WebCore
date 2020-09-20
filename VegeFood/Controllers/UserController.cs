using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using VegeFood.Models.SQLModel;
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

        [Route("/users")]
        [HttpGet]
        public IActionResult IndexAdmin()
        {
            List<User> userList = userService.GetListUsers();
            return View(userList);
        }

        public IActionResult AdminUser()
        {
            return View();
        }

        [Route("/user/detail/{userId}")]
        public IActionResult DetailAdmin(int userId)
        {
            User user = userService.GetUserById(userId);
            if (user == null) return BadRequest();
            else return View(user);
        }
    }
}
