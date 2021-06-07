using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //Usado para criar as migrações
            var connectionStringMySql = "Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=1234567";
            //var connectionStringSqlServer = "Server=WINAP9PSX6DQSD3;Initial Catalog=dbiapi;MultipleActiveResultSets=true;User ID=txf;Password=robo@0101;";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseMySql(connectionStringMySql);
            //optionsBuilder.UseSqlServer(connectionStringSqlServer);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
