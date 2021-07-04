using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Seeds
{
    public static class UFSeeds
    {
        public static void CreateUFs(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UFEntity>().HasData(
                  new UFEntity()
                  {
                      Id = new Guid("22ffbd18-cdb9-45cc-97b0-51e97700bf71"),
                      FederateUnit = "AC",
                      Name = "Acre",
                      CreateAt = DateTime.UtcNow
                  },
                new UFEntity()
                {
                    Id = new Guid("7cc33300-586e-4be8-9a4d-bd9f01ee9ad8"),
                    FederateUnit = "AL",
                    Name = "Alagoas",
                    CreateAt = DateTime.UtcNow
                },
                new UFEntity()
                {
                    Id = new Guid("cb9e6888-2094-45ee-bc44-37ced33c693a"),
                    FederateUnit = "AM",
                    Name = "Amazonas",
                    CreateAt = DateTime.UtcNow
                },
                 new UFEntity()
                 {
                     Id = new Guid("409b9043-88a4-4e86-9cca-ca1fb0d0d35b"),
                     FederateUnit = "AP",
                     Name = "Amapá",
                     CreateAt = DateTime.UtcNow
                 },
                 new UFEntity()
                 {
                     Id = new Guid("5abca453-d035-4766-a81b-9f73d683a54b"),
                     FederateUnit = "BA",
                     Name = "Bahia",
                     CreateAt = DateTime.UtcNow
                 },
                 new UFEntity()
                 {
                     Id = new Guid("5ff1b59e-11e7-414d-827e-609dc5f7e333"),
                     FederateUnit = "CE",
                     Name = "Ceará",
                     CreateAt = DateTime.UtcNow
                 },
                 new UFEntity()
                 {
                     Id = new Guid("bd08208b-bfca-47a4-9cd0-37e4e1fa5006"),
                     FederateUnit = "DF",
                     Name = "Distrito Federal",
                     CreateAt = DateTime.UtcNow
                 },
                 new UFEntity()
                 {
                     Id = new Guid("c623f804-37d8-4a19-92c1-67fd162862e6"),
                     FederateUnit = "ES",
                     Name = "Espírito Santo",
                     CreateAt = DateTime.UtcNow
                 },
                 new UFEntity()
                 {
                     Id = new Guid("837a64d3-c649-4172-a4e0-2b20d3c85224"),
                     FederateUnit = "GO",
                     Name = "Goiás",
                     CreateAt = DateTime.UtcNow
                 },
                 new UFEntity()
                 {
                     Id = new Guid("57a9e9f7-9aea-40fe-a783-65d4feb59fa8"),
                     FederateUnit = "MA",
                     Name = "Maranhão",
                     CreateAt = DateTime.UtcNow
                 },
                 new UFEntity()
                 {
                     Id = new Guid("27f7a92b-1979-4e1c-be9d-cd3bb73552a8"),
                     FederateUnit = "MG",
                     Name = "Minas Gerais",
                     CreateAt = DateTime.UtcNow
                 },
                 new UFEntity()
                 {
                     Id = new Guid("3739969c-fd8a-4411-9faa-3f718ca85e70"),
                     FederateUnit = "MS",
                     Name = "Mato Grosso do Sul",
                     CreateAt = DateTime.UtcNow
                 },
                 new UFEntity()
                 {
                     Id = new Guid("29eec4d3-b061-427d-894f-7f0fecc7f65f"),
                     FederateUnit = "MT",
                     Name = "Mato Grosso",
                     CreateAt = DateTime.UtcNow
                 },
                 new UFEntity()
                 {
                     Id = new Guid("8411e9bc-d3b2-4a9b-9d15-78633d64fc7c"),
                     FederateUnit = "PA",
                     Name = "Pará",
                     CreateAt = DateTime.UtcNow
                 },
                 new UFEntity()
                 {
                     Id = new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee"),
                     FederateUnit = "PB",
                     Name = "Paraíba",
                     CreateAt = DateTime.UtcNow
                 },
                 new UFEntity()
                 {
                     Id = new Guid("ad5969bd-82dc-4e23-ace2-d8495935dd2e"),
                     FederateUnit = "PE",
                     Name = "Pernambuco",
                     CreateAt = DateTime.UtcNow
                 },
                 new UFEntity()
                 {
                     Id = new Guid("f85a6cd0-2237-46b1-a103-d3494ab27774"),
                     FederateUnit = "PI",
                     Name = "Piauí",
                     CreateAt = DateTime.UtcNow
                 },
                 new UFEntity()
                 {
                     Id = new Guid("1dd25850-6270-48f8-8b77-2f0f079480ab"),
                     FederateUnit = "PR",
                     Name = "Paraná",
                     CreateAt = DateTime.UtcNow
                 },
                 new UFEntity()
                 {
                     Id = new Guid("43a0f783-a042-4c46-8688-5dd4489d2ec7"),
                     FederateUnit = "RJ",
                     Name = "Rio de Janeiro",
                     CreateAt = DateTime.UtcNow
                 },
                 new UFEntity()
                 {
                     Id = new Guid("542668d1-50ba-4fca-bbc3-4b27af108ea3"),
                     FederateUnit = "RN",
                     Name = "Rio Grande do Norte",
                     CreateAt = DateTime.UtcNow
                 },
                 new UFEntity()
                 {
                     Id = new Guid("924e7250-7d39-4e8b-86bf-a8578cbf4002"),
                     FederateUnit = "RO",
                     Name = "Rondônia",
                     CreateAt = DateTime.UtcNow
                 },
                 new UFEntity()
                 {
                     Id = new Guid("9fd3c97a-dc68-4af5-bc65-694cca0f2869"),
                     FederateUnit = "RR",
                     Name = "Roraima",
                     CreateAt = DateTime.UtcNow
                 },
                 new UFEntity()
                 {
                     Id = new Guid("88970a32-3a2a-4a95-8a18-2087b65f59d1"),
                     FederateUnit = "RS",
                     Name = "Rio Grande do Sul",
                     CreateAt = DateTime.UtcNow
                 },
                 new UFEntity()
                 {
                     Id = new Guid("b81f95e0-f226-4afd-9763-290001637ed4"),
                     FederateUnit = "SC",
                     Name = "Santa Catarina",
                     CreateAt = DateTime.UtcNow
                 },
                 new UFEntity()
                 {
                     Id = new Guid("fe8ca516-034f-4249-bc5a-31c85ef220ea"),
                     FederateUnit = "SE",
                     Name = "Sergipe",
                     CreateAt = DateTime.UtcNow
                 },
                 new UFEntity()
                 {
                     Id = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                     FederateUnit = "SP",
                     Name = "São Paulo",
                     CreateAt = DateTime.UtcNow
                 },
                 new UFEntity()
                 {
                     Id = new Guid("971dcb34-86ea-4f92-989d-064f749e23c9"),
                     FederateUnit = "TO",
                     Name = "Tocantins",
                     CreateAt = DateTime.UtcNow
                 }
            );
        }
    }
}
