using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using VegeFood.Models;
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
        public async Task<IActionResult> IndexAdmin()
        {
            List<User> userList = await userService.GetListUsersAsync();
            ViewBag.Route = "/admin/users";
            ViewBag.RouteName = "User List";
            return View(userList);
        }

        [Route("/admin/users/{userId}")]
        [HttpGet]
        public async Task<IActionResult> DetailAdmin(int userId)
        {
            User user = await userService.GetUserByIdAsync(userId);
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
        public async Task<IActionResult> EditAdmin(int userId)
        {
            User user = await userService.GetUserByIdAsync(userId);
            if (user == null) return BadRequest();
            else
            {
                ViewBag.Route = $"/admin/users/edit/{userId}";
                ViewBag.RouteName = "User Edit";
                return View(user);
            }
        }

        [Route("/admin/users/edit/handle")]
        [HttpPost]
        public async Task<IActionResult> EditAdmin(User updateUser)
        {
            Result result = await userService.UpdateUserAsync(updateUser);
            if (result.status) return Redirect($"/admin/users/edit/{updateUser.Id}");
            else return BadRequest();
        }
    }
}
