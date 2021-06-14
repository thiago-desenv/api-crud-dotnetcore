using System;
using System.Threading.Tasks;
using Api.Domain.DTOS.User;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.UnitaryTest.User
{
    public class TesteGetExecutado : UserTests
    {
        private IUserService _serviceTest;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Teste método GET")]
        public async Task Realiza_Teste_Metodo_GET()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(IdUsuario)).ReturnsAsync(userDTO);
            _serviceTest = _serviceMock.Object;

            var result = await _serviceTest.Get(IdUsuario);
            Assert.NotNull(result);
            Assert.True(result.Id == IdUsuario);
            Assert.Equal(NomeUsuario, result.Name);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UserDTO)null));
            _serviceTest = _serviceMock.Object;

            var _record = await _serviceTest.Get(IdUsuario);
            Assert.Null(_record);
        }
    }
}
