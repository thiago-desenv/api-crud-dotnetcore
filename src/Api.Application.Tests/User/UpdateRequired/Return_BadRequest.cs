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
    public class Return_BadRequest
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
            _controller.ModelState.AddModelError("Email", "É um campo obrigatório");

            var userDTOUpdate = new UserDTOUpdate
            {
                Id = Guid.NewGuid(),
                Name = nome,
                Email = email
            };

            var result = await _controller.Put(userDTOUpdate);
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}
