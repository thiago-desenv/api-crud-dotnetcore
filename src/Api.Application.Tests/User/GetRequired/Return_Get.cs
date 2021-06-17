using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.DTOS.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Tests.User.GetRequired
{
    public class Return_Get
    {
        private UsersController _controller;

        [Fact(DisplayName = "Testa método GET")]
        public async Task Realiza_Teste_Metodo_GET()
        {
            var serviceMock = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new UserDTO
                {
                    Id = Guid.NewGuid(),
                    Name = nome,
                    Email = email,
                    CreateAt = DateTime.Now
                }
            );

            _controller = new UsersController(serviceMock.Object);

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as UserDTO;
            Assert.NotNull(resultValue);
            Assert.Equal(resultValue.Name, nome);
            Assert.Equal(resultValue.Email, email);
        }
    }
}
