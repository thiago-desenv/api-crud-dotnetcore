using System;
using Api.Data.Mapping;
using Api.Data.Seeds;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CEPEntity> CEP { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<CEPEntity>(new CEPMap().Configure);
            modelBuilder.Entity<UFEntity>(new UFMap().Configure);
            modelBuilder.Entity<CountyEntity>(new CountyMap().Configure);

            UserSeeds.CreateUsers(modelBuilder);
            UFSeeds.CreateUFs(modelBuilder);
        }
    }
}
