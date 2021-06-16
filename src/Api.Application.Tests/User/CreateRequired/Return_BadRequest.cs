using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.DTOS.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Tests.User.CreateRequired
{
    public class Return_BadRequest
    {
        private UsersController _controller;
        [Fact(DisplayName = "Teste método Created")]
        public async Task Realiza_Teste_Metodo_Create()
        {
            var serviceMock = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Post(It.IsAny<UserDTOCreate>())).ReturnsAsync(
                new UserDTOCreateResult
                {
                    Id = Guid.NewGuid(),
                    Name = nome,
                    Email = email,
                    CreateAt = DateTime.Now
                }
            );

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Name", "É um campo obrigatório");

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(u => u.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var userDTOCreate = new UserDTOCreate
            {
                Name = nome,
                Email = email
            };

            var result = await _controller.Post(userDTOCreate);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
