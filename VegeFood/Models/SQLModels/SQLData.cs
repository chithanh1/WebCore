using Microsoft.EntityFrameworkCore;

namespace VegeFood.Models.SQLModels
{
    public class SQLData: DbContext
    {
        public SQLData(DbContextOptions<SQLData> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }
}
