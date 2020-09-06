using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VegeFood.Models.SQLServer;

namespace VegeFood.Services
{
    public class SQLBaseService
    {
        private SQLData sqlData;
        private DbContextOptionsBuilder<SQLData> option;

        public SQLBaseService(IConfiguration configuration)
        {
            option = new DbContextOptionsBuilder<SQLData>();
            option.UseSqlServer(configuration.GetConnectionString("SQLServer"));
            sqlData = new SQLData(option.Options);
        }

        public SQLData SqlData
        {
            get { return sqlData; }
        }

        public DbContextOptionsBuilder<SQLData> Option
        {
            get { return option; }
        }
    }
}
