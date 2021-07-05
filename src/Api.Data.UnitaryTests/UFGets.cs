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
    public class UFGets : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public UFGets(DbTest dbteste)
        {
            _serviceProvider = dbteste.ServiceProvider;
        }

        [Fact(DisplayName = "Teste gets UF")]
        [Trait("GETs", "UFEntity")]
        public async Task Realiza_Teste_Gets_UF()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UFImplementation _repositorio = new UFImplementation(context);

                UFEntity _entity = new UFEntity()
                {
                    Id = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                    FederateUnit = "SP",
                    Name = "São Paulo"
                };

                await TesteExistAsync(_repositorio, _entity);
                await TesteSelecionaUFPorId(_repositorio, _entity);
                await TesteSelecaoTodasUFs(_repositorio, _entity);
            }
        }

        private async Task TesteExistAsync(UFImplementation repositorio, UFEntity entity)
        {
            var _registroExiste = await repositorio.ExistAsync(entity.Id);
            Assert.True(_registroExiste);
        }

        private async Task TesteSelecionaUFPorId(UFImplementation repositorio, UFEntity entity)
        {
            var _registroSelecionado = await repositorio.SelectAsync(entity.Id);
            Assert.NotNull(_registroSelecionado);
            Assert.Equal(_registroSelecionado.Id, entity.Id);
            Assert.Equal(_registroSelecionado.Name, entity.Name);
            Assert.Equal(_registroSelecionado.FederateUnit, entity.FederateUnit);
        }

        private async Task TesteSelecaoTodasUFs(UFImplementation repositorio, UFEntity entity)
        {
            var _todosRegistros = await repositorio.SelectAllAsync();
            Assert.NotNull(_todosRegistros);
            Assert.True(_todosRegistros.Count() == 28);
        }
    }
}
