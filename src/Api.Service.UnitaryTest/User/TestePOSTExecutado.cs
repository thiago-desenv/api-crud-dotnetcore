using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.UnitaryTest.User
{
    public class TestePOSTExecutado : UserTests
    {
        [Fact(DisplayName = "Teste método PUT")]
        public async Task Realiza_Teste_Metodo_POST()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Post(userDTOCreate)).ReturnsAsync(userDTOCreateResult);
            _serviceTest = _serviceMock.Object;

            var result = await _serviceTest.Post(userDTOCreate);
            Assert.NotNull(result);
            Assert.Equal(NomeUsuario, result.Name);
            Assert.Equal(EmailUsuario, result.Email);
        }
    }
}
