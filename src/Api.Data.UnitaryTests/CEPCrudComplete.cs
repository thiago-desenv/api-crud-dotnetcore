using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using UnitaryTests;
using Xunit;

namespace Api.Data.UnitaryTests
{
    public class CEPCrudComplete : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public CEPCrudComplete(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de CEP")]
        [Trait("CRUD", "CEPEntity")]
        public async Task Realiza_Teste_CRUD_CEP()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                CountyImplementation _repositorioCounty = new CountyImplementation(context);
                CountyEntity _entityCounty = new CountyEntity
                {
                    Name = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(1000000, 9999999),
                    UFId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
                };

                var registroCriado = await TesteInsereCounty(_repositorioCounty, _entityCounty);

                CEPImplementation _repositorioCEP = new CEPImplementation(context);
                CEPEntity _entityCEP = new CEPEntity()
                {
                    CEP = "14.546-010",
                    Logradouro = Faker.Address.StreetName(),
                    Numero = "2000",
                    CountyID = registroCriado.Id
                };

                await TesteInsereCEP(_repositorioCEP, _entityCEP);
            }

        }

        private async Task<CountyEntity> TesteInsereCounty(CountyImplementation repositorio, CountyEntity entity)
        {
            var _registroCriado = await repositorio.InsertAsync(entity);
            Assert.NotNull(_registroCriado);
            Assert.Equal(_registroCriado.Name, entity.Name);
            Assert.Equal(_registroCriado.CodIBGE, entity.CodIBGE);
            Assert.Equal(_registroCriado.UFId, entity.UFId);
            Assert.False(_registroCriado.Id == Guid.Empty);

            return _registroCriado;
        }

        private async Task TesteInsereCEP(CEPImplementation repositorio, CEPEntity entity)
        {
            var _registroCEPCriado = await repositorio.InsertAsync(entity);
            Assert.NotNull(_registroCEPCriado);
            Assert.Equal(_registroCEPCriado.CEP, entity.CEP);
            Assert.Equal(_registroCEPCriado.Logradouro, entity.Logradouro);
            Assert.Equal(_registroCEPCriado.Numero, entity.Numero);
            Assert.Equal(_registroCEPCriado.CountyID, entity.CountyID);
            Assert.False(_registroCEPCriado.Id == Guid.Empty);
        }
    }
}
