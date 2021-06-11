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
    public class UserCrudComplete : BaseTest, IClassFixture<DbTest>
    {
        public ServiceProvider _serviceProvider { get; set; }

        public UserCrudComplete(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de usuário")]
        [Trait("CRUD", "UserEntity")]
        public async Task Verifica_Criacao_Usuario()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UserImplementation _repositoio = new UserImplementation(context);

                UserEntity _entity = new UserEntity
                {
                    Name = Faker.Internet.Email(),
                    Email = Faker.Name.FullName()
                };

                var _registroCriado = await _repositoio.InsertAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Email, _registroCriado.Email);
                Assert.Equal(_entity.Name, _registroCriado.Name);
                Assert.False(_registroCriado.Id == Guid.Empty);
            }
        }
    }
}
