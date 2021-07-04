using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Seeds
{
    public class UserSeeds
    {
        public static void CreateUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Administrator",
                    Email = "administrator@hotmail.com",
                    CreateAt = DateTime.Now
                }
            );
        }
    }
}
