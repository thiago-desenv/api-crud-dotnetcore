using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.UnitaryTest.User
{
    public class TesteDeleteExecutado : UserTests
    {
        [Fact(DisplayName = "Teste método DELETE")]
        public async Task Realiza_Teste_Metodo_Delete()
        {
            _serviceMock = new Moq.Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _serviceTest = _serviceMock.Object;

            var deletado = await _serviceTest.Delete(IdUsuario);
            Assert.True(deletado);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _serviceTest = _serviceMock.Object;

            deletado = await _serviceTest.Delete(Guid.NewGuid());
            Assert.False(deletado);
        }
    }
}
