using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using VegeFood.Models;
using VegeFood.Models.SQLModel;
using VegeFood.Services.SQLService;

namespace VegeFood.Services
{
    public class LoginService
    {
        private UserService userService;
        public LoginService(IConfiguration configuration)
        {
            userService = new UserService(configuration);
        }

        public Result LoginWithUsernameAndPassword(LoginUserInfo loginUser)
        {
            Result result = userService.Login(loginUser.Username, loginUser.Password);
            return result;
        }

        public async Task<Result> LoginWithUsernameAndPasswordAsync(LoginUserInfo loginUser)
        {
            Result result = await userService.LoginAsync(loginUser.Username, loginUser.Password);
            return result;
        }
    }
}
