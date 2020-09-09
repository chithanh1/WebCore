using Microsoft.Extensions.Configuration;

namespace VegeFood.Services.SQLService
{
    public class BlogService: SQLBaseService
    {
        public BlogService(IConfiguration configuration): base(configuration)
        {

        }


    }
}
