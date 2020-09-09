using Microsoft.Extensions.Configuration;

namespace VegeFood.Services
{
    public class BlogService: SQLBaseService
    {
        public BlogService(IConfiguration configuration): base(configuration)
        {

        }


    }
}
