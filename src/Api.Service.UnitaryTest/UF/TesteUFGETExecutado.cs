using System;
using System.Threading.Tasks;
using Api.Domain.DTOS.UF;
using Api.Domain.Interfaces.Services.UF;
using Moq;
using Xunit;

namespace Api.Service.UnitaryTest.UF
{
    public class TesteUFGETExecutado : UFTestes
    {
        private IUFService _service;
        private Mock<IUFService> _serviceMock;

        [Fact(DisplayName = "Teste método GET")]
        public async Task Realiza_Teste_Metodo_GET()
        {
            _serviceMock = new Mock<IUFService>();
            _serviceMock.Setup(m => m.Get(IdUF)).ReturnsAsync(UfDTO);
            _service = _serviceMock.Object;

            var result = await _service.Get(IdUF);
            Assert.NotNull(result);
            Assert.True(result.Id == IdUF);
            Assert.Equal(Name, result.Name);

            _serviceMock = new Mock<IUFService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UfDTO)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(IdUF);
            Assert.Null(_record);
        }
    }
}
