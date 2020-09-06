using Microsoft.Extensions.Configuration;

namespace VegeFood.Services
{
    public class UserService: SQLBaseService
    {
        public UserService(IConfiguration configuration) : base(configuration) { }


    }
}
