using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VegeFood.Models.SQLModel;

namespace VegeFood.Services.SQLService
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

        protected SQLData SqlData
        {
            get { return sqlData; }
        }

        protected DbContextOptionsBuilder<SQLData> Option
        {
            get { return option; }
        }
    }
}
