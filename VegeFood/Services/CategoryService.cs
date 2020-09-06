using Microsoft.Extensions.Configuration;

namespace VegeFood.Services
{
    public class CategoryService: SQLBaseService
    {
        public CategoryService(IConfiguration configuration) : base(configuration) { }


    }
}
