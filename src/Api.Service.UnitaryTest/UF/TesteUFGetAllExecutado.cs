using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.DTOS.UF;
using Api.Domain.Interfaces.Services.UF;
using Moq;
using Xunit;

namespace Api.Service.UnitaryTest.UF
{
    public class TesteUFGetAllExecutado : UFTestes
    {
        private IUFService _service;
        private Mock<IUFService> _serviceMock;

        [Fact(DisplayName = "Teste método GETALL")]
        public async Task Reaaliza_Teste_Metodo_GETALL()
        {
            _serviceMock = new Mock<IUFService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(ListaUfDTO);
            _service = _serviceMock.Object;

            var _result = await _service.GetAll();
            Assert.NotNull(_result);
            Assert.True(_result.Count() == 10);

            var _listaResult = new List<UfDTO>();

            _serviceMock = new Mock<IUFService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listaResult.AsEnumerable);
            _service = _serviceMock.Object;

            var _resultEmpty = await _service.GetAll();
            Assert.Empty(_resultEmpty);
            Assert.True(_resultEmpty.Count() == 0);
        }
    }
}
