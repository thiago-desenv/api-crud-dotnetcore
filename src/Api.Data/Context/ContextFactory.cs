using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //Usado para criar as migrações
            var typeDataBase = "SQLSERVER";
            var connectionString = @"Persist Security Info=True;Data Source=DESKTOP-2GT602A\SQLEXPRESS;Initial Catalog=dbapi;Integrated Security=True";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();

            ConfigureDataBase(typeDataBase, connectionString, optionsBuilder);
            return new MyContext(optionsBuilder.Options);
        }

        private void ConfigureDataBase(string typeDataBase, string connectionString, DbContextOptionsBuilder<MyContext> optionsBuilder)
        {
            if (typeDataBase.ToUpper() == "SQLSERVER")
                optionsBuilder.UseSqlServer(connectionString);
            else
                optionsBuilder.UseMySql(connectionString);
        }
    }
}
