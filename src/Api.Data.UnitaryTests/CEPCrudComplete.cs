using System;
using System.Linq;
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
                await TesteAtualizaCEP(_repositorioCEP, _entityCEP);
                await TesteExistAsync(_repositorioCEP, _entityCEP);
                await TesteSelecionaPorId(_repositorioCEP, _entityCEP);
                await TesteSelecionaPorCEP(_repositorioCEP, _entityCEP);
                await TesteSelecionaTodosRegistros(_repositorioCEP);
                await TesteDeletePorID(_repositorioCEP, _entityCEP);
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

        private async Task TesteAtualizaCEP(CEPImplementation repositorio, CEPEntity entity)
        {
            entity.Logradouro = Faker.Address.StreetName();
            var _registroAtualizado = await repositorio.UpdateAsync(entity);
            Assert.NotNull(_registroAtualizado);
            Assert.Equal(_registroAtualizado.CEP, entity.CEP);
            Assert.Equal(_registroAtualizado.Logradouro, entity.Logradouro);
            Assert.Equal(_registroAtualizado.Numero, entity.Numero);
            Assert.Equal(_registroAtualizado.CountyID, entity.CountyID);
            Assert.True(_registroAtualizado.Id == entity.Id);
        }

        private async Task TesteExistAsync(CEPImplementation repositorio, CEPEntity entity)
        {
            var _registroExiste = await repositorio.ExistAsync(entity.Id);
            Assert.True(_registroExiste);
        }

        private async Task TesteSelecionaPorId(CEPImplementation repositorio, CEPEntity entity)
        {
            var _registroSelecionado = await repositorio.SelectAsync(entity.Id);
            Assert.NotNull(_registroSelecionado);
            Assert.Equal(_registroSelecionado.CEP, entity.CEP);
            Assert.Equal(_registroSelecionado.Logradouro, entity.Logradouro);
            Assert.Equal(_registroSelecionado.Numero, entity.Numero);
            Assert.Equal(_registroSelecionado.CountyID, entity.CountyID);
        }

        private async Task TesteSelecionaPorCEP(CEPImplementation repositorio, CEPEntity entity)
        {
            var _registroSelecionado = await repositorio.SelectAsync(entity.CEP);
            Assert.NotNull(_registroSelecionado);
            Assert.Equal(_registroSelecionado.CEP, entity.CEP);
            Assert.Equal(_registroSelecionado.Logradouro, entity.Logradouro);
            Assert.Equal(_registroSelecionado.Numero, entity.Numero);
            Assert.Equal(_registroSelecionado.CountyID, entity.CountyID);
            Assert.NotNull(_registroSelecionado.County);
            Assert.NotNull(_registroSelecionado.County.UF);
        }

        private async Task TesteSelecionaTodosRegistros(CEPImplementation repositorio)
        {
            var _registrosSelecionados = await repositorio.SelectAllAsync();
            Assert.NotNull(_registrosSelecionados);
            Assert.True(_registrosSelecionados.Count() > 0);
        }

        private async Task TesteDeletePorID(CEPImplementation repositorio, CEPEntity entity)
        {
            var _removeu = await repositorio.DeleteAsync(entity.Id);
            Assert.True(_removeu);
        }
    }
}
