using System;
using System.Threading.Tasks;
using Api.Domain.DTOS;
using Api.Domain.Interfaces.Services.User;
using Api.Service.UnitaryTest.User;
using Moq;
using Xunit;

namespace Api.Service.UnitaryTest.Login
{
    public class TesteFindByLoginExecutado
    {
        public ILoginService _serviceTest;
        public Mock<ILoginService> _serviceMock;

        [Fact(DisplayName = "Teste método FindByLogin")]
        public async Task Realiza_Teste_Metodo_FindByLogin()
        {
            var email = Faker.Internet.Email();
            var objRetorno = new
            {
                authenticated = true,
                create = DateTime.Now,
                expiration = DateTime.Now.AddHours(8),
                accessToken = Guid.NewGuid(),
                userName = Faker.Name.FullName(),
                email = email,
                message = "Usuário logado com sucesso"
            };

            var loginDto = new LoginDTO
            {
                Email = email
            };

            _serviceMock = new Mock<ILoginService>();
            _serviceMock.Setup(m => m.FindByLogin(loginDto)).ReturnsAsync(objRetorno);
            _serviceTest = _serviceMock.Object;

            var result = await _serviceTest.FindByLogin(loginDto);
            Assert.NotNull(result);
        }
    }
}
