using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.UnitaryTest.User
{
    public class TestePUTExecutado : UserTests
    {
        private IUserService _serviceTest;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Testa método PUT")]
        public async Task Realiza_Teste_Metodo_PUT()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Post(userDTOCreate)).ReturnsAsync(userDTOCreateResult);
            _serviceTest = _serviceMock.Object;

            var result = await _serviceTest.Post(userDTOCreate);
            Assert.NotNull(result);
            Assert.Equal(NomeUsuario, result.Name);
            Assert.Equal(EmailUsuario, result.Email);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Put(userDTOUpdate)).ReturnsAsync(userDTOUpdateResult);
            _serviceTest = _serviceMock.Object;

            var resultUpdate = await _serviceTest.Put(userDTOUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(NomeUsuarioAlterado, resultUpdate.Name);
            Assert.Equal(EmailUsuarioAlterado, resultUpdate.Email);
        }
    }
}
