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
    public class CountyCrudComplete : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public CountyCrudComplete(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de município")]
        [Trait("CRUD", "CountyEntity")]
        public async Task Realiza_Teste_CRUD_County()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                CountyImplementation _repositorio = new CountyImplementation(context);
                CountyEntity _entity = new CountyEntity
                {
                    Name = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(1000000, 9999999),
                    UFId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
                };

                await TesteInsereMunicipio(_repositorio, _entity);
                await TesteAtualizaMunicipio(_repositorio, _entity);
                await TesteExistAsync(_repositorio, _entity);
                await TesteSelecionaCountyPorId(_repositorio, _entity);
                await TesteSelecionaCountyPorIBGE(_repositorio, _entity);
                await TesteSelecionaCountyPorID(_repositorio, _entity);
                await TesteSelecionaTodosMunicipios(_repositorio);
                await TesteDeletaCountyPorID(_repositorio, _entity);
            }
        }

        private async Task TesteInsereMunicipio(CountyImplementation repositorio, CountyEntity entity)
        {
            var _registroCriado = await repositorio.InsertAsync(entity);
            Assert.NotNull(_registroCriado);
            Assert.Equal(_registroCriado.Name, entity.Name);
            Assert.Equal(_registroCriado.CodIBGE, entity.CodIBGE);
            Assert.Equal(_registroCriado.UFId, entity.UFId);
            Assert.False(_registroCriado.Id == Guid.Empty);
        }

        private async Task TesteAtualizaMunicipio(CountyImplementation repositorio, CountyEntity entity)
        {
            entity.Name = Faker.Address.City();
            var _registroAtualizado = await repositorio.UpdateAsync(entity);
            Assert.NotNull(_registroAtualizado);
            Assert.Equal(_registroAtualizado.Name, entity.Name);
            Assert.Equal(_registroAtualizado.CodIBGE, entity.CodIBGE);
            Assert.Equal(_registroAtualizado.UFId, entity.UFId);
            Assert.True(_registroAtualizado.Id == entity.Id);
        }

        private async Task TesteExistAsync(CountyImplementation repositorio, CountyEntity entity)
        {
            var _registroExiste = await repositorio.ExistAsync(entity.Id);
            Assert.True(_registroExiste);
        }

        private async Task TesteSelecionaCountyPorId(CountyImplementation repositorio, CountyEntity entity)
        {
            var _registroSelecionado = await repositorio.SelectAsync(entity.Id);
            Assert.NotNull(_registroSelecionado);
            Assert.Equal(_registroSelecionado.Name, entity.Name);
            Assert.Equal(_registroSelecionado.CodIBGE, entity.CodIBGE);
            Assert.Equal(_registroSelecionado.UFId, entity.UFId);
            Assert.Null(_registroSelecionado.UF);
        }

        private async Task TesteSelecionaCountyPorIBGE(CountyImplementation repositorio, CountyEntity entity)
        {
            var _registroSelecionado = await repositorio.GetCompleteIBGE(entity.CodIBGE);
            Assert.NotNull(_registroSelecionado);
            Assert.Equal(_registroSelecionado.Name, entity.Name);
            Assert.Equal(_registroSelecionado.CodIBGE, entity.CodIBGE);
            Assert.Equal(_registroSelecionado.UFId, entity.UFId);
            Assert.NotNull(_registroSelecionado.UF);
        }

        private async Task TesteSelecionaCountyPorID(CountyImplementation repositorio, CountyEntity entity)
        {
            var _registroSelecionado = await repositorio.GetCompleteById(entity.Id);
            Assert.NotNull(_registroSelecionado);
            Assert.Equal(_registroSelecionado.Name, entity.Name);
            Assert.Equal(_registroSelecionado.CodIBGE, entity.CodIBGE);
            Assert.Equal(_registroSelecionado.UFId, entity.UFId);
            Assert.NotNull(_registroSelecionado.UF);
        }

        private async Task TesteSelecionaTodosMunicipios(CountyImplementation repositorio)
        {
            var _todosRegistros = await repositorio.SelectAllAsync();
            Assert.NotNull(_todosRegistros);
            Assert.True(_todosRegistros.Count() > 0);
        }

        private async Task TesteDeletaCountyPorID(CountyImplementation repositorio, CountyEntity entity)
        {
            var _registroRemovido = await repositorio.DeleteAsync(entity.Id);
            Assert.True(_registroRemovido);
        }
    }
}
