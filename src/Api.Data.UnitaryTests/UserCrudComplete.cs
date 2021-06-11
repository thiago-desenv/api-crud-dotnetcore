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
    public class UserCrudComplete : BaseTest, IClassFixture<DbTest>
    {
        public ServiceProvider _serviceProvider { get; set; }

        public UserCrudComplete(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de usuário")]
        [Trait("CRUD", "UserEntity")]
        public async Task Realiza_Validacao_CRUD()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UserImplementation _repositorio = new UserImplementation(context);

                UserEntity _entity = new UserEntity
                {
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email()
                };

                await TestaCriacaoUsuario(_repositorio, _entity);
                await TestaLogin(_repositorio, _entity);
                await TestaAtualizacaoUsuario(_repositorio, _entity);
                await TestaExistAsync(_repositorio, _entity);
                await TestaSelecionaUsuarioPorId(_repositorio, _entity);
                await TestaSelecaoTodosusuarios(_repositorio, _entity);
                await TestaRemocaoUsuario(_repositorio, _entity);
            }
        }

        private async Task TestaCriacaoUsuario(UserImplementation repositorio, UserEntity entity)
        {
            var _registroCriado = await repositorio.InsertAsync(entity);
            Assert.NotNull(_registroCriado);
            Assert.Equal(entity.Name, _registroCriado.Name);
            Assert.Equal(entity.Email, _registroCriado.Email);
            Assert.False(_registroCriado.Id == Guid.Empty);
        }

        private async Task TestaAtualizacaoUsuario(UserImplementation repositorio, UserEntity entity)
        {
            entity.Name = Faker.Name.First();
            var _registroAtualizado = await repositorio.UpdateAsync(entity);
            Assert.NotNull(_registroAtualizado);
            Assert.Equal(entity.Name, _registroAtualizado.Name);
            Assert.Equal(entity.Email, _registroAtualizado.Email);
        }

        private async Task TestaExistAsync(UserImplementation repositorio, UserEntity entity)
        {
            var _registroExiste = await repositorio.ExistAsync(entity.Id);
            Assert.True(_registroExiste);
        }

        private async Task TestaSelecionaUsuarioPorId(UserImplementation repositorio, UserEntity entity)
        {
            var _registroSelecionado = await repositorio.SelectAsync(entity.Id);
            Assert.NotNull(_registroSelecionado);
            Assert.Equal(entity.Name, _registroSelecionado.Name);
            Assert.Equal(entity.Email, _registroSelecionado.Email);
        }

        private async Task TestaSelecaoTodosusuarios(UserImplementation repositorio, UserEntity entity)
        {
            var _todosRegistros = await repositorio.SelectAllAsync();
            Assert.NotNull(_todosRegistros);
            Assert.True(_todosRegistros.Count() > 0);
        }

        private async Task TestaRemocaoUsuario(UserImplementation repositorio, UserEntity entity)
        {
            var _removeu = await repositorio.DeleteAsync(entity.Id);
            Assert.True(_removeu);
        }

        private async Task TestaLogin(UserImplementation repositorio, UserEntity entity)
        {
            var _login = await repositorio.FindByLogin(entity.Email);
            Assert.NotNull(_login);
            Assert.Equal(entity.Name, _login.Name);
            Assert.Equal(entity.Email, _login.Email);
        }
    }
}
