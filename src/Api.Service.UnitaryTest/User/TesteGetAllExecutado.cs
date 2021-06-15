using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.DTOS.User;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.UnitaryTest.User
{
    public class TesteGetAllExecutado : UserTests
    {
        private IUserService _serviceTest;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Teste método GETALL")]
        public async Task Realiza_Teste_Metodo_GETALL()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(lsUserDTO);
            _serviceTest = _serviceMock.Object;

            var result = await _serviceTest.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(new List<UserDTO>().AsEnumerable());
            _serviceTest = _serviceMock.Object;

            var _resultEmpty = await _serviceTest.GetAll();
            Assert.Empty(_resultEmpty);
            Assert.True(_resultEmpty.Count() == 0);
        }
    }
}
