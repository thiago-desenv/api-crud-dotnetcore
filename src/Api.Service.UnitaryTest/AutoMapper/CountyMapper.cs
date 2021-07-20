using System;
using System.Collections.Generic;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.UnitaryTest.AutoMapper
{
    public class CountyMapper : BaseTest
    {
        [Fact(DisplayName = "Teste mapeamento modelo de County")]
        public void Realiza_Teste_Modelos_County()
        {
            var model = CriaObjetoModel();

            var listaEntity = new List<CountyEntity>();
            for (int i = 0; i < 5; i++)
                listaEntity.Add(CriaObjetoEntity());


        }

        private CountyModel CriaObjetoModel()
        {
            return new CountyModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Address.City(),
                CodIBGE = Faker.RandomNumber.Next(1000000, 9999999),
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now
            };
        }

        private CountyEntity CriaObjetoEntity()
        {
            return new CountyEntity
            {
                Id = Guid.NewGuid(),
                Name = Faker.Address.City(),
                CodIBGE = Faker.RandomNumber.Next(1, 10000),
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                UF = new UFEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Address.UsState(),
                    UF = Faker.Address.UsState().Substring(1, 3)
                }
            };
        }
    }
}
