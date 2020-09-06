using Microsoft.Extensions.Configuration;

namespace VegeFood.Services
{
    public class ProductService: SQLBaseService
    {
        public ProductService(IConfiguration configuration) : base(configuration) { }


    }
}
