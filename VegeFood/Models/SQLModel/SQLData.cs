using Microsoft.EntityFrameworkCore;

namespace VegeFood.Models.SQLModel
{
    public class SQLData: DbContext
    {
        public SQLData(DbContextOptions<SQLData> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
