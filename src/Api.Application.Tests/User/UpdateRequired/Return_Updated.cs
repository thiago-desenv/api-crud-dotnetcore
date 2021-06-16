using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.DTOS.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Tests.User.UpdateRequired
{
    public class Return_Updated
    {
        private UsersController _controller;

        [Fact(DisplayName = "Testa método Updated(PUT)")]
        public async Task Realiza_Teste_Meotodo_PUT()
        {
            var serviceMock = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Put(It.IsAny<UserDTOUpdate>())).ReturnsAsync(
                new UserDTOUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Name = nome,
                    Email = email,
                    UpdateAt = DateTime.Now
                }
            );

            _controller = new UsersController(serviceMock.Object);

            var userDTOUpdate = new UserDTOUpdate
            {
                Id = Guid.NewGuid(),
                Name = nome,
                Email = email
            };

            var result = await _controller.Put(userDTOUpdate);
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as UserDTOUpdateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(resultValue.Name, userDTOUpdate.Name);
            Assert.Equal(resultValue.Email, userDTOUpdate.Email);
        }
    }
}
