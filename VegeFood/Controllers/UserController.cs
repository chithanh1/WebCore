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

        [Route("/admin/users")]
        [HttpGet]
        public IActionResult IndexAdmin()
        {
            List<User> userList = userService.GetListUsers();
            ViewBag.Route = "/admin/users";
            ViewBag.RouteName = "User List";
            return View(userList);
        }

        [Route("/admin/users/{userId}")]
        [HttpGet]
        public IActionResult DetailAdmin(int userId)
        {
            User user = userService.GetUserById(userId);
            if (user == null) return BadRequest();
            else
            {
                ViewBag.Route = $"/admin/users/{userId}";
                ViewBag.RouteName = "User Detail";
                return View(user);
            }
        }

        [Route("/admin/users/edit/{userId}")]
        [HttpGet]
        public IActionResult EditAdmin(int userId)
        {
            User user = userService.GetUserById(userId);
            if (user == null) return BadRequest();
            else
            {
                ViewBag.Route = $"/admin/users/edit/{userId}";
                ViewBag.RouteName = "User Detail";
                return View(user);
            }
        }
    }
}
