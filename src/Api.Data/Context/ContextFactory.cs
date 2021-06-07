using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //Usado para criar as migrações
            //var connectionStringMySql = "Server=localhost;Port=3306;Database=xxx;Uid=root;Pwd=xxx";
            var connectionStringSqlServer = @"Data Source=DESKTOP-2GT602A\SQLEXPRESS;Initial Catalog=dbapi;Integrated Security=True";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            //optionsBuilder.UseMySql(connectionStringSqlServer);
            optionsBuilder.UseSqlServer(connectionStringSqlServer);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
